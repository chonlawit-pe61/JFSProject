using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProjectCharacteristicRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _characteristicID;
		private bool _isSetCharacteristicID = false;
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
		public int CharacteristicID
		{
			get { return _characteristicID; }
			set { _characteristicID = value;
			      _isSetCharacteristicID = true; }
		}
		public bool _IsSetCharacteristicID
		{
			get { return _isSetCharacteristicID; }
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
	public class ProjectCharacteristicData
	{
		private int _caseID;
		private int _characteristicID;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int CharacteristicID
		{
			get{ return _characteristicID; }
			set{ _characteristicID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ProjectCharacteristicPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProjectCharacteristicRow[] projectCharacteristicRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProjectCharacteristicItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProjectCharacteristicItems : ProjectCharacteristicData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProjectCharacteristicItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProjectCharacteristicItems[] projectCharacteristicItems { get; set; }
	}
}

