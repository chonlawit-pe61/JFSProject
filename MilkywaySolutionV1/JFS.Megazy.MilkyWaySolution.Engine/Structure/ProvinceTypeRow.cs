using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProvinceTypeRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private string _provinceTypeCode;
		private bool _isSetProvinceTypeCode = false;
		private string _provinceTypeName;
		private bool _isSetProvinceTypeName = false;
		private int _provinceGroup;
		private bool _isSetProvinceGroup = false;
		private bool _provinceGroupNull = true;
		private bool _isShow;
		private bool _isSetIsShow = false;
		private bool _isShowNull = true;
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
		public string ProvinceTypeCode
		{
			get { return _provinceTypeCode; }
			set { _provinceTypeCode = value;
			      _isMapRecord = false;
			      _isSetProvinceTypeCode = true; }
		}
		public Boolean _IsSetProvinceTypeCode
		{
			get { return _isSetProvinceTypeCode; }
		}
		[Required]
		public string ProvinceTypeName
		{
			get { return _provinceTypeName; }
			set { _provinceTypeName = value;
			      _isMapRecord = false;
			      _isSetProvinceTypeName = true; }
		}
		public Boolean _IsSetProvinceTypeName
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
				_isMapRecord = false;
			}
		}
		public bool IsProvinceGroupNull
		{
			get {
				 return _provinceGroupNull; }
			set { _provinceGroupNull = value; }
		}
		public Boolean _IsSetProvinceGroup
		{
			get { return _isSetProvinceGroup; }
		}
		public bool IsShow
		{
			get
			{
				return _isShow;
			}
			set
			{
				_isShowNull = false;
				_isSetIsShow = true;
				_isShow = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsShowNull
		{
			get {
				 return _isShowNull; }
			set { _isShowNull = value; }
		}
		public Boolean _IsSetIsShow
		{
			get { return _isSetIsShow; }
		}
	}
	[Serializable]
	public class ProvinceTypeData
	{
		private string _provinceTypeCode;
		private string _provinceTypeName;
		private int _provinceGroup;
		private bool _isShow;
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
		public bool IsShow
		{
			get{ return _isShow; }
			set{ _isShow = value; }
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

