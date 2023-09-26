using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantBailRow
	{
		private int _bailID;
		private bool _isSetBailID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _bailStatusID;
		private bool _isSetBailStatusID = false;
		private string _description;
		private bool _isSetDescription = false;
		private DateTime _modified;
		private bool _isSetModified = false;
		private bool _modifiedNull = true;
		[Required]
		public int BailID
		{
			get { return _bailID; }
			set { _bailID = value;
			      _isSetBailID = true; }
		}
		public bool _IsSetBailID
		{
			get { return _isSetBailID; }
		}
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
		public int BailStatusID
		{
			get { return _bailStatusID; }
			set { _bailStatusID = value;
			      _isSetBailStatusID = true; }
		}
		public bool _IsSetBailStatusID
		{
			get { return _isSetBailStatusID; }
		}
		public string Description
		{
			get { return _description; }
			set { _description = value;
			      _isSetDescription = true; }
		}
		public bool _IsSetDescription
		{
			get { return _isSetDescription; }
		}
		[Required]
		public DateTime Modified
		{
			get { return _modified; }
			set { _modified = value;
			      _modifiedNull = false;
			      _isSetModified = true; }
		}
		public bool IsModifiedNull
		{
			get {
				 return _modifiedNull; }
			set { _modifiedNull = value; }
		}
		public bool _IsSetModified
		{
			get { return _isSetModified; }
		}
	}
	[Serializable]
	public class ApplicantBailData
	{
		private int _bailID;
		private int _applicantID;
		private int _bailStatusID;
		private string _description;
		private DateTime _modified;
		public int BailID
		{
			get{ return _bailID; }
			set{ _bailID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int BailStatusID
		{
			get{ return _bailStatusID; }
			set{ _bailStatusID = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public DateTime Modified
		{
			get{ return _modified; }
			set{ _modified = value; }
		}
		public string ModifiedStr { get; set; }
	}
	[Serializable]
	public class ApplicantBailPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantBailRow[] applicantBailRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantBailItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantBailItems : ApplicantBailData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantBailItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantBailItems[] applicantBailItems { get; set; }
	}
}

