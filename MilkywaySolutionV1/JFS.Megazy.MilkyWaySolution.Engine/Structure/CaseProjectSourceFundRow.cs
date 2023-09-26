using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseProjectSourceFundRow
	{
		private int _sourceFundID;
		private bool _isSetSourceFundID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private string _sourceFundName;
		private bool _isSetSourceFundName = false;
		private double _amount;
		private bool _isSetAmount = false;
		private bool _amountNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int SourceFundID
		{
			get { return _sourceFundID; }
			set { _sourceFundID = value;
			      _isSetSourceFundID = true; }
		}
		public bool _IsSetSourceFundID
		{
			get { return _isSetSourceFundID; }
		}
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isSetCaseID = true; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		[Required]
		public string SourceFundName
		{
			get { return _sourceFundName; }
			set { _sourceFundName = value;
			      _isSetSourceFundName = true; }
		}
		public bool _IsSetSourceFundName
		{
			get { return _isSetSourceFundName; }
		}
		public double Amount
		{
			get
			{
				return _amount;
			}
			set
			{
				_amountNull = false;
				_isSetAmount = true;
				_amount = value;
			}
		}
		public bool IsAmountNull
		{
			get {
				 return _amountNull; }
			set { _amountNull = value; }
		}
		public bool _IsSetAmount
		{
			get { return _isSetAmount; }
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
	public class CaseProjectSourceFundData
	{
		private int _sourceFundID;
		private int _caseID;
		private string _sourceFundName;
		private double _amount;
		private DateTime _modifiedDate;
		public int SourceFundID
		{
			get{ return _sourceFundID; }
			set{ _sourceFundID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public string SourceFundName
		{
			get{ return _sourceFundName; }
			set{ _sourceFundName = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseProjectSourceFundPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseProjectSourceFundRow[] caseProjectSourceFundRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseProjectSourceFundItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseProjectSourceFundItems : CaseProjectSourceFundData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseProjectSourceFundItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseProjectSourceFundItems[] caseProjectSourceFundItems { get; set; }
	}
}

