using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class SystemsLogRow
	{
		private int _systemsLogID;
		private bool _isSetSystemsLogID = false;
		private int _processID;
		private bool _isSetProcessID = false;
		private string _logType;
		private bool _isSetLogType = false;
		private string _pageURL;
		private bool _isSetPageURL = false;
		private string _rawUrl;
		private bool _isSetRawUrl = false;
		private string _error;
		private bool _isSetError = false;
		private DateTime _stampTime;
		private bool _isSetStampTime = false;
		private bool _stampTimeNull = true;
		private bool _isignore;
		private bool _isSetIsIgnore = false;
		private string _comment;
		private bool _isSetComment = false;
		[Required]
		public int SystemsLogID
		{
			get { return _systemsLogID; }
			set { _systemsLogID = value;
			      _isSetSystemsLogID = true; }
		}
		public bool _IsSetSystemsLogID
		{
			get { return _isSetSystemsLogID; }
		}
		[Required]
		public int ProcessID
		{
			get { return _processID; }
			set { _processID = value;
			      _isSetProcessID = true; }
		}
		public bool _IsSetProcessID
		{
			get { return _isSetProcessID; }
		}
		[Required]
		public string LogType
		{
			get { return _logType; }
			set { _logType = value;
			      _isSetLogType = true; }
		}
		public bool _IsSetLogType
		{
			get { return _isSetLogType; }
		}
		public string PageURL
		{
			get { return _pageURL; }
			set { _pageURL = value;
			      _isSetPageURL = true; }
		}
		public bool _IsSetPageURL
		{
			get { return _isSetPageURL; }
		}
		public string RawUrl
		{
			get { return _rawUrl; }
			set { _rawUrl = value;
			      _isSetRawUrl = true; }
		}
		public bool _IsSetRawUrl
		{
			get { return _isSetRawUrl; }
		}
		[Required]
		public string Error
		{
			get { return _error; }
			set { _error = value;
			      _isSetError = true; }
		}
		public bool _IsSetError
		{
			get { return _isSetError; }
		}
		[Required]
		public DateTime StampTime
		{
			get { return _stampTime; }
			set { _stampTime = value;
			      _stampTimeNull = false;
			      _isSetStampTime = true; }
		}
		public bool IsStampTimeNull
		{
			get {
				 return _stampTimeNull; }
			set { _stampTimeNull = value; }
		}
		public bool _IsSetStampTime
		{
			get { return _isSetStampTime; }
		}
		[Required]
		public bool IsIgnore
		{
			get { return _isignore; }
			set { _isignore = value;
			      _isSetIsIgnore = true; }
		}
		public bool _IsSetIsIgnore
		{
			get { return _isSetIsIgnore; }
		}
		public string Comment
		{
			get { return _comment; }
			set { _comment = value;
			      _isSetComment = true; }
		}
		public bool _IsSetComment
		{
			get { return _isSetComment; }
		}
	}
	[Serializable]
	public class SystemsLogData
	{
		private int _systemsLogID;
		private int _processID;
		private string _logType;
		private string _pageURL;
		private string _rawUrl;
		private string _error;
		private DateTime _stampTime;
		private bool _isignore;
		private string _comment;
		public int SystemsLogID
		{
			get{ return _systemsLogID; }
			set{ _systemsLogID = value; }
		}
		public int ProcessID
		{
			get{ return _processID; }
			set{ _processID = value; }
		}
		public string LogType
		{
			get{ return _logType; }
			set{ _logType = value; }
		}
		public string PageURL
		{
			get{ return _pageURL; }
			set{ _pageURL = value; }
		}
		public string RawUrl
		{
			get{ return _rawUrl; }
			set{ _rawUrl = value; }
		}
		public string Error
		{
			get{ return _error; }
			set{ _error = value; }
		}
		public DateTime StampTime
		{
			get{ return _stampTime; }
			set{ _stampTime = value; }
		}
		public string StampTimeStr { get; set; }
		public bool IsIgnore
		{
			get{ return _isignore; }
			set{ _isignore = value; }
		}
		public string Comment
		{
			get{ return _comment; }
			set{ _comment = value; }
		}
	}
	[Serializable]
	public class SystemsLogPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SystemsLogRow[] systemsLogRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SystemsLogItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SystemsLogItems : SystemsLogData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SystemsLogItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SystemsLogItems[] systemsLogItems { get; set; }
	}
}

