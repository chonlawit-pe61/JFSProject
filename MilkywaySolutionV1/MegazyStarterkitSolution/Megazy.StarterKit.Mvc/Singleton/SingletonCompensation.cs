using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megazy.StarterKit.Mvc.Singleton
{
    //public class SingletonCompensation : IDisposable
    //{
    //    private static SingletonCompensation _instance = null;
    //    private static readonly object _syncLock = new object();
    //    private DateTime lastDate = DateTime.Now;
    //    public DateTime LastDate
    //    {
    //        get { return lastDate; }
    //        set { lastDate = value; }
    //    }
    //    public View_CompensationData[] Compensation { get; set; }
    //    private SingletonCompensation() { }
    //    public static SingletonCompensation Instance
    //    {
    //        get
    //        {
    //            lock (_syncLock)
    //            {
    //                if (_instance == null)
    //                {
    //                    _instance = new SingletonCompensation();
    //                    _instance.Compensation = _instance.GetCompensation();
    //                    _instance.lastDate = _instance.lastDate.AddMinutes(30);
    //                }
    //                else
    //                {
    //                    if ((DateTime.Now - _instance.lastDate).Minutes >= 30)
    //                    {
    //                        _instance.Compensation = _instance.GetCompensation();
    //                        _instance.lastDate = _instance.lastDate.AddMinutes(30);
    //                    }
    //                }
    //            }
    //            return _instance;
    //        }
    //    }

    //    private View_CompensationData[] GetCompensation()
    //    {
    //        View_CompensationData[] res = null;
    //        try
    //        {
    //            string path = System.Web.HttpContext.Current.Server.MapPath(@"/assets/json/compensation.json");
    //            if (!File.Exists(path))
    //            {
    //                res = CreateCompensationFile(path);
    //            }
    //            else
    //            {
    //                if (FileHelper.GetLastUpdateTotalMinutes(path) > 120)
    //                {
    //                    res = CreateCompensationFile(path);
    //                }
    //                else
    //                {
    //                    using (StreamReader r = new StreamReader(path))
    //                    {
    //                        string json = r.ReadToEnd();
    //                        res = JsonConvert.DeserializeObject<View_CompensationData[]>(json);
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
    //        }

    //        return res;
    //    }

    //    private View_CompensationData[] CreateCompensationFile(string path)
    //    {
    //        View_CompensationData[] res = null;
    //        try
    //        {
    //            List<SqlParameter> parameter = new List<SqlParameter>();
    //            SqlParameter sqlParameter = new SqlParameter();
    //            View_CompensationCollection_Base obj = new View_CompensationCollection_Base(CSystems.ProcessID);
    //            sqlParameter = new SqlParameter("@IsActive", System.Data.SqlDbType.Bit) { Value = true };
    //            parameter.Add(sqlParameter);
    //            string sql = "IsActive= @IsActive";
    //            View_CompensationRow[] row = obj.GetAsArray(parameter, sql, "SortOrder ASC");
    //            obj.Dispose();
    //            if (row != null)
    //            {
    //                res = (from q in row
    //                       select new View_CompensationData
    //                       {
    //                           CompensationID = q.CompensationID,
    //                           CompensationName = q.CompensationName,
    //                           ComplainantType = q.ComplainantType,
    //                           Matter = q.Matter,
    //                           Bracket = q.Bracket,
    //                           IsShowComplainant = q.IsShowComplainant,
    //                           IsShowOfficer = q.IsShowOfficer,
    //                           MaxAmount = q.MaxAmount,
    //                           Note = q.Note,
    //                           SortOrder = q.SortOrder
    //                       }).ToArray();

    //                string jsonString = JsonConvert.SerializeObject(res);
    //                File.WriteAllText(path, jsonString);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
    //        }
    //        return res;
    //    }
    //    public List<View_CompensationData> AccussedForComplainant()
    //    {
    //        var r = (from q in Instance.Compensation
    //                 where q.ComplainantType == "A" && q.IsShowComplainant == true
    //                 select q).ToList();
    //        return r;
    //    }
    //    public List<View_CompensationData> VictimForComplainant()
    //    {
    //        var r = (from q in Instance.Compensation
    //                 where q.ComplainantType == "V" && q.IsShowComplainant == true
    //                 select q).ToList();
    //        return r;
    //    }
    //    public List<View_CompensationData> AccussedForOffice()
    //    {
    //        var r = (from q in Instance.Compensation
    //                 where q.ComplainantType == "A" && q.IsShowOfficer == true
    //                 select q).ToList();
    //        return r;
    //    }
    //    public List<View_CompensationData> VictimForOffice()
    //    {
    //        var r = (from q in Instance.Compensation
    //                 where q.ComplainantType == "V" && q.IsShowOfficer == true
    //                 select q).ToList();
    //        return r;
    //    }
    //    public List<View_CompensationData> CompensationComplainant(string complaintType)
    //    {
    //        var r = (from q in Instance.Compensation
    //                 where q.ComplainantType.Equals(complaintType, StringComparison.CurrentCultureIgnoreCase) && q.IsShowComplainant == true
    //                 select q).ToList();
    //        return r;
    //    }
    //    public List<View_CompensationData> CompensationForOffice(string complaintType)
    //    {
    //        var r = (from q in Instance.Compensation
    //                 where q.ComplainantType.Equals(complaintType, StringComparison.CurrentCultureIgnoreCase) && q.IsShowOfficer == true
    //                 select q).ToList();
    //        return r;
    //    }

    //    public void Reset()
    //    {
    //        _instance.Dispose(true);
    //    }

    //    #region IDisposable Support
    //    private bool disposedValue = false; // To detect redundant calls

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)
    //        {
    //            if (disposing)
    //            {
    //                _instance = null;
    //            }

    //            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
    //            // TODO: set large fields to null.

    //            disposedValue = true;
    //        }
    //    }

    //    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    //    // ~SingletonLawyer()
    //    // {
    //    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //    //   Dispose(false);
    //    // }

    //    // This code added to correctly implement the disposable pattern.
    //    public void Dispose()
    //    {
    //        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //        Dispose(true);
    //        // TODO: uncomment the following line if the finalizer is overridden above.
    //        // GC.SuppressFinalize(this);
    //    }
    //    #endregion
    //}
}
