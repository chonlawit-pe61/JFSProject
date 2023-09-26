using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class EducationLevelRow
	{
		private short _educationLevelID;
		private bool _isSetEducationLevelID = false;
		private string _education;
		private bool _isSetEducation = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public short EducationLevelID
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
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
	}
	[Serializable]
	public class EducationLevelData
	{
		private short _educationLevelID;
		private string _education;
		private bool _isActive;
		public short EducationLevelID
		{
			get{ return _educationLevelID; }
			set{ _educationLevelID = value; }
		}
		public string Education
		{
			get{ return _education; }
			set{ _education = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class EducationLevelPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public EducationLevelRow[] educationLevelRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส EducationLevelItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class EducationLevelItems : EducationLevelData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class EducationLevelItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public EducationLevelItems[] educationLevelItems { get; set; }
	}
}

