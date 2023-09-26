using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ContractPersonRow
	{
		private int _personID;
		private bool _isSetPersonID = false;
		private int _contractID;
		private bool _isSetContractID = false;
		private bool _contractIDNull = true;
		private int _roleID;
		private bool _isSetRoleID = false;
		private bool _roleIDNull = true;
		private string _roleName;
		private bool _isSetRoleName = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private bool _addressIDNull = true;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int PersonID
		{
			get { return _personID; }
			set { _personID = value;
			      _isSetPersonID = true; }
		}
		public bool _IsSetPersonID
		{
			get { return _isSetPersonID; }
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
			}
		}
		public bool IsContractIDNull
		{
			get {
				 return _contractIDNull; }
			set { _contractIDNull = value; }
		}
		public bool _IsSetContractID
		{
			get { return _isSetContractID; }
		}
		public int RoleID
		{
			get
			{
				return _roleID;
			}
			set
			{
				_roleIDNull = false;
				_isSetRoleID = true;
				_roleID = value;
			}
		}
		public bool IsRoleIDNull
		{
			get {
				 return _roleIDNull; }
			set { _roleIDNull = value; }
		}
		public bool _IsSetRoleID
		{
			get { return _isSetRoleID; }
		}
		public string RoleName
		{
			get { return _roleName; }
			set { _roleName = value;
			      _isSetRoleName = true; }
		}
		public bool _IsSetRoleName
		{
			get { return _isSetRoleName; }
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
	public class ContractPersonData
	{
		private int _personID;
		private int _contractID;
		private int _roleID;
		private string _roleName;
		private int _addressID;
		private string _telephoneNo;
		private DateTime _modifiedDate;
		public int PersonID
		{
			get{ return _personID; }
			set{ _personID = value; }
		}
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public int RoleID
		{
			get{ return _roleID; }
			set{ _roleID = value; }
		}
		public string RoleName
		{
			get{ return _roleName; }
			set{ _roleName = value; }
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ContractPersonPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ContractPersonRow[] contractPersonRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ContractPersonItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ContractPersonItems : ContractPersonData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ContractPersonItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ContractPersonItems[] contractPersonItems { get; set; }
	}
}

