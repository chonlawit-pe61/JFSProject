using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class SystemTransactionLogRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _transactionLogID;
		private bool _isSetTransactionLogID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private bool _userIDNull = true;
		private string _userFullName;
		private bool _isSetUserFullName = false;
		private bool _userFullNameNull = true;
		private string _referenceKeyValue;
		private bool _isSetReferenceKeyValue = false;
		private bool _referenceKeyValueNull = true;
		private string _referenceKeyName;
		private bool _isSetReferenceKeyName = false;
		private bool _referenceKeyNameNull = true;
		private string _transactiontypeName;
		private bool _isSetTransactionTypeName = false;
		private bool _transactiontypeNameNull = true;
		private string _comment;
		private bool _isSetComment = false;
		private bool _commentNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int TransactionLogID
		{
			get { return _transactionLogID; }
			set { _transactionLogID = value;
			      _isMapRecord = false;
			      _isSetTransactionLogID = true; }
		}
		public Boolean _IsSetTransactionLogID
		{
			get { return _isSetTransactionLogID; }
		}
		public int UserID
		{
			get
			{
				return _userID;
			}
			set
			{
				_userIDNull = false;
				_isSetUserID = true;
				_userID = value;
				_isMapRecord = false;
			}
		}
		public bool IsUserIDNull
		{
			get {
				 return _userIDNull; }
			set { _userIDNull = value; }
		}
		public Boolean _IsSetUserID
		{
			get { return _isSetUserID; }
		}
		public string UserFullName
		{
			get
			{
				return _userFullName;
			}
			set
			{
				_userFullNameNull = false;
				_isSetUserFullName = true;
				_userFullName = value;
				_isMapRecord = false;
			}
		}
		public bool IsUserFullNameNull
		{
			get {
				 return _userFullNameNull; }
			set { _userFullNameNull = value; }
		}
		public Boolean _IsSetUserFullName
		{
			get { return _isSetUserFullName; }
		}
		public string ReferenceKeyValue
		{
			get
			{
				return _referenceKeyValue;
			}
			set
			{
				_referenceKeyValueNull = false;
				_isSetReferenceKeyValue = true;
				_referenceKeyValue = value;
				_isMapRecord = false;
			}
		}
		public bool IsReferenceKeyValueNull
		{
			get {
				 return _referenceKeyValueNull; }
			set { _referenceKeyValueNull = value; }
		}
		public Boolean _IsSetReferenceKeyValue
		{
			get { return _isSetReferenceKeyValue; }
		}
		public string ReferenceKeyName
		{
			get
			{
				return _referenceKeyName;
			}
			set
			{
				_referenceKeyNameNull = false;
				_isSetReferenceKeyName = true;
				_referenceKeyName = value;
				_isMapRecord = false;
			}
		}
		public bool IsReferenceKeyNameNull
		{
			get {
				 return _referenceKeyNameNull; }
			set { _referenceKeyNameNull = value; }
		}
		public Boolean _IsSetReferenceKeyName
		{
			get { return _isSetReferenceKeyName; }
		}
		public string TransactionTypeName
		{
			get
			{
				return _transactiontypeName;
			}
			set
			{
				_transactiontypeNameNull = false;
				_isSetTransactionTypeName = true;
				_transactiontypeName = value;
				_isMapRecord = false;
			}
		}
		public bool IsTransactionTypeNameNull
		{
			get {
				 return _transactiontypeNameNull; }
			set { _transactiontypeNameNull = value; }
		}
		public Boolean _IsSetTransactionTypeName
		{
			get { return _isSetTransactionTypeName; }
		}
		public string Comment
		{
			get
			{
				return _comment;
			}
			set
			{
				_commentNull = false;
				_isSetComment = true;
				_comment = value;
				_isMapRecord = false;
			}
		}
		public bool IsCommentNull
		{
			get {
				 return _commentNull; }
			set { _commentNull = value; }
		}
		public Boolean _IsSetComment
		{
			get { return _isSetComment; }
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
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class SystemTransactionLogData
	{
		private int _transactionLogID;
		private int _userID;
		private string _userFullName;
		private string _referenceKeyValue;
		private string _referenceKeyName;
		private string _transactiontypeName;
		private string _comment;
		private DateTime _modifiedDate;
		public int TransactionLogID
		{
			get{ return _transactionLogID; }
			set{ _transactionLogID = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public string UserFullName
		{
			get{ return _userFullName; }
			set{ _userFullName = value; }
		}
		public string ReferenceKeyValue
		{
			get{ return _referenceKeyValue; }
			set{ _referenceKeyValue = value; }
		}
		public string ReferenceKeyName
		{
			get{ return _referenceKeyName; }
			set{ _referenceKeyName = value; }
		}
		public string TransactionTypeName
		{
			get{ return _transactiontypeName; }
			set{ _transactiontypeName = value; }
		}
		public string Comment
		{
			get{ return _comment; }
			set{ _comment = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class SystemTransactionLogPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SystemTransactionLogRow[] systemTransactionLogRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SystemTransactionLogItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SystemTransactionLogItems : SystemTransactionLogData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SystemTransactionLogItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SystemTransactionLogItems[] systemTransactionLogItems { get; set; }
	}
}

