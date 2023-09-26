using Megazy.StarterKit.Engine.Dal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Megazy.StarterKit.Engine.Structure
{
    [Serializable]
    public class View_SysScreenRow
    {
        private int _screenID;
        private bool _isSetScreenID = false;
        private int _moduleID;
        private bool _isSetModuleID = false;
        private int _parentScreenID;
        private bool _isSetParentScreenID = false;
        private bool _parentScreenIDNull = true;
        private string _screenName;
        private bool _isSetScreenName = false;
        private string _screenTitle;
        private bool _isSetScreenTitle = false;
        private int _sortOrder;
        private bool _isSetSortOrder = false;
        private bool _isActive;
        private bool _isSetIsActive = false;
        private DateTime _modifiedDate;
        private bool _isSetModifiedDate = false;
        private bool _modifiedDateNull = true;
        private string _subscreen;
        private bool _isSetSubScreen = false;
        [Required]
        public int ScreenID
        {
            get { return _screenID; }
            set
            {
                _screenID = value;
                _isSetScreenID = true;
            }
        }
        public bool _IsSetScreenID
        {
            get { return _isSetScreenID; }
        }
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
        public int ParentScreenID
        {
            get
            {
                return _parentScreenID;
            }
            set
            {
                _parentScreenIDNull = false;
                _isSetParentScreenID = true;
                _parentScreenID = value;
            }
        }
        public bool IsParentScreenIDNull
        {
            get
            {
                return _parentScreenIDNull;
            }
            set { _parentScreenIDNull = value; }
        }
        public bool _IsSetParentScreenID
        {
            get { return _isSetParentScreenID; }
        }
        [Required]
        public string ScreenName
        {
            get { return _screenName; }
            set
            {
                _screenName = value;
                _isSetScreenName = true;
            }
        }
        public bool _IsSetScreenName
        {
            get { return _isSetScreenName; }
        }
        public string ScreenTitle
        {
            get { return _screenTitle; }
            set
            {
                _screenTitle = value;
                _isSetScreenTitle = true;
            }
        }
        public bool _IsSetScreenTitle
        {
            get { return _isSetScreenTitle; }
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
            get
            {
                return _modifiedDateNull;
            }
            set { _modifiedDateNull = value; }
        }
        public bool _IsSetModifiedDate
        {
            get { return _isSetModifiedDate; }
        }
        public string SubScreen
        {
            get { return _subscreen; }
            set
            {
                _subscreen = value;
                _isSetSubScreen = true;
            }
        }
        public bool _IsSetSubScreen
        {
            get { return _isSetSubScreen; }
        }
    }
    [Serializable]
    public class View_SysScreenData
    {
        private int _screenID;
        private int _moduleID;
        private int _parentScreenID;
        private string _screenName;
        private string _screenTitle;
        private int _sortOrder;
        private bool _isActive;
        private DateTime _modifiedDate;
        private string _subscreen;
        public int ScreenID
        {
            get { return _screenID; }
            set { _screenID = value; }
        }
        public int ModuleID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }
        public int ParentScreenID
        {
            get { return _parentScreenID; }
            set { _parentScreenID = value; }
        }
        public string ScreenName
        {
            get { return _screenName; }
            set { _screenName = value; }
        }
        public string ScreenTitle
        {
            get { return _screenTitle; }
            set { _screenTitle = value; }
        }
        public int SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }
        public string ModifiedDateStr { get; set; }
        public string SubScreen
        {
            get { return _subscreen; }
            set { _subscreen = value; }
        }
    }
    [Serializable]
    public class View_SysScreenPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public View_SysScreenRow[] view_SysScreenRow { get; set; }
    }
    /// <summary>
    /// ส่วนขยายคลาส View_SysScreenItemsPaging เพิ่ม RowRank
    /// </summary>
    [Serializable]
    public class View_SysScreenItems : View_SysScreenData
    {
        public int RowRank { get; set; }
    }
    /// <summary>
    /// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
    /// </summary>
    public class View_SysScreenItemsPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public View_SysScreenItems[] view_SysScreenItems { get; set; }
    }
}

