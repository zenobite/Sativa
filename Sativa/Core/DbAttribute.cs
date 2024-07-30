using System;

namespace Sativa.Core
{
    /// <summary>
    /// Sativa Database Attribute Classes
    /// </summary>
    public class DbField : Attribute
    {
        public string FieldName;
        public DbFieldType FieldType;
        public Object FieldValue;
        public string LookupTable;
        public string ChildPK;
        public string ParentPK;
        public string FieldNameAlias;
        public Boolean IsLookupField;

        public DbField()
        {
        }

        public DbField(string FieldName, DbFieldType FieldType)
        {
            this.FieldName = FieldName;
            this.FieldType = FieldType;
            this.LookupTable = "";
            this.ChildPK = "";
            this.ParentPK = "";
            this.FieldNameAlias = "";
            IsLookupField = false;
        }

        public DbField(string FieldName, string LookupTable, string ChildPK, string ParentPK, string FieldNameAlias)
        {
            this.FieldName = FieldName;
            this.LookupTable = LookupTable;
            this.ChildPK = ChildPK;
            this.ParentPK = ParentPK;
            this.FieldNameAlias = FieldNameAlias;
            IsLookupField = true;
        }
    }

    public class DbReadOnly : Attribute
    {
        public DbReadOnly()
        {
        }
    }

    public class DbCreatable : Attribute
    {
        public DbCreatable()
        {
        }
    }

    public class DbCreatableAutoIncrement : Attribute
    {
        public DbCreatableAutoIncrement()
        {
        }
    }
}