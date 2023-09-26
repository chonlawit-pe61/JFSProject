using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class ProvinceTypeRow
	{
		private string _provinceTypeCode;
		private bool _isSetProvinceTypeCode = false;
		private string _provinceTypeName;
		private bool _isSetProvinceTypeName = false;
		private int _provinceGroup;
		private bool _isSetProvinceGroup = false;
		private bool _provinceGroupNull = true;
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
		[Required]
		public string ProvinceTypeName
		{
			get { return _provinceTypeName; }
			set { _provinceTypeName = value;
			      _isSetProvinceTypeName = true; }
		}
		public bool _IsSetProvinceTypeName
		{
			get { return _isSetProvinceTypeName; }
		}
		public int ProvinceGroup
		{
			get
			{
				return _provinceGroup;
			}
			set
			{
				_provinceGroupNull = false;
				_isSetProvinceGroup = true;
				_provinceGroup = value;
			}
		}
		public bool IsProvinceGroupNull
		{
			get {
				 return _provinceGroupNull; }
			set { _provinceGroupNull = value; }
		}
		public bool _IsSetProvinceGroup
		{
			get { return _isSetProvinceGroup; }
		}
	}
	[Serializable]
	public class ProvinceTypeData
	{
		private string _provinceTypeCode;
		private string _provinceTypeName;
		private int _provinceGroup;
		public string ProvinceTypeCode
		{
			get{ return _provinceTypeCode; }
			set{ _provinceTypeCode = value; }
		}
		public string ProvinceTypeName
		{
			get{ return _provinceTypeName; }
			set{ _provinceTypeName = value; }
		}
		public int ProvinceGroup
		{
			get{ return _provinceGroup; }
			set{ _provinceGroup = value; }
		}
	}
	[Serializable]
	public class ProvinceTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProvinceTypeRow[] provinceTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProvinceTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProvinceTypeItems : ProvinceTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProvinceTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProvinceTypeItems[] provinceTypeItems { get; set; }
	}
}

