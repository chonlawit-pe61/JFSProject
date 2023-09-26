using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseProjectCharacteristicsRow
	{
		private int _characteristicID;
		private bool _isSetCharacteristicID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private string _remark;
		private bool _isSetRemark = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public string Remark
		{
			get { return _remark; }
			set { _remark = value;
			      _isSetRemark = true; }
		}
		public bool _IsSetRemark
		{
			get { return _isSetRemark; }
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
	public class CaseProjectCharacteristicsData
	{
		private int _characteristicID;
		private int _caseID;
		private string _remark;
		private DateTime _modifiedDate;
		public int CharacteristicID
		{
			get{ return _characteristicID; }
			set{ _characteristicID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseProjectCharacteristicsPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseProjectCharacteristicsRow[] caseProjectcharacteristicsRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseProjectCharacteristicsItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseProjectCharacteristicsItems : CaseProjectCharacteristicsData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseProjectCharacteristicsItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseProjectCharacteristicsItems[] caseProjectcharacteristicsItems { get; set; }
	}
}

