using System;

namespace Sativa.Framework.Core
{
    /// <summary>
    /// Sativa Db Field Sort Class
    /// </summary>
    public class DbFieldSort
    {
        public string Name;
        public DbSortDirection Direction;

        public DbFieldSort(string name)
        {
            this.Name = name;
            this.Direction = DbSortDirection.Asc;
        }

        public DbFieldSort(string name, DbSortDirection direction)
        {
            this.Name = name;
            this.Direction = direction;
        }


    }
}