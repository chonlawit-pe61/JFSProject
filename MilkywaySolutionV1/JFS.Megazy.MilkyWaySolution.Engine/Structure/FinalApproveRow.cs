using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class FinalApproveRow
	{
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private string _finalApproveName;
		private bool _isSetFinalApproveName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int OfficerRoleID
		{
			get { return _officerRoleID; }
			set { _officerRoleID = value;
			      _isSetOfficerRoleID = true; }
		}
		public bool _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
		}
		[Required]
		public string FinalApproveName
		{
			get { return _finalApproveName; }
			set { _finalApproveName = value;
			      _isSetFinalApproveName = true; }
		}
		public bool _IsSetFinalApproveName
		{
			get { return _isSetFinalApproveName; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
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
	public class FinalApproveData
	{
		private int _officerRoleID;
		private string _finalApproveName;
		private DateTime _modifiedDate;
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public string FinalApproveName
		{
			get{ return _finalApproveName; }
			set{ _finalApproveName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class FinalApprovePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public FinalApproveRow[] finalApproveRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส FinalApproveItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class FinalApproveItems : FinalApproveData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class FinalApproveItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public FinalApproveItems[] finalApproveItems { get; set; }
	}
}

