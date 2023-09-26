using Megazy.StarterKit.Engine.Dal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Megazy.StarterKit.Engine.Structure
{
    [Serializable]
    public class View_RolePermissionRow
    {
        private int _moduleID;
        private bool _isSetModuleID = false;
        private string _moduleName;
        private bool _isSetModuleName = false;
        private string _moduleTitle;
        private bool _isSetModuleTitle = false;
        private bool _isActive;
        private bool _isSetIsActive = false;
        private int _sortOrder;
        private bool _isSetSortOrder = false;
        private string _moduleIcon;
        private bool _isSetModuleIcon = false;
        private string _permission;
        private bool _isSetPermission = false;
        [Required]
        public int ModuleID
        {
            get { return _moduleID; }
            set
            {
                _moduleID = value;
                _isSetModuleID = true;
            }
        }
        public bool _IsSetModuleID
        {
            get { return _isSetModuleID; }
        }
        [Required]
        public string ModuleName
        {
            get { return _moduleName; }
            set
            {
                _moduleName = value;
                _isSetModuleName = true;
            }
        }
        public bool _IsSetModuleName
        {
            get { return _isSetModuleName; }
        }
        [Required]
        public string ModuleTitle
        {
            get { return _moduleTitle; }
            set
            {
                _moduleTitle = value;
                _isSetModuleTitle = true;
            }
        }
        public bool _IsSetModuleTitle
        {
            get { return _isSetModuleTitle; }
        }
        [Required]
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                _isSetIsActive = true;
            }
        }
        public bool _IsSetIsActive
        {
            get { return _isSetIsActive; }
        }
        [Required]
        public int SortOrder
        {
            get { return _sortOrder; }
            set
            {
                _sortOrder = value;
                _isSetSortOrder = true;
            }
        }
        public bool _IsSetSortOrder
        {
            get { return _isSetSortOrder; }
        }
        public string ModuleIcon
        {
            get { return _moduleIcon; }
            set
            {
                _moduleIcon = value;
                _isSetModuleIcon = true;
            }
        }
        public bool _IsSetModuleIcon
        {
            get { return _isSetModuleIcon; }
        }
        public string Permission
        {
            get { return _permission; }
            set
            {
                _permission = value;
                _isSetPermission = true;
            }
        }
        public bool _IsSetPermission
        {
            get { return _isSetPermission; }
        }
    }
    [Serializable]
    public class View_RolePermissionData
    {
        private int _moduleID;
        private string _moduleName;
        private string _moduleTitle;
        private bool _isActive;
        private int _sortOrder;
        private string _moduleIcon;
        private string _permission;
        public int ModuleID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }
        public string ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }
        public string ModuleTitle
        {
            get { return _moduleTitle; }
            set { _moduleTitle = value; }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public int SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }
        public string ModuleIcon
        {
            get { return _moduleIcon; }
            set { _moduleIcon = value; }
        }
        public string Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }
    }
    [Serializable]
    public class View_RolePermissionPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public View_RolePermissionRow[] view_RolePermissionRow { get; set; }
    }
    /// <summary>
    /// ส่วนขยายคลาส View_RolePermissionItemsPaging เพิ่ม RowRank
    /// </summary>
    [Serializable]
    public class View_RolePermissionItems : View_RolePermissionData
    {
        public int RowRank { get; set; }
    }
    /// <summary>
    /// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
    /// </summary>
    public class View_RolePermissionItemsPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public View_RolePermissionItems[] view_RolePermissionItems { get; set; }
    }
}

