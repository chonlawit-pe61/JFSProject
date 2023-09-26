using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OpinionReportRow
	{
		private int _opinionReportID;
		private bool _isSetOpinionReportID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private int _formID;
		private bool _isSetFormID = false;
		private bool _formIDNull = true;
		private string _seniorLawyerName;
		private bool _isSetSeniorLawyerName = false;
		private string _seniorPosition;
		private bool _isSetSeniorPosition = false;
		private string _directorName;
		private bool _isSetDirectorName = false;
		private string _directorPosition;
		private bool _isSetDirectorPosition = false;
		private string _chairmanName;
		private bool _isSetChairmanName = false;
		private string _chairmanPosition;
		private bool _isSetChairmanPosition = false;
		private DateTime _crateDate;
		private bool _isSetCrateDate = false;
		private bool _crateDateNull = true;
		[Required]
		public int OpinionReportID
		{
			get { return _opinionReportID; }
			set { _opinionReportID = value;
			      _isSetOpinionReportID = true; }
		}
		public bool _IsSetOpinionReportID
		{
			get { return _isSetOpinionReportID; }
		}
		public int ApplicantID
		{
			get
			{
				return _applicantID;
			}
			set
			{
				_applicantIDNull = false;
				_isSetApplicantID = true;
				_applicantID = value;
			}
		}
		public bool IsApplicantIDNull
		{
			get {
				 return _applicantIDNull; }
			set { _applicantIDNull = value; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public int FormID
		{
			get
			{
				return _formID;
			}
			set
			{
				_formIDNull = false;
				_isSetFormID = true;
				_formID = value;
			}
		}
		public bool IsFormIDNull
		{
			get {
				 return _formIDNull; }
			set { _formIDNull = value; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
		}
		public string SeniorLawyerName
		{
			get { return _seniorLawyerName; }
			set { _seniorLawyerName = value;
			      _isSetSeniorLawyerName = true; }
		}
		public bool _IsSetSeniorLawyerName
		{
			get { return _isSetSeniorLawyerName; }
		}
		public string SeniorPosition
		{
			get { return _seniorPosition; }
			set { _seniorPosition = value;
			      _isSetSeniorPosition = true; }
		}
		public bool _IsSetSeniorPosition
		{
			get { return _isSetSeniorPosition; }
		}
		public string DirectorName
		{
			get { return _directorName; }
			set { _directorName = value;
			      _isSetDirectorName = true; }
		}
		public bool _IsSetDirectorName
		{
			get { return _isSetDirectorName; }
		}
		public string DirectorPosition
		{
			get { return _directorPosition; }
			set { _directorPosition = value;
			      _isSetDirectorPosition = true; }
		}
		public bool _IsSetDirectorPosition
		{
			get { return _isSetDirectorPosition; }
		}
		public string ChairmanName
		{
			get { return _chairmanName; }
			set { _chairmanName = value;
			      _isSetChairmanName = true; }
		}
		public bool _IsSetChairmanName
		{
			get { return _isSetChairmanName; }
		}
		public string ChairmanPosition
		{
			get { return _chairmanPosition; }
			set { _chairmanPosition = value;
			      _isSetChairmanPosition = true; }
		}
		public bool _IsSetChairmanPosition
		{
			get { return _isSetChairmanPosition; }
		}
		public DateTime CrateDate
		{
			get
			{
				return _crateDate;
			}
			set
			{
				_crateDateNull = false;
				_isSetCrateDate = true;
				_crateDate = value;
			}
		}
		public bool IsCrateDateNull
		{
			get {
				 return _crateDateNull; }
			set { _crateDateNull = value; }
		}
		public bool _IsSetCrateDate
		{
			get { return _isSetCrateDate; }
		}
	}
	[Serializable]
	public class OpinionReportData
	{
		private int _opinionReportID;
		private int _applicantID;
		private int _formID;
		private string _seniorLawyerName;
		private string _seniorPosition;
		private string _directorName;
		private string _directorPosition;
		private string _chairmanName;
		private string _chairmanPosition;
		private DateTime _crateDate;
		public int OpinionReportID
		{
			get{ return _opinionReportID; }
			set{ _opinionReportID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public string SeniorLawyerName
		{
			get{ return _seniorLawyerName; }
			set{ _seniorLawyerName = value; }
		}
		public string SeniorPosition
		{
			get{ return _seniorPosition; }
			set{ _seniorPosition = value; }
		}
		public string DirectorName
		{
			get{ return _directorName; }
			set{ _directorName = value; }
		}
		public string DirectorPosition
		{
			get{ return _directorPosition; }
			set{ _directorPosition = value; }
		}
		public string ChairmanName
		{
			get{ return _chairmanName; }
			set{ _chairmanName = value; }
		}
		public string ChairmanPosition
		{
			get{ return _chairmanPosition; }
			set{ _chairmanPosition = value; }
		}
		public DateTime CrateDate
		{
			get{ return _crateDate; }
			set{ _crateDate = value; }
		}
		public string CrateDateStr { get; set; }
	}
	[Serializable]
	public class OpinionReportPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OpinionReportRow[] opinionReportRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OpinionReportItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OpinionReportItems : OpinionReportData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OpinionReportItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OpinionReportItems[] opinionReportItems { get; set; }
	}
}

