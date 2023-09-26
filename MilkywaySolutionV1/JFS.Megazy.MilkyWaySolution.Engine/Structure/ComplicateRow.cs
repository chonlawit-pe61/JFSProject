using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ComplicateRow
	{
		private int _complicateID;
		private bool _isSetComplicateID = false;
		private string _complicateName;
		private bool _isSetComplicateName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isOther;
		private bool _isSetIsOther = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ComplicateID
		{
			get { return _complicateID; }
			set { _complicateID = value;
			      _isSetComplicateID = true; }
		}
		public bool _IsSetComplicateID
		{
			get { return _isSetComplicateID; }
		}
		[Required]
		public string ComplicateName
		{
			get { return _complicateName; }
			set { _complicateName = value;
			      _isSetComplicateName = true; }
		}
		public bool _IsSetComplicateName
		{
			get { return _isSetComplicateName; }
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
		[Required]
		public bool IsOther
		{
			get { return _isOther; }
			set { _isOther = value;
			      _isSetIsOther = true; }
		}
		public bool _IsSetIsOther
		{
			get { return _isSetIsOther; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
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
	public class ComplicateData
	{
		private int _complicateID;
		private string _complicateName;
		private bool _isActive;
		private bool _isOther;
		private DateTime _modifiedDate;
		public int ComplicateID
		{
			get{ return _complicateID; }
			set{ _complicateID = value; }
		}
		public string ComplicateName
		{
			get{ return _complicateName; }
			set{ _complicateName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public bool IsOther
		{
			get{ return _isOther; }
			set{ _isOther = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ComplicatePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ComplicateRow[] complicateRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ComplicateItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ComplicateItems : ComplicateData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ComplicateItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ComplicateItems[] complicateItems { get; set; }
	}
}

