using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantAttributeRow
	{
		private int _applicantattrID;
		private bool _isSetApplicantAttrID = false;
		private string _applicantattrName;
		private bool _isSetApplicantAttrName = false;
		[Required]
		public int ApplicantAttrID
		{
			get { return _applicantattrID; }
			set { _applicantattrID = value;
			      _isSetApplicantAttrID = true; }
		}
		public bool _IsSetApplicantAttrID
		{
			get { return _isSetApplicantAttrID; }
		}
		[Required]
		public string ApplicantAttrName
		{
			get { return _applicantattrName; }
			set { _applicantattrName = value;
			      _isSetApplicantAttrName = true; }
		}
		public bool _IsSetApplicantAttrName
		{
			get { return _isSetApplicantAttrName; }
		}
	}
	[Serializable]
	public class ApplicantAttributeData
	{
		private int _applicantattrID;
		private string _applicantattrName;
		public int ApplicantAttrID
		{
			get{ return _applicantattrID; }
			set{ _applicantattrID = value; }
		}
		public string ApplicantAttrName
		{
			get{ return _applicantattrName; }
			set{ _applicantattrName = value; }
		}
	}
	[Serializable]
	public class ApplicantAttributePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantAttributeRow[] applicantattributeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantAttributeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantAttributeItems : ApplicantAttributeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantAttributeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantAttributeItems[] applicantattributeItems { get; set; }
	}
}

