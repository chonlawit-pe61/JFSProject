using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerOfficeRow
	{
		private int _lawyerOfficeID;
		private bool _isSetLawyerOfficeID = false;
		private string _lawyerFirmName;
		private bool _isSetLawyerFirmName = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _faxNo;
		private bool _isSetFaxNo = false;
		private string _email;
		private bool _isSetEmail = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		[Required]
		public int LawyerOfficeID
		{
			get { return _lawyerOfficeID; }
			set { _lawyerOfficeID = value;
			      _isSetLawyerOfficeID = true; }
		}
		public bool _IsSetLawyerOfficeID
		{
			get { return _isSetLawyerOfficeID; }
		}
		[Required]
		public string LawyerFirmName
		{
			get { return _lawyerFirmName; }
			set { _lawyerFirmName = value;
			      _isSetLawyerFirmName = true; }
		}
		public bool _IsSetLawyerFirmName
		{
			get { return _isSetLawyerFirmName; }
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
		[Required]
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value;
			      _isSetIsActive = true; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
	}
	[Serializable]
	public class LawyerOfficeData
	{
		private int _lawyerOfficeID;
		private string _lawyerFirmName;
		private string _telephoneNo;
		private string _faxNo;
		private string _email;
		private DateTime _modifiedDate;
		private bool _isActive;
		public int LawyerOfficeID
		{
			get{ return _lawyerOfficeID; }
			set{ _lawyerOfficeID = value; }
		}
		public string LawyerFirmName
		{
			get{ return _lawyerFirmName; }
			set{ _lawyerFirmName = value; }
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
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
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
	public class LawyerOfficePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerOfficeRow[] lawyerOfficeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerOfficeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerOfficeItems : LawyerOfficeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerOfficeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerOfficeItems[] lawyerOfficeItems { get; set; }
	}
}

