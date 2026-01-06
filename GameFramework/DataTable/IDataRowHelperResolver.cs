using System;

namespace GameFramework.DataTable
{
    public interface IDataRowHelperResolver
    {
        IDataRowHelper GetHelper(Type dataRowType);
        IDataRowHelper<T> GetHelper<T>();
    }
}
