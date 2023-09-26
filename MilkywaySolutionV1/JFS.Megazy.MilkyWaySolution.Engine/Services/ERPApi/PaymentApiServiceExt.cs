using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.ERPData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.ERPApi
{
    public partial class PaymentApiService
    {
        private readonly string DummyData = @"{
    'Status':'Success',
    'Result':[{'TRANSACTIONNO': 'JF00000096',
      'TRANSACTIONSTATUSID': '5',
      'DETAILBACK': '',
      'PAY_DATE': '2022-01-14',
      'CHEQUE_INFO': {
        'CHEQUE_NO': '10544980',
        'CHEQUE_BANK_NO': '101-0-27403-1',
        'CHEQUE_BANK_NAME': 'ธนาคาร กรุงไทย จำกัด (มหาชน)',
        'CHEQUE_BANK_BRANCH': 'กระบี่',
        'CHEQUE_RECEIVE_NAME': 'ศาลจังหวัดกระบี่',
        'CHEQUE_AMOUNT': 9888}
}]
}";
        public async Task<PaymentDataResult> GetPaymentAsync2(PaymentFillter fillter)
        {

            try
            {
               // fillter.TRANSACTIONNO = "JF00002937";
                var requestUrl = "https://jfportal.moj.go.th/finance_account/webservice/provide/GetPaymentStatus.php";
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
                    return new PaymentDataResult
                    {
                        Status = response.StatusCode.ToString(),
                        ErrorMessage = errorMessage,
                    };
                }
#if DEBUG
                //  result = DummyData;
#endif
                // Get content from json into rich object model.
                var resData = JsonConvert.DeserializeObject<PaymentData>(result);
                return new PaymentDataResult
                {
                    Status = response.StatusCode.ToString(),
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
        //private static List<KeyValuePair<string, string>> ConvertCompenentFilter(string TransactionNo)
        //{
        //    var items = new List<KeyValuePair<string, string>>();
        //    if (!string.IsNullOrWhiteSpace(TransactionNo))
        //    {
        //        items.Add(new KeyValuePair<string, string>("TRANSACTIONNO", TransactionNo));
        //    }
        //    return items;
        //}



    }
}

