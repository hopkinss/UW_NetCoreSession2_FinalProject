using Lab.Data;
using System;

namespace InitDb
{
    class Program
    {
        private static LabDbContext context = new LabDbContext();
        static void Main(string[] args)
        {
           context.Database.EnsureCreated();
        }
    }
}
