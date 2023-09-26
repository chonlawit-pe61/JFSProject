using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ClaimStatusRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _claimStatusID;
		private bool _isSetClaimStatusID = false;
		private string _claimStatus;
		private bool _isSetClaimStatus = false;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int ClaimStatusID
		{
			get { return _claimStatusID; }
			set { _claimStatusID = value;
			      _isMapRecord = false;
			      _isSetClaimStatusID = true; }
		}
		public Boolean _IsSetClaimStatusID
		{
			get { return _isSetClaimStatusID; }
		}
		[Required]
		public string ClaimStatus
		{
			get { return _claimStatus; }
			set { _claimStatus = value;
			      _isMapRecord = false;
			      _isSetClaimStatus = true; }
		}
		public Boolean _IsSetClaimStatus
		{
			get { return _isSetClaimStatus; }
		}
	}
	[Serializable]
	public class ClaimStatusData
	{
		private int _claimStatusID;
		private string _claimStatus;
		public int ClaimStatusID
		{
			get{ return _claimStatusID; }
			set{ _claimStatusID = value; }
		}
		public string ClaimStatus
		{
			get{ return _claimStatus; }
			set{ _claimStatus = value; }
		}
	}
	[Serializable]
	public class ClaimStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ClaimStatusRow[] claimStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ClaimStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ClaimStatusItems : ClaimStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ClaimStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ClaimStatusItems[] claimStatusItems { get; set; }
	}
}

