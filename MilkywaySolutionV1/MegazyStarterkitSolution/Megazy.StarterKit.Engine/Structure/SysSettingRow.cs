using Megazy.StarterKit.Engine.Dal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Megazy.StarterKit.Engine.Structure
{
    [Serializable]
    public class SysSettingRow
    {
        private int _settingID;
        private bool _isSetSettingID = false;
        private string _tag;
        private bool _isSetTag = false;
        private string _key;
        private bool _isSetKey = false;
        private string _label;
        private bool _isSetLabel = false;
        private string _value;
        private bool _isSetValue = false;
        [Required]
        public int SettingID
        {
            get { return _settingID; }
            set
            {
                _settingID = value;
                _isSetSettingID = true;
            }
        }
        public bool _IsSetSettingID
        {
            get { return _isSetSettingID; }
        }
        [Required]
        public string Tag
        {
            get { return _tag; }
            set
            {
                _tag = value;
                _isSetTag = true;
            }
        }
        public bool _IsSetTag
        {
            get { return _isSetTag; }
        }
        [Required]
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                _isSetKey = true;
            }
        }
        public bool _IsSetKey
        {
            get { return _isSetKey; }
        }
        [Required]
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                _isSetLabel = true;
            }
        }
        public bool _IsSetLabel
        {
            get { return _isSetLabel; }
        }
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                _isSetValue = true;
            }
        }
        public bool _IsSetValue
        {
            get { return _isSetValue; }
        }
    }
    [Serializable]
    public class SysSettingData
    {
        private int _settingID;
        private string _tag;
        private string _key;
        private string _label;
        private string _value;
        public int SettingID
        {
            get { return _settingID; }
            set { _settingID = value; }
        }
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
    [Serializable]
    public class SysSettingPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public SysSettingRow[] syssettingRow { get; set; }
    }
    /// <summary>
    /// ส่วนขยายคลาส SysSettingItemsPaging เพิ่ม RowRank
    /// </summary>
    [Serializable]
    public class SysSettingItems : SysSettingData
    {
        public int RowRank { get; set; }
    }
    /// <summary>
    /// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
    /// </summary>
    public class SysSettingItemsPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public SysSettingItems[] syssettingItems { get; set; }
    }
}

