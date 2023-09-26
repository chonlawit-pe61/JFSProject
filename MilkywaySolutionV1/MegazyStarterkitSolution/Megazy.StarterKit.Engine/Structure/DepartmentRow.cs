using Megazy.StarterKit.Engine.Dal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Megazy.StarterKit.Engine.Structure
{
    [Serializable]
    public class DepartmentRow
    {
        private int _departmentId;
        private bool _isSetDepartmentID = false;
        private int _provinceID;
        private bool _isSetProvinceID = false;
        private string _departmentName;
        private bool _isSetDepartmentName = false;
        private string _departmentNameAbbr;
        private bool _isSetDepartmentNameAbbr = false;
        private string _departmentCode;
        private bool _isSetDepartmentCode = false;
        private bool _isActive;
        private bool _isSetIsActive = false;
        private bool _isActiveNull = true;
        private DateTime _modifiedDate;
        private bool _isSetModifiedDate = false;
        private bool _modifiedDateNull = true;
        private int _sortOder;
        private bool _isSetSortOder = false;
        private bool _sortOderNull = true;
        [Required]
        public int DepartmentID
        {
            get { return _departmentId; }
            set
            {
                _departmentId = value;
                _isSetDepartmentID = true;
            }
        }
        public bool _IsSetDepartmentID
        {
            get { return _isSetDepartmentID; }
        }
        [Required]
        public int ProvinceID
        {
            get { return _provinceID; }
            set
            {
                _provinceID = value;
                _isSetProvinceID = true;
            }
        }
        public bool _IsSetProvinceID
        {
            get { return _isSetProvinceID; }
        }
        [Required]
        public string DepartmentName
        {
            get { return _departmentName; }
            set
            {
                _departmentName = value;
                _isSetDepartmentName = true;
            }
        }
        public bool _IsSetDepartmentName
        {
            get { return _isSetDepartmentName; }
        }
        [Required]
        public string DepartmentNameAbbr
        {
            get { return _departmentNameAbbr; }
            set
            {
                _departmentNameAbbr = value;
                _isSetDepartmentNameAbbr = true;
            }
        }
        public bool _IsSetDepartmentNameAbbr
        {
            get { return _isSetDepartmentNameAbbr; }
        }
        public string DepartmentCode
        {
            get { return _departmentCode; }
            set
            {
                _departmentCode = value;
                _isSetDepartmentCode = true;
            }
        }
        public bool _IsSetDepartmentCode
        {
            get { return _isSetDepartmentCode; }
        }
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
            get
            {
                return _isActiveNull;
            }
            set { _isActiveNull = value; }
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
        public int SortOder
        {
            get
            {
                return _sortOder;
            }
            set
            {
                _sortOderNull = false;
                _isSetSortOder = true;
                _sortOder = value;
            }
        }
        public bool IsSortOderNull
        {
            get
            {
                return _sortOderNull;
            }
            set { _sortOderNull = value; }
        }
        public bool _IsSetSortOder
        {
            get { return _isSetSortOder; }
        }
    }
    [Serializable]
    public class DepartmentData
    {
        private int _departmentId;
        private int _provinceID;
        private string _departmentName;
        private string _departmentNameAbbr;
        private string _departmentCode;
        private bool _isActive;
        private DateTime _modifiedDate;
        private int _sortOder;
        public int DepartmentID
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
        public int ProvinceID
        {
            get { return _provinceID; }
            set { _provinceID = value; }
        }
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }
        public string DepartmentNameAbbr
        {
            get { return _departmentNameAbbr; }
            set { _departmentNameAbbr = value; }
        }
        public string DepartmentCode
        {
            get { return _departmentCode; }
            set { _departmentCode = value; }
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
        public int SortOder
        {
            get { return _sortOder; }
            set { _sortOder = value; }
        }
    }
    [Serializable]
    public class DepartmentPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public DepartmentRow[] departmentRow { get; set; }
    }
    /// <summary>
    /// ส่วนขยายคลาส DepartmentItemsPaging เพิ่ม RowRank
    /// </summary>
    [Serializable]
    public class DepartmentItems : DepartmentData
    {
        public int RowRank { get; set; }
    }
    /// <summary>
    /// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
    /// </summary>
    public class DepartmentItemsPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public DepartmentItems[] departmentItems { get; set; }
    }
}

