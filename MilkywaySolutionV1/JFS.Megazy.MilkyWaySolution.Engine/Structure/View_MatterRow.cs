using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_MatterRow
	{
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private int _matterID;
		private bool _isSetMatterID = false;
		private string _matterCode;
		private bool _isSetMatterCode = false;
		private string _matterName;
		private bool _isSetMatterName = false;
		private string _matterDescription;
		private bool _isSetMatterDescription = false;
		private int _bracketID;
		private bool _isSetBracketID = false;
		private string _bracketName;
		private bool _isSetBracketName = false;
		private string _bracketDescription;
		private bool _isSetBracketDescription = false;
		[Required]
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isSetJFCaseTypeID = true; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		[Required]
		public int MatterID
		{
			get { return _matterID; }
			set { _matterID = value;
			      _isSetMatterID = true; }
		}
		public bool _IsSetMatterID
		{
			get { return _isSetMatterID; }
		}
		public string MatterCode
		{
			get { return _matterCode; }
			set { _matterCode = value;
			      _isSetMatterCode = true; }
		}
		public bool _IsSetMatterCode
		{
			get { return _isSetMatterCode; }
		}
		public string MatterName
		{
			get { return _matterName; }
			set { _matterName = value;
			      _isSetMatterName = true; }
		}
		public bool _IsSetMatterName
		{
			get { return _isSetMatterName; }
		}
		public string MatterDescription
		{
			get { return _matterDescription; }
			set { _matterDescription = value;
			      _isSetMatterDescription = true; }
		}
		public bool _IsSetMatterDescription
		{
			get { return _isSetMatterDescription; }
		}
		[Required]
		public int BracketID
		{
			get { return _bracketID; }
			set { _bracketID = value;
			      _isSetBracketID = true; }
		}
		public bool _IsSetBracketID
		{
			get { return _isSetBracketID; }
		}
		public string BracketName
		{
			get { return _bracketName; }
			set { _bracketName = value;
			      _isSetBracketName = true; }
		}
		public bool _IsSetBracketName
		{
			get { return _isSetBracketName; }
		}
		public string BracketDescription
		{
			get { return _bracketDescription; }
			set { _bracketDescription = value;
			      _isSetBracketDescription = true; }
		}
		public bool _IsSetBracketDescription
		{
			get { return _isSetBracketDescription; }
		}
	}
	[Serializable]
	public class View_MatterData
	{
		private int _jFCaseTypeID;
		private int _matterID;
		private string _matterCode;
		private string _matterName;
		private string _matterDescription;
		private int _bracketID;
		private string _bracketName;
		private string _bracketDescription;
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public int MatterID
		{
			get{ return _matterID; }
			set{ _matterID = value; }
		}
		public string MatterCode
		{
			get{ return _matterCode; }
			set{ _matterCode = value; }
		}
		public string MatterName
		{
			get{ return _matterName; }
			set{ _matterName = value; }
		}
		public string MatterDescription
		{
			get{ return _matterDescription; }
			set{ _matterDescription = value; }
		}
		public int BracketID
		{
			get{ return _bracketID; }
			set{ _bracketID = value; }
		}
		public string BracketName
		{
			get{ return _bracketName; }
			set{ _bracketName = value; }
		}
		public string BracketDescription
		{
			get{ return _bracketDescription; }
			set{ _bracketDescription = value; }
		}
	}
	[Serializable]
	public class View_MatterPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_MatterRow[] view_MatterRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_MatterItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_MatterItems : View_MatterData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_MatterItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_MatterItems[] view_MatterItems { get; set; }
	}
}

