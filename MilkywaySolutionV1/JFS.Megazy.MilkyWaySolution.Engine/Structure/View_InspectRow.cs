using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_InspectRow
	{
		private int _inspectiD;
		private bool _isSetInspectID = false;
		private string _inspectName;
		private bool _isSetInspectName = false;
		private bool _isThaiCitizen;
		private bool _isSetIsThaiCitizen = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private int _inspectValueType;
		private bool _isSetInspectValueType = false;
		private bool _inspectValueTypeNull = true;
		private string _inspectValueTypeName;
		private bool _isSetInspectValueTypeName = false;
		private string _serviceCode;
		private bool _isSetServiceCode = false;
		[Required]
		public int InspectID
		{
			get { return _inspectiD; }
			set { _inspectiD = value;
			      _isSetInspectID = true; }
		}
		public bool _IsSetInspectID
		{
			get { return _isSetInspectID; }
		}
		[Required]
		public string InspectName
		{
			get { return _inspectName; }
			set { _inspectName = value;
			      _isSetInspectName = true; }
		}
		public bool _IsSetInspectName
		{
			get { return _isSetInspectName; }
		}
		[Required]
		public bool IsThaiCitizen
		{
			get { return _isThaiCitizen; }
			set { _isThaiCitizen = value;
			      _isSetIsThaiCitizen = true; }
		}
		public bool _IsSetIsThaiCitizen
		{
			get { return _isSetIsThaiCitizen; }
		}
		[Required]
		public int SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value;
			      _isSetSortOrder = true; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
		}
		[Required]
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value;
			      _isSetIsActive = true; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public int InspectValueType
		{
			get
			{
				return _inspectValueType;
			}
			set
			{
				_inspectValueTypeNull = false;
				_isSetInspectValueType = true;
				_inspectValueType = value;
			}
		}
		public bool IsInspectValueTypeNull
		{
			get {
				 return _inspectValueTypeNull; }
			set { _inspectValueTypeNull = value; }
		}
		public bool _IsSetInspectValueType
		{
			get { return _isSetInspectValueType; }
		}
		[Required]
		public string InspectValueTypeName
		{
			get { return _inspectValueTypeName; }
			set { _inspectValueTypeName = value;
			      _isSetInspectValueTypeName = true; }
		}
		public bool _IsSetInspectValueTypeName
		{
			get { return _isSetInspectValueTypeName; }
		}
		public string ServiceCode
		{
			get { return _serviceCode; }
			set { _serviceCode = value;
			      _isSetServiceCode = true; }
		}
		public bool _IsSetServiceCode
		{
			get { return _isSetServiceCode; }
		}
	}
	[Serializable]
	public class View_InspectData
	{
		private int _inspectiD;
		private string _inspectName;
		private bool _isThaiCitizen;
		private int _sortOrder;
		private bool _isActive;
		private int _inspectValueType;
		private string _inspectValueTypeName;
		private string _serviceCode;
		public int InspectID
		{
			get{ return _inspectiD; }
			set{ _inspectiD = value; }
		}
		public string InspectName
		{
			get{ return _inspectName; }
			set{ _inspectName = value; }
		}
		public bool IsThaiCitizen
		{
			get{ return _isThaiCitizen; }
			set{ _isThaiCitizen = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public int InspectValueType
		{
			get{ return _inspectValueType; }
			set{ _inspectValueType = value; }
		}
		public string InspectValueTypeName
		{
			get{ return _inspectValueTypeName; }
			set{ _inspectValueTypeName = value; }
		}
		public string ServiceCode
		{
			get{ return _serviceCode; }
			set{ _serviceCode = value; }
		}
	}
	[Serializable]
	public class View_InspectPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_InspectRow[] view_InspectRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_InspectItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_InspectItems : View_InspectData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_InspectItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_InspectItems[] view_InspectItems { get; set; }
	}
}

