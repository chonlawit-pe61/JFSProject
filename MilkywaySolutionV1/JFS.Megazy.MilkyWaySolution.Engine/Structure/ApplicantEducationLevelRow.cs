using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantEducationLevelRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _educationLevelID;
		private bool _isSetEducationLevelID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isSetApplicantID = true; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		[Required]
		public int EducationLevelID
		{
			get { return _educationLevelID; }
			set { _educationLevelID = value;
			      _isSetEducationLevelID = true; }
		}
		public bool _IsSetEducationLevelID
		{
			get { return _isSetEducationLevelID; }
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
	public class ApplicantEducationLevelData
	{
		private int _applicantID;
		private int _educationLevelID;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int EducationLevelID
		{
			get{ return _educationLevelID; }
			set{ _educationLevelID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantEducationLevelPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantEducationLevelRow[] applicantEducationLevelRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantEducationLevelItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantEducationLevelItems : ApplicantEducationLevelData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantEducationLevelItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantEducationLevelItems[] applicantEducationLevelItems { get; set; }
	}
}

