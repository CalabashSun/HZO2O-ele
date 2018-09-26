using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using O2OApi.Data.DataBase;
using O2OApi.Services.Repositorys;

namespace O2OApi.Services.DataServices
{
    public interface IProductCategoryService:IRepository<EleProductCategory>
    {
        void TruncateTable();

        void DeleteCate(int cateId=0,long shopId=0);
    }

    public class ProductCategoryService:Repository<EleProductCategory>,IProductCategoryService
    {
        public void TruncateTable()
        {
            var exeSql = "truncate table EleProductCategory";
            _Conn.Execute(exeSql);
        }

        public void DeleteCate(int cateId = 0, long shopId = 0)
        {
            #region 查询条件
            var sqlStence = "1=1";

            if (cateId != 0)
            {
                sqlStence += $" and PlatformId={cateId}";
            }

            if (shopId != 0)
            {
                sqlStence += $" and ShopId={shopId}";
            }

            #endregion
            var exeSql = $"delete from EleProductCategory where " +sqlStence;
            _Conn.Execute(exeSql);
        }
    }


}
