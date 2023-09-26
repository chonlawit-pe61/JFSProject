using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_AddressRow
	{
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private int _districtId;
		private bool _isSetDistrictID = false;
		private string _districtName;
		private bool _isSetDistrictName = false;
		private int _subdistrictID;
		private bool _isSetSubdistrictID = false;
		private string _subdistrictName;
		private bool _isSetSubdistrictName = false;
		private string _postCode;
		private bool _isSetPostCode = false;
		private int _provinceCode;
		private bool _isSetProvinceCode = false;
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
		public string ProvinceName
		{
			get { return _provinceName; }
			set { _provinceName = value;
			      _isSetProvinceName = true; }
		}
		public bool _IsSetProvinceName
		{
			get { return _isSetProvinceName; }
		}
		[Required]
		public int DistrictID
		{
			get { return _districtId; }
			set { _districtId = value;
			      _isSetDistrictID = true; }
		}
		public bool _IsSetDistrictID
		{
			get { return _isSetDistrictID; }
		}
		public string DistrictName
		{
			get { return _districtName; }
			set { _districtName = value;
			      _isSetDistrictName = true; }
		}
		public bool _IsSetDistrictName
		{
			get { return _isSetDistrictName; }
		}
		[Required]
		public int SubdistrictID
		{
			get { return _subdistrictID; }
			set { _subdistrictID = value;
			      _isSetSubdistrictID = true; }
		}
		public bool _IsSetSubdistrictID
		{
			get { return _isSetSubdistrictID; }
		}
		public string SubdistrictName
		{
			get { return _subdistrictName; }
			set { _subdistrictName = value;
			      _isSetSubdistrictName = true; }
		}
		public bool _IsSetSubdistrictName
		{
			get { return _isSetSubdistrictName; }
		}
		public string PostCode
		{
			get { return _postCode; }
			set { _postCode = value;
			      _isSetPostCode = true; }
		}
		public bool _IsSetPostCode
		{
			get { return _isSetPostCode; }
		}
		[Required]
		public int ProvinceCode
		{
			get { return _provinceCode; }
			set { _provinceCode = value;
			      _isSetProvinceCode = true; }
		}
		public bool _IsSetProvinceCode
		{
			get { return _isSetProvinceCode; }
		}
	}
	[Serializable]
	public class View_AddressData
	{
		private int _provinceID;
		private string _provinceName;
		private int _districtId;
		private string _districtName;
		private int _subdistrictID;
		private string _subdistrictName;
		private string _postCode;
		private int _provinceCode;
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string ProvinceName
		{
			get{ return _provinceName; }
			set{ _provinceName = value; }
		}
		public int DistrictID
		{
			get{ return _districtId; }
			set{ _districtId = value; }
		}
		public string DistrictName
		{
			get{ return _districtName; }
			set{ _districtName = value; }
		}
		public int SubdistrictID
		{
			get{ return _subdistrictID; }
			set{ _subdistrictID = value; }
		}
		public string SubdistrictName
		{
			get{ return _subdistrictName; }
			set{ _subdistrictName = value; }
		}
		public string PostCode
		{
			get{ return _postCode; }
			set{ _postCode = value; }
		}
		public int ProvinceCode
		{
			get{ return _provinceCode; }
			set{ _provinceCode = value; }
		}
	}
	[Serializable]
	public class View_AddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_AddressRow[] view_AddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_AddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_AddressItems : View_AddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_AddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_AddressItems[] view_AddressItems { get; set; }
	}
}

