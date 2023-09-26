using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseGuaranteeRow
	{
		private int _guaranteeID;
		private bool _isSetGuaranteeID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _formID;
		private bool _isSetFormID = false;
		private bool _formIDNull = true;
		private string _title;
		private bool _isSetTitle = false;
		private string _name;
		private bool _isSetName = false;
		private string _position;
		private bool _isSetPosition = false;
		private string _relation;
		private bool _isSetRelation = false;
		private string _cardID;
		private bool _isSetCardID = false;
		private string _subjection;
		private bool _isSetSubjection = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private bool _addressIDNull = true;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private DateTime _modified;
		private bool _isSetModified = false;
		private bool _modifiedNull = true;
		[Required]
		public int GuaranteeID
		{
			get { return _guaranteeID; }
			set { _guaranteeID = value;
			      _isSetGuaranteeID = true; }
		}
		public bool _IsSetGuaranteeID
		{
			get { return _isSetGuaranteeID; }
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
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isSetApplicantID = true; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public int FormID
		{
			get
			{
				return _formID;
			}
			set
			{
				_formIDNull = false;
				_isSetFormID = true;
				_formID = value;
			}
		}
		public bool IsFormIDNull
		{
			get {
				 return _formIDNull; }
			set { _formIDNull = value; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
		}
		public string Title
		{
			get { return _title; }
			set { _title = value;
			      _isSetTitle = true; }
		}
		public bool _IsSetTitle
		{
			get { return _isSetTitle; }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value;
			      _isSetName = true; }
		}
		public bool _IsSetName
		{
			get { return _isSetName; }
		}
		public string Position
		{
			get { return _position; }
			set { _position = value;
			      _isSetPosition = true; }
		}
		public bool _IsSetPosition
		{
			get { return _isSetPosition; }
		}
		public string Relation
		{
			get { return _relation; }
			set { _relation = value;
			      _isSetRelation = true; }
		}
		public bool _IsSetRelation
		{
			get { return _isSetRelation; }
		}
		public string CardID
		{
			get { return _cardID; }
			set { _cardID = value;
			      _isSetCardID = true; }
		}
		public bool _IsSetCardID
		{
			get { return _isSetCardID; }
		}
		public string Subjection
		{
			get { return _subjection; }
			set { _subjection = value;
			      _isSetSubjection = true; }
		}
		public bool _IsSetSubjection
		{
			get { return _isSetSubjection; }
		}
		public int AddressID
		{
			get
			{
				return _addressID;
			}
			set
			{
				_addressIDNull = false;
				_isSetAddressID = true;
				_addressID = value;
			}
		}
		public bool IsAddressIDNull
		{
			get {
				 return _addressIDNull; }
			set { _addressIDNull = value; }
		}
		public bool _IsSetAddressID
		{
			get { return _isSetAddressID; }
		}
		public string TelephoneNo
		{
			get { return _telephoneNo; }
			set { _telephoneNo = value;
			      _isSetTelephoneNo = true; }
		}
		public bool _IsSetTelephoneNo
		{
			get { return _isSetTelephoneNo; }
		}
		[Required]
		public DateTime Modified
		{
			get { return _modified; }
			set { _modified = value;
			      _modifiedNull = false;
			      _isSetModified = true; }
		}
		public bool IsModifiedNull
		{
			get {
				 return _modifiedNull; }
			set { _modifiedNull = value; }
		}
		public bool _IsSetModified
		{
			get { return _isSetModified; }
		}
	}
	[Serializable]
	public class CaseGuaranteeData
	{
		private int _guaranteeID;
		private int _caseID;
		private int _applicantID;
		private int _formID;
		private string _title;
		private string _name;
		private string _position;
		private string _relation;
		private string _cardID;
		private string _subjection;
		private int _addressID;
		private string _telephoneNo;
		private DateTime _modified;
		public int GuaranteeID
		{
			get{ return _guaranteeID; }
			set{ _guaranteeID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public string Title
		{
			get{ return _title; }
			set{ _title = value; }
		}
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}
		public string Position
		{
			get{ return _position; }
			set{ _position = value; }
		}
		public string Relation
		{
			get{ return _relation; }
			set{ _relation = value; }
		}
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		public string Subjection
		{
			get{ return _subjection; }
			set{ _subjection = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public DateTime Modified
		{
			get{ return _modified; }
			set{ _modified = value; }
		}
		public string ModifiedStr { get; set; }
	}
	[Serializable]
	public class CaseGuaranteePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseGuaranteeRow[] caseGuaranteeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseGuaranteeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseGuaranteeItems : CaseGuaranteeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseGuaranteeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseGuaranteeItems[] caseGuaranteeItems { get; set; }
	}
}

