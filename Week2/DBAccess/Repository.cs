using DBAccess.Attributes;
using DBAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DBAccess
{
    public class Repository<TTable> : IRepository<TTable>
        where TTable : Table
    {
        public string TableName { get; private set; }

        private readonly Type tableType;

        private List<PropertyInfo> tableFieldPropertyInfos;
        private PropertyInfo primaryKeyFieldPropertyInfo;
        private List<string> tableFieldNames;
        private string primaryKeyFieldName;

        public Repository()
        {
            tableType = typeof(TTable);

            TableNameAttribute tableNameAttrib = tableType.GetCustomAttribute(typeof(TableNameAttribute), true) as TableNameAttribute;

            TableName = tableNameAttrib.Name;
            PropertyInfo[] allTableFieldsProperties = tableType.GetProperties();

            SetupTablePrimaryField(allTableFieldsProperties);
            SetupTableNonPrimaryFields(allTableFieldsProperties);
        }

        public string Select()
        {
            return Select(null);
        }

        public string Select(TTable entity)
        {
            Dictionary<string, string> selectFields = GetFieldsWithValues(entity);

            string selectQuery = $"SELECT {string.Join(", ", selectFields.Keys)} FROM {TableName}";

            IEnumerable<KeyValuePair<string, string>> whereClause = selectFields.Where(w => !string.IsNullOrWhiteSpace(w.Value));
            if (whereClause.Any())
            {
                selectQuery += $" WHERE {string.Join(", ", whereClause.Select(w => $"'{w.Key}'='{w.Value}'"))}";
            }

            return selectQuery;
        }

        public string Insert(TTable entity)
        {
            string primaryKeyValue = primaryKeyFieldPropertyInfo.GetValue(entity)?.ToString();
            if(primaryKeyValue == null)
            {
                throw new InvalidCrudOperationException($"Insert operation executed on {TableName} without primary key value.");
            }

            IEnumerable<string> fieldValues = GetFieldsWithValues(entity).Where(f => f.Value != null).Select(fwv => $"'{fwv.Value}'");

            string queryFields = string.Join(", ", tableFieldNames);
            string queryValues = string.Join(", ",  fieldValues);

            string insertQuery = $"INSERT INTO {TableName} ({queryFields}) VALUES ({queryValues})";

            // INSERT INTO <TABLENAME>(<FIELDS_SEPARATE_BY_COMMA>) VALUES(<VALUES_SEPARATED_BY_COMMA_FROM_ENTITY>)
            // CoolTable: INSERT INTO myCoolTable(myId, myName) VALUES(entity.Id, entity.Name)
            //throw new NotImplementedException();

            return insertQuery;
        }

        public string Update(TTable entity)
        {
            string primaryKeyValue = primaryKeyFieldPropertyInfo.GetValue(entity)?.ToString();
            if (primaryKeyValue == null)
            {
                throw new InvalidCrudOperationException($"Update operation executed on {TableName} without primary key value.");
            }

            IEnumerable<string> fieldsWithValues = GetFieldsWithValues(entity)
                .Where(f => f.Value != null)
                .Select(fwv => $"'{fwv.Key}'='{fwv.Value}'");

            string querySet = string.Join(", ", fieldsWithValues);
            string queryWhere = $"'{primaryKeyFieldName}'='{primaryKeyValue}'";

            string updateQuery = $"UPDATE {TableName} SET {querySet} WHERE {queryWhere}";

            return updateQuery;
            // UPDATE <TABLENAME> SET <FIELD> = "<ENTITY.FIELD_VALUE>" WHERE <PRIMARY_KEY_FIELD> = <ENTITY.PRIMARY_FIELD_VALUE_FROM_ENTITY>
            // CoolTable: UPDATE myCoolTable SET myName = 'entity.Name' WHERE myId = 'entity.Id'
            //throw new NotImplementedException();
        }

        public string Delete(TTable entity)
        {
            // primaryKeyValue is the value from entity which has the PrimaryKey attribute
            //return Delete(primaryKeyValue);
            string primaryKeyValueAsString = primaryKeyFieldPropertyInfo.GetValue(entity)?.ToString();
            bool succeded = int.TryParse(primaryKeyValueAsString, out int primaryKeyValue);
            if (succeded)
            {
                return Delete(primaryKeyValue);
            }
            else throw new InvalidCrudOperationException($"Couldnt execute delete operation on table {TableName}.");

        }

        public string Delete(int primaryID)
        {
            
            string queryWhere = $"'{primaryKeyFieldName}'='{primaryID}'";
            string deleteQuery = $"DELETE FROM {TableName} WHERE {queryWhere}";
            return deleteQuery;
            // DELETE FROM <TABLENAME> WHERE <PRIMARY_KEY_FIELD> = <ENTITY.PRIMARY_FIELD_VALUE_FROM_ENTITY>

        }
        

        #region SetupFields
        private void SetupTableNonPrimaryFields(PropertyInfo[] allTableFieldsProperties)
        {
            tableFieldPropertyInfos = allTableFieldsProperties.Where(f => f.GetCustomAttribute(typeof(PrimaryKeyAttribute)) == null).ToList();

            tableFieldNames = tableFieldPropertyInfos
                .Select(pf =>
                {
                    KeyAttribute keyNameAttribute = (pf.GetCustomAttribute(typeof(KeyAttribute)) as KeyAttribute);

                    return keyNameAttribute?.Name ?? pf.Name;
                })
                .ToList();
        }

        private void SetupTablePrimaryField(PropertyInfo[] allTableFieldsProperties)
        {
            List<PropertyInfo> primaryKeyFields = allTableFieldsProperties.Where(f => f.GetCustomAttribute(typeof(PrimaryKeyAttribute)) != null).ToList();
            if (primaryKeyFields.Count != 1)
            {
                throw new InvalidRepositoryTableException($"Table {TableName} has {primaryKeyFields.Count} primary fields and should have one.");
            }
            primaryKeyFieldPropertyInfo = primaryKeyFields.First();

            KeyAttribute primaryKeyKeyNameAttribute = (primaryKeyFieldPropertyInfo.GetCustomAttribute(typeof(KeyAttribute)) as KeyAttribute);

            primaryKeyFieldName = primaryKeyKeyNameAttribute?.Name ?? primaryKeyFieldPropertyInfo.Name;
        }
        #endregion SetupFields

        private Dictionary<string, string> GetFieldsWithValues(TTable entity)
        {
            Dictionary<string, string> fieldsWithValues = new Dictionary<string, string>();

            foreach (PropertyInfo prop in tableFieldPropertyInfos)
            {
                KeyAttribute keyNameAttribute = (prop.GetCustomAttribute(typeof(KeyAttribute)) as KeyAttribute);

                string name = keyNameAttribute?.Name ?? prop.Name;

                string value = entity != null ? prop.GetValue(entity)?.ToString() : null;

                fieldsWithValues.Add(name, value);
            }

            return fieldsWithValues;
        }

        #region BonusYield
        private IEnumerable<KeyValuePair<string, string>> BonusGetFieldsWithValuesIEnumerable(TTable entity)
        {
            foreach (PropertyInfo prop in tableFieldPropertyInfos)
            {
                KeyAttribute keyNameAttribute = (prop.GetCustomAttribute(typeof(KeyAttribute)) as KeyAttribute);

                string name = keyNameAttribute?.Name ?? prop.Name;

                string value = entity != null ? prop.GetValue(entity)?.ToString() : null;

                yield return new KeyValuePair<string, string>(name, value);
            }
        }
        #endregion BonusYield
    }
}
