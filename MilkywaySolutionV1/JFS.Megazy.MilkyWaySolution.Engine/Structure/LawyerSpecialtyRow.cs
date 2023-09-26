using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerSpecialtyRow
	{
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private int _caseTypeID;
		private bool _isSetCaseTypeID = false;
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
		public int CaseTypeID
		{
			get { return _caseTypeID; }
			set { _caseTypeID = value;
			      _isSetCaseTypeID = true; }
		}
		public bool _IsSetCaseTypeID
		{
			get { return _isSetCaseTypeID; }
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
	public class LawyerSpecialtyData
	{
		private int _lawyerID;
		private int _caseTypeID;
		private DateTime _modifiedDate;
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public int CaseTypeID
		{
			get{ return _caseTypeID; }
			set{ _caseTypeID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class LawyerSpecialtyPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerSpecialtyRow[] lawyerSpecialtyRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerSpecialtyItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerSpecialtyItems : LawyerSpecialtyData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerSpecialtyItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerSpecialtyItems[] lawyerSpecialtyItems { get; set; }
	}
}

