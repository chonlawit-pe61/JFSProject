using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class DepartmentService
    {
        //public int GetProvinceByDepartmentID(int departmentID)
        //{
        //    View_JFAddressRow row = new View_JFAddressRow(); 
        //    try
        //    {
        //        DepartmentAddressCollection_Base department = new DepartmentAddressCollection_Base(CSystems.ProcessID);
        //        var deprow = department.GetByDepartmentID(departmentID);
        //        department.Dispose();
        //        if(deprow.Length !=0 )
        //        {
        //            View_JFAddressCollection_Base obj = new View_JFAddressCollection_Base(CSystems.ProcessID);
        //            List<SqlParameter> parameter = new List<SqlParameter>();
        //            SqlParameter sqlpara = new SqlParameter("@AddressID", System.Data.SqlDbType.Int) { Value = deprow[0].AddressID };
        //            parameter.Add(sqlpara);
        //            string whereSql = "[AddressID] = @AddressID";
        //            row = obj.GetRow(parameter, whereSql);
        //            obj.Dispose();
        //        }              
        //    }
        //    catch (Exception ex)
        //    {
        //        DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //    }
        //    return row.ProvinceID;
        //}
        public int GetProvinceByDepartmentID(int departmentID)
        {
            int provinceID = 0;
             try
            {
                DepartmentCollection_Base department = new DepartmentCollection_Base(CSystems.ProcessID);
                var deprow = department.GetByPrimaryKey(departmentID);
                department.Dispose();
                if (deprow != null)
                {
                    provinceID = deprow.ProvinceID;
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return provinceID;
        }
    }
}
