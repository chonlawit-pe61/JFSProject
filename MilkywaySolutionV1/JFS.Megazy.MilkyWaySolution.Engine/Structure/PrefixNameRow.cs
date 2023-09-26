using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class PrefixNameRow
	{
		private int _titleID;
		private bool _isSetTitleID = false;
		private string _title;
		private bool _isSetTitle = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int TitleID
		{
			get { return _titleID; }
			set { _titleID = value;
			      _isSetTitleID = true; }
		}
		public bool _IsSetTitleID
		{
			get { return _isSetTitleID; }
		}
		public string Title
		{
			get { return _title; }
			set { _title = value;
			      _isSetTitle = true; }
		}
		public bool _IsSetTitle
		{
			get { return _isSetTitle; }
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
	public class PrefixNameData
	{
		private int _titleID;
		private string _title;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int TitleID
		{
			get{ return _titleID; }
			set{ _titleID = value; }
		}
		public string Title
		{
			get{ return _title; }
			set{ _title = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class PrefixNamePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public PrefixNameRow[] prefixNameRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส PrefixNameItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class PrefixNameItems : PrefixNameData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class PrefixNameItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public PrefixNameItems[] prefixNameItems { get; set; }
	}
}

