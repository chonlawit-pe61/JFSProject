using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_UserMapModuleRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private int _moduleID;
		private bool _isSetModuleID = false;
		private bool _moduleIDNull = true;
		[Required]
		public int UserID
		{
			get { return _userID; }
			set { _userID = value;
			      _isSetUserID = true; }
		}
		public bool _IsSetUserID
		{
			get { return _isSetUserID; }
		}
		public int ModuleID
		{
			get
			{
				return _moduleID;
			}
			set
			{
				_moduleIDNull = false;
				_isSetModuleID = true;
				_moduleID = value;
			}
		}
		public bool IsModuleIDNull
		{
			get {
				 return _moduleIDNull; }
			set { _moduleIDNull = value; }
		}
		public bool _IsSetModuleID
		{
			get { return _isSetModuleID; }
		}
	}
	[Serializable]
	public class View_UserMapModuleData
	{
		private int _userID;
		private int _moduleID;
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public int ModuleID
		{
			get{ return _moduleID; }
			set{ _moduleID = value; }
		}
	}
	[Serializable]
	public class View_UserMapModulePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_UserMapModuleRow[] view_UserMapModuleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_UserMapModuleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_UserMapModuleItems : View_UserMapModuleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_UserMapModuleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_UserMapModuleItems[] view_UserMapModuleItems { get; set; }
	}
}

