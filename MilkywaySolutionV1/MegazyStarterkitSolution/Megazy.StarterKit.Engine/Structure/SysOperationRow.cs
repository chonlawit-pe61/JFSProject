using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Engine.Dal;
namespace Megazy.StarterKit.Engine.Structure
{
	[Serializable]
	public class SysOperationRow
	{
		private int _operationID;
		private bool _isSetOperationID = false;
		private string _operationName;
		private bool _isSetOperationName = false;
		private bool _isCreate;
		private bool _isSetIsCreate = false;
		private bool _isCreateNull = true;
		private bool _isRead;
		private bool _isSetIsRead = false;
		private bool _isReadNull = true;
		private bool _isUpdate;
		private bool _isSetIsUpdate = false;
		private bool _isUpdateNull = true;
		private bool _isDelete;
		private bool _isSetIsDelete = false;
		private bool _isDeleteNull = true;
		private bool _isLock;
		private bool _isSetIsLock = false;
		private bool _isLockNull = true;
		[Required]
		public int OperationID
		{
			get { return _operationID; }
			set { _operationID = value;
			      _isSetOperationID = true; }
		}
		public bool _IsSetOperationID
		{
			get { return _isSetOperationID; }
		}
		public string OperationName
		{
			get { return _operationName; }
			set { _operationName = value;
			      _isSetOperationName = true; }
		}
		public bool _IsSetOperationName
		{
			get { return _isSetOperationName; }
		}
		public bool IsCreate
		{
			get
			{
				return _isCreate;
			}
			set
			{
				_isCreateNull = false;
				_isSetIsCreate = true;
				_isCreate = value;
			}
		}
		public bool IsIsCreateNull
		{
			get {
				 return _isCreateNull; }
			set { _isCreateNull = value; }
		}
		public bool _IsSetIsCreate
		{
			get { return _isSetIsCreate; }
		}
		public bool IsRead
		{
			get
			{
				return _isRead;
			}
			set
			{
				_isReadNull = false;
				_isSetIsRead = true;
				_isRead = value;
			}
		}
		public bool IsIsReadNull
		{
			get {
				 return _isReadNull; }
			set { _isReadNull = value; }
		}
		public bool _IsSetIsRead
		{
			get { return _isSetIsRead; }
		}
		public bool IsUpdate
		{
			get
			{
				return _isUpdate;
			}
			set
			{
				_isUpdateNull = false;
				_isSetIsUpdate = true;
				_isUpdate = value;
			}
		}
		public bool IsIsUpdateNull
		{
			get {
				 return _isUpdateNull; }
			set { _isUpdateNull = value; }
		}
		public bool _IsSetIsUpdate
		{
			get { return _isSetIsUpdate; }
		}
		public bool IsDelete
		{
			get
			{
				return _isDelete;
			}
			set
			{
				_isDeleteNull = false;
				_isSetIsDelete = true;
				_isDelete = value;
			}
		}
		public bool IsIsDeleteNull
		{
			get {
				 return _isDeleteNull; }
			set { _isDeleteNull = value; }
		}
		public bool _IsSetIsDelete
		{
			get { return _isSetIsDelete; }
		}
		public bool IsLock
		{
			get
			{
				return _isLock;
			}
			set
			{
				_isLockNull = false;
				_isSetIsLock = true;
				_isLock = value;
			}
		}
		public bool IsIsLockNull
		{
			get {
				 return _isLockNull; }
			set { _isLockNull = value; }
		}
		public bool _IsSetIsLock
		{
			get { return _isSetIsLock; }
		}
	}
	[Serializable]
	public class SysOperationData
	{
		private int _operationID;
		private string _operationName;
		private bool _isCreate;
		private bool _isRead;
		private bool _isUpdate;
		private bool _isDelete;
		private bool _isLock;
		public int OperationID
		{
			get{ return _operationID; }
			set{ _operationID = value; }
		}
		public string OperationName
		{
			get{ return _operationName; }
			set{ _operationName = value; }
		}
		public bool IsCreate
		{
			get{ return _isCreate; }
			set{ _isCreate = value; }
		}
		public bool IsRead
		{
			get{ return _isRead; }
			set{ _isRead = value; }
		}
		public bool IsUpdate
		{
			get{ return _isUpdate; }
			set{ _isUpdate = value; }
		}
		public bool IsDelete
		{
			get{ return _isDelete; }
			set{ _isDelete = value; }
		}
		public bool IsLock
		{
			get{ return _isLock; }
			set{ _isLock = value; }
		}
	}
	[Serializable]
	public class SysOperationPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SysOperationRow[] sysOperationRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SysOperationItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SysOperationItems : SysOperationData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SysOperationItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SysOperationItems[] sysOperationItems { get; set; }
	}
}

