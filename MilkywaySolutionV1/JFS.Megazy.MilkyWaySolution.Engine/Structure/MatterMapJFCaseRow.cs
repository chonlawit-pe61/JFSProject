using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MatterMapJFCaseRow
	{
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private int _matterID;
		private bool _isSetMatterID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public int MatterID
		{
			get { return _matterID; }
			set { _matterID = value;
			      _isSetMatterID = true; }
		}
		public bool _IsSetMatterID
		{
			get { return _isSetMatterID; }
		}
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				_modifiedDateNull = false;
				_isSetModifiedDate = true;
				_modifiedDate = value;
			}
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
	public class MatterMapJFCaseData
	{
		private int _jFCaseTypeID;
		private int _matterID;
		private DateTime _modifiedDate;
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public int MatterID
		{
			get{ return _matterID; }
			set{ _matterID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class MatterMapJFCasePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MatterMapJFCaseRow[] mattermapJFCaseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MatterMapJFCaseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MatterMapJFCaseItems : MatterMapJFCaseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MatterMapJFCaseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MatterMapJFCaseItems[] mattermapJFCaseItems { get; set; }
	}
}

