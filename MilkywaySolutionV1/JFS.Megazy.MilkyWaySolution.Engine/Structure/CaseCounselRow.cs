using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseCounselRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _cunselTime;
		private bool _isSetCunselTime = false;
		private bool _cunselTimeNull = true;
		private string _conselSummary;
		private bool _isSetConselSummary = false;
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
		public int CunselTime
		{
			get
			{
				return _cunselTime;
			}
			set
			{
				_cunselTimeNull = false;
				_isSetCunselTime = true;
				_cunselTime = value;
			}
		}
		public bool IsCunselTimeNull
		{
			get {
				 return _cunselTimeNull; }
			set { _cunselTimeNull = value; }
		}
		public bool _IsSetCunselTime
		{
			get { return _isSetCunselTime; }
		}
		public string ConselSummary
		{
			get { return _conselSummary; }
			set { _conselSummary = value;
			      _isSetConselSummary = true; }
		}
		public bool _IsSetConselSummary
		{
			get { return _isSetConselSummary; }
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
	public class CaseCounselData
	{
		private int _applicantID;
		private int _cunselTime;
		private string _conselSummary;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int CunselTime
		{
			get{ return _cunselTime; }
			set{ _cunselTime = value; }
		}
		public string ConselSummary
		{
			get{ return _conselSummary; }
			set{ _conselSummary = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseCounselPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseCounselRow[] casecounselRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseCounselItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseCounselItems : CaseCounselData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseCounselItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseCounselItems[] casecounselItems { get; set; }
	}
}

