using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProxyReligionOtherRow
	{
		private int _proxyID;
		private bool _isSetProxyID = false;
		private string _religionOther;
		private bool _isSetReligionOther = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ProxyID
		{
			get { return _proxyID; }
			set { _proxyID = value;
			      _isSetProxyID = true; }
		}
		public bool _IsSetProxyID
		{
			get { return _isSetProxyID; }
		}
		[Required]
		public string ReligionOther
		{
			get { return _religionOther; }
			set { _religionOther = value;
			      _isSetReligionOther = true; }
		}
		public bool _IsSetReligionOther
		{
			get { return _isSetReligionOther; }
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
	public class ProxyReligionOtherData
	{
		private int _proxyID;
		private string _religionOther;
		private DateTime _modifiedDate;
		public int ProxyID
		{
			get{ return _proxyID; }
			set{ _proxyID = value; }
		}
		public string ReligionOther
		{
			get{ return _religionOther; }
			set{ _religionOther = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ProxyReligionOtherPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProxyReligionOtherRow[] proxyReligionOtherRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProxyReligionOtherItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProxyReligionOtherItems : ProxyReligionOtherData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProxyReligionOtherItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProxyReligionOtherItems[] proxyReligionOtherItems { get; set; }
	}
}

