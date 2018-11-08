using System;
using System.Collections.Generic;
using System.Text;
using O2OApi.Data.DataBase;
using O2OApi.Services.Repositorys;

namespace O2OApi.Services.DataServices
{
    public interface IEleOrderLogService:IRepository<EleOrderLog>
    {

    }

    public class EleOrderLogService:Repository<EleOrderLog>,IEleOrderLogService
    {

    }
}
