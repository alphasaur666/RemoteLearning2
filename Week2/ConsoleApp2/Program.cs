using DBAccess;
using DBAccess.Models;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var coolRepository = new Repository<CoolTable>();

            var selectWithWhere = new CoolTable {
                Name = "asd",
                Status = StatusEnum.Active
            };

            string selectWithWhereOut = coolRepository.Select(selectWithWhere);

            Console.WriteLine("selectWithWhere: {0}", selectWithWhereOut);

            var selectWithoutWhere = new CoolTable();

            string selectWithoutWhereOut = coolRepository.Select(selectWithoutWhere);

            Console.WriteLine("selectWithoutWhere: {0}", selectWithoutWhereOut);

            var update = new CoolTable
            {
                Id = 3,
                Name = "asd",
                Status = StatusEnum.Active
            };

            string updateOut = coolRepository.Update(update);

            Console.WriteLine("Update: {0}", updateOut);

            var insert = new CoolTable
            {
                Id = 2,
                Name = "ads",
                Status = StatusEnum.Active
            };

            string insertOut = coolRepository.Insert(insert);
            Console.WriteLine("Insert: {0}", insertOut);

            var delete = new CoolTable
            {
                Id = 2,
                Name = "ads",
                Status = StatusEnum.Active
            };

            string deleteOut = coolRepository.Delete(delete);
            string deleteOutWithID = coolRepository.Delete(2);

            Console.WriteLine("Delete: {0}", deleteOut);
            Console.WriteLine("Delete with ID: {0}", deleteOutWithID);

        }
    }
}
