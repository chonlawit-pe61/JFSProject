using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class GroupMapCaseRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _groupID;
		private bool _isSetGroupID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int GroupID
		{
			get { return _groupID; }
			set { _groupID = value;
			      _isMapRecord = false;
			      _isSetGroupID = true; }
		}
		public Boolean _IsSetGroupID
		{
			get { return _isSetGroupID; }
		}
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isMapRecord = false;
			      _isSetCaseID = true; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
	}
	[Serializable]
	public class GroupMapCaseData
	{
		private int _groupID;
		private int _caseID;
		public int GroupID
		{
			get{ return _groupID; }
			set{ _groupID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
	}
	[Serializable]
	public class GroupMapCasePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public GroupMapCaseRow[] groupMapCaseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส GroupMapCaseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class GroupMapCaseItems : GroupMapCaseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class GroupMapCaseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public GroupMapCaseItems[] groupMapCaseItems { get; set; }
	}
}

