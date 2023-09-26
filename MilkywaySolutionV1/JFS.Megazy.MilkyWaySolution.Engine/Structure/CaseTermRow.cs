using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseTermRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _temID;
		private bool _isSetTemID = false;
		private int _finalApproveID;
		private bool _isSetFinalApproveID = false;
		private int _subcommitteeID;
		private bool _isSetSubcommitteeID = false;
		private bool _subcommitteeIDNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public int TemID
		{
			get { return _temID; }
			set { _temID = value;
			      _isSetTemID = true; }
		}
		public bool _IsSetTemID
		{
			get { return _isSetTemID; }
		}
		[Required]
		public int FinalApproveID
		{
			get { return _finalApproveID; }
			set { _finalApproveID = value;
			      _isSetFinalApproveID = true; }
		}
		public bool _IsSetFinalApproveID
		{
			get { return _isSetFinalApproveID; }
		}
		public int SubcommitteeID
		{
			get
			{
				return _subcommitteeID;
			}
			set
			{
				_subcommitteeIDNull = false;
				_isSetSubcommitteeID = true;
				_subcommitteeID = value;
			}
		}
		public bool IsSubcommitteeIDNull
		{
			get {
				 return _subcommitteeIDNull; }
			set { _subcommitteeIDNull = value; }
		}
		public bool _IsSetSubcommitteeID
		{
			get { return _isSetSubcommitteeID; }
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
	public class CaseTermData
	{
		private int _caseID;
		private int _temID;
		private int _finalApproveID;
		private int _subcommitteeID;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int TemID
		{
			get{ return _temID; }
			set{ _temID = value; }
		}
		public int FinalApproveID
		{
			get{ return _finalApproveID; }
			set{ _finalApproveID = value; }
		}
		public int SubcommitteeID
		{
			get{ return _subcommitteeID; }
			set{ _subcommitteeID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseTermPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseTermRow[] caseTermRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseTermItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseTermItems : CaseTermData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseTermItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseTermItems[] caseTermItems { get; set; }
	}
}

