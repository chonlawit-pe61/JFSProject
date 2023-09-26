using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class FAQRow
	{
		private int _faqID;
		private bool _isSetFaqID = false;
		private string _title;
		private bool _isSetTitle = false;
		private string _description;
		private bool _isSetDescription = false;
		private int _seq;
		private bool _isSetSeq = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		[Required]
		public int FaqID
		{
			get { return _faqID; }
			set { _faqID = value;
			      _isSetFaqID = true; }
		}
		public bool _IsSetFaqID
		{
			get { return _isSetFaqID; }
		}
		[Required]
		public string Title
		{
			get { return _title; }
			set { _title = value;
			      _isSetTitle = true; }
		}
		public bool _IsSetTitle
		{
			get { return _isSetTitle; }
		}
		[Required]
		public string Description
		{
			get { return _description; }
			set { _description = value;
			      _isSetDescription = true; }
		}
		public bool _IsSetDescription
		{
			get { return _isSetDescription; }
		}
		[Required]
		public int Seq
		{
			get { return _seq; }
			set { _seq = value;
			      _isSetSeq = true; }
		}
		public bool _IsSetSeq
		{
			get { return _isSetSeq; }
		}
		[Required]
		public DateTime CreateDate
		{
			get { return _createDate; }
			set { _createDate = value;
			      _createDateNull = false;
			      _isSetCreateDate = true; }
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public bool _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
	}
	[Serializable]
	public class FAQData
	{
		private int _faqID;
		private string _title;
		private string _description;
		private int _seq;
		private DateTime _createDate;
		public int FaqID
		{
			get{ return _faqID; }
			set{ _faqID = value; }
		}
		public string Title
		{
			get{ return _title; }
			set{ _title = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public int Seq
		{
			get{ return _seq; }
			set{ _seq = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
	}
	[Serializable]
	public class FAQPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public FAQRow[] fAQRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส FAQItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class FAQItems : FAQData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class FAQItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public FAQItems[] fAQItems { get; set; }
	}
}

