using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class InspectLinkageServiceRow
	{
		private int _inspectiD;
		private bool _isSetInspectID = false;
		private string _supportCode;
		private bool _isSetSupportCode = false;
		private string _officeID;
		private bool _isSetOfficeID = false;
		private string _serviceVersion;
		private bool _isSetServiceVersion = false;
		private string _serviceID;
		private bool _isSetServiceID = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private string _note;
		private bool _isSetNote = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int InspectID
		{
			get { return _inspectiD; }
			set { _inspectiD = value;
			      _isSetInspectID = true; }
		}
		public bool _IsSetInspectID
		{
			get { return _isSetInspectID; }
		}
		public string SupportCode
		{
			get { return _supportCode; }
			set { _supportCode = value;
			      _isSetSupportCode = true; }
		}
		public bool _IsSetSupportCode
		{
			get { return _isSetSupportCode; }
		}
		public string OfficeID
		{
			get { return _officeID; }
			set { _officeID = value;
			      _isSetOfficeID = true; }
		}
		public bool _IsSetOfficeID
		{
			get { return _isSetOfficeID; }
		}
		public string ServiceVersion
		{
			get { return _serviceVersion; }
			set { _serviceVersion = value;
			      _isSetServiceVersion = true; }
		}
		public bool _IsSetServiceVersion
		{
			get { return _isSetServiceVersion; }
		}
		public string ServiceID
		{
			get { return _serviceID; }
			set { _serviceID = value;
			      _isSetServiceID = true; }
		}
		public bool _IsSetServiceID
		{
			get { return _isSetServiceID; }
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
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public string Note
		{
			get { return _note; }
			set { _note = value;
			      _isSetNote = true; }
		}
		public bool _IsSetNote
		{
			get { return _isSetNote; }
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
	public class InspectLinkageServiceData
	{
		private int _inspectiD;
		private string _supportCode;
		private string _officeID;
		private string _serviceVersion;
		private string _serviceID;
		private bool _isActive;
		private string _note;
		private DateTime _modifiedDate;
		public int InspectID
		{
			get{ return _inspectiD; }
			set{ _inspectiD = value; }
		}
		public string SupportCode
		{
			get{ return _supportCode; }
			set{ _supportCode = value; }
		}
		public string OfficeID
		{
			get{ return _officeID; }
			set{ _officeID = value; }
		}
		public string ServiceVersion
		{
			get{ return _serviceVersion; }
			set{ _serviceVersion = value; }
		}
		public string ServiceID
		{
			get{ return _serviceID; }
			set{ _serviceID = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class InspectLinkageServicePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public InspectLinkageServiceRow[] inspectLinkageServiceRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส InspectLinkageServiceItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class InspectLinkageServiceItems : InspectLinkageServiceData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class InspectLinkageServiceItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public InspectLinkageServiceItems[] inspectLinkageServiceItems { get; set; }
	}
}

