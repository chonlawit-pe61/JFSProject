using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantCareerRow
	{
		private int _incomeiD;
		private bool _isSetIncomeID = false;
		private int _careerID;
		private bool _isSetCareerID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int IncomeID
		{
			get { return _incomeiD; }
			set { _incomeiD = value;
			      _isSetIncomeID = true; }
		}
		public bool _IsSetIncomeID
		{
			get { return _isSetIncomeID; }
		}
		[Required]
		public int CareerID
		{
			get { return _careerID; }
			set { _careerID = value;
			      _isSetCareerID = true; }
		}
		public bool _IsSetCareerID
		{
			get { return _isSetCareerID; }
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
	public class ApplicantCareerData
	{
		private int _incomeiD;
		private int _careerID;
		private DateTime _modifiedDate;
		public int IncomeID
		{
			get{ return _incomeiD; }
			set{ _incomeiD = value; }
		}
		public int CareerID
		{
			get{ return _careerID; }
			set{ _careerID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantCareerPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantCareerRow[] applicantCareerRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantCareerItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantCareerItems : ApplicantCareerData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantCareerItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantCareerItems[] applicantCareerItems { get; set; }
	}
}

