using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_FamilyAddressRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _familyID;
		private bool _isSetFamilyID = false;
		private string _name;
		private bool _isSetName = false;
		private int _age;
		private bool _isSetAge = false;
		private bool _ageNull = true;
		private string _career;
		private bool _isSetCareer = false;
		private double _income;
		private bool _isSetIncome = false;
		private bool _incomeNull = true;
		private string _incomeUnit;
		private bool _isSetIncomeUnit = false;
		private string _grupName;
		private bool _isSetGrupName = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private string _houseNo;
		private bool _isSetHouseNo = false;
		private string _villageNo;
		private bool _isSetVillageNo = false;
		private string _street;
		private bool _isSetStreet = false;
		private string _soi;
		private bool _isSetSoi = false;
		private string _subdistrictName;
		private bool _isSetSubdistrictName = false;
		private string _districtName;
		private bool _isSetDistrictName = false;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private string _postCode;
		private bool _isSetPostCode = false;
		public int CaseID
		{
			get
			{
				return _caseID;
			}
			set
			{
				_caseIDNull = false;
				_isSetCaseID = true;
				_caseID = value;
			}
		}
		public bool IsCaseIDNull
		{
			get {
				 return _caseIDNull; }
			set { _caseIDNull = value; }
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
		public double Income
		{
			get
			{
				return _income;
			}
			set
			{
				_incomeNull = false;
				_isSetIncome = true;
				_income = value;
			}
		}
		public bool IsIncomeNull
		{
			get {
				 return _incomeNull; }
			set { _incomeNull = value; }
		}
		public bool _IsSetIncome
		{
			get { return _isSetIncome; }
		}
		public string IncomeUnit
		{
			get { return _incomeUnit; }
			set { _incomeUnit = value;
			      _isSetIncomeUnit = true; }
		}
		public bool _IsSetIncomeUnit
		{
			get { return _isSetIncomeUnit; }
		}
		public string GrupName
		{
			get { return _grupName; }
			set { _grupName = value;
			      _isSetGrupName = true; }
		}
		public bool _IsSetGrupName
		{
			get { return _isSetGrupName; }
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
		public int AddressID
		{
			get { return _addressID; }
			set { _addressID = value;
			      _isSetAddressID = true; }
		}
		public bool _IsSetAddressID
		{
			get { return _isSetAddressID; }
		}
		public string HouseNo
		{
			get { return _houseNo; }
			set { _houseNo = value;
			      _isSetHouseNo = true; }
		}
		public bool _IsSetHouseNo
		{
			get { return _isSetHouseNo; }
		}
		public string VillageNo
		{
			get { return _villageNo; }
			set { _villageNo = value;
			      _isSetVillageNo = true; }
		}
		public bool _IsSetVillageNo
		{
			get { return _isSetVillageNo; }
		}
		public string Street
		{
			get { return _street; }
			set { _street = value;
			      _isSetStreet = true; }
		}
		public bool _IsSetStreet
		{
			get { return _isSetStreet; }
		}
		public string Soi
		{
			get { return _soi; }
			set { _soi = value;
			      _isSetSoi = true; }
		}
		public bool _IsSetSoi
		{
			get { return _isSetSoi; }
		}
		public string SubdistrictName
		{
			get { return _subdistrictName; }
			set { _subdistrictName = value;
			      _isSetSubdistrictName = true; }
		}
		public bool _IsSetSubdistrictName
		{
			get { return _isSetSubdistrictName; }
		}
		public string DistrictName
		{
			get { return _districtName; }
			set { _districtName = value;
			      _isSetDistrictName = true; }
		}
		public bool _IsSetDistrictName
		{
			get { return _isSetDistrictName; }
		}
		public string ProvinceName
		{
			get { return _provinceName; }
			set { _provinceName = value;
			      _isSetProvinceName = true; }
		}
		public bool _IsSetProvinceName
		{
			get { return _isSetProvinceName; }
		}
		public string PostCode
		{
			get { return _postCode; }
			set { _postCode = value;
			      _isSetPostCode = true; }
		}
		public bool _IsSetPostCode
		{
			get { return _isSetPostCode; }
		}
	}
	[Serializable]
	public class View_FamilyAddressData
	{
		private int _caseID;
		private int _applicantID;
		private int _familyID;
		private string _name;
		private int _age;
		private string _career;
		private double _income;
		private string _incomeUnit;
		private string _grupName;
		private string _telephoneNo;
		private int _addressID;
		private string _houseNo;
		private string _villageNo;
		private string _street;
		private string _soi;
		private string _subdistrictName;
		private string _districtName;
		private string _provinceName;
		private string _postCode;
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
		public int FamilyID
		{
			get{ return _familyID; }
			set{ _familyID = value; }
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
		public string Career
		{
			get{ return _career; }
			set{ _career = value; }
		}
		public double Income
		{
			get{ return _income; }
			set{ _income = value; }
		}
		public string IncomeUnit
		{
			get{ return _incomeUnit; }
			set{ _incomeUnit = value; }
		}
		public string GrupName
		{
			get{ return _grupName; }
			set{ _grupName = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public string HouseNo
		{
			get{ return _houseNo; }
			set{ _houseNo = value; }
		}
		public string VillageNo
		{
			get{ return _villageNo; }
			set{ _villageNo = value; }
		}
		public string Street
		{
			get{ return _street; }
			set{ _street = value; }
		}
		public string Soi
		{
			get{ return _soi; }
			set{ _soi = value; }
		}
		public string SubdistrictName
		{
			get{ return _subdistrictName; }
			set{ _subdistrictName = value; }
		}
		public string DistrictName
		{
			get{ return _districtName; }
			set{ _districtName = value; }
		}
		public string ProvinceName
		{
			get{ return _provinceName; }
			set{ _provinceName = value; }
		}
		public string PostCode
		{
			get{ return _postCode; }
			set{ _postCode = value; }
		}
	}
	[Serializable]
	public class View_FamilyAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_FamilyAddressRow[] view_FamilyAddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_FamilyAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_FamilyAddressItems : View_FamilyAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_FamilyAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_FamilyAddressItems[] view_FamilyAddressItems { get; set; }
	}
}

