using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class WageRow
	{
		private int _wageID;
		private bool _isSetWageID = false;
		private string _wageName;
		private bool _isSetWageName = false;
		private int _formID;
		private bool _isSetFormID = false;
		private bool _formIDNull = true;
		[Required]
		public int WageID
		{
			get { return _wageID; }
			set { _wageID = value;
			      _isSetWageID = true; }
		}
		public bool _IsSetWageID
		{
			get { return _isSetWageID; }
		}
		public string WageName
		{
			get { return _wageName; }
			set { _wageName = value;
			      _isSetWageName = true; }
		}
		public bool _IsSetWageName
		{
			get { return _isSetWageName; }
		}
		public int FormID
		{
			get
			{
				return _formID;
			}
			set
			{
				_formIDNull = false;
				_isSetFormID = true;
				_formID = value;
			}
		}
		public bool IsFormIDNull
		{
			get {
				 return _formIDNull; }
			set { _formIDNull = value; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
		}
	}
	[Serializable]
	public class WageData
	{
		private int _wageID;
		private string _wageName;
		private int _formID;
		public int WageID
		{
			get{ return _wageID; }
			set{ _wageID = value; }
		}
		public string WageName
		{
			get{ return _wageName; }
			set{ _wageName = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
	}
	[Serializable]
	public class WagePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public WageRow[] wageRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส WageItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class WageItems : WageData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class WageItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public WageItems[] wageItems { get; set; }
	}
}

