using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class DXCAccessTokenRow
	{
		private int _userID;
		private bool _isSetUserID = false;
		private string _codechallenge;
		private bool _isSetCodeChallenge = false;
		private string _codeVerifier;
		private bool _isSetCodeVerifier = false;
		private string _authorizationCode;
		private bool _isSetAuthorizationCode = false;
		private string _accessToken;
		private bool _isSetAccessToken = false;
		private int _expiresIn;
		private bool _isSetExpiresIn = false;
		private bool _expiresInNull = true;
		private int _refreshExpiresIn;
		private bool _isSetRefreshExpiresIn = false;
		private bool _refreshExpiresInNull = true;
		private string _refreshToken;
		private bool _isSetRefreshToken = false;
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
		public string CodeChallenge
		{
			get { return _codechallenge; }
			set { _codechallenge = value;
			      _isSetCodeChallenge = true; }
		}
		public bool _IsSetCodeChallenge
		{
			get { return _isSetCodeChallenge; }
		}
		public string CodeVerifier
		{
			get { return _codeVerifier; }
			set { _codeVerifier = value;
			      _isSetCodeVerifier = true; }
		}
		public bool _IsSetCodeVerifier
		{
			get { return _isSetCodeVerifier; }
		}
		public string AuthorizationCode
		{
			get { return _authorizationCode; }
			set { _authorizationCode = value;
			      _isSetAuthorizationCode = true; }
		}
		public bool _IsSetAuthorizationCode
		{
			get { return _isSetAuthorizationCode; }
		}
		public string AccessToken
		{
			get { return _accessToken; }
			set { _accessToken = value;
			      _isSetAccessToken = true; }
		}
		public bool _IsSetAccessToken
		{
			get { return _isSetAccessToken; }
		}
		public int ExpiresIn
		{
			get
			{
				return _expiresIn;
			}
			set
			{
				_expiresInNull = false;
				_isSetExpiresIn = true;
				_expiresIn = value;
			}
		}
		public bool IsExpiresInNull
		{
			get {
				 return _expiresInNull; }
			set { _expiresInNull = value; }
		}
		public bool _IsSetExpiresIn
		{
			get { return _isSetExpiresIn; }
		}
		public int RefreshExpiresIn
		{
			get
			{
				return _refreshExpiresIn;
			}
			set
			{
				_refreshExpiresInNull = false;
				_isSetRefreshExpiresIn = true;
				_refreshExpiresIn = value;
			}
		}
		public bool IsRefreshExpiresInNull
		{
			get {
				 return _refreshExpiresInNull; }
			set { _refreshExpiresInNull = value; }
		}
		public bool _IsSetRefreshExpiresIn
		{
			get { return _isSetRefreshExpiresIn; }
		}
		public string RefreshToken
		{
			get { return _refreshToken; }
			set { _refreshToken = value;
			      _isSetRefreshToken = true; }
		}
		public bool _IsSetRefreshToken
		{
			get { return _isSetRefreshToken; }
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
	public class DXCAccessTokenData
	{
		private int _userID;
		private string _codechallenge;
		private string _codeVerifier;
		private string _authorizationCode;
		private string _accessToken;
		private int _expiresIn;
		private int _refreshExpiresIn;
		private string _refreshToken;
		private DateTime _modifiedDate;
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public string CodeChallenge
		{
			get{ return _codechallenge; }
			set{ _codechallenge = value; }
		}
		public string CodeVerifier
		{
			get{ return _codeVerifier; }
			set{ _codeVerifier = value; }
		}
		public string AuthorizationCode
		{
			get{ return _authorizationCode; }
			set{ _authorizationCode = value; }
		}
		public string AccessToken
		{
			get{ return _accessToken; }
			set{ _accessToken = value; }
		}
		public int ExpiresIn
		{
			get{ return _expiresIn; }
			set{ _expiresIn = value; }
		}
		public int RefreshExpiresIn
		{
			get{ return _refreshExpiresIn; }
			set{ _refreshExpiresIn = value; }
		}
		public string RefreshToken
		{
			get{ return _refreshToken; }
			set{ _refreshToken = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class DXCAccessTokenPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public DXCAccessTokenRow[] dXCAccessTokenRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส DXCAccessTokenItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class DXCAccessTokenItems : DXCAccessTokenData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class DXCAccessTokenItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public DXCAccessTokenItems[] dXCAccessTokenItems { get; set; }
	}
}

