using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicantRequestExtensionRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private string _additionalDataJson;
		private bool _isSetAdditionalDataJson = false;
		private bool _additionalDataJsonNull = true;
		private string _remark;
		private bool _isSetRemark = false;
		private bool _remarkNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int TransactionID
		{
			get { return _transactionID; }
			set { _transactionID = value;
			      _isMapRecord = false;
			      _isSetTransactionID = true; }
		}
		public Boolean _IsSetTransactionID
		{
			get { return _isSetTransactionID; }
		}
		public string AdditionalDataJson
		{
			get
			{
				return _additionalDataJson;
			}
			set
			{
				_additionalDataJsonNull = false;
				_isSetAdditionalDataJson = true;
				_additionalDataJson = value;
				_isMapRecord = false;
			}
		}
		public bool IsAdditionalDataJsonNull
		{
			get {
				 return _additionalDataJsonNull; }
			set { _additionalDataJsonNull = value; }
		}
		public Boolean _IsSetAdditionalDataJson
		{
			get { return _isSetAdditionalDataJson; }
		}
		public string Remark
		{
			get
			{
				return _remark;
			}
			set
			{
				_remarkNull = false;
				_isSetRemark = true;
				_remark = value;
				_isMapRecord = false;
			}
		}
		public bool IsRemarkNull
		{
			get {
				 return _remarkNull; }
			set { _remarkNull = value; }
		}
		public Boolean _IsSetRemark
		{
			get { return _isSetRemark; }
		}
	}
	[Serializable]
	public class CaseApplicantRequestExtensionData
	{
		private int _transactionID;
		private string _additionalDataJson;
		private string _remark;
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public string AdditionalDataJson
		{
			get{ return _additionalDataJson; }
			set{ _additionalDataJson = value; }
		}
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
	}
	[Serializable]
	public class CaseApplicantRequestExtensionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantRequestExtensionRow[] caseApplicantRequestExtensionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantRequestExtensionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantRequestExtensionItems : CaseApplicantRequestExtensionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantRequestExtensionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantRequestExtensionItems[] caseApplicantRequestExtensionItems { get; set; }
	}
}

