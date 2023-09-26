using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_QueueAllVersionRow
	{
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private int _queueVersionID;
		private bool _isSetQueueVersionID = false;
		private bool _queueVersionIDNull = true;
		private int _numberOfLawyer;
		private bool _isSetNumberOfLawyer = false;
		private bool _numberOfLawyerNull = true;
		private int _regionID;
		private bool _isSetRegionID = false;
		private bool _regionIDNull = true;
		private int _queueYear;
		private bool _isSetQueueYear = false;
		private bool _queueYearNull = true;
		private string _queueName;
		private bool _isSetQueueName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
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
		public int QueueVersionID
		{
			get
			{
				return _queueVersionID;
			}
			set
			{
				_queueVersionIDNull = false;
				_isSetQueueVersionID = true;
				_queueVersionID = value;
			}
		}
		public bool IsQueueVersionIDNull
		{
			get {
				 return _queueVersionIDNull; }
			set { _queueVersionIDNull = value; }
		}
		public bool _IsSetQueueVersionID
		{
			get { return _isSetQueueVersionID; }
		}
		public int NumberOfLawyer
		{
			get
			{
				return _numberOfLawyer;
			}
			set
			{
				_numberOfLawyerNull = false;
				_isSetNumberOfLawyer = true;
				_numberOfLawyer = value;
			}
		}
		public bool IsNumberOfLawyerNull
		{
			get {
				 return _numberOfLawyerNull; }
			set { _numberOfLawyerNull = value; }
		}
		public bool _IsSetNumberOfLawyer
		{
			get { return _isSetNumberOfLawyer; }
		}
		public int RegionID
		{
			get
			{
				return _regionID;
			}
			set
			{
				_regionIDNull = false;
				_isSetRegionID = true;
				_regionID = value;
			}
		}
		public bool IsRegionIDNull
		{
			get {
				 return _regionIDNull; }
			set { _regionIDNull = value; }
		}
		public bool _IsSetRegionID
		{
			get { return _isSetRegionID; }
		}
		public int QueueYear
		{
			get
			{
				return _queueYear;
			}
			set
			{
				_queueYearNull = false;
				_isSetQueueYear = true;
				_queueYear = value;
			}
		}
		public bool IsQueueYearNull
		{
			get {
				 return _queueYearNull; }
			set { _queueYearNull = value; }
		}
		public bool _IsSetQueueYear
		{
			get { return _isSetQueueYear; }
		}
		public string QueueName
		{
			get { return _queueName; }
			set { _queueName = value;
			      _isSetQueueName = true; }
		}
		public bool _IsSetQueueName
		{
			get { return _isSetQueueName; }
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
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public DateTime CreateDate
		{
			get
			{
				return _createDate;
			}
			set
			{
				_createDateNull = false;
				_isSetCreateDate = true;
				_createDate = value;
			}
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public bool _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
	}
	[Serializable]
	public class View_QueueAllVersionData
	{
		private int _provinceID;
		private string _provinceName;
		private int _queueVersionID;
		private int _numberOfLawyer;
		private int _regionID;
		private int _queueYear;
		private string _queueName;
		private bool _isActive;
		private DateTime _createDate;
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
		public int QueueVersionID
		{
			get{ return _queueVersionID; }
			set{ _queueVersionID = value; }
		}
		public int NumberOfLawyer
		{
			get{ return _numberOfLawyer; }
			set{ _numberOfLawyer = value; }
		}
		public int RegionID
		{
			get{ return _regionID; }
			set{ _regionID = value; }
		}
		public int QueueYear
		{
			get{ return _queueYear; }
			set{ _queueYear = value; }
		}
		public string QueueName
		{
			get{ return _queueName; }
			set{ _queueName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string CreateDateStr { get; set; }
	}
	[Serializable]
	public class View_QueueAllVersionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_QueueAllVersionRow[] view_QueueAllversionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_QueueAllVersionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_QueueAllVersionItems : View_QueueAllVersionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_QueueAllVersionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_QueueAllVersionItems[] view_QueueAllversionItems { get; set; }
	}
}

