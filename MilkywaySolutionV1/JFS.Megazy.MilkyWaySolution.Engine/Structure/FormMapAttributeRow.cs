using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class FormMapAttributeRow
	{
		private int _formMapAttrID;
		private bool _isSetFormMapAttrID = false;
		private int _formID;
		private bool _isSetFormID = false;
		private int _formAttrID;
		private bool _isSetFormAttrID = false;
		private int _sortID;
		private bool _isSetSortID = false;
		private bool _sortIDNull = true;
		private int _columns;
		private bool _isSetColumns = false;
		private bool _columnsNull = true;
		[Required]
		public int FormMapAttrID
		{
			get { return _formMapAttrID; }
			set { _formMapAttrID = value;
			      _isSetFormMapAttrID = true; }
		}
		public bool _IsSetFormMapAttrID
		{
			get { return _isSetFormMapAttrID; }
		}
		[Required]
		public int FormID
		{
			get { return _formID; }
			set { _formID = value;
			      _isSetFormID = true; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
		}
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
		public int SortID
		{
			get
			{
				return _sortID;
			}
			set
			{
				_sortIDNull = false;
				_isSetSortID = true;
				_sortID = value;
			}
		}
		public bool IsSortIDNull
		{
			get {
				 return _sortIDNull; }
			set { _sortIDNull = value; }
		}
		public bool _IsSetSortID
		{
			get { return _isSetSortID; }
		}
		public int Columns
		{
			get
			{
				return _columns;
			}
			set
			{
				_columnsNull = false;
				_isSetColumns = true;
				_columns = value;
			}
		}
		public bool IsColumnsNull
		{
			get {
				 return _columnsNull; }
			set { _columnsNull = value; }
		}
		public bool _IsSetColumns
		{
			get { return _isSetColumns; }
		}
	}
	[Serializable]
	public class FormMapAttributeData
	{
		private int _formMapAttrID;
		private int _formID;
		private int _formAttrID;
		private int _sortID;
		private int _columns;
		public int FormMapAttrID
		{
			get{ return _formMapAttrID; }
			set{ _formMapAttrID = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public int FormAttrID
		{
			get{ return _formAttrID; }
			set{ _formAttrID = value; }
		}
		public int SortID
		{
			get{ return _sortID; }
			set{ _sortID = value; }
		}
		public int Columns
		{
			get{ return _columns; }
			set{ _columns = value; }
		}
	}
	[Serializable]
	public class FormMapAttributePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public FormMapAttributeRow[] formMapAttributeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส FormMapAttributeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class FormMapAttributeItems : FormMapAttributeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class FormMapAttributeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public FormMapAttributeItems[] formMapAttributeItems { get; set; }
	}
}

