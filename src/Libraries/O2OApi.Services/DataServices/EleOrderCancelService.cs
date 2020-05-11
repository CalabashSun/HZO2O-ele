using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;
using O2OApi.Data.DataBase;
using O2OApi.Services.Repositorys;

namespace O2OApi.Services.DataServices
{
    public interface IEleOrderCancelService:IRepository<EleOrderCancel>
    {
        void AddCancelRecord(EleOrderCancel orderCancel);
    }

    public class EleOrderCancelService : Repository<EleOrderCancel>, IEleOrderCancelService
    {
        public void AddCancelRecord(EleOrderCancel orderCancel)
        {
            //判断退单是否存在
            var sqlString = $"select * from EleOrderCancel where OrderId='{orderCancel.OrderId}'";
            var existData = _Conn.QueryFirstOrDefault<EleOrderCancel>(sqlString);
            if (existData == null)
            {
                try
                {
                    _Conn.Insert<EleOrderCancel>(orderCancel);
                }
                catch(Exception ex)
                {
                    throw ex;
                }

            }
        }
    } 
}
