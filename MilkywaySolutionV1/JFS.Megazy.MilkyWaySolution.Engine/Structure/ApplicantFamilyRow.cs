using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantFamilyRow
	{
		private int _familyID;
		private bool _isSetFamilyID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _groupName;
		private bool _isSetGroupName = false;
		private string _name;
		private bool _isSetName = false;
		private int _age;
		private bool _isSetAge = false;
		private bool _ageNull = true;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _career;
		private bool _isSetCareer = false;
		private string _addressLine;
		private bool _isSetAddressLine = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int FamilyID
		{
			get { return _familyID; }
			set { _familyID = value;
			      _isSetFamilyID = true; }
		}
		public bool _IsSetFamilyID
		{
			get { return _isSetFamilyID; }
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
		public string GroupName
		{
			get { return _groupName; }
			set { _groupName = value;
			      _isSetGroupName = true; }
		}
		public bool _IsSetGroupName
		{
			get { return _isSetGroupName; }
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
		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_ageNull = false;
				_isSetAge = true;
				_age = value;
			}
		}
		public bool IsAgeNull
		{
			get {
				 return _ageNull; }
			set { _ageNull = value; }
		}
		public bool _IsSetAge
		{
			get { return _isSetAge; }
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
		public string Career
		{
			get { return _career; }
			set { _career = value;
			      _isSetCareer = true; }
		}
		public bool _IsSetCareer
		{
			get { return _isSetCareer; }
		}
		public string AddressLine
		{
			get { return _addressLine; }
			set { _addressLine = value;
			      _isSetAddressLine = true; }
		}
		public bool _IsSetAddressLine
		{
			get { return _isSetAddressLine; }
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
	public class ApplicantFamilyData
	{
		private int _familyID;
		private int _applicantID;
		private string _groupName;
		private string _name;
		private int _age;
		private string _telephoneNo;
		private string _career;
		private string _addressLine;
		private DateTime _modifiedDate;
		public int FamilyID
		{
			get{ return _familyID; }
			set{ _familyID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public string GroupName
		{
			get{ return _groupName; }
			set{ _groupName = value; }
		}
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}
		public int Age
		{
			get{ return _age; }
			set{ _age = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public string Career
		{
			get{ return _career; }
			set{ _career = value; }
		}
		public string AddressLine
		{
			get{ return _addressLine; }
			set{ _addressLine = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantFamilyPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantFamilyRow[] applicantFamilyRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantFamilyItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantFamilyItems : ApplicantFamilyData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantFamilyItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantFamilyItems[] applicantFamilyItems { get; set; }
	}
}

