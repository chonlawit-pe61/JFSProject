using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FormRequest;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class FormRequestService
    {
        public int InsertCaseApplicantTemp(CaseApplicantRequestData req,int memberID)
        {
			int tempcaseid = 0;
			DalBase dal = new DalBase();
			try
			{
				CaseApplicantRequestCollection_Base obj = new CaseApplicantRequestCollection_Base(CSystems.ProcessID);
				var row = obj.GetByPrimaryKey(req.TransactionID);
				obj.Dispose();
				if (row != null)
				{
					tempcaseid = req.TransactionID;
					row.Subject = req.Subject;
					row.Title = req.Title;
					row.FirstName = req.FirstName;
					row.LastName = req.LastName;
					row.CardID = req.CardID;
					row.Gender = req.Gender;
					row.Central = "0";
					row.ProvinceID = 1;
					row.DepartmentID = 2;
					row.StatusID = req.StatusID;
					row.ChannelID = 10006;
					row.TelephoneNo = req.TelephoneNo;
					row.PostCode = req.PostCode;
					row.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
					row.IsAgree = req.IsAgree;
					obj = new CaseApplicantRequestCollection_Base(CSystems.ProcessID);
					obj.UpdateOnlyPlainText(row);
					obj.Dispose();
				}
				else
				{
					obj = new CaseApplicantRequestCollection_Base(CSystems.ProcessID);
					tempcaseid = obj.InsertOnlyPlainText(new CaseApplicantRequestRow
					{
						Title = req.Title,
						Subject = req.Subject,
						FirstName = req.FirstName,
						LastName = req.LastName,
						CardID = req.CardID,
						Gender = req.Gender,
						Central = "0",
						ProvinceID = 1,
						DepartmentID = 2,
						StatusID = 0,
						ChannelID = 10006,
						TelephoneNo = req.TelephoneNo,
						PostCode = req.PostCode,
						CreateDate = dal.GetSqlNow(CSystems.ProcessID),
						ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)

					});
					obj.Dispose();
					InsertMemberTranMap(memberID, tempcaseid);
				}

			}
			catch (Exception ex)
			{
				DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
			}
			return tempcaseid;
        }
		public bool InsInsertOrUpdateRequestExtension(int id,string AdditionalData)
        {
			bool ispass = false;
			CaseApplicantRequestExtensionCollection_Base obj = new CaseApplicantRequestExtensionCollection_Base(CSystems.ProcessID);
			var row = obj.GetByPrimaryKey(id);
			obj.Dispose();
			if(row != null)
            {
				row.TransactionID = id;
				row.AdditionalDataJson = AdditionalData;
				obj = new CaseApplicantRequestExtensionCollection_Base(CSystems.ProcessID);
				obj.Update(row);
				obj.Dispose();
				ispass = true;
			}
            else
            {
				obj = new CaseApplicantRequestExtensionCollection_Base(CSystems.ProcessID);
				obj.Insert(new CaseApplicantRequestExtensionRow { 
				TransactionID = id,
				AdditionalDataJson = AdditionalData
				});
				obj.Dispose();
				ispass = true;
			}
			return ispass;
		}
		public bool InsertMemberTranMap(int memberID,int transactionID)
        {
			bool ispass = false;
			MemberTransactionMappingCollection_Base obj = new MemberTransactionMappingCollection_Base(CSystems.ProcessID);
			obj.DeleteByPrimaryKey(memberID, transactionID);
			obj.InsertOnlyPlainText(new MemberTransactionMappingRow { MemberID = memberID, TransactionID = transactionID });
			obj.Dispose();
			ispass = true;

			return ispass;
        }
		//public void InsertAddressTemp(AddressRow req,int tempcaseid)
		//{
		//	DalBase dal = new DalBase();
		//	try
		//	{
		//		dal.DbBeginTransaction(CSystems.ProcessID);

		//		dal.DbCommit(CSystems.ProcessID);
		//	}
		//	catch (Exception ex)
		//	{
		//		dal.DbRollBack(CSystems.ProcessID);
		//		DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);

		//	}
		//}
		//public void InsertCaseType(JFSCaseRequest req ,int tempcaseid)
		//{
		//	DalBase dal = new DalBase();
		//	try
		//	{
		//		dal.DbBeginTransaction(CSystems.ProcessID);
		//		dal.DbCommit(CSystems.ProcessID);
		//	}
		//	catch (Exception ex)
		//	{
		//		dal.DbRollBack(CSystems.ProcessID);
		//		DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
		//	}
		//}
	}
}
