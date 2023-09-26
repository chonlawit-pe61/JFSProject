using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerContractRow
	{
		private int _contractID;
		private bool _isSetContractID = false;
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private int _courtJudgmentID;
		private bool _isSetCourtJudgmentID = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private string _note;
		private bool _isSetNote = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ContractID
		{
			get { return _contractID; }
			set { _contractID = value;
			      _isSetContractID = true; }
		}
		public bool _IsSetContractID
		{
			get { return _isSetContractID; }
		}
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
		public int CourtJudgmentID
		{
			get { return _courtJudgmentID; }
			set { _courtJudgmentID = value;
			      _isSetCourtJudgmentID = true; }
		}
		public bool _IsSetCourtJudgmentID
		{
			get { return _isSetCourtJudgmentID; }
		}
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public string Note
		{
			get { return _note; }
			set { _note = value;
			      _isSetNote = true; }
		}
		public bool _IsSetNote
		{
			get { return _isSetNote; }
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
	public class LawyerContractData
	{
		private int _contractID;
		private int _lawyerID;
		private int _courtJudgmentID;
		private bool _isActive;
		private string _note;
		private DateTime _modifiedDate;
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public int CourtJudgmentID
		{
			get{ return _courtJudgmentID; }
			set{ _courtJudgmentID = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class LawyerContractPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerContractRow[] lawyerContractRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerContractItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerContractItems : LawyerContractData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerContractItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerContractItems[] lawyerContractItems { get; set; }
	}
}

