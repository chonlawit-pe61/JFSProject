using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProcedureRow
	{
		private int _procedureID;
		private bool _isSetProcedureID = false;
		private int _actID;
		private bool _isSetActID = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private string _procedureName;
		private bool _isSetProcedureName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ProcedureID
		{
			get { return _procedureID; }
			set { _procedureID = value;
			      _isSetProcedureID = true; }
		}
		public bool _IsSetProcedureID
		{
			get { return _isSetProcedureID; }
		}
		[Required]
		public int ActID
		{
			get { return _actID; }
			set { _actID = value;
			      _isSetActID = true; }
		}
		public bool _IsSetActID
		{
			get { return _isSetActID; }
		}
		[Required]
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isSetJFCaseTypeID = true; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		[Required]
		public string ProcedureName
		{
			get { return _procedureName; }
			set { _procedureName = value;
			      _isSetProcedureName = true; }
		}
		public bool _IsSetProcedureName
		{
			get { return _isSetProcedureName; }
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
	public class ProcedureData
	{
		private int _procedureID;
		private int _actID;
		private int _jFCaseTypeID;
		private string _procedureName;
		private DateTime _modifiedDate;
		public int ProcedureID
		{
			get{ return _procedureID; }
			set{ _procedureID = value; }
		}
		public int ActID
		{
			get{ return _actID; }
			set{ _actID = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public string ProcedureName
		{
			get{ return _procedureName; }
			set{ _procedureName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ProcedurePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProcedureRow[] procedureRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProcedureItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProcedureItems : ProcedureData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProcedureItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProcedureItems[] procedureItems { get; set; }
	}
}

