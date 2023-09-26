using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerStatusRow
	{
		private int _lawyerStatusID;
		private bool _isSetLawyerStatusID = false;
		private string _lawyerStatusName;
		private bool _isSetLawyerStatusName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int LawyerStatusID
		{
			get { return _lawyerStatusID; }
			set { _lawyerStatusID = value;
			      _isSetLawyerStatusID = true; }
		}
		public bool _IsSetLawyerStatusID
		{
			get { return _isSetLawyerStatusID; }
		}
		[Required]
		public string LawyerStatusName
		{
			get { return _lawyerStatusName; }
			set { _lawyerStatusName = value;
			      _isSetLawyerStatusName = true; }
		}
		public bool _IsSetLawyerStatusName
		{
			get { return _isSetLawyerStatusName; }
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
	public class LawyerStatusData
	{
		private int _lawyerStatusID;
		private string _lawyerStatusName;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int LawyerStatusID
		{
			get{ return _lawyerStatusID; }
			set{ _lawyerStatusID = value; }
		}
		public string LawyerStatusName
		{
			get{ return _lawyerStatusName; }
			set{ _lawyerStatusName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class LawyerStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerStatusRow[] lawyerStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerStatusItems : LawyerStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerStatusItems[] lawyerStatusItems { get; set; }
	}
}

