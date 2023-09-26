using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class JudgeRow
	{
		private int _judgeID;
		private bool _isSetJudgeID = false;
		private string _judgeName;
		private bool _isSetJudgeName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int JudgeID
		{
			get { return _judgeID; }
			set { _judgeID = value;
			      _isSetJudgeID = true; }
		}
		public bool _IsSetJudgeID
		{
			get { return _isSetJudgeID; }
		}
		[Required]
		public string JudgeName
		{
			get { return _judgeName; }
			set { _judgeName = value;
			      _isSetJudgeName = true; }
		}
		public bool _IsSetJudgeName
		{
			get { return _isSetJudgeName; }
		}
		[Required]
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value;
			      _isSetIsActive = true; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
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
	public class JudgeData
	{
		private int _judgeID;
		private string _judgeName;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int JudgeID
		{
			get{ return _judgeID; }
			set{ _judgeID = value; }
		}
		public string JudgeName
		{
			get{ return _judgeName; }
			set{ _judgeName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class JudgePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public JudgeRow[] judgeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส JudgeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class JudgeItems : JudgeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class JudgeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public JudgeItems[] judgeItems { get; set; }
	}
}

