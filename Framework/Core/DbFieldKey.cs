using System;

namespace Sativa.Framework.Core
{
    /// <summary>
    /// Sativa Db Field Key Class
    /// </summary>
    public class DbFieldKey
    {
        public String Name;
        public String Value;
        public DbFieldType Type;
        public DbOperatorType OperatorType;

        public DbFieldKey(string name, string value)
        {
            this.Name = name;
            this.Value = value;
            this.Type = DbFieldType.Text;
            this.OperatorType = DbOperatorType.Equal;
        }

        public DbFieldKey(string name, string value, DbFieldType type)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
            this.OperatorType = DbOperatorType.Equal;
        }

        public DbFieldKey(string name, string value, DbFieldType type, DbOperatorType operatortype)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
            this.OperatorType = operatortype;
        }

    }
}