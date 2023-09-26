using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantMaritalRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _maritalStatusID;
		private bool _isSetMaritalStatusID = false;
		private int _additionalMaritalStatus;
		private bool _isSetAdditionalMaritalStatus = false;
		private bool _additionalMaritalStatusNull = true;
		private int _numberOfChild;
		private bool _isSetNumberOfChild = false;
		private bool _numberOfChildNull = true;
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
		public int MaritalStatusID
		{
			get { return _maritalStatusID; }
			set { _maritalStatusID = value;
			      _isSetMaritalStatusID = true; }
		}
		public bool _IsSetMaritalStatusID
		{
			get { return _isSetMaritalStatusID; }
		}
		public int AdditionalMaritalStatus
		{
			get
			{
				return _additionalMaritalStatus;
			}
			set
			{
				_additionalMaritalStatusNull = false;
				_isSetAdditionalMaritalStatus = true;
				_additionalMaritalStatus = value;
			}
		}
		public bool IsAdditionalMaritalStatusNull
		{
			get {
				 return _additionalMaritalStatusNull; }
			set { _additionalMaritalStatusNull = value; }
		}
		public bool _IsSetAdditionalMaritalStatus
		{
			get { return _isSetAdditionalMaritalStatus; }
		}
		public int NumberOfChild
		{
			get
			{
				return _numberOfChild;
			}
			set
			{
				_numberOfChildNull = false;
				_isSetNumberOfChild = true;
				_numberOfChild = value;
			}
		}
		public bool IsNumberOfChildNull
		{
			get {
				 return _numberOfChildNull; }
			set { _numberOfChildNull = value; }
		}
		public bool _IsSetNumberOfChild
		{
			get { return _isSetNumberOfChild; }
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
	public class ApplicantMaritalData
	{
		private int _applicantID;
		private int _maritalStatusID;
		private int _additionalMaritalStatus;
		private int _numberOfChild;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int MaritalStatusID
		{
			get{ return _maritalStatusID; }
			set{ _maritalStatusID = value; }
		}
		public int AdditionalMaritalStatus
		{
			get{ return _additionalMaritalStatus; }
			set{ _additionalMaritalStatus = value; }
		}
		public int NumberOfChild
		{
			get{ return _numberOfChild; }
			set{ _numberOfChild = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantMaritalPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantMaritalRow[] applicantMaritalRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantMaritalItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantMaritalItems : ApplicantMaritalData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantMaritalItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantMaritalItems[] applicantMaritalItems { get; set; }
	}
}

