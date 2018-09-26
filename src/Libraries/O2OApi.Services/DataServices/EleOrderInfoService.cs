using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Dapper;
using O2OApi.Data.DataBase;
using O2OApi.Services.Repositorys;

namespace O2OApi.Services.DataServices
{
    public interface IEleOrderInfoService:IRepository<EleOrderInfo>
    {
        EleOrderInfo GetEleOrderInfoService(long orderId);
    }


    public class EleOrderInfoService : Repository<EleOrderInfo>, IEleOrderInfoService
    {
        public EleOrderInfo GetEleOrderInfoService(long orderId)
        {
            var selectSql = $"select * from EleOrderInfo where orderId='{orderId}'";
            return _Conn.QueryFirstOrDefault<EleOrderInfo>(selectSql);
        }
    }
}
