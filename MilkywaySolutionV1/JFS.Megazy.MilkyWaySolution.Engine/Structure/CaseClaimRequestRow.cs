using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseClaimRequestRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _memberID;
		private bool _isSetMemberID = false;
		private DateTime _requestDate;
		private bool _isSetRequestDate = false;
		private bool _requestDateNull = true;
		private int _claimStatusID;
		private bool _isSetClaimStatusID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isMapRecord = false;
			      _isSetCaseID = true; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		[Required]
		public int MemberID
		{
			get { return _memberID; }
			set { _memberID = value;
			      _isMapRecord = false;
			      _isSetMemberID = true; }
		}
		public Boolean _IsSetMemberID
		{
			get { return _isSetMemberID; }
		}
		[Required]
		public DateTime RequestDate
		{
			get { return _requestDate; }
			set { _requestDate = value;
			      _requestDateNull = false;
			      _isMapRecord = false;
			      _isSetRequestDate = true; }
		}
		public bool IsRequestDateNull
		{
			get {
				 return _requestDateNull; }
			set { _requestDateNull = value; }
		}
		public Boolean _IsSetRequestDate
		{
			get { return _isSetRequestDate; }
		}
		[Required]
		public int ClaimStatusID
		{
			get { return _claimStatusID; }
			set { _claimStatusID = value;
			      _isMapRecord = false;
			      _isSetClaimStatusID = true; }
		}
		public Boolean _IsSetClaimStatusID
		{
			get { return _isSetClaimStatusID; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isMapRecord = false;
			      _isSetModifiedDate = true; }
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class CaseClaimRequestData
	{
		private int _caseID;
		private int _memberID;
		private DateTime _requestDate;
		private int _claimStatusID;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int MemberID
		{
			get{ return _memberID; }
			set{ _memberID = value; }
		}
		public DateTime RequestDate
		{
			get{ return _requestDate; }
			set{ _requestDate = value; }
		}
		public string RequestDateStr { get; set; }
		public int ClaimStatusID
		{
			get{ return _claimStatusID; }
			set{ _claimStatusID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseClaimRequestPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseClaimRequestRow[] caseclaimRequestRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseClaimRequestItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseClaimRequestItems : CaseClaimRequestData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseClaimRequestItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseClaimRequestItems[] caseclaimRequestItems { get; set; }
	}
}

