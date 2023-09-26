using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class GenderRow
	{
		private string _genderCode;
		private bool _isSetGenderCode = false;
		private string _genderName;
		private bool _isSetGenderName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		[Required]
		public string GenderCode
		{
			get { return _genderCode; }
			set { _genderCode = value;
			      _isSetGenderCode = true; }
		}
		public bool _IsSetGenderCode
		{
			get { return _isSetGenderCode; }
		}
		[Required]
		public string GenderName
		{
			get { return _genderName; }
			set { _genderName = value;
			      _isSetGenderName = true; }
		}
		public bool _IsSetGenderName
		{
			get { return _isSetGenderName; }
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
	}
	[Serializable]
	public class GenderData
	{
		private string _genderCode;
		private string _genderName;
		private bool _isActive;
		public string GenderCode
		{
			get{ return _genderCode; }
			set{ _genderCode = value; }
		}
		public string GenderName
		{
			get{ return _genderName; }
			set{ _genderName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class GenderPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public GenderRow[] genderRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส GenderItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class GenderItems : GenderData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class GenderItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public GenderItems[] genderItems { get; set; }
	}
}

