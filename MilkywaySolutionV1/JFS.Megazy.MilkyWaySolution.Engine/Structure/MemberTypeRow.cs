using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MemberTypeRow
	{
		private string _memberTypeID;
		private bool _isSetMemberTypeID = false;
		private string _name;
		private bool _isSetName = false;
		/// <summary>
		/// รหัสประเภทสมาชิก
		/// </summary>
		[Required]
		public string MemberTypeID
		{
			get { return _memberTypeID; }
			set { _memberTypeID = value;
			      _isSetMemberTypeID = true; }
		}
		public bool _IsSetMemberTypeID
		{
			get { return _isSetMemberTypeID; }
		}
		/// <summary>
		/// ชื่อประเภทสมาชิก
		/// </summary>
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
	public class MemberTypeData
	{
		private string _memberTypeID;
		private string _name;
		/// <summary>
		/// รหัสประเภทสมาชิก
		/// </summary>
		public string MemberTypeID
		{
			get{ return _memberTypeID; }
			set{ _memberTypeID = value; }
		}
		/// <summary>
		/// ชื่อประเภทสมาชิก
		/// </summary>
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}
	}
	[Serializable]
	public class MemberTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MemberTypeRow[] memberTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MemberTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MemberTypeItems : MemberTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MemberTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MemberTypeItems[] memberTypeItems { get; set; }
	}
}

