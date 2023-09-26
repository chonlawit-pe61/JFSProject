using System;

namespace Megazy.StarterKit.Engine.Helpers
{
    public class BindingHelper
    {
        private static BindingHelper instance = null;
        private static readonly object padlock = new object();
        private DateTime lastDate;

        //private SubcountryRow[] _subcountryRow = null;
        //public SubcountryRow[] SubcountryRow { get { return _subcountryRow; }}

        //private CityRow[] _cityRow = null;
        //public CityRow[] CityRow { get { return _cityRow; } }

        //private ProjectStatusRow[] _projectStatusRow = null;
        //public ProjectStatusRow[] ProjectStatusRow { get { return _projectStatusRow; } }

        //private PlaceTypesRow[] PlaceTypeRow = null;
        //public PlaceTypesRow[] placetypeRow { get { return PlaceTypeRow; } }

        //private View_PropertyTypeRow[] _propertyTypeRow = null;
        //public View_PropertyTypeRow[] PropertyTypeRow { get { return _propertyTypeRow; } }
   
        ////private ZoneRow[] _zoneRow = null;
        ////public ZoneRow[] ZoneRow { get { return _zoneRow; } }

        //private ReportsSaleRow[] _reportsSaleRow = null;
        //public ReportsSaleRow[] ReportsSaleRow { get { return _reportsSaleRow; } }

        //private AttributesOptionListRow[] _attributeOptionListRow = null;
        //public AttributesOptionListRow[] AttributesOptionListRow { get { return _attributeOptionListRow; } }

        //private DataRepository.TookTeePromotionInfo[] _tookTeePromotion = null;
        //public DataRepository.TookTeePromotionInfo[] TookTeePromotion { get { return _tookTeePromotion; } }

        //public DateTime LastDate
        //{
        //    get { return lastDate; }
        //    set { lastDate = value; }
        //}
        //private LanguageRow[] _languageRow = null;
        //public LanguageRow[] languageRow
        //{
        //    get { return _languageRow; }
        //}
        //public static BindingHelper Instance
        //{
        //    get
        //    {
        //        lock (padlock)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new BindingHelper();

        //                instance._subcountryRow = instance.GetSubcountry();
        //                instance._projectStatusRow = instance.GetProjectStatus();
        //                instance._propertyTypeRow = instance.GetPropertyType();
        //                instance.PlaceTypeRow = instance.GetPlaceType();
        //                instance._languageRow = instance.GetLanguage();
        //               // instance._zoneRow = instance.GetZone();
        //                instance._reportsSaleRow = instance.GetReportSale();
        //                instance._attributeOptionListRow = instance.GetAttributeOptionList();
        //                instance._tookTeePromotion = instance.GetTookTeePromotion();
        //                //instance.lastDate = DateTime.Now;
        //                instance.lastDate = instance.lastDate.AddMinutes(5);
        //            }
        //            else
        //            {
        //                if ((DateTime.Now - instance.lastDate).Minutes >= 5)
        //                {
        //                    instance._subcountryRow = instance.GetSubcountry();
        //                    instance._projectStatusRow = instance.GetProjectStatus();
        //                    instance._languageRow = instance.GetLanguage();
        //                    instance.PlaceTypeRow = instance.GetPlaceType();
        //                    instance._propertyTypeRow = instance.GetPropertyType();
        //                   // instance._zoneRow = instance.GetZone();
        //                    instance._reportsSaleRow = instance.GetReportSale();
        //                    instance._attributeOptionListRow = instance.GetAttributeOptionList();
        //                    instance._tookTeePromotion = instance.GetTookTeePromotion();
        //                    instance.lastDate = instance.lastDate.AddMinutes(5);
        //                }
        //            }
        //            return instance;
        //        }
        //    }
        //}

        //private SubcountryRow[] GetSubcountry()
        //{
        //    SubcountryCollection_Base obj = new SubcountryCollection_Base(CSystems.ProcessID);
        //    List<SqlParameter> parameter = new List<SqlParameter>();
        //    parameter.Add(new SqlParameter("@IsActive", System.Data.SqlDbType.Bit));
        //    parameter[0].Value = true;
        //    string whereSql = "IsActive = @IsActive AND CountryCode='TH'";
        //    string orderBySql = "SubcountryName ASC";
        //    var res = obj.GetAsArray(parameter, whereSql, orderBySql);
        //    obj.Dispose();
        //    return res;
        //}
        //private ProjectStatusRow[] GetProjectStatus()
        //{
        //    ProjectStatusCollection_Base obj = new ProjectStatusCollection_Base(CSystems.ProcessID);
        //    var res = obj.GetAll();
        //    obj.Dispose();
        //    return res;
        //}
        //private PlaceTypesRow[] GetPlaceType()
        //{
        //    PlaceTypesCollection_Base obj = new PlaceTypesCollection_Base(CSystems.ProcessID);
        //    var res = obj.GetAll();
        //    obj.Dispose();
        //    return res;
        //}
        //private View_PropertyTypeRow[] GetPropertyType(string lang="TH")
        //{
        //    View_PropertyTypeCollection_Base obj = new View_PropertyTypeCollection_Base(CSystems.ProcessID);
        //    List<SqlParameter> parameter = new List<SqlParameter>();
        //    parameter.Add(new SqlParameter("@IsActive", System.Data.SqlDbType.Bit));
        //    parameter[0].Value = true;
        //    parameter.Add(new SqlParameter("@LanguageCode", System.Data.SqlDbType.VarChar));
        //    parameter[1].Value = lang;
        //    string whereSql = "IsActive = @IsActive AND LanguageCode = @LanguageCode";
        //    string orderBySql = "[Sequence] ASC";
        //    var res = obj.GetAsArray(parameter, whereSql, orderBySql);
        //    obj.Dispose();
        //    return res;
        //}
        //private LanguageRow[] GetLanguage()
        //{
        //    LanguageCollection_Base obj = new LanguageCollection_Base(CSystems.ProcessID);
        //    List<SqlParameter> parameter = new List<SqlParameter>();
        //    parameter.Add(new SqlParameter("@IsActive", System.Data.SqlDbType.Bit));
        //    parameter[0].Value = true;
        //    string whereSql = "IsActive = @IsActive";
        //    string orderBySql = "Sequence ASC";
        //    var res = obj.GetAsArray(parameter, whereSql, orderBySql);
        //    obj.Dispose();
        //    return res;

        //}
        ////private ZoneRow[] GetZone()
        ////{
        ////    ZoneCollection_Base obj = new ZoneCollection_Base(CSystems.ProcessID);
        ////    List<SqlParameter> parameter = new List<SqlParameter>();
        ////    parameter.Add(new SqlParameter("@IsActive", System.Data.SqlDbType.Bit));
        ////    parameter[0].Value = true;
        ////    string whereSql = "IsActive = @IsActive";
        ////    string orderBySql = "ZoneCode ASC";
        ////    var res = obj.GetAsArray(parameter, whereSql, orderBySql);
        ////    obj.Dispose();
        ////    return res;
        ////}
        //private ReportsSaleRow[] GetReportSale()
        //{
        //    ReportsSaleCollection_Base obj = new ReportsSaleCollection_Base(CSystems.ProcessID);
        //    var res = obj.GetAll();
        //    obj.Dispose();
        //    return res;
        //}
        //private AttributesOptionListRow[] GetAttributeOptionList()
        //{
        //    AttributesOptionListCollection_Base obj = new AttributesOptionListCollection_Base(CSystems.ProcessID);
        //    var res = obj.GetAll();
        //    obj.Dispose();
        //    return res;
        //}
        //private DataRepository.TookTeePromotionInfo[] GetTookTeePromotion()
        //{
        //    List<DataRepository.TookTeePromotionInfo> res = new List<DataRepository.TookTeePromotionInfo>();
        //    View_TookTeePromotionCollection_Base obj = new View_TookTeePromotionCollection_Base(CSystems.ProcessID);
        //    List<SqlParameter> parameter = new List<SqlParameter>();
        //    parameter.Add(new SqlParameter("@IsActive", System.Data.SqlDbType.Bit));
        //    parameter[0].Value = true;
        //    string whereSql = "IsActive = @IsActive";
        //    string orderBySql = "[PromotionID] ASC";
        //    var row = obj.GetAsArray(parameter, whereSql, orderBySql);
        //    obj.Dispose();
        //    foreach (var item in row)
        //    {               
        //        DataRepository.TookTeePromotionInfo data = new DataRepository.TookTeePromotionInfo();
        //        data.PromotionID = item.PromotionID;
        //        List<DataRepository.TookteePromotionTrans> TookteePromotionTrans = JsonConvert.DeserializeObject<List<DataRepository.TookteePromotionTrans>>(item.PromotionName);
        //        if (TookteePromotionTrans.Safe().Any())
        //        {
        //            var rowName = (from q in TookteePromotionTrans
        //                           select q.Name).ToArray();
        //            if (rowName != null)
        //            {
        //                data.PromotionName = string.Join("/", rowName);
        //            }                 
        //        }
        //        data.StartDate = item.StartDate;
        //        data.EndDate = item.EndDate;
        //        data.Discount = item.Discount;

        //        res.Add(data);
        //    }         
        //    return res.ToArray();
        //}
    }
}
