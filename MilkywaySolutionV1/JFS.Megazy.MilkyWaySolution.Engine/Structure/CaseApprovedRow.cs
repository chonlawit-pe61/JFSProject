using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApprovedRow
	{
		private int _approvedID;
		private bool _isSetApprovedID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private double _approvedamount;
		private bool _isSetApprovedAmount = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ApprovedID
		{
			get { return _approvedID; }
			set { _approvedID = value;
			      _isSetApprovedID = true; }
		}
		public bool _IsSetApprovedID
		{
			get { return _isSetApprovedID; }
		}
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isSetCaseID = true; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		[Required]
		public double ApprovedAmount
		{
			get { return _approvedamount; }
			set { _approvedamount = value;
			      _isSetApprovedAmount = true; }
		}
		public bool _IsSetApprovedAmount
		{
			get { return _isSetApprovedAmount; }
		}
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				_modifiedDateNull = false;
				_isSetModifiedDate = true;
				_modifiedDate = value;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public bool _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class CaseApprovedData
	{
		private int _approvedID;
		private int _caseID;
		private double _approvedamount;
		private DateTime _modifiedDate;
		public int ApprovedID
		{
			get{ return _approvedID; }
			set{ _approvedID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public double ApprovedAmount
		{
			get{ return _approvedamount; }
			set{ _approvedamount = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseApprovedPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApprovedRow[] caseApprovedRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApprovedItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApprovedItems : CaseApprovedData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApprovedItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApprovedItems[] caseApprovedItems { get; set; }
	}
}

