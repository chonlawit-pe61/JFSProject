using Megazy.StarterKit.Engine.Dal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Megazy.StarterKit.Engine.Structure
{
    [Serializable]
    public class View_UserModulePermissionRow
    {
        private int _userID;
        private bool _isSetUserID = false;
        private int _permissionID;
        private bool _isSetPermissionID = false;
        private int _moduleID;
        private bool _isSetModuleID = false;
        private bool _moduleIDNull = true;
        private string _permissionName;
        private bool _isSetPermissionName = false;
        [Required]
        public int UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                _isSetUserID = true;
            }
        }
        public bool _IsSetUserID
        {
            get { return _isSetUserID; }
        }
        [Required]
        public int PermissionID
        {
            get { return _permissionID; }
            set
            {
                _permissionID = value;
                _isSetPermissionID = true;
            }
        }
        public bool _IsSetPermissionID
        {
            get { return _isSetPermissionID; }
        }
        public int ModuleID
        {
            get
            {
                return _moduleID;
            }
            set
            {
                _moduleIDNull = false;
                _isSetModuleID = true;
                _moduleID = value;
            }
        }
        public bool IsModuleIDNull
        {
            get
            {
                return _moduleIDNull;
            }
            set { _moduleIDNull = value; }
        }
        public bool _IsSetModuleID
        {
            get { return _isSetModuleID; }
        }
        public string PermissionName
        {
            get { return _permissionName; }
            set
            {
                _permissionName = value;
                _isSetPermissionName = true;
            }
        }
        public bool _IsSetPermissionName
        {
            get { return _isSetPermissionName; }
        }
    }
    [Serializable]
    public class View_UserModulePermissionData
    {
        private int _userID;
        private int _permissionID;
        private int _moduleID;
        private string _permissionName;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public int PermissionID
        {
            get { return _permissionID; }
            set { _permissionID = value; }
        }
        public int ModuleID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }
        public string PermissionName
        {
            get { return _permissionName; }
            set { _permissionName = value; }
        }
    }
    [Serializable]
    public class View_UserModulePermissionPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public View_UserModulePermissionRow[] view_UserModulePermissionRow { get; set; }
    }
    /// <summary>
    /// ส่วนขยายคลาส View_UserModulePermissionItemsPaging เพิ่ม RowRank
    /// </summary>
    [Serializable]
    public class View_UserModulePermissionItems : View_UserModulePermissionData
    {
        public int RowRank { get; set; }
    }
    /// <summary>
    /// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
    /// </summary>
    public class View_UserModulePermissionItemsPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public View_UserModulePermissionItems[] view_UserModulePermissionItems { get; set; }
    }
}

