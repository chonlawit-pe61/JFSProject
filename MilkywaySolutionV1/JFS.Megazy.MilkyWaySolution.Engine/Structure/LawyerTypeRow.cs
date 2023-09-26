using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerTypeRow
	{
		private int _lawyerTypeID;
		private bool _isSetLawyerTypeID = false;
		private string _lawyerTypeName;
		private bool _isSetLawyerTypeName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int LawyerTypeID
		{
			get { return _lawyerTypeID; }
			set { _lawyerTypeID = value;
			      _isSetLawyerTypeID = true; }
		}
		public bool _IsSetLawyerTypeID
		{
			get { return _isSetLawyerTypeID; }
		}
		[Required]
		public string LawyerTypeName
		{
			get { return _lawyerTypeName; }
			set { _lawyerTypeName = value;
			      _isSetLawyerTypeName = true; }
		}
		public bool _IsSetLawyerTypeName
		{
			get { return _isSetLawyerTypeName; }
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
	public class LawyerTypeData
	{
		private int _lawyerTypeID;
		private string _lawyerTypeName;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int LawyerTypeID
		{
			get{ return _lawyerTypeID; }
			set{ _lawyerTypeID = value; }
		}
		public string LawyerTypeName
		{
			get{ return _lawyerTypeName; }
			set{ _lawyerTypeName = value; }
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
	public class LawyerTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerTypeRow[] lawyerTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerTypeItems : LawyerTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerTypeItems[] lawyerTypeItems { get; set; }
	}
}

