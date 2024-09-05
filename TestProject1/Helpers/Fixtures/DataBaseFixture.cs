using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Helpers.Fixtures
{
    public class DataBaseFixture
    {
        private const string _connectionString = @"Server=localhost;" +
            "Database=TestProject;" +
            "User Id=root;" +
            "Password=root;";

        private static object _lock = new object();
        private static bool _databaseInitialize;

        public DataBaseFixture() 
        { 
            lock(_lock)
            {
                if (!_databaseInitialize)
                {
                    using var context = CreateContext();
                    context.Database.EnsureDeleted();
                }
            }
        }
        public AppDbContext CreateContext()
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));
            return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseMySql(_connectionString, serverVersion).Options);
        }
    }
}
