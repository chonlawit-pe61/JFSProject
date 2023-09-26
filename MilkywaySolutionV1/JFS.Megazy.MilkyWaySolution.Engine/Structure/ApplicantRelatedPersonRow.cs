using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantRelatedPersonRow
	{
		private int _contactPersonID;
		private bool _isSetContactPersonID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _personRoleID;
		private bool _isSetPersonRoleID = false;
		private bool _personRoleIDNull = true;
		private string _telephoneNumber;
		private bool _isSetTelephoneNumber = false;
		private string _email;
		private bool _isSetEmail = false;
		private string _relatedAs;
		private bool _isSetRelatedAs = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private bool _addressIDNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ContactPersonID
		{
			get { return _contactPersonID; }
			set { _contactPersonID = value;
			      _isSetContactPersonID = true; }
		}
		public bool _IsSetContactPersonID
		{
			get { return _isSetContactPersonID; }
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
		public int PersonRoleID
		{
			get
			{
				return _personRoleID;
			}
			set
			{
				_personRoleIDNull = false;
				_isSetPersonRoleID = true;
				_personRoleID = value;
			}
		}
		public bool IsPersonRoleIDNull
		{
			get {
				 return _personRoleIDNull; }
			set { _personRoleIDNull = value; }
		}
		public bool _IsSetPersonRoleID
		{
			get { return _isSetPersonRoleID; }
		}
		public string TelephoneNumber
		{
			get { return _telephoneNumber; }
			set { _telephoneNumber = value;
			      _isSetTelephoneNumber = true; }
		}
		public bool _IsSetTelephoneNumber
		{
			get { return _isSetTelephoneNumber; }
		}
		public string Email
		{
			get { return _email; }
			set { _email = value;
			      _isSetEmail = true; }
		}
		public bool _IsSetEmail
		{
			get { return _isSetEmail; }
		}
		public string RelatedAs
		{
			get { return _relatedAs; }
			set { _relatedAs = value;
			      _isSetRelatedAs = true; }
		}
		public bool _IsSetRelatedAs
		{
			get { return _isSetRelatedAs; }
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
	public class ApplicantRelatedPersonData
	{
		private int _contactPersonID;
		private int _caseID;
		private int _applicantID;
		private int _personRoleID;
		private string _telephoneNumber;
		private string _email;
		private string _relatedAs;
		private int _addressID;
		private DateTime _modifiedDate;
		public int ContactPersonID
		{
			get{ return _contactPersonID; }
			set{ _contactPersonID = value; }
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
		public int PersonRoleID
		{
			get{ return _personRoleID; }
			set{ _personRoleID = value; }
		}
		public string TelephoneNumber
		{
			get{ return _telephoneNumber; }
			set{ _telephoneNumber = value; }
		}
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public string RelatedAs
		{
			get{ return _relatedAs; }
			set{ _relatedAs = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantRelatedPersonPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantRelatedPersonRow[] applicantRelatedPersonRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantRelatedPersonItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantRelatedPersonItems : ApplicantRelatedPersonData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantRelatedPersonItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantRelatedPersonItems[] applicantRelatedPersonItems { get; set; }
	}
}

