using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ContractCaseFollowUpRow
	{
		private int _contractID;
		private bool _isSetContractID = false;
		private string _courtLocation;
		private bool _isSetCourtLocation = false;
		private int _courtOrderID;
		private bool _isSetCourtOrderID = false;
		private bool _courtOrderIDNull = true;
		private int _resultID;
		private bool _isSetResultID = false;
		private bool _resultIDNull = true;
		private double _courtOrderAmount;
		private bool _isSetCourtOrderAmount = false;
		private bool _courtOrderAmountNull = true;
		private DateTime _judgmentDate;
		private bool _isSetJudgmentDate = false;
		private bool _judgmentDateNull = true;
		private string _note;
		private bool _isSetNote = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _courtOrderName;
		private bool _isSetCourtOrderName = false;
		private string _resultName;
		private bool _isSetResultName = false;
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
		public string CourtLocation
		{
			get { return _courtLocation; }
			set { _courtLocation = value;
			      _isSetCourtLocation = true; }
		}
		public bool _IsSetCourtLocation
		{
			get { return _isSetCourtLocation; }
		}
		public int CourtOrderID
		{
			get
			{
				return _courtOrderID;
			}
			set
			{
				_courtOrderIDNull = false;
				_isSetCourtOrderID = true;
				_courtOrderID = value;
			}
		}
		public bool IsCourtOrderIDNull
		{
			get {
				 return _courtOrderIDNull; }
			set { _courtOrderIDNull = value; }
		}
		public bool _IsSetCourtOrderID
		{
			get { return _isSetCourtOrderID; }
		}
		public int ResultID
		{
			get
			{
				return _resultID;
			}
			set
			{
				_resultIDNull = false;
				_isSetResultID = true;
				_resultID = value;
			}
		}
		public bool IsResultIDNull
		{
			get {
				 return _resultIDNull; }
			set { _resultIDNull = value; }
		}
		public bool _IsSetResultID
		{
			get { return _isSetResultID; }
		}
		public double CourtOrderAmount
		{
			get
			{
				return _courtOrderAmount;
			}
			set
			{
				_courtOrderAmountNull = false;
				_isSetCourtOrderAmount = true;
				_courtOrderAmount = value;
			}
		}
		public bool IsCourtOrderAmountNull
		{
			get {
				 return _courtOrderAmountNull; }
			set { _courtOrderAmountNull = value; }
		}
		public bool _IsSetCourtOrderAmount
		{
			get { return _isSetCourtOrderAmount; }
		}
		public DateTime JudgmentDate
		{
			get
			{
				return _judgmentDate;
			}
			set
			{
				_judgmentDateNull = false;
				_isSetJudgmentDate = true;
				_judgmentDate = value;
			}
		}
		public bool IsJudgmentDateNull
		{
			get {
				 return _judgmentDateNull; }
			set { _judgmentDateNull = value; }
		}
		public bool _IsSetJudgmentDate
		{
			get { return _isSetJudgmentDate; }
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
		public string CourtOrderName
		{
			get { return _courtOrderName; }
			set { _courtOrderName = value;
			      _isSetCourtOrderName = true; }
		}
		public bool _IsSetCourtOrderName
		{
			get { return _isSetCourtOrderName; }
		}
		public string ResultName
		{
			get { return _resultName; }
			set { _resultName = value;
			      _isSetResultName = true; }
		}
		public bool _IsSetResultName
		{
			get { return _isSetResultName; }
		}
	}
	[Serializable]
	public class View_ContractCaseFollowUpData
	{
		private int _contractID;
		private string _courtLocation;
		private int _courtOrderID;
		private int _resultID;
		private double _courtOrderAmount;
		private DateTime _judgmentDate;
		private string _note;
		private DateTime _modifiedDate;
		private string _courtOrderName;
		private string _resultName;
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public string CourtLocation
		{
			get{ return _courtLocation; }
			set{ _courtLocation = value; }
		}
		public int CourtOrderID
		{
			get{ return _courtOrderID; }
			set{ _courtOrderID = value; }
		}
		public int ResultID
		{
			get{ return _resultID; }
			set{ _resultID = value; }
		}
		public double CourtOrderAmount
		{
			get{ return _courtOrderAmount; }
			set{ _courtOrderAmount = value; }
		}
		public DateTime JudgmentDate
		{
			get{ return _judgmentDate; }
			set{ _judgmentDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string JudgmentDateStr { get; set; }
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
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
		public string CourtOrderName
		{
			get{ return _courtOrderName; }
			set{ _courtOrderName = value; }
		}
		public string ResultName
		{
			get{ return _resultName; }
			set{ _resultName = value; }
		}
	}
	[Serializable]
	public class View_ContractCaseFollowUpPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ContractCaseFollowUpRow[] view_ContractCaseFollowUpRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ContractCaseFollowUpItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ContractCaseFollowUpItems : View_ContractCaseFollowUpData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ContractCaseFollowUpItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ContractCaseFollowUpItems[] view_ContractCaseFollowUpItems { get; set; }
	}
}

