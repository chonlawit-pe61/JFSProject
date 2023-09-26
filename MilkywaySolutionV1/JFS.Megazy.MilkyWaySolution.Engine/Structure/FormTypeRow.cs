using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class FormTypeRow
	{
		private int _formTypeID;
		private bool _isSetFormTypeID = false;
		private string _formTypeName;
		private bool _isSetFormTypeName = false;
		[Required]
		public int FormTypeID
		{
			get { return _formTypeID; }
			set { _formTypeID = value;
			      _isSetFormTypeID = true; }
		}
		public bool _IsSetFormTypeID
		{
			get { return _isSetFormTypeID; }
		}
		public string FormTypeName
		{
			get { return _formTypeName; }
			set { _formTypeName = value;
			      _isSetFormTypeName = true; }
		}
		public bool _IsSetFormTypeName
		{
			get { return _isSetFormTypeName; }
		}
	}
	[Serializable]
	public class FormTypeData
	{
		private int _formTypeID;
		private string _formTypeName;
		public int FormTypeID
		{
			get{ return _formTypeID; }
			set{ _formTypeID = value; }
		}
		public string FormTypeName
		{
			get{ return _formTypeName; }
			set{ _formTypeName = value; }
		}
	}
	[Serializable]
	public class FormTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public FormTypeRow[] formTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส FormTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class FormTypeItems : FormTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class FormTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public FormTypeItems[] formTypeItems { get; set; }
	}
}

