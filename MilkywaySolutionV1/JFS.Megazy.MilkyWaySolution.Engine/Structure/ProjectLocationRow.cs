using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProjectLocationRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private string _locationName;
		private bool _isSetLocationName = false;
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
		public int AddressID
		{
			get { return _addressID; }
			set { _addressID = value;
			      _isSetAddressID = true; }
		}
		public bool _IsSetAddressID
		{
			get { return _isSetAddressID; }
		}
		public string LocationName
		{
			get { return _locationName; }
			set { _locationName = value;
			      _isSetLocationName = true; }
		}
		public bool _IsSetLocationName
		{
			get { return _isSetLocationName; }
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
	public class ProjectLocationData
	{
		private int _caseID;
		private int _addressID;
		private string _locationName;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public string LocationName
		{
			get{ return _locationName; }
			set{ _locationName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ProjectLocationPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProjectLocationRow[] projectLocationRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProjectLocationItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProjectLocationItems : ProjectLocationData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProjectLocationItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProjectLocationItems[] projectLocationItems { get; set; }
	}
}

