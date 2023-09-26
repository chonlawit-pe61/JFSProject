using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseFormRow
	{
		private int _formID;
		private bool _isSetFormID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _formAttrID;
		private bool _isSetFormAttrID = false;
		private bool _formAttrIDNull = true;
		private string _formAttrVal;
		private bool _isSetFormAttrVal = false;
		[Required]
		public int FormID
		{
			get { return _formID; }
			set { _formID = value;
			      _isSetFormID = true; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
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
		public int FormAttrID
		{
			get
			{
				return _formAttrID;
			}
			set
			{
				_formAttrIDNull = false;
				_isSetFormAttrID = true;
				_formAttrID = value;
			}
		}
		public bool IsFormAttrIDNull
		{
			get {
				 return _formAttrIDNull; }
			set { _formAttrIDNull = value; }
		}
		public bool _IsSetFormAttrID
		{
			get { return _isSetFormAttrID; }
		}
		public string FormAttrVal
		{
			get { return _formAttrVal; }
			set { _formAttrVal = value;
			      _isSetFormAttrVal = true; }
		}
		public bool _IsSetFormAttrVal
		{
			get { return _isSetFormAttrVal; }
		}
	}
	[Serializable]
	public class CaseFormData
	{
		private int _formID;
		private int _applicantID;
		private int _formAttrID;
		private string _formAttrVal;
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int FormAttrID
		{
			get{ return _formAttrID; }
			set{ _formAttrID = value; }
		}
		public string FormAttrVal
		{
			get{ return _formAttrVal; }
			set{ _formAttrVal = value; }
		}
	}
	[Serializable]
	public class CaseFormPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseFormRow[] caseFormRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseFormItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseFormItems : CaseFormData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseFormItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseFormItems[] caseFormItems { get; set; }
	}
}

