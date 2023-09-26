using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class UserStatusRow
	{
		private int _userStatusID;
		private bool _isSetUserStatusID = false;
		private string _description;
		private bool _isSetDescription = false;
		[Required]
		public int UserStatusID
		{
			get { return _userStatusID; }
			set { _userStatusID = value;
			      _isSetUserStatusID = true; }
		}
		public bool _IsSetUserStatusID
		{
			get { return _isSetUserStatusID; }
		}
		public string Description
		{
			get { return _description; }
			set { _description = value;
			      _isSetDescription = true; }
		}
		public bool _IsSetDescription
		{
			get { return _isSetDescription; }
		}
	}
	[Serializable]
	public class UserStatusData
	{
		private int _userStatusID;
		private string _description;
		public int UserStatusID
		{
			get{ return _userStatusID; }
			set{ _userStatusID = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
	}
	[Serializable]
	public class UserStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public UserStatusRow[] userStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส UserStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class UserStatusItems : UserStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class UserStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public UserStatusItems[] userStatusItems { get; set; }
	}
}

