using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class DepartmentAuthorizedPersonRow
	{
		private int _authorizedPersonID;
		private bool _isSetAuthorizedPersonID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private string _authorizedPersonTitle;
		private bool _isSetAuthorizedPersonTitle = false;
		private string _authorizedPersonFirstName;
		private bool _isSetAuthorizedPersonFirstName = false;
		private string _authorizedPersonLastName;
		private bool _isSetAuthorizedPersonLastName = false;
		private string _authorizedPersonPosition;
		private bool _isSetAuthorizedPersonPosition = false;
		private string _mobileNumber;
		private bool _isSetMobileNumber = false;
		private string _powerOfAttorney;
		private bool _isSetPowerOfAttorney = false;
		private bool _isPrimary;
		private bool _isSetIsPrimary = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int AuthorizedPersonID
		{
			get { return _authorizedPersonID; }
			set { _authorizedPersonID = value;
			      _isSetAuthorizedPersonID = true; }
		}
		public bool _IsSetAuthorizedPersonID
		{
			get { return _isSetAuthorizedPersonID; }
		}
		[Required]
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isSetDepartmentID = true; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		[Required]
		public string AuthorizedPersonTitle
		{
			get { return _authorizedPersonTitle; }
			set { _authorizedPersonTitle = value;
			      _isSetAuthorizedPersonTitle = true; }
		}
		public bool _IsSetAuthorizedPersonTitle
		{
			get { return _isSetAuthorizedPersonTitle; }
		}
		[Required]
		public string AuthorizedPersonFirstName
		{
			get { return _authorizedPersonFirstName; }
			set { _authorizedPersonFirstName = value;
			      _isSetAuthorizedPersonFirstName = true; }
		}
		public bool _IsSetAuthorizedPersonFirstName
		{
			get { return _isSetAuthorizedPersonFirstName; }
		}
		[Required]
		public string AuthorizedPersonLastName
		{
			get { return _authorizedPersonLastName; }
			set { _authorizedPersonLastName = value;
			      _isSetAuthorizedPersonLastName = true; }
		}
		public bool _IsSetAuthorizedPersonLastName
		{
			get { return _isSetAuthorizedPersonLastName; }
		}
		public string AuthorizedPersonPosition
		{
			get { return _authorizedPersonPosition; }
			set { _authorizedPersonPosition = value;
			      _isSetAuthorizedPersonPosition = true; }
		}
		public bool _IsSetAuthorizedPersonPosition
		{
			get { return _isSetAuthorizedPersonPosition; }
		}
		public string MobileNumber
		{
			get { return _mobileNumber; }
			set { _mobileNumber = value;
			      _isSetMobileNumber = true; }
		}
		public bool _IsSetMobileNumber
		{
			get { return _isSetMobileNumber; }
		}
		public string PowerOfAttorney
		{
			get { return _powerOfAttorney; }
			set { _powerOfAttorney = value;
			      _isSetPowerOfAttorney = true; }
		}
		public bool _IsSetPowerOfAttorney
		{
			get { return _isSetPowerOfAttorney; }
		}
		[Required]
		public bool IsPrimary
		{
			get { return _isPrimary; }
			set { _isPrimary = value;
			      _isSetIsPrimary = true; }
		}
		public bool _IsSetIsPrimary
		{
			get { return _isSetIsPrimary; }
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
	public class DepartmentAuthorizedPersonData
	{
		private int _authorizedPersonID;
		private int _departmentId;
		private string _authorizedPersonTitle;
		private string _authorizedPersonFirstName;
		private string _authorizedPersonLastName;
		private string _authorizedPersonPosition;
		private string _mobileNumber;
		private string _powerOfAttorney;
		private bool _isPrimary;
		private DateTime _modifiedDate;
		public int AuthorizedPersonID
		{
			get{ return _authorizedPersonID; }
			set{ _authorizedPersonID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public string AuthorizedPersonTitle
		{
			get{ return _authorizedPersonTitle; }
			set{ _authorizedPersonTitle = value; }
		}
		public string AuthorizedPersonFirstName
		{
			get{ return _authorizedPersonFirstName; }
			set{ _authorizedPersonFirstName = value; }
		}
		public string AuthorizedPersonLastName
		{
			get{ return _authorizedPersonLastName; }
			set{ _authorizedPersonLastName = value; }
		}
		public string AuthorizedPersonPosition
		{
			get{ return _authorizedPersonPosition; }
			set{ _authorizedPersonPosition = value; }
		}
		public string MobileNumber
		{
			get{ return _mobileNumber; }
			set{ _mobileNumber = value; }
		}
		public string PowerOfAttorney
		{
			get{ return _powerOfAttorney; }
			set{ _powerOfAttorney = value; }
		}
		public bool IsPrimary
		{
			get{ return _isPrimary; }
			set{ _isPrimary = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class DepartmentAuthorizedPersonPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public DepartmentAuthorizedPersonRow[] departmentAuthorizedPersonRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส DepartmentAuthorizedPersonItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class DepartmentAuthorizedPersonItems : DepartmentAuthorizedPersonData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class DepartmentAuthorizedPersonItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public DepartmentAuthorizedPersonItems[] departmentAuthorizedPersonItems { get; set; }
	}
}

