using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.AddressData;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using JFS.Megazy.MilkyWaySolution.Engine;
using JFS.Megazy.MilkyWaySolution.Engine.Services;
using JFS.Megazy.MilkyWaySolution.Engine.Singleton;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
using System.Data;


namespace JFS.Megazy.MilkyWaySolution.Web.Front.Controllers
{
    [RoutePrefix("jfservices")]
    public partial class JFServicesController : Controller
    {
       

        #region jfservices/address

        // POST: jfservices/address/getdistrictlist

        [HttpPost]
        [Route("address/getdistrictlist")]
        public JsonResult GetDistrictList(int id)
        {
            ResponseResult res = new ResponseResult();
            try
            {
                DistrictCollection_Base obj = new DistrictCollection_Base(CSystems.ProcessID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@ProvinceID", System.Data.SqlDbType.Int) { Value = id };
                parameter.Add(sqlpara);
                string whereSql = "[ProvinceID] = @ProvinceID";
                string orderbySql = "DistrictName ASC";
                var row = obj.GetAsArray(parameter, whereSql, orderbySql);
                obj.Dispose();
                if (row != null)
                {
                    res.Status = true;
                    res.Data = (from q in row
                                select new DistrictResponse
                                {
                                    DistrictID = q.DistrictID,
                                    DistrictName = q.DistrictName
                                }).ToArray();
                }
            }
            catch (Exception ex)
            {
                
            }
            return Json(res, JsonRequestBehavior.DenyGet);
        }
        // POST: jfservices/address/getsubdistrictlist
        [HttpPost]
        [Route("address/getsubdistrictlist")]
        public JsonResult GetSubDistrictList(int id)
        {
            ResponseResult res = new ResponseResult();
            try
            {
                SubdistrictCollection_Base obj = new SubdistrictCollection_Base(CSystems.ProcessID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@DistrictID", System.Data.SqlDbType.Int) { Value = id };
                parameter.Add(sqlpara);
                string whereSql = "[DistrictID] = @DistrictID";
                string orderbySql = "SubdistrictName ASC";
                var row = obj.GetAsArray(parameter, whereSql, orderbySql);
                obj.Dispose();
                if (row != null)
                {
                    res.Status = true;
                    res.Data = (from q in row
                                select new SubDistrictResponse
                                {
                                    SubDistrictID = q.SubdistrictID,
                                    SubDistrictName = q.SubdistrictName,
                                    PostCode = q.PostCode
                                }).ToArray();
                }
            }
            catch (Exception ex)
            {
                
            }
            return Json(res, JsonRequestBehavior.DenyGet);
        }
        // POST: jfservices/address/getaddresslistbypostcode?postCode=44000
        [HttpPost]
        [Route("Address/GetAddressListByPostCode")]
        public JsonResult GetAddressListByPostCode(string postCode)
        {
            ResponseResult res = new ResponseResult();
            try
            {
                View_AddressCollection_Base obj = new View_AddressCollection_Base(CSystems.ProcessID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@PostCode", System.Data.SqlDbType.VarChar) { Value = postCode };
                parameter.Add(sqlpara);
                string whereSql = "[PostCode] = @PostCode";
                string orderbySql = "ProvinceID Asc";
                var row = obj.GetAsArray(parameter, whereSql, orderbySql);
                obj.Dispose();
                if (row != null)
                {
                    res.Status = true;

                    ProvinceDistrictSubDistrict data = new ProvinceDistrictSubDistrict
                    {
                        Province = (from q in row
                                    group q by new { q.ProvinceID, q.ProvinceName } into g
                                    orderby g.Key.ProvinceID
                                    select new ProvinceResponse { ProvinceID = g.Key.ProvinceID, ProvinceName = g.Key.ProvinceName }).SingleOrDefault(),
                        District = from q in row
                                   group q by new { q.DistrictID, q.DistrictName } into g
                                   orderby g.Key.DistrictID
                                   select new DistrictResponse { DistrictID = g.Key.DistrictID, DistrictName = g.Key.DistrictName },
                    };
                    if (data.District.Count() != 0)
                    {
                        data.SubDistrict = from q in row
                                           where q.DistrictID == data.District.FirstOrDefault().DistrictID
                                           group q by new { q.SubdistrictID, q.SubdistrictName } into g
                                           orderby g.Key.SubdistrictID
                                           select new SubDistrictResponse { SubDistrictID = g.Key.SubdistrictID, SubDistrictName = g.Key.SubdistrictName, PostCode = g.Select(o => o.PostCode).FirstOrDefault() };
                    }
                    res.Data = data;
                }


            }
            catch (Exception ex)
            {
               
            }
            return Json(res, JsonRequestBehavior.DenyGet);
        }
        #endregion

      




    }
}
