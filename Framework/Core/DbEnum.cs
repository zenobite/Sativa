using System;

namespace Sativa.Framework.Core
{
    /// <summary>
    /// Sativa Database Enums
    /// </summary>
    public enum DbFieldType
    {
        Text = 1,
        NonText = 2
    }

    public enum DbOperatorType
    {
        Equal = 0,
        NotEqual = 1,
        Like = 2,
        NotLike = 3,
        LessThan = 4,
        GreaterThan = 5,
        LessThanOrEqual = 6,
        GreaterThanOrEqual = 7
    }

    public enum DbSortDirection
    {
        Asc = 0,
        Desc = 1
    }
}