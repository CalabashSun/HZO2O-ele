using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace O2OApi.Services.Repositorys
{
    public interface IRepository<T>
        where T : class
    {
        void Add(T model, IDbTransaction transcation = null);

        void Add(IList<T> modeList);

        void Update(T model, IDbTransaction transcation = null);

        void Update(IList<T> modeList);

        T Find(int id);

        void Remove(int id);

        void Remove(T model);

        T QueryFirst(object sqlParas);

        T QueryFirst(string sql, object sqlParas);

        IList<T> GetAll();

        IList<T> Query(object sqlParas);

        IList<T> Query(string sql, object sqlParas);

        IList<T> Query(object sqlParas, int pageSize, int pageIndex);
        /// <summary>
        /// 开启连接池
        /// </summary>
        void Open();
        /// <summary>
        /// 创建连接池
        /// </summary>
        /// <returns></returns>
        IDbConnection CreateConnection();
    }
}
