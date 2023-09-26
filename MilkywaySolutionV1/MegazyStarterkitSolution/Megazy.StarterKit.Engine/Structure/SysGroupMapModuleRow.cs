using Megazy.StarterKit.Engine.Dal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Megazy.StarterKit.Engine.Structure
{
    [Serializable]
    public class SysGroupMapModuleRow
    {
        private int _groupID;
        private bool _isSetGroupID = false;
        private int _moduleID;
        private bool _isSetModuleID = false;
        [Required]
        public int GroupID
        {
            get { return _groupID; }
            set
            {
                _groupID = value;
                _isSetGroupID = true;
            }
        }
        public bool _IsSetGroupID
        {
            get { return _isSetGroupID; }
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
    }
    [Serializable]
    public class SysGroupMapModuleData
    {
        private int _groupID;
        private int _moduleID;
        public int GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }
        public int ModuleID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }
    }
    [Serializable]
    public class SysGroupMapModulePaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public SysGroupMapModuleRow[] sysGroupMapModuleRow { get; set; }
    }
    /// <summary>
    /// ส่วนขยายคลาส SysGroupMapModuleItemsPaging เพิ่ม RowRank
    /// </summary>
    [Serializable]
    public class SysGroupMapModuleItems : SysGroupMapModuleData
    {
        public int RowRank { get; set; }
    }
    /// <summary>
    /// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
    /// </summary>
    public class SysGroupMapModuleItemsPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public SysGroupMapModuleItems[] sysGroupMapModuleItems { get; set; }
    }
}

