using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TermRow
	{
		private int _termID;
		private bool _isSetTermID = false;
		private string _termName;
		private bool _isSetTermName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int TermID
		{
			get { return _termID; }
			set { _termID = value;
			      _isSetTermID = true; }
		}
		public bool _IsSetTermID
		{
			get { return _isSetTermID; }
		}
		[Required]
		public string TermName
		{
			get { return _termName; }
			set { _termName = value;
			      _isSetTermName = true; }
		}
		public bool _IsSetTermName
		{
			get { return _isSetTermName; }
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
	public class TermData
	{
		private int _termID;
		private string _termName;
		private DateTime _modifiedDate;
		public int TermID
		{
			get{ return _termID; }
			set{ _termID = value; }
		}
		public string TermName
		{
			get{ return _termName; }
			set{ _termName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class TermPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TermRow[] termRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TermItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TermItems : TermData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TermItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TermItems[] termItems { get; set; }
	}
}

