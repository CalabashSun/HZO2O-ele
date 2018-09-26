using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using O2OApi.Data.DataBase;
using O2OApi.Services.Ele;
using O2OApi.Services.Repositorys;

namespace O2OApi.Services.DataServices
{
    public interface IEleProductInfoService:IRepository<EleProductInfo>
    {
        void DeleteProduct(long shopId);
    }

    public class EleProductInfoService:Repository<EleProductInfo>,IEleProductInfoService
    {
        public void DeleteProduct(long shopId)
        {
            var sqlString = $"delete from EleProductInfo where ShopId={shopId}";
            _Conn.Execute(sqlString);
        }
    }
}
