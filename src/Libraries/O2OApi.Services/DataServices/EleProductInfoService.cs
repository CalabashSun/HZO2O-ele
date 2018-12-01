using System;
using System.Collections.Generic;
using System.Linq;
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

        List<TempEleProductInfo> ListProductInfo(long shopId);

        void DeleteById(int id);
    }

    public class EleProductInfoService:Repository<EleProductInfo>,IEleProductInfoService
    {
        public void DeleteProduct(long shopId)
        {
            var sqlString = $"delete from EleProductInfo where ShopId={shopId}";
            _Conn.Execute(sqlString);
        }

        public List<TempEleProductInfo> ListProductInfo(long shopId)
        {
            var selectSql = $"select * from EleProductInfo where ShopId='{shopId}'";
            return _Conn.Query<TempEleProductInfo>(selectSql).ToList();
        }

        public  void DeleteById(int id)
        {
            var deleteSql = $"delete from EleProductInfo where id='{id}'";
            _Conn.Execute(deleteSql);
        }
    }
}
