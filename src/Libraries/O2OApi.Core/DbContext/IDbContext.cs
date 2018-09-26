using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace O2OApi.Core.DbContext
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Conn { get; }

        void InitConnection();
    }
}
