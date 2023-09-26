using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MemberStatusRow
	{
		private int _memberStatusID;
		private bool _isSetMemberStatusID = false;
		private string _description;
		private bool _isSetDescription = false;
		/// <summary>
		/// รหัสสถานะสมาชิก
		/// </summary>
		[Required]
		public int MemberStatusID
		{
			get { return _memberStatusID; }
			set { _memberStatusID = value;
			      _isSetMemberStatusID = true; }
		}
		public bool _IsSetMemberStatusID
		{
			get { return _isSetMemberStatusID; }
		}
		/// <summary>
		/// สถานะ
		/// </summary>
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
	public class MemberStatusData
	{
		private int _memberStatusID;
		private string _description;
		/// <summary>
		/// รหัสสถานะสมาชิก
		/// </summary>
		public int MemberStatusID
		{
			get{ return _memberStatusID; }
			set{ _memberStatusID = value; }
		}
		/// <summary>
		/// สถานะ
		/// </summary>
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
	}
	[Serializable]
	public class MemberStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MemberStatusRow[] memberStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MemberStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MemberStatusItems : MemberStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MemberStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MemberStatusItems[] memberStatusItems { get; set; }
	}
}

