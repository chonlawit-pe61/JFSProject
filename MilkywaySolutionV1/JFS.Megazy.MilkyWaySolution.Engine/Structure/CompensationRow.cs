using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CompensationRow
	{
		private int _compensationID;
		private bool _isSetCompensationID = false;
		private string _compensationName;
		private bool _isSetCompensationName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isOther;
		private bool _isSetIsOther = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CompensationID
		{
			get { return _compensationID; }
			set { _compensationID = value;
			      _isSetCompensationID = true; }
		}
		public bool _IsSetCompensationID
		{
			get { return _isSetCompensationID; }
		}
		[Required]
		public string CompensationName
		{
			get { return _compensationName; }
			set { _compensationName = value;
			      _isSetCompensationName = true; }
		}
		public bool _IsSetCompensationName
		{
			get { return _isSetCompensationName; }
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
	public class CompensationData
	{
		private int _compensationID;
		private string _compensationName;
		private bool _isActive;
		private bool _isOther;
		private DateTime _modifiedDate;
		public int CompensationID
		{
			get{ return _compensationID; }
			set{ _compensationID = value; }
		}
		public string CompensationName
		{
			get{ return _compensationName; }
			set{ _compensationName = value; }
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
	public class CompensationPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CompensationRow[] compensationRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CompensationItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CompensationItems : CompensationData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CompensationItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CompensationItems[] compensationItems { get; set; }
	}
}

