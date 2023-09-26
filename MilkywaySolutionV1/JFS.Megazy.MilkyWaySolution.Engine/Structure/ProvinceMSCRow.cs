using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProvinceMSCRow
	{
		private int _provId;
		private bool _isSetprovId = false;
		private string _provName;
		private bool _isSetprovName = false;
		private int _regnId;
		private bool _isSetregnId = false;
		private bool _flag;
		private bool _isSetflag = false;
		private int _belongJFSProvinceID;
		private bool _isSetBelongJFSProvinceID = false;
		private bool _belongJFSProvinceIDNull = true;
		[Required]
		public int provId
		{
			get { return _provId; }
			set { _provId = value;
			      _isSetprovId = true; }
		}
		public bool _IsSetprovId
		{
			get { return _isSetprovId; }
		}
		[Required]
		public string provName
		{
			get { return _provName; }
			set { _provName = value;
			      _isSetprovName = true; }
		}
		public bool _IsSetprovName
		{
			get { return _isSetprovName; }
		}
		[Required]
		public int regnId
		{
			get { return _regnId; }
			set { _regnId = value;
			      _isSetregnId = true; }
		}
		public bool _IsSetregnId
		{
			get { return _isSetregnId; }
		}
		[Required]
		public bool flag
		{
			get { return _flag; }
			set { _flag = value;
			      _isSetflag = true; }
		}
		public bool _IsSetflag
		{
			get { return _isSetflag; }
		}
		/// <summary>
		/// รหัสจังหวัดอ้างอิงตาราง Province: ProvinceID
		/// </summary>
		public int BelongJFSProvinceID
		{
			get
			{
				return _belongJFSProvinceID;
			}
			set
			{
				_belongJFSProvinceIDNull = false;
				_isSetBelongJFSProvinceID = true;
				_belongJFSProvinceID = value;
			}
		}
		public bool IsBelongJFSProvinceIDNull
		{
			get {
				 return _belongJFSProvinceIDNull; }
			set { _belongJFSProvinceIDNull = value; }
		}
		public bool _IsSetBelongJFSProvinceID
		{
			get { return _isSetBelongJFSProvinceID; }
		}
	}
	[Serializable]
	public class ProvinceMSCData
	{
		private int _provId;
		private string _provName;
		private int _regnId;
		private bool _flag;
		private int _belongJFSProvinceID;
		public int provId
		{
			get{ return _provId; }
			set{ _provId = value; }
		}
		public string provName
		{
			get{ return _provName; }
			set{ _provName = value; }
		}
		public int regnId
		{
			get{ return _regnId; }
			set{ _regnId = value; }
		}
		public bool flag
		{
			get{ return _flag; }
			set{ _flag = value; }
		}
		/// <summary>
		/// รหัสจังหวัดอ้างอิงตาราง Province: ProvinceID
		/// </summary>
		public int BelongJFSProvinceID
		{
			get{ return _belongJFSProvinceID; }
			set{ _belongJFSProvinceID = value; }
		}
	}
	[Serializable]
	public class ProvinceMSCPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProvinceMSCRow[] provinceMSCRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProvinceMSCItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProvinceMSCItems : ProvinceMSCData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProvinceMSCItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProvinceMSCItems[] provinceMSCItems { get; set; }
	}
}

