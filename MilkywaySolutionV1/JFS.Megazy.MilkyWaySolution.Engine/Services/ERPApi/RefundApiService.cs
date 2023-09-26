using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.ERPData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.ERPApi
{
    public class RefundApiService
    {
        private readonly string TOKEN = ConfigurationManager.AppSettings["ERPToken"].ToString();
        private readonly HttpClient _httpClient;
        private readonly string DummyData = @"{
    'Status': 'REFUND',
    'Result': [
        {
            'REFUND': [
                {
                    'TRANSACTIONNO': 'JF00006362',
                    'call_refund': [
                        {
                            'call_refund_id': '26',
                            'pay_cost_id': '21912',
                            'money_refund': '2970',
                            'call_status': '1',
                            'call_status_name': 'เรียกเงินคืน',
                            'pay_cost_desc': 'งวดที่1',
                            'cost_value': '3000',
                            'note': 'เนื่องจากแบ่งงวดเงินผิด',
                            'BDGLISTID': '51',
                            'create_time': '2023-05-03 10:14:39.173'
                        }
                    ]
                }
            ]
        }
    ]
}";
        public RefundApiService() : this(null)
        {
        }

        public RefundApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public async Task<RefundDataResult> GetReFundAsync(PaymentFillter fillter)
        {

            try
            {
                //fillter = new PaymentFillter { TRANSACTIONNO = "JF00006362" };

                var requestUrl = "https://jfportal.moj.go.th/finance_account/webservice/provide/call_refund.php";
                // var content = new FormUrlEncodedContent(ConvertCompenentFilter(TransactionNo));//สำหรับ form post
                var content = new StringContent(ConvertCompenentFilter(fillter).ToString(), Encoding.UTF8, "application/json");//สำหรับส่งข้อมูลผ่าน json body
                var httpClient = _httpClient ?? new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");// new AuthenticationHeaderValue( "Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{DXCClientID}:{DXCClientSecret}")));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Token", TOKEN);//.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.PostAsync(requestUrl, content).ConfigureAwait(false);
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage =
                        $"Failed to retrieve a ERP token result. Status Code: {response.StatusCode}. Message: {result}";
                    return new RefundDataResult
                    {
                        Status = response.StatusCode.ToString(),
                        ErrorMessage = errorMessage,
                    };
                }
#if DEBUG
            // result = DummyData;
#endif
                // Get content from json into rich object model.
                var resData = JsonConvert.DeserializeObject<RefundRetult>(result);
                return new RefundDataResult
                {
                    Status =resData.Status== "Error" ? "Error" : response.StatusCode.ToString(),
                    Result = resData
                };
            }
            catch (Exception ex)
            {

                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return null;

        }
        private static JObject ConvertCompenentFilter(PaymentFillter paymentFillter)
        {

            var myObject = (dynamic)new JObject();
            if (!string.IsNullOrWhiteSpace(paymentFillter.TRANSACTIONNO))
            {
                myObject.TRANSACTIONNO = paymentFillter.TRANSACTIONNO;
            }
            if (!string.IsNullOrWhiteSpace(paymentFillter.STARTDATE))
            {
                myObject.START_DATE = paymentFillter.STARTDATE;
            }
            if (!string.IsNullOrWhiteSpace(paymentFillter.ENDDATE))
            {
                myObject.END_DATE = paymentFillter.ENDDATE;
            }
            //if (!string.IsNullOrWhiteSpace(TRANSACTIONSTATUSID))
            //{
            //    myObject.TRANSACTIONSTATUSID = Transactionstatusid;
            //}
            var n = myObject.ToString();
            return myObject;
        }
        public bool UpdateTransactionSqlBulk(RefundDataResult req)
        {
            bool res = false;
            int id = 0;
            if (req.Result.Result != null && req.Result.Result.Count > 0)
            {
                TransactionRefundCollection_Base obj = new TransactionRefundCollection_Base(CSystems.ProcessID);
                DataTable dt = obj.CreateDataTable();
                obj.Delete("1=1");
                obj.Dispose();
                DataRow row;
                int index = 0;
                foreach (var i in req.Result.Result)
                {
                    foreach (var item in i.Refund)
                    {
                        id++;
                        if (index >= 0)
                        {
                            row = dt.NewRow();
                            row["TransactionRefundID"] = id;
                            row["TransactionNo"] = item.TransactionNo;
                            //row["RefundAmount"] = Helpers.Utility.TryParseToFloat(i.Refund.MoneyRefund);
                            //row["Note"] = i.Refund.Note;
                            //row["RefCostID"] = Helpers.Utility.TryParseToInt(i.Refund.PayCostID);
                            row["ModifiedDate"] = new DalBase().GetSqlNow(CSystems.ProcessID);
                            dt.Rows.Add(row);
                        }
                        index++;
                        
                    }
                }
                string consString = ConfigurationManager.AppSettings["DefaultLog"].ToString();
                using (SqlConnection conn = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conn))
                    {
                        //Set the database table name
                        conn.Open();
                        sqlBulkCopy.BatchSize = 5000;
                        sqlBulkCopy.DestinationTableName = "[dbo].[TransactionRefund]";
                        sqlBulkCopy.WriteToServer(dt);
                        conn.Close();
                    }

                    string sqlStr = @"
                    UPDATE tb2
                    SET    tb2.IsRequestRefund = 1  
                    FROM  [Transaction]  as tb1
	                INNER JOIN TransactionAdditional  as tb2 ON tb1.TransactionID = tb2.TransactionID
		            INNER JOIN TransactionRefund as tb3 ON tb1.TransactionNo = tb3.TransactionNo;";
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlStr, conn);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    conn.Close();



                }
                res = true;
            }
            return res;
        }

   public RefundDataResult GetReFundTest(PaymentFillter fillter)
    {
        var result = DummyData;
        var resData = JsonConvert.DeserializeObject<RefundRetult>(result);
        return new RefundDataResult
        {
            Result = resData
        };
    }  
    
    }
   

}
