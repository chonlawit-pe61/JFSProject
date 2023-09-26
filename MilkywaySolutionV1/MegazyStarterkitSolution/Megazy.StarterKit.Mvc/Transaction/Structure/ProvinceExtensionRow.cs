using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class ProvinceExtensionRow
	{
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private string _provinceTypeCode;
		private bool _isSetProvinceTypeCode = false;
		private string _groupCode;
		private bool _isSetGroupCode = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ProvinceID
		{
			get { return _provinceID; }
			set { _provinceID = value;
			      _isSetProvinceID = true; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		[Required]
		public string ProvinceTypeCode
		{
			get { return _provinceTypeCode; }
			set { _provinceTypeCode = value;
			      _isSetProvinceTypeCode = true; }
		}
		public bool _IsSetProvinceTypeCode
		{
			get { return _isSetProvinceTypeCode; }
		}
		public string GroupCode
		{
			get { return _groupCode; }
			set { _groupCode = value;
			      _isSetGroupCode = true; }
		}
		public bool _IsSetGroupCode
		{
			get { return _isSetGroupCode; }
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
	public class ProvinceExtensionData
	{
		private int _provinceID;
		private string _provinceTypeCode;
		private string _groupCode;
		private DateTime _modifiedDate;
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string ProvinceTypeCode
		{
			get{ return _provinceTypeCode; }
			set{ _provinceTypeCode = value; }
		}
		public string GroupCode
		{
			get{ return _groupCode; }
			set{ _groupCode = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ProvinceExtensionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProvinceExtensionRow[] provinceExtensionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProvinceExtensionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProvinceExtensionItems : ProvinceExtensionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProvinceExtensionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProvinceExtensionItems[] provinceExtensionItems { get; set; }
	}
}

