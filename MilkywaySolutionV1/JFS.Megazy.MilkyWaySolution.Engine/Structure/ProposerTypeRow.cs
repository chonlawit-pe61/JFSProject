using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProposerTypeRow
	{
		private int _proposerTypeID;
		private bool _isSetProposerTypeID = false;
		private string _proposerTypeName;
		private bool _isSetProposerTypeName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ProposerTypeID
		{
			get { return _proposerTypeID; }
			set { _proposerTypeID = value;
			      _isSetProposerTypeID = true; }
		}
		public bool _IsSetProposerTypeID
		{
			get { return _isSetProposerTypeID; }
		}
		[Required]
		public string ProposerTypeName
		{
			get { return _proposerTypeName; }
			set { _proposerTypeName = value;
			      _isSetProposerTypeName = true; }
		}
		public bool _IsSetProposerTypeName
		{
			get { return _isSetProposerTypeName; }
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
	public class ProposerTypeData
	{
		private int _proposerTypeID;
		private string _proposerTypeName;
		private DateTime _modifiedDate;
		public int ProposerTypeID
		{
			get{ return _proposerTypeID; }
			set{ _proposerTypeID = value; }
		}
		public string ProposerTypeName
		{
			get{ return _proposerTypeName; }
			set{ _proposerTypeName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ProposerTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProposerTypeRow[] proposerTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProposerTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProposerTypeItems : ProposerTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProposerTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProposerTypeItems[] proposerTypeItems { get; set; }
	}
}

