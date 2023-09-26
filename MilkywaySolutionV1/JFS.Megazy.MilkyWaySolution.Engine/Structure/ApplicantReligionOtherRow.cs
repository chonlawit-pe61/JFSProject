using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantReligionOtherRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _religionOther;
		private bool _isSetReligionOther = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isMapRecord = false;
			      _isSetApplicantID = true; }
		}
		public Boolean _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		[Required]
		public string ReligionOther
		{
			get { return _religionOther; }
			set { _religionOther = value;
			      _isMapRecord = false;
			      _isSetReligionOther = true; }
		}
		public Boolean _IsSetReligionOther
		{
			get { return _isSetReligionOther; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isMapRecord = false;
			      _isSetModifiedDate = true; }
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class ApplicantReligionOtherData
	{
		private int _applicantID;
		private string _religionOther;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public string ReligionOther
		{
			get{ return _religionOther; }
			set{ _religionOther = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantReligionOtherPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantReligionOtherRow[] applicantReligionOtherRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantReligionOtherItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantReligionOtherItems : ApplicantReligionOtherData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantReligionOtherItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantReligionOtherItems[] applicantReligionOtherItems { get; set; }
	}
}

