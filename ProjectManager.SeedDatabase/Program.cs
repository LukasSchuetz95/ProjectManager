using ProjectManager.Persistence;
using System;

namespace ProjectManager.SeedDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.DeleteDatabase();
                Console.WriteLine("<Taste drücken>");
                Console.ReadKey();
            }
        }
    }
}
