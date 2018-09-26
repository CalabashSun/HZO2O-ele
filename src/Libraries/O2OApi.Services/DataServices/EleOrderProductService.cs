using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using O2OApi.Data.DataBase;
using O2OApi.Services.Repositorys;

namespace O2OApi.Services.DataServices
{

    public interface IEleOrderProductService:IRepository<EleOrderProduct>
    {
        EleOrderProduct GetOrderProductInfo(long orderProductId);
    }

    public  class EleOrderProductService:Repository<EleOrderProduct>,IEleOrderProductService
    {
        public EleOrderProduct GetOrderProductInfo(long orderProductId)
        {
            var selectSql = $"select * from EleOrderProduct where OrderProductId='{orderProductId}'";
            return _Conn.QueryFirstOrDefault(selectSql);
        }
    }
}
