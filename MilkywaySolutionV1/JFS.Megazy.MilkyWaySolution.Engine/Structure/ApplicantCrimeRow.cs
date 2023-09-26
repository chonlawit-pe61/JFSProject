using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantCrimeRow
	{
		private int _crimeID;
		private bool _isSetCrimeID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private string _policeStation;
		private bool _isSetPoliceStation = false;
		private string _charge;
		private bool _isSetCharge = false;
		private string _legalConsequence;
		private bool _isSetLegalConsequence = false;
		private DateTime _crimeDate;
		private bool _isSetCrimeDate = false;
		private bool _crimeDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CrimeID
		{
			get { return _crimeID; }
			set { _crimeID = value;
			      _isSetCrimeID = true; }
		}
		public bool _IsSetCrimeID
		{
			get { return _isSetCrimeID; }
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
		public string PoliceStation
		{
			get { return _policeStation; }
			set { _policeStation = value;
			      _isSetPoliceStation = true; }
		}
		public bool _IsSetPoliceStation
		{
			get { return _isSetPoliceStation; }
		}
		public string Charge
		{
			get { return _charge; }
			set { _charge = value;
			      _isSetCharge = true; }
		}
		public bool _IsSetCharge
		{
			get { return _isSetCharge; }
		}
		public string LegalConsequence
		{
			get { return _legalConsequence; }
			set { _legalConsequence = value;
			      _isSetLegalConsequence = true; }
		}
		public bool _IsSetLegalConsequence
		{
			get { return _isSetLegalConsequence; }
		}
		public DateTime CrimeDate
		{
			get
			{
				return _crimeDate;
			}
			set
			{
				_crimeDateNull = false;
				_isSetCrimeDate = true;
				_crimeDate = value;
			}
		}
		public bool IsCrimeDateNull
		{
			get {
				 return _crimeDateNull; }
			set { _crimeDateNull = value; }
		}
		public bool _IsSetCrimeDate
		{
			get { return _isSetCrimeDate; }
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
	public class ApplicantCrimeData
	{
		private int _crimeID;
		private int _applicantID;
		private string _policeStation;
		private string _charge;
		private string _legalConsequence;
		private DateTime _crimeDate;
		private DateTime _modifiedDate;
		public int CrimeID
		{
			get{ return _crimeID; }
			set{ _crimeID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public string PoliceStation
		{
			get{ return _policeStation; }
			set{ _policeStation = value; }
		}
		public string Charge
		{
			get{ return _charge; }
			set{ _charge = value; }
		}
		public string LegalConsequence
		{
			get{ return _legalConsequence; }
			set{ _legalConsequence = value; }
		}
		public DateTime CrimeDate
		{
			get{ return _crimeDate; }
			set{ _crimeDate = value; }
		}
		public string CrimeDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantCrimePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantCrimeRow[] applicantCrimeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantCrimeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantCrimeItems : ApplicantCrimeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantCrimeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantCrimeItems[] applicantCrimeItems { get; set; }
	}
}

