using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class UserTypeRow
	{
		private string _userTypeID;
		private bool _isSetUserTypeID = false;
		private string _name;
		private bool _isSetName = false;
		[Required]
		public string UserTypeID
		{
			get { return _userTypeID; }
			set { _userTypeID = value;
			      _isSetUserTypeID = true; }
		}
		public bool _IsSetUserTypeID
		{
			get { return _isSetUserTypeID; }
		}
		[Required]
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
	public class UserTypeData
	{
		private string _userTypeID;
		private string _name;
		public string UserTypeID
		{
			get{ return _userTypeID; }
			set{ _userTypeID = value; }
		}
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}
	}
	[Serializable]
	public class UserTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public UserTypeRow[] userTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส UserTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class UserTypeItems : UserTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class UserTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public UserTypeItems[] userTypeItems { get; set; }
	}
}

