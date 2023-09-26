using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ContractPersonRoleRow
	{
		private int _roleID;
		private bool _isSetRoleID = false;
		private string _name;
		private bool _isSetName = false;
		[Required]
		public int RoleID
		{
			get { return _roleID; }
			set { _roleID = value;
			      _isSetRoleID = true; }
		}
		public bool _IsSetRoleID
		{
			get { return _isSetRoleID; }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value;
			      _isSetName = true; }
		}
		public bool _IsSetName
		{
			get { return _isSetName; }
		}
	}
	[Serializable]
	public class ContractPersonRoleData
	{
		private int _roleID;
		private string _name;
		public int RoleID
		{
			get{ return _roleID; }
			set{ _roleID = value; }
		}
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}
	}
	[Serializable]
	public class ContractPersonRolePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ContractPersonRoleRow[] contractPersonRoleRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ContractPersonRoleItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ContractPersonRoleItems : ContractPersonRoleData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ContractPersonRoleItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ContractPersonRoleItems[] contractPersonRoleItems { get; set; }
	}
}

