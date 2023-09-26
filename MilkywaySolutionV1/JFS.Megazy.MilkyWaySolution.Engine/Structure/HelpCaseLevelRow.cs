using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class HelpCaseLevelRow
	{
		private int _helpCaseLevelID;
		private bool _isSetHelpCaseLevelID = false;
		private string _helpCaseLevelName;
		private bool _isSetHelpCaseLevelName = false;
		private bool _isOtherHelpCaseLevel;
		private bool _isSetIsOtherHelpCaseLevel = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int HelpCaseLevelID
		{
			get { return _helpCaseLevelID; }
			set { _helpCaseLevelID = value;
			      _isSetHelpCaseLevelID = true; }
		}
		public bool _IsSetHelpCaseLevelID
		{
			get { return _isSetHelpCaseLevelID; }
		}
		[Required]
		public string HelpCaseLevelName
		{
			get { return _helpCaseLevelName; }
			set { _helpCaseLevelName = value;
			      _isSetHelpCaseLevelName = true; }
		}
		public bool _IsSetHelpCaseLevelName
		{
			get { return _isSetHelpCaseLevelName; }
		}
		[Required]
		public bool IsOtherHelpCaseLevel
		{
			get { return _isOtherHelpCaseLevel; }
			set { _isOtherHelpCaseLevel = value;
			      _isSetIsOtherHelpCaseLevel = true; }
		}
		public bool _IsSetIsOtherHelpCaseLevel
		{
			get { return _isSetIsOtherHelpCaseLevel; }
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
	public class HelpCaseLevelData
	{
		private int _helpCaseLevelID;
		private string _helpCaseLevelName;
		private bool _isOtherHelpCaseLevel;
		private DateTime _modifiedDate;
		public int HelpCaseLevelID
		{
			get{ return _helpCaseLevelID; }
			set{ _helpCaseLevelID = value; }
		}
		public string HelpCaseLevelName
		{
			get{ return _helpCaseLevelName; }
			set{ _helpCaseLevelName = value; }
		}
		public bool IsOtherHelpCaseLevel
		{
			get{ return _isOtherHelpCaseLevel; }
			set{ _isOtherHelpCaseLevel = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class HelpCaseLevelPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public HelpCaseLevelRow[] helpCaseLevelRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส HelpCaseLevelItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class HelpCaseLevelItems : HelpCaseLevelData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class HelpCaseLevelItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public HelpCaseLevelItems[] helpCaseLevelItems { get; set; }
	}
}

