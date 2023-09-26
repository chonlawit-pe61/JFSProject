using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OpinionRow
	{
		private int _opinionID;
		private bool _isSetOpinionID = false;
		private string _opinionName;
		private bool _isSetOpinionName = false;
		private bool _isPay;
		private bool _isSetIsPay = false;
		private bool _isPayNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		/// <summary>
		/// รหัสความคิดเห็น
		/// </summary>
		[Required]
		public int OpinionID
		{
			get { return _opinionID; }
			set { _opinionID = value;
			      _isSetOpinionID = true; }
		}
		public bool _IsSetOpinionID
		{
			get { return _isSetOpinionID; }
		}
		/// <summary>
		/// ชื่ความคิดเห็น
		/// </summary>
		[Required]
		public string OpinionName
		{
			get { return _opinionName; }
			set { _opinionName = value;
			      _isSetOpinionName = true; }
		}
		public bool _IsSetOpinionName
		{
			get { return _isSetOpinionName; }
		}
		/// <summary>
		/// ความเห็นที่อนุมัติจ่ายเงินใช่หรือไม่ 1= ใช่ 0=ไม่ใช่
		/// </summary>
		public bool IsPay
		{
			get
			{
				return _isPay;
			}
			set
			{
				_isPayNull = false;
				_isSetIsPay = true;
				_isPay = value;
			}
		}
		public bool IsIsPayNull
		{
			get {
				 return _isPayNull; }
			set { _isPayNull = value; }
		}
		public bool _IsSetIsPay
		{
			get { return _isSetIsPay; }
		}
		/// <summary>
		/// วันที่แก้ไข
		/// </summary>
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
	public class OpinionData
	{
		private int _opinionID;
		private string _opinionName;
		private bool _isPay;
		private DateTime _modifiedDate;
		/// <summary>
		/// รหัสความคิดเห็น
		/// </summary>
		public int OpinionID
		{
			get{ return _opinionID; }
			set{ _opinionID = value; }
		}
		/// <summary>
		/// ชื่ความคิดเห็น
		/// </summary>
		public string OpinionName
		{
			get{ return _opinionName; }
			set{ _opinionName = value; }
		}
		/// <summary>
		/// ความเห็นที่อนุมัติจ่ายเงินใช่หรือไม่ 1= ใช่ 0=ไม่ใช่
		/// </summary>
		public bool IsPay
		{
			get{ return _isPay; }
			set{ _isPay = value; }
		}
		/// <summary>
		/// วันที่แก้ไข
		/// </summary>
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		/// วันที่แก้ไข เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class OpinionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OpinionRow[] opinionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OpinionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OpinionItems : OpinionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OpinionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OpinionItems[] opinionItems { get; set; }
	}
}

