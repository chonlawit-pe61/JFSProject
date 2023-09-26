using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantAdditionalInfoRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _applicantattrID;
		private bool _isSetApplicantAttrID = false;
		private string _applicantattrVal;
		private bool _isSetApplicantAttrVal = false;
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
		public int ApplicantAttrID
		{
			get { return _applicantattrID; }
			set { _applicantattrID = value;
			      _isSetApplicantAttrID = true; }
		}
		public bool _IsSetApplicantAttrID
		{
			get { return _isSetApplicantAttrID; }
		}
		[Required]
		public string ApplicantAttrVal
		{
			get { return _applicantattrVal; }
			set { _applicantattrVal = value;
			      _isSetApplicantAttrVal = true; }
		}
		public bool _IsSetApplicantAttrVal
		{
			get { return _isSetApplicantAttrVal; }
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
	public class ApplicantAdditionalInfoData
	{
		private int _applicantID;
		private int _applicantattrID;
		private string _applicantattrVal;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int ApplicantAttrID
		{
			get{ return _applicantattrID; }
			set{ _applicantattrID = value; }
		}
		public string ApplicantAttrVal
		{
			get{ return _applicantattrVal; }
			set{ _applicantattrVal = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantAdditionalInfoPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantAdditionalInfoRow[] applicantadditionalInfoRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantAdditionalInfoItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantAdditionalInfoItems : ApplicantAdditionalInfoData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantAdditionalInfoItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantAdditionalInfoItems[] applicantadditionalInfoItems { get; set; }
	}
}

