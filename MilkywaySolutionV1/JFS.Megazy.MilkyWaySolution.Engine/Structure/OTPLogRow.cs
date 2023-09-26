using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OTPLogRow
	{
		private string _messageID;
		private bool _isSetMessageID = false;
		private string _phoneNumber;
		private bool _isSetPhoneNumber = false;
		private string _oTP;
		private bool _isSetOTP = false;
		private bool _isVerify;
		private bool _isSetIsVerify = false;
		private DateTime _expiryDate;
		private bool _isSetExpiryDate = false;
		private bool _expiryDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		/// <summary>
		/// รหัสอ้างอิง
		/// </summary>
		[Required]
		public string MessageID
		{
			get { return _messageID; }
			set { _messageID = value;
			      _isSetMessageID = true; }
		}
		public bool _IsSetMessageID
		{
			get { return _isSetMessageID; }
		}
		/// <summary>
		/// เบอร์โทรศัพท์
		/// </summary>
		[Required]
		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value;
			      _isSetPhoneNumber = true; }
		}
		public bool _IsSetPhoneNumber
		{
			get { return _isSetPhoneNumber; }
		}
		/// <summary>
		/// One Time Password
		/// </summary>
		[Required]
		public string OTP
		{
			get { return _oTP; }
			set { _oTP = value;
			      _isSetOTP = true; }
		}
		public bool _IsSetOTP
		{
			get { return _isSetOTP; }
		}
		/// <summary>
		/// สถานะการใช้งาน OTP 1=ใช้งานแล้ว 0=ยังไม่ได้ใช้งาน
		/// </summary>
		[Required]
		public bool IsVerify
		{
			get { return _isVerify; }
			set { _isVerify = value;
			      _isSetIsVerify = true; }
		}
		public bool _IsSetIsVerify
		{
			get { return _isSetIsVerify; }
		}
		[Required]
		public DateTime ExpiryDate
		{
			get { return _expiryDate; }
			set { _expiryDate = value;
			      _expiryDateNull = false;
			      _isSetExpiryDate = true; }
		}
		public bool IsExpiryDateNull
		{
			get {
				 return _expiryDateNull; }
			set { _expiryDateNull = value; }
		}
		public bool _IsSetExpiryDate
		{
			get { return _isSetExpiryDate; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
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
	public class OTPLogData
	{
		private string _messageID;
		private string _phoneNumber;
		private string _oTP;
		private bool _isVerify;
		private DateTime _expiryDate;
		private DateTime _modifiedDate;
		/// <summary>
		/// รหัสอ้างอิง
		/// </summary>
		public string MessageID
		{
			get{ return _messageID; }
			set{ _messageID = value; }
		}
		/// <summary>
		/// เบอร์โทรศัพท์
		/// </summary>
		public string PhoneNumber
		{
			get{ return _phoneNumber; }
			set{ _phoneNumber = value; }
		}
		/// <summary>
		/// One Time Password
		/// </summary>
		public string OTP
		{
			get{ return _oTP; }
			set{ _oTP = value; }
		}
		/// <summary>
		/// สถานะการใช้งาน OTP 1=ใช้งานแล้ว 0=ยังไม่ได้ใช้งาน
		/// </summary>
		public bool IsVerify
		{
			get{ return _isVerify; }
			set{ _isVerify = value; }
		}
		public DateTime ExpiryDate
		{
			get{ return _expiryDate; }
			set{ _expiryDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ExpiryDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class OTPLogPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OTPLogRow[] oTPLogRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OTPLogItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OTPLogItems : OTPLogData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OTPLogItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OTPLogItems[] oTPLogItems { get; set; }
	}
}

