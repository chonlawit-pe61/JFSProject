using System;
using System.Data;
using Archi.DevelopComponent.Transaction.Engine;
using Sk.StepUpSolution.SComponent;
namespace Megazy.StarterKit.Mvc
{
    public class DalBase
    {
        private DbTransactionClient dbTransactionClient = new DbTransactionClient("Developer", "Archi Solution Co.,ltd", "\\config.ini", 1);
        public int intProcessID;
        private static ExceptionSv _exception = null;


        public DalBase()
        {
            //สำหรับการเก็บ Error log
            if (_exception == null)
            {
                _exception = new ExceptionSv();
                _exception.NameLog = "SSUS ENGINE";
            }

        }
        public static ExceptionSv ExceptEngine
        {

            get
            {
                if (_exception == null)
                {
                    _exception = new ExceptionSv();
                    _exception.NameLog = "SSUS ENGINE";
                }

                return _exception;
            }
        }
        private DbTransactionClient DbTransactionClient
        {
            get
            {
                return dbTransactionClient;
            }
        }
        //เพิ่มอีกสอง Class กรณีเปิด Begin Tran บนหน้า UI
        public void DbBeginTransaction()
        {
            if (intProcessID != 0)
            {
                dbTransactionClient.BeginDbTransaction(intProcessID);
            }
            else
            {
                dbTransactionClient.BeginDbTransaction();
            }
        }
        public void DbBeginTransaction(IsolationLevel iso)
        {
            if (intProcessID != 0)
            {
                dbTransactionClient.BeginDbTransaction(intProcessID, iso);
            }
            else
            {
                dbTransactionClient.BeginDbTransaction(iso);
            }
        }
        //Update 051030 ต้องการให้เปิด Begin Tran ในกรณีเป็น Multi Tier จาก Front end
        public void DbBeginTransaction(int processID)
        {
            dbTransactionClient.BeginDbTransaction(processID);
        }
        //Update 20140221
        public void DbBeginTransaction(int processID, IsolationLevel iso)
        {
            dbTransactionClient.BeginDbTransaction(processID, iso);
        }
        //Update 051030 Class Commit และ RollBack ด้านล่าง  เพราะต้องการให้เปิด Begin Tran ในกรณีเป็น Multi Tier จาก Front end
        public void DbCommit(int processID)
        {
            dbTransactionClient.Commit(processID);
        }
        public void DbRollBack(int processID)
        {
            dbTransactionClient.RollBack(processID);
        }
        //Update 051030 Class InitCommand ด้านล่าง  เพราะต้องการให้เปิด Begin Tran ในกรณีเป็น Multi Tier จาก Front end
        public void InitCommand(int processID, System.Data.IDbCommand command)
        {
            //Check ว่า มี Transaction มาจากก่อนหน้านี่หรือไม่  
            //ถ้ามีเป็น  True ให้เก็บ History ของ Command ของ Transaction
            //ถ้าเป็น	False ไม่เก็บ  Command ของ Transaction
            IDbTransaction tranObj = DbTransactionClient.CurrentTransaction(processID, command, true);
            var cc = command;

            if (tranObj == null)
            {
                //กรณีไม่มี Begintran 	
                DbTransactionClient.CurrentCommand(command);
            }



        }
        //Update 051030 Class Close ด้านล่าง  เพราะต้องการให้เปิด Begin Tran ในกรณีเป็น Multi Tier จาก Front end
        public void Close(int processID, System.Data.IDbCommand command)
        {
            IDbTransaction tranObj = DbTransactionClient.CurrentTransaction(processID, command, false);
            if (tranObj == null)
            {
                //กรณีไม่มี Begintran ก่อนหน้า นำไป Check 
                //ว่ามี Command อื่นค้างอยู่อีกหรือป่าว ไม่มี Close connection 
                DbTransactionClient.Close(command);
            }

        }


        public void DbCommit()
        {
            if (intProcessID != 0)
            {
                dbTransactionClient.Commit(intProcessID);
            }
            else
            {
                dbTransactionClient.Commit();
            }

        }
        public void DbRollBack()
        {
            if (intProcessID != 0)
            {
                dbTransactionClient.RollBack(intProcessID);
            }
            else
            {
                dbTransactionClient.RollBack();
            }

        }

        public void InitCommand(System.Data.IDbCommand command)
        {
            //Check ว่า มี Transaction มาจากก่อนหน้านี่หรือไม่  
            //ถ้ามีเป็น  True ให้เก็บ History ของ Command ของ Transaction
            //ถ้าเป็น	False ไม่เก็บ  Command ของ Transaction
            IDbTransaction tranObj = DbTransactionClient.CurrentTransaction(command, true);

            if (tranObj == null)
            {
                //กรณีไม่มี Begintran
                DbTransactionClient.CurrentCommand(command);
            }


        }
        public void Close(System.Data.IDbCommand command)
        {
            IDbTransaction tranObj = DbTransactionClient.CurrentTransaction(command, false);
            if (tranObj == null)
            {
                //กรณีไม่มี Begintran ก่อนหน้า นำไป Check 
                //ว่ามี Command อื่นค้างอยู่อีกหรือป่าว ไม่มี Close connection 
                DbTransactionClient.Close(command);
            }
        }
        public static DateTime SqlNowIncludePd(int processID)
        {

            SqlDataTime sqlDateTime = new SqlDataTime();
            sqlDateTime.ProcessID(processID);
            DateTime returnDateTime = Convert.ToDateTime((sqlDateTime.CreateDataTable("Select GetDate() As SqlDateTime")).Rows[0]["SqlDateTime"]);
            sqlDateTime.Dispose();

            return returnDateTime;


        }
        public DateTime GetSqlNow(int processID)
        {
            return DalBase.SqlNowIncludePd(processID);
        }

        //Linq
        public void InitLinq(int processID, ConnectorLinq cLinq)
        {
            //Check ว่า มี Transaction มาจากก่อนหน้านี่หรือไม่  
            //ถ้ามีเป็น  True ให้เก็บ History ของ Command ของ Transaction
            //ถ้าเป็น	False ไม่เก็บ  Command ของ Transaction
            IDbTransaction tranObj = DbTransactionClient.CurrentTransaction(processID, cLinq, true);

            if (tranObj == null)
            {
                //กรณีไม่มี Begintran 	
                DbTransactionClient.CurrentCommand(cLinq);
            }

        }
    }
}