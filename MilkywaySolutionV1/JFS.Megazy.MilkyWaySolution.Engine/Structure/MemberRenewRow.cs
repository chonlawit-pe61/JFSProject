using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MemberRenewRow
	{
		private string _token;
		private bool _isSetToken = false;
		private int _memberID;
		private bool _isSetMemberID = false;
		private string _verificationType;
		private bool _isSetVerificationType = false;
		private DateTime _expireDate;
		private bool _isSetExpireDate = false;
		private bool _expireDateNull = true;
		/// <summary>
		/// Token สำหรับ email /Code สำหรับ Mobile
		/// </summary>
		[Required]
		public string Token
		{
			get { return _token; }
			set { _token = value;
			      _isSetToken = true; }
		}
		public bool _IsSetToken
		{
			get { return _isSetToken; }
		}
		/// <summary>
		/// รหัสสมาชิกผู้ใช้งาน
		/// </summary>
		[Required]
		public int MemberID
		{
			get { return _memberID; }
			set { _memberID = value;
			      _isSetMemberID = true; }
		}
		public bool _IsSetMemberID
		{
			get { return _isSetMemberID; }
		}
		/// <summary>
		/// ประเภทการตรวจสอบ [email/mobile]
		/// </summary>
		[Required]
		public string VerificationType
		{
			get { return _verificationType; }
			set { _verificationType = value;
			      _isSetVerificationType = true; }
		}
		public bool _IsSetVerificationType
		{
			get { return _isSetVerificationType; }
		}
		/// <summary>
		/// วันที่หมดอายุ
		/// </summary>
		[Required]
		public DateTime ExpireDate
		{
			get { return _expireDate; }
			set { _expireDate = value;
			      _expireDateNull = false;
			      _isSetExpireDate = true; }
		}
		public bool IsExpireDateNull
		{
			get {
				 return _expireDateNull; }
			set { _expireDateNull = value; }
		}
		public bool _IsSetExpireDate
		{
			get { return _isSetExpireDate; }
		}
	}
	[Serializable]
	public class MemberRenewData
	{
		private string _token;
		private int _memberID;
		private string _verificationType;
		private DateTime _expireDate;
		/// <summary>
		/// Token สำหรับ email /Code สำหรับ Mobile
		/// </summary>
		public string Token
		{
			get{ return _token; }
			set{ _token = value; }
		}
		/// <summary>
		/// รหัสสมาชิกผู้ใช้งาน
		/// </summary>
		public int MemberID
		{
			get{ return _memberID; }
			set{ _memberID = value; }
		}
		/// <summary>
		/// ประเภทการตรวจสอบ [email/mobile]
		/// </summary>
		public string VerificationType
		{
			get{ return _verificationType; }
			set{ _verificationType = value; }
		}
		/// <summary>
		/// วันที่หมดอายุ
		/// </summary>
		public DateTime ExpireDate
		{
			get{ return _expireDate; }
			set{ _expireDate = value; }
		}
		/// <summary>
		/// วันที่หมดอายุ เก็บวันที่แบบ String
		/// </summary>
		public string ExpireDateStr { get; set; }
	}
	[Serializable]
	public class MemberRenewPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MemberRenewRow[] memberRenewRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MemberRenewItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MemberRenewItems : MemberRenewData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MemberRenewItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MemberRenewItems[] memberRenewItems { get; set; }
	}
}

