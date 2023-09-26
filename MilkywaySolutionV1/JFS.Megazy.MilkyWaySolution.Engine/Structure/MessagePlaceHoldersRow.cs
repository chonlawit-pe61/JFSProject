using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MessagePlaceHoldersRow
	{
		private int _placeHolderID;
		private bool _isSetPlaceHolderID = false;
		private string _placeHolder;
		private bool _isSetPlaceHolder = false;
		[Required]
		public int PlaceHolderID
		{
			get { return _placeHolderID; }
			set { _placeHolderID = value;
			      _isSetPlaceHolderID = true; }
		}
		public bool _IsSetPlaceHolderID
		{
			get { return _isSetPlaceHolderID; }
		}
		public string PlaceHolder
		{
			get { return _placeHolder; }
			set { _placeHolder = value;
			      _isSetPlaceHolder = true; }
		}
		public bool _IsSetPlaceHolder
		{
			get { return _isSetPlaceHolder; }
		}
	}
	[Serializable]
	public class MessagePlaceHoldersData
	{
		private int _placeHolderID;
		private string _placeHolder;
		public int PlaceHolderID
		{
			get{ return _placeHolderID; }
			set{ _placeHolderID = value; }
		}
		public string PlaceHolder
		{
			get{ return _placeHolder; }
			set{ _placeHolder = value; }
		}
	}
	[Serializable]
	public class MessagePlaceHoldersPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MessagePlaceHoldersRow[] messagePlaceHoldersRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MessagePlaceHoldersItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MessagePlaceHoldersItems : MessagePlaceHoldersData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MessagePlaceHoldersItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MessagePlaceHoldersItems[] messagePlaceHoldersItems { get; set; }
	}
}

