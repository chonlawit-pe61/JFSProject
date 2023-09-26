using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ChequeReturnedResonsRow
	{
		private string _chequeReturnedResonscode;
		private bool _isSetChequeReturnedResonsCode = false;
		private string _chequeReturnedResonsName;
		private bool _isSetChequeReturnedResonsName = false;
		private string _retureType;
		private bool _isSetRetureType = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		/// <summary>
		/// รหัสเหตุผลยกเลิกเช็ค
		/// </summary>
		[Required]
		public string ChequeReturnedResonsCode
		{
			get { return _chequeReturnedResonscode; }
			set { _chequeReturnedResonscode = value;
			      _isSetChequeReturnedResonsCode = true; }
		}
		public bool _IsSetChequeReturnedResonsCode
		{
			get { return _isSetChequeReturnedResonsCode; }
		}
		/// <summary>
		/// เหตุผลยกเลิกหรือไม่ได้ใช้เช็ค
		/// </summary>
		public string ChequeReturnedResonsName
		{
			get { return _chequeReturnedResonsName; }
			set { _chequeReturnedResonsName = value;
			      _isSetChequeReturnedResonsName = true; }
		}
		public bool _IsSetChequeReturnedResonsName
		{
			get { return _isSetChequeReturnedResonsName; }
		}
		/// <summary>
		/// ประเภทการคืนเช็ก เช่น CANCEL,NOTUSED
		/// </summary>
		public string RetureType
		{
			get { return _retureType; }
			set { _retureType = value;
			      _isSetRetureType = true; }
		}
		public bool _IsSetRetureType
		{
			get { return _isSetRetureType; }
		}
		/// <summary>
		/// สถานะเปิดปิดการใช้งาน 1=เปิด 0= ปิดการใช้งาน
		/// </summary>
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
	}
	[Serializable]
	public class ChequeReturnedResonsData
	{
		private string _chequeReturnedResonscode;
		private string _chequeReturnedResonsName;
		private string _retureType;
		private bool _isActive;
		/// <summary>
		/// รหัสเหตุผลยกเลิกเช็ค
		/// </summary>
		public string ChequeReturnedResonsCode
		{
			get{ return _chequeReturnedResonscode; }
			set{ _chequeReturnedResonscode = value; }
		}
		/// <summary>
		/// เหตุผลยกเลิกหรือไม่ได้ใช้เช็ค
		/// </summary>
		public string ChequeReturnedResonsName
		{
			get{ return _chequeReturnedResonsName; }
			set{ _chequeReturnedResonsName = value; }
		}
		/// <summary>
		/// ประเภทการคืนเช็ก เช่น CANCEL,NOTUSED
		/// </summary>
		public string RetureType
		{
			get{ return _retureType; }
			set{ _retureType = value; }
		}
		/// <summary>
		/// สถานะเปิดปิดการใช้งาน 1=เปิด 0= ปิดการใช้งาน
		/// </summary>
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class ChequeReturnedResonsPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ChequeReturnedResonsRow[] chequeReturnedResonsRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ChequeReturnedResonsItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ChequeReturnedResonsItems : ChequeReturnedResonsData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ChequeReturnedResonsItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ChequeReturnedResonsItems[] chequeReturnedResonsItems { get; set; }
	}
}

