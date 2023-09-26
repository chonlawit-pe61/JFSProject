using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OfficerRoleRow
	{
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private string _officerRoleName;
		private bool _isSetOfficerRoleName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int OfficerRoleID
		{
			get { return _officerRoleID; }
			set { _officerRoleID = value;
			      _isSetOfficerRoleID = true; }
		}
		public bool _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
		}
		public string OfficerRoleName
		{
			get { return _officerRoleName; }
			set { _officerRoleName = value;
			      _isSetOfficerRoleName = true; }
		}
		public bool _IsSetOfficerRoleName
		{
			get { return _isSetOfficerRoleName; }
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
	public class OfficerRoleData
	{
		private int _officerRoleID;
		private string _officerRoleName;
		private DateTime _modifiedDate;
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public string OfficerRoleName
		{
			get{ return _officerRoleName; }
			set{ _officerRoleName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class OfficerRolePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OfficerRoleRow[] officerRoleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OfficerRoleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OfficerRoleItems : OfficerRoleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OfficerRoleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OfficerRoleItems[] officerRoleItems { get; set; }
	}
}

