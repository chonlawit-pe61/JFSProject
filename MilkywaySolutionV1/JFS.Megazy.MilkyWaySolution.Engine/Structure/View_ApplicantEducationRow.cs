using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ApplicantEducationRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _educationLevelID;
		private bool _isSetEducationLevelID = false;
		private string _education;
		private bool _isSetEducation = false;
		private string _educationOther;
		private bool _isSetEducationOther = false;
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
		public string Education
		{
			get { return _education; }
			set { _education = value;
			      _isSetEducation = true; }
		}
		public bool _IsSetEducation
		{
			get { return _isSetEducation; }
		}
		public string EducationOther
		{
			get { return _educationOther; }
			set { _educationOther = value;
			      _isSetEducationOther = true; }
		}
		public bool _IsSetEducationOther
		{
			get { return _isSetEducationOther; }
		}
	}
	[Serializable]
	public class View_ApplicantEducationData
	{
		private int _applicantID;
		private int _educationLevelID;
		private string _education;
		private string _educationOther;
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
		public string Education
		{
			get{ return _education; }
			set{ _education = value; }
		}
		public string EducationOther
		{
			get{ return _educationOther; }
			set{ _educationOther = value; }
		}
	}
	[Serializable]
	public class View_ApplicantEducationPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ApplicantEducationRow[] view_ApplicantEducationRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ApplicantEducationItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ApplicantEducationItems : View_ApplicantEducationData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ApplicantEducationItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ApplicantEducationItems[] view_ApplicantEducationItems { get; set; }
	}
}

