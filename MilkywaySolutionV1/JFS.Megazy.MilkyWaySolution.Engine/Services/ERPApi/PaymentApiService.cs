using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.ERPData;
using Newtonsoft.Json;
using RestSharp;


namespace JFS.Megazy.MilkyWaySolution.Engine.Services.ERPApi
{
    public partial class PaymentApiService
    {

        private readonly string TOKEN = ConfigurationManager.AppSettings["ERPToken"].ToString();
        private readonly HttpClient _httpClient;

        public PaymentApiService() : this(null)
        {
        }

        public PaymentApiService(HttpClient httpClient)
        {
            //if (!string.IsNullOrWhiteSpace(apiKey))
            //{
            //    _apiKey = apiKey.Trim();
            //}
            _httpClient = httpClient ?? new HttpClient();
        }


        public async Task<PaymentDataResult> GetPaymentAsync(string TransactionNo)
        {
            Payment data = new Payment();
            data.TRANSACTIONNO = TransactionNo;
            var client = new RestClient("https://jfportal.moj.go.th/finance_account/webservice/provide/GetPaymentStatus.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("token", TOKEN);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", CreateJSONString(data), ParameterType.RequestBody);
            IRestResponse responses = client.Execute(request);
            if (!responses.IsSuccessful)
            {
                var errorMessage =
                $"Failed to retrieve a ERP token result. Status Code: {responses.StatusCode}. Message: {responses.Content}";
                return new PaymentDataResult
                {
                    Status = responses.StatusCode.ToString(),
                    ErrorMessage = errorMessage,
                };
            }
            // Get content from json into rich object model.
            var resData = JsonConvert.DeserializeObject<PaymentData>(responses.Content);
            return new PaymentDataResult
            {
                Status = responses.StatusCode.ToString(),
                Result = resData
            };
        }
        private string CreateJSONString(Payment data)
        {
            string Jsonstring = "{";
            if (!string.IsNullOrEmpty(data.TRANSACTIONNO))
            {
                Jsonstring += string.Format("\"{0}\":\"{1}\"", "TRANSACTIONNO", data.TRANSACTIONNO);
            }
            //if (!string.IsNullOrEmpty(data.TRANSACTIONSTATUSID))
            //{
            //    if (Jsonstring.Length > 1)
            //    {
            //        Jsonstring += string.Format(",\"{0}\":\"{1}\"", "TRANSACTIONSTATUSID", data.TRANSACTIONSTATUSID);

            //    }
            //    else
            //    {
            //        Jsonstring += string.Format("\"{0}\":\"{1}\"", "TRANSACTIONSTATUSID", data.TRANSACTIONSTATUSID);
            //    }
            //}
            Jsonstring += "}";
            return Jsonstring;
        }

        public bool UpdateTransactionSqlBulk(PaymentDataResult req)
        {
            bool res = false;
            int id = 0;
            if (req.Result.Result.Count > 0)
            {
                TransactionTempCollection_Base obj = new TransactionTempCollection_Base(CSystems.ProcessID);
                DataTable dt =  obj.CreateDataTable();
                obj.Delete("1=1");
                obj.Dispose();
                DataRow row;
                int index = 0;
                foreach (var i in req.Result.Result)
                {
                    if (index >= 0)
                    {
                        row = dt.NewRow();
                        row["TransactionTempID"] = id;
                        row["TransactionNo"] = i.TRANSACTIONNO;
                        row["FinancialOfficerNote"] = i.DETAILBACK;
                        row["PaidDate"] = Helpers.Utility.ConvertStringToDate(i.PAY_DATE);
                        row["TransactionStatusID"] = Helpers.Utility.TryParseToInt(i.TRANSACTIONSTATUSID);
                        row["PaymentListJson"] = JsonConvert.SerializeObject(i.CHEQUE_INFO);
                        dt.Rows.Add(row);
                    }
                    index++;
                    id++;
                }
                string consString = ConfigurationManager.AppSettings["DefaultLog"].ToString();
                using (SqlConnection conn = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conn))
                    {
                        //Set the database table name
                        conn.Open();
                        sqlBulkCopy.BatchSize = 5000;
                        sqlBulkCopy.DestinationTableName = "[dbo].[TransactionTemp]";
                        sqlBulkCopy.WriteToServer(dt);
                        conn.Close();
                    }

                    string sqlStr = @"
UPDATE
    tb1
SET
    tb1.FinancialOfficerNote = tb2.FinancialOfficerNote,
    tb1.PaidDate = tb2.PaidDate,
    tb1.TransactionStatusID = tb2.TransactionStatusID,
    tb1.ModifiedDate = GETDATE(),
    tb1.PaymentListJson =  tb2.PaymentListJson
FROM 
    [dbo].[Transaction] as tb1
    INNER JOIN [dbo].[TransactionTemp] as tb2
        ON tb1.TransactionNo = tb2.TransactionNo;";
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

    }
}

