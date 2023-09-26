using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OfficerMapRoleRow
	{
		private int _officeRoleID;
		private bool _isSetOfficeRoleID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int OfficeRoleID
		{
			get { return _officeRoleID; }
			set { _officeRoleID = value;
			      _isSetOfficeRoleID = true; }
		}
		public bool _IsSetOfficeRoleID
		{
			get { return _isSetOfficeRoleID; }
		}
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
	public class OfficerMapRoleData
	{
		private int _officeRoleID;
		private int _userID;
		private DateTime _modifiedDate;
		public int OfficeRoleID
		{
			get{ return _officeRoleID; }
			set{ _officeRoleID = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class OfficerMapRolePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OfficerMapRoleRow[] officerMapRoleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OfficerMapRoleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OfficerMapRoleItems : OfficerMapRoleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OfficerMapRoleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OfficerMapRoleItems[] officerMapRoleItems { get; set; }
	}
}

