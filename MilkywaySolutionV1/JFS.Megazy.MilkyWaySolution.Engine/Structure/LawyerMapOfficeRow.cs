using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerMapOfficeRow
	{
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private int _lawyerOfficeID;
		private bool _isSetLawyerOfficeID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int LawyerID
		{
			get { return _lawyerID; }
			set { _lawyerID = value;
			      _isSetLawyerID = true; }
		}
		public bool _IsSetLawyerID
		{
			get { return _isSetLawyerID; }
		}
		[Required]
		public int LawyerOfficeID
		{
			get { return _lawyerOfficeID; }
			set { _lawyerOfficeID = value;
			      _isSetLawyerOfficeID = true; }
		}
		public bool _IsSetLawyerOfficeID
		{
			get { return _isSetLawyerOfficeID; }
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
	public class LawyerMapOfficeData
	{
		private int _lawyerID;
		private int _lawyerOfficeID;
		private DateTime _modifiedDate;
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public int LawyerOfficeID
		{
			get{ return _lawyerOfficeID; }
			set{ _lawyerOfficeID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class LawyerMapOfficePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerMapOfficeRow[] lawyerMapOfficeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerMapOfficeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerMapOfficeItems : LawyerMapOfficeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerMapOfficeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerMapOfficeItems[] lawyerMapOfficeItems { get; set; }
	}
}

