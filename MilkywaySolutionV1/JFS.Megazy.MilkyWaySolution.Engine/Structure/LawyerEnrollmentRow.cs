using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerEnrollmentRow
	{
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private int _enrollmentYear;
		private bool _isSetEnrollmentYear = false;
		private DateTime _enrollmentDate;
		private bool _isSetEnrollmentDate = false;
		private bool _enrollmentDateNull = true;
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
		public int EnrollmentYear
		{
			get { return _enrollmentYear; }
			set { _enrollmentYear = value;
			      _isSetEnrollmentYear = true; }
		}
		public bool _IsSetEnrollmentYear
		{
			get { return _isSetEnrollmentYear; }
		}
		public DateTime EnrollmentDate
		{
			get
			{
				return _enrollmentDate;
			}
			set
			{
				_enrollmentDateNull = false;
				_isSetEnrollmentDate = true;
				_enrollmentDate = value;
			}
		}
		public bool IsEnrollmentDateNull
		{
			get {
				 return _enrollmentDateNull; }
			set { _enrollmentDateNull = value; }
		}
		public bool _IsSetEnrollmentDate
		{
			get { return _isSetEnrollmentDate; }
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
	public class LawyerEnrollmentData
	{
		private int _lawyerID;
		private int _enrollmentYear;
		private DateTime _enrollmentDate;
		private DateTime _modifiedDate;
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public int EnrollmentYear
		{
			get{ return _enrollmentYear; }
			set{ _enrollmentYear = value; }
		}
		public DateTime EnrollmentDate
		{
			get{ return _enrollmentDate; }
			set{ _enrollmentDate = value; }
		}
		public string EnrollmentDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class LawyerEnrollmentPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerEnrollmentRow[] lawyerEnrollmentRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerEnrollmentItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerEnrollmentItems : LawyerEnrollmentData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerEnrollmentItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerEnrollmentItems[] lawyerEnrollmentItems { get; set; }
	}
}

