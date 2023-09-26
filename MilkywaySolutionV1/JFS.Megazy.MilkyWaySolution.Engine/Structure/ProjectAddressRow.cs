using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProjectAddressRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private string _email;
		private bool _isSetEmail = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _faxNo;
		private bool _isSetFaxNo = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public string FaxNo
		{
			get { return _faxNo; }
			set { _faxNo = value;
			      _isSetFaxNo = true; }
		}
		public bool _IsSetFaxNo
		{
			get { return _isSetFaxNo; }
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
	public class ProjectAddressData
	{
		private int _caseID;
		private int _addressID;
		private string _email;
		private string _telephoneNo;
		private string _faxNo;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public string FaxNo
		{
			get{ return _faxNo; }
			set{ _faxNo = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ProjectAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProjectAddressRow[] projectAddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProjectAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProjectAddressItems : ProjectAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProjectAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProjectAddressItems[] projectAddressItems { get; set; }
	}
}

