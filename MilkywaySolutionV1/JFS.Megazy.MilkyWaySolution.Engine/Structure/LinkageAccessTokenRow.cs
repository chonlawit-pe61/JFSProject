using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LinkageAccessTokenRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private string _pID;
		private bool _isSetPID = false;
		private string _cID;
		private bool _isSetCID = false;
		private string _xKey;
		private bool _isSetXKey = false;
		private string _matchKey;
		private bool _isSetMatchKey = false;
		private string _envelopGMXs;
		private bool _isSetEnvelopGMXs = false;
		private string _tokenKey;
		private bool _isSetTokenKey = false;
		private DateTime _dateCreated;
		private bool _isSetDateCreated = false;
		private bool _dateCreatedNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int UserID
		{
			get { return _userID; }
			set { _userID = value;
			      _isSetUserID = true; }
		}
		public bool _IsSetUserID
		{
			get { return _isSetUserID; }
		}
		[Required]
		public string PID
		{
			get { return _pID; }
			set { _pID = value;
			      _isSetPID = true; }
		}
		public bool _IsSetPID
		{
			get { return _isSetPID; }
		}
		public string CID
		{
			get { return _cID; }
			set { _cID = value;
			      _isSetCID = true; }
		}
		public bool _IsSetCID
		{
			get { return _isSetCID; }
		}
		public string XKey
		{
			get { return _xKey; }
			set { _xKey = value;
			      _isSetXKey = true; }
		}
		public bool _IsSetXKey
		{
			get { return _isSetXKey; }
		}
		public string MatchKey
		{
			get { return _matchKey; }
			set { _matchKey = value;
			      _isSetMatchKey = true; }
		}
		public bool _IsSetMatchKey
		{
			get { return _isSetMatchKey; }
		}
		public string EnvelopGMXs
		{
			get { return _envelopGMXs; }
			set { _envelopGMXs = value;
			      _isSetEnvelopGMXs = true; }
		}
		public bool _IsSetEnvelopGMXs
		{
			get { return _isSetEnvelopGMXs; }
		}
		public string TokenKey
		{
			get { return _tokenKey; }
			set { _tokenKey = value;
			      _isSetTokenKey = true; }
		}
		public bool _IsSetTokenKey
		{
			get { return _isSetTokenKey; }
		}
		public DateTime DateCreated
		{
			get
			{
				return _dateCreated;
			}
			set
			{
				_dateCreatedNull = false;
				_isSetDateCreated = true;
				_dateCreated = value;
			}
		}
		public bool IsDateCreatedNull
		{
			get {
				 return _dateCreatedNull; }
			set { _dateCreatedNull = value; }
		}
		public bool _IsSetDateCreated
		{
			get { return _isSetDateCreated; }
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
	public class LinkageAccessTokenData
	{
		private int _userID;
		private string _pID;
		private string _cID;
		private string _xKey;
		private string _matchKey;
		private string _envelopGMXs;
		private string _tokenKey;
		private DateTime _dateCreated;
		private DateTime _modifiedDate;
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public string PID
		{
			get{ return _pID; }
			set{ _pID = value; }
		}
		public string CID
		{
			get{ return _cID; }
			set{ _cID = value; }
		}
		public string XKey
		{
			get{ return _xKey; }
			set{ _xKey = value; }
		}
		public string MatchKey
		{
			get{ return _matchKey; }
			set{ _matchKey = value; }
		}
		public string EnvelopGMXs
		{
			get{ return _envelopGMXs; }
			set{ _envelopGMXs = value; }
		}
		public string TokenKey
		{
			get{ return _tokenKey; }
			set{ _tokenKey = value; }
		}
		public DateTime DateCreated
		{
			get{ return _dateCreated; }
			set{ _dateCreated = value; }
		}
		public string DateCreatedStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class LinkageAccessTokenPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LinkageAccessTokenRow[] linkageAccessTokenRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LinkageAccessTokenItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LinkageAccessTokenItems : LinkageAccessTokenData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LinkageAccessTokenItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LinkageAccessTokenItems[] linkageAccessTokenItems { get; set; }
	}
}

