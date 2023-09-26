using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseProjectReferencePersonRow
	{
		private int _refPersonID;
		private bool _isSetRefPersonID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private string _refPersonName;
		private bool _isSetRefPersonName = false;
		private string _refPersonAddress;
		private bool _isSetRefPersonAddress = false;
		private string _refPersonTelephonNo;
		private bool _isSetRefPersonTelephonNo = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int RefPersonID
		{
			get { return _refPersonID; }
			set { _refPersonID = value;
			      _isSetRefPersonID = true; }
		}
		public bool _IsSetRefPersonID
		{
			get { return _isSetRefPersonID; }
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
		public string RefPersonName
		{
			get { return _refPersonName; }
			set { _refPersonName = value;
			      _isSetRefPersonName = true; }
		}
		public bool _IsSetRefPersonName
		{
			get { return _isSetRefPersonName; }
		}
		public string RefPersonAddress
		{
			get { return _refPersonAddress; }
			set { _refPersonAddress = value;
			      _isSetRefPersonAddress = true; }
		}
		public bool _IsSetRefPersonAddress
		{
			get { return _isSetRefPersonAddress; }
		}
		public string RefPersonTelephonNo
		{
			get { return _refPersonTelephonNo; }
			set { _refPersonTelephonNo = value;
			      _isSetRefPersonTelephonNo = true; }
		}
		public bool _IsSetRefPersonTelephonNo
		{
			get { return _isSetRefPersonTelephonNo; }
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
	public class CaseProjectReferencePersonData
	{
		private int _refPersonID;
		private int _caseID;
		private string _refPersonName;
		private string _refPersonAddress;
		private string _refPersonTelephonNo;
		private DateTime _modifiedDate;
		public int RefPersonID
		{
			get{ return _refPersonID; }
			set{ _refPersonID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public string RefPersonName
		{
			get{ return _refPersonName; }
			set{ _refPersonName = value; }
		}
		public string RefPersonAddress
		{
			get{ return _refPersonAddress; }
			set{ _refPersonAddress = value; }
		}
		public string RefPersonTelephonNo
		{
			get{ return _refPersonTelephonNo; }
			set{ _refPersonTelephonNo = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseProjectReferencePersonPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseProjectReferencePersonRow[] caseProjectReferencePersonRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseProjectReferencePersonItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseProjectReferencePersonItems : CaseProjectReferencePersonData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseProjectReferencePersonItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseProjectReferencePersonItems[] caseProjectReferencePersonItems { get; set; }
	}
}

