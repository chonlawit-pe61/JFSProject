using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantLawyerRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _formID;
		private bool _isSetFormID = false;
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private int _contractID;
		private bool _isSetContractID = false;
		private bool _contractIDNull = true;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
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
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isMapRecord = false;
			      _isSetApplicantID = true; }
		}
		public Boolean _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		[Required]
		public int FormID
		{
			get { return _formID; }
			set { _formID = value;
			      _isMapRecord = false;
			      _isSetFormID = true; }
		}
		public Boolean _IsSetFormID
		{
			get { return _isSetFormID; }
		}
		[Required]
		public int LawyerID
		{
			get { return _lawyerID; }
			set { _lawyerID = value;
			      _isMapRecord = false;
			      _isSetLawyerID = true; }
		}
		public Boolean _IsSetLawyerID
		{
			get { return _isSetLawyerID; }
		}
		public int ContractID
		{
			get
			{
				return _contractID;
			}
			set
			{
				_contractIDNull = false;
				_isSetContractID = true;
				_contractID = value;
				_isMapRecord = false;
			}
		}
		public bool IsContractIDNull
		{
			get {
				 return _contractIDNull; }
			set { _contractIDNull = value; }
		}
		public Boolean _IsSetContractID
		{
			get { return _isSetContractID; }
		}
		[Required]
		public DateTime CreateDate
		{
			get { return _createDate; }
			set { _createDate = value;
			      _createDateNull = false;
			      _isMapRecord = false;
			      _isSetCreateDate = true; }
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public Boolean _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
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
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public Boolean _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
	}
	[Serializable]
	public class ApplicantLawyerData
	{
		private int _applicantID;
		private int _formID;
		private int _lawyerID;
		private int _contractID;
		private DateTime _createDate;
		private DateTime _modifiedDate;
		private bool _isActive;
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
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class ApplicantLawyerPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantLawyerRow[] applicantLawyerRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantLawyerItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantLawyerItems : ApplicantLawyerData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantLawyerItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantLawyerItems[] applicantLawyerItems { get; set; }
	}
}

