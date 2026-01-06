//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;

namespace GameFramework.DataTable
{
    /// <summary>
    /// 数据表行辅助器接口。
    /// </summary>
    public interface IDataRowHelper
    {
        Type DataRowType { get; }

        /// <summary>
        /// 获取数据表行的编号。
        /// </summary>
        /// <param name="dataRow">数据表行。</param>
        /// <returns>数据表行的编号。</returns>
        int GetId(object dataRow);

        /// <summary>
        /// 解析数据表行。
        /// </summary>
        /// <param name="dataRow">要解析到的数据表行。</param>
        /// <param name="dataRowString">要解析的数据表行字符串。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>是否解析数据表行成功。</returns>
        bool ParseDataRow(out object dataRow, string dataRowString, object userData);

        /// <summary>
        /// 解析数据表行。
        /// </summary>
        /// <param name="dataRow">要解析到的数据表行。</param>
        /// <param name="dataRowBytes">要解析的数据表行二进制流。</param>
        /// <param name="startIndex">数据表行二进制流的起始位置。</param>
        /// <param name="length">数据表行二进制流的长度。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>是否解析数据表行成功。</returns>
        bool ParseDataRow(out object dataRow, byte[] dataRowBytes, int startIndex, int length, object userData);
    }

    public interface IDataRowHelper<T> : IDataRowHelper
    {
        new int GetId(T dataRow);
        new bool ParseDataRow(out T dataRow, string dataRowString, object userData);
        new bool ParseDataRow(out T dataRow, byte[] dataRowBytes, int startIndex, int length, object userData);
    }

    public abstract class DataRowHelperBase<T> : IDataRowHelper<T>
    {
        Type IDataRowHelper.DataRowType => typeof(T);

        int IDataRowHelper<T>.GetId(T dataRow)
        {
            return GetId(dataRow);
        }

        int IDataRowHelper.GetId(object dataRow)
        {
            return GetId((T)dataRow);
        }

        bool IDataRowHelper<T>.ParseDataRow(out T dataRow, string dataRowString, object userData)
        {
            return ParseDataRow(out dataRow, dataRowString, userData);
        }

        bool IDataRowHelper<T>.ParseDataRow(out T dataRow, byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            return ParseDataRow(out dataRow, dataRowBytes, startIndex, length, userData);
        }

        bool IDataRowHelper.ParseDataRow(out object dataRow, string dataRowString, object userData)
        {
            bool result = ParseDataRow(out T dataRowT, dataRowString, userData);
            dataRow = dataRowT;
            return result;
        }

        bool IDataRowHelper.ParseDataRow(out object dataRow, byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            bool result = ParseDataRow(out T dataRowT, dataRowBytes, startIndex, length, userData);
            dataRow = dataRowT;
            return result;
        }

        protected abstract int GetId(T dataRow);
        protected abstract bool ParseDataRow(out T dataRow, string dataRowString, object userData);
        protected abstract bool ParseDataRow(out T dataRow, byte[] dataRowBytes, int startIndex, int length, object userData);
    }
}
