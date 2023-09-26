using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class FormAttributeRow
	{
		private int _formAttrID;
		private bool _isSetFormAttrID = false;
		private string _formAttrAlias;
		private bool _isSetFormAttrAlias = false;
		private string _formAttrName;
		private bool _isSetFormAttrName = false;
		private string _defaultVal;
		private bool _isSetDefaultVal = false;
		private bool _isRequire;
		private bool _isSetIsRequire = false;
		private string _dataType;
		private bool _isSetDataType = false;
		private string _unit;
		private bool _isSetUnit = false;
		[Required]
		public int FormAttrID
		{
			get { return _formAttrID; }
			set { _formAttrID = value;
			      _isSetFormAttrID = true; }
		}
		public bool _IsSetFormAttrID
		{
			get { return _isSetFormAttrID; }
		}
		public string FormAttrAlias
		{
			get { return _formAttrAlias; }
			set { _formAttrAlias = value;
			      _isSetFormAttrAlias = true; }
		}
		public bool _IsSetFormAttrAlias
		{
			get { return _isSetFormAttrAlias; }
		}
		[Required]
		public string FormAttrName
		{
			get { return _formAttrName; }
			set { _formAttrName = value;
			      _isSetFormAttrName = true; }
		}
		public bool _IsSetFormAttrName
		{
			get { return _isSetFormAttrName; }
		}
		public string DefaultVal
		{
			get { return _defaultVal; }
			set { _defaultVal = value;
			      _isSetDefaultVal = true; }
		}
		public bool _IsSetDefaultVal
		{
			get { return _isSetDefaultVal; }
		}
		[Required]
		public bool IsRequire
		{
			get { return _isRequire; }
			set { _isRequire = value;
			      _isSetIsRequire = true; }
		}
		public bool _IsSetIsRequire
		{
			get { return _isSetIsRequire; }
		}
		public string DataType
		{
			get { return _dataType; }
			set { _dataType = value;
			      _isSetDataType = true; }
		}
		public bool _IsSetDataType
		{
			get { return _isSetDataType; }
		}
		public string Unit
		{
			get { return _unit; }
			set { _unit = value;
			      _isSetUnit = true; }
		}
		public bool _IsSetUnit
		{
			get { return _isSetUnit; }
		}
	}
	[Serializable]
	public class FormAttributeData
	{
		private int _formAttrID;
		private string _formAttrAlias;
		private string _formAttrName;
		private string _defaultVal;
		private bool _isRequire;
		private string _dataType;
		private string _unit;
		public int FormAttrID
		{
			get{ return _formAttrID; }
			set{ _formAttrID = value; }
		}
		public string FormAttrAlias
		{
			get{ return _formAttrAlias; }
			set{ _formAttrAlias = value; }
		}
		public string FormAttrName
		{
			get{ return _formAttrName; }
			set{ _formAttrName = value; }
		}
		public string DefaultVal
		{
			get{ return _defaultVal; }
			set{ _defaultVal = value; }
		}
		public bool IsRequire
		{
			get{ return _isRequire; }
			set{ _isRequire = value; }
		}
		public string DataType
		{
			get{ return _dataType; }
			set{ _dataType = value; }
		}
		public string Unit
		{
			get{ return _unit; }
			set{ _unit = value; }
		}
	}
	[Serializable]
	public class FormAttributePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public FormAttributeRow[] formAttributeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส FormAttributeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class FormAttributeItems : FormAttributeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class FormAttributeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public FormAttributeItems[] formAttributeItems { get; set; }
	}
}

