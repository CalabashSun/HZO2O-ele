using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using O2OApi.Data.DataBase;
using O2OApi.Services.Repositorys;

namespace O2OApi.Services.DataServices
{
    public interface IEleOrderLogService:IRepository<EleOrderLog>
    {
        List<EleOrderLog> GetOrderLogs();

        void SetHandeled();

        List<EleOrderCancel> GetCancelOrder();
    }

    public class EleOrderLogService : Repository<EleOrderLog>, IEleOrderLogService
    {
        public List<EleOrderCancel> GetCancelOrder()
        {
            var selectSql = $"select * from EleOrderCancel where DATEDIFF(DAY,CreateTime,GETDATE())=0";
            return _Conn.Query<EleOrderCancel>(selectSql).ToList();
        }

        public List<EleOrderLog> GetOrderLogs()
        {
            var selectSql = $"select * from EleOrderLog where isHandle=0 and OrderType=10";
            return _Conn.Query<EleOrderLog>(selectSql).ToList();
        }

        public void SetHandeled()
        {
            var execSql = $"update EleOrderLog set isHandle=1 where isHandle=0";
            _Conn.Execute(execSql);
        }
    }
}
