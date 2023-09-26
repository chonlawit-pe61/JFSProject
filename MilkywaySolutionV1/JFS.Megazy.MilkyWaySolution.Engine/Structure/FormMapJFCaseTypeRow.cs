using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class FormMapJFCaseTypeRow
	{
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private int _formID;
		private bool _isSetFormID = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		[Required]
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isSetJFCaseTypeID = true; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
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
	}
	[Serializable]
	public class FormMapJFCaseTypeData
	{
		private int _jFCaseTypeID;
		private int _formID;
		private int _sortOrder;
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
	}
	[Serializable]
	public class FormMapJFCaseTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public FormMapJFCaseTypeRow[] formMapJfCaseTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส FormMapJFCaseTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class FormMapJFCaseTypeItems : FormMapJFCaseTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class FormMapJFCaseTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public FormMapJFCaseTypeItems[] formMapJfCaseTypeItems { get; set; }
	}
}

