using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class PersonRoleRow
	{
		private int _personRoleID;
		private bool _isSetPersonRoleID = false;
		private string _personRoleName;
		private bool _isSetPersonRoleName = false;
		private string _note;
		private bool _isSetNote = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int PersonRoleID
		{
			get { return _personRoleID; }
			set { _personRoleID = value;
			      _isSetPersonRoleID = true; }
		}
		public bool _IsSetPersonRoleID
		{
			get { return _isSetPersonRoleID; }
		}
		public string PersonRoleName
		{
			get { return _personRoleName; }
			set { _personRoleName = value;
			      _isSetPersonRoleName = true; }
		}
		public bool _IsSetPersonRoleName
		{
			get { return _isSetPersonRoleName; }
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
	}
	[Serializable]
	public class PersonRoleData
	{
		private int _personRoleID;
		private string _personRoleName;
		private string _note;
		private bool _isActive;
		public int PersonRoleID
		{
			get{ return _personRoleID; }
			set{ _personRoleID = value; }
		}
		public string PersonRoleName
		{
			get{ return _personRoleName; }
			set{ _personRoleName = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class PersonRolePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public PersonRoleRow[] personRoleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส PersonRoleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class PersonRoleItems : PersonRoleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class PersonRoleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public PersonRoleItems[] personRoleItems { get; set; }
	}
}

