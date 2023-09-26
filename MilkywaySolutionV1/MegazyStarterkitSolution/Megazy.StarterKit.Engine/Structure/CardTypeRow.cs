using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Engine.Dal;
namespace Megazy.StarterKit.Engine.Structure
{
	[Serializable]
	public class CardTypeRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _cardTypeID;
		private bool _isSetCardTypeID = false;
		private string _cardTypeName;
		private bool _isSetCardTypeName = false;
		private bool _cardTypeNameNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
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
		public int CardTypeID
		{
			get { return _cardTypeID; }
			set { _cardTypeID = value;
			      _isMapRecord = false;
			      _isSetCardTypeID = true; }
		}
		public Boolean _IsSetCardTypeID
		{
			get { return _isSetCardTypeID; }
		}
		public string CardTypeName
		{
			get
			{
				return _cardTypeName;
			}
			set
			{
				_cardTypeNameNull = false;
				_isSetCardTypeName = true;
				_cardTypeName = value;
				_isMapRecord = false;
			}
		}
		public bool IsCardTypeNameNull
		{
			get {
				 return _cardTypeNameNull; }
			set { _cardTypeNameNull = value; }
		}
		public Boolean _IsSetCardTypeName
		{
			get { return _isSetCardTypeName; }
		}
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public Boolean _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
	}
	[Serializable]
	public class CardTypeData
	{
		private int _cardTypeID;
		private string _cardTypeName;
		private bool _isActive;
		public int CardTypeID
		{
			get{ return _cardTypeID; }
			set{ _cardTypeID = value; }
		}
		public string CardTypeName
		{
			get{ return _cardTypeName; }
			set{ _cardTypeName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class CardTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CardTypeRow[] cardTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CardTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CardTypeItems : CardTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CardTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CardTypeItems[] cardTypeItems { get; set; }
	}
}

