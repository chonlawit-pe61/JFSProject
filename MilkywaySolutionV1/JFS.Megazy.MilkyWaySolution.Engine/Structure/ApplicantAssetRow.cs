using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantAssetRow
	{
		private int _assetID;
		private bool _isSetAssetID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private string _asset;
		private bool _isSetAsset = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int AssetID
		{
			get { return _assetID; }
			set { _assetID = value;
			      _isSetAssetID = true; }
		}
		public bool _IsSetAssetID
		{
			get { return _isSetAssetID; }
		}
		public int ApplicantID
		{
			get
			{
				return _applicantID;
			}
			set
			{
				_applicantIDNull = false;
				_isSetApplicantID = true;
				_applicantID = value;
			}
		}
		public bool IsApplicantIDNull
		{
			get {
				 return _applicantIDNull; }
			set { _applicantIDNull = value; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public string Asset
		{
			get { return _asset; }
			set { _asset = value;
			      _isSetAsset = true; }
		}
		public bool _IsSetAsset
		{
			get { return _isSetAsset; }
		}
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				_modifiedDateNull = false;
				_isSetModifiedDate = true;
				_modifiedDate = value;
			}
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
	public class ApplicantAssetData
	{
		private int _assetID;
		private int _applicantID;
		private string _asset;
		private DateTime _modifiedDate;
		public int AssetID
		{
			get{ return _assetID; }
			set{ _assetID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public string Asset
		{
			get{ return _asset; }
			set{ _asset = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantAssetPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantAssetRow[] applicantassetRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantAssetItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantAssetItems : ApplicantAssetData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantAssetItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantAssetItems[] applicantassetItems { get; set; }
	}
}

