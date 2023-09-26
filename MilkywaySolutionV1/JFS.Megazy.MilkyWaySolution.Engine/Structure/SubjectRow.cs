using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class SubjectRow
	{
		private int _subjectID;
		private bool _isSetSubjectID = false;
		private string _subjectName;
		private bool _isSetSubjectName = false;
		private string _imageEra;
		private bool _isSetImageEra = false;
		private string _imageBowl;
		private bool _isSetImageBowl = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		[Required]
		public int SubjectID
		{
			get { return _subjectID; }
			set { _subjectID = value;
			      _isSetSubjectID = true; }
		}
		public bool _IsSetSubjectID
		{
			get { return _isSetSubjectID; }
		}
		[Required]
		public string SubjectName
		{
			get { return _subjectName; }
			set { _subjectName = value;
			      _isSetSubjectName = true; }
		}
		public bool _IsSetSubjectName
		{
			get { return _isSetSubjectName; }
		}
		public string ImageEra
		{
			get { return _imageEra; }
			set { _imageEra = value;
			      _isSetImageEra = true; }
		}
		public bool _IsSetImageEra
		{
			get { return _isSetImageEra; }
		}
		public string ImageBowl
		{
			get { return _imageBowl; }
			set { _imageBowl = value;
			      _isSetImageBowl = true; }
		}
		public bool _IsSetImageBowl
		{
			get { return _isSetImageBowl; }
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
	}
	[Serializable]
	public class SubjectData
	{
		private int _subjectID;
		private string _subjectName;
		private string _imageEra;
		private string _imageBowl;
		private bool _isActive;
		public int SubjectID
		{
			get{ return _subjectID; }
			set{ _subjectID = value; }
		}
		public string SubjectName
		{
			get{ return _subjectName; }
			set{ _subjectName = value; }
		}
		public string ImageEra
		{
			get{ return _imageEra; }
			set{ _imageEra = value; }
		}
		public string ImageBowl
		{
			get{ return _imageBowl; }
			set{ _imageBowl = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class SubjectPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SubjectRow[] subjectRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SubjectItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SubjectItems : SubjectData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SubjectItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SubjectItems[] subjectItems { get; set; }
	}
}

