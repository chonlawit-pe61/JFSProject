using Megazy.StarterKit.Engine.Dal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Megazy.StarterKit.Engine.Structure
{
    [Serializable]
    public class UserLoginHistoryRow
    {
        private int _logID;
        private bool _isSetLogID = false;
        private int _userID;
        private bool _isSetUserID = false;
        private bool _userIDNull = true;
        private string _iP;
        private bool _isSetIP = false;
        private string _deviceType;
        private bool _isSetDeviceType = false;
        private DateTime _loginDate;
        private bool _isSetLoginDate = false;
        private bool _loginDateNull = true;
        [Required]
        public int LogID
        {
            get { return _logID; }
            set
            {
                _logID = value;
                _isSetLogID = true;
            }
        }
        public bool _IsSetLogID
        {
            get { return _isSetLogID; }
        }
        public int UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userIDNull = false;
                _isSetUserID = true;
                _userID = value;
            }
        }
        public bool IsUserIDNull
        {
            get
            {
                return _userIDNull;
            }
            set { _userIDNull = value; }
        }
        public bool _IsSetUserID
        {
            get { return _isSetUserID; }
        }
        public string IP
        {
            get { return _iP; }
            set
            {
                _iP = value;
                _isSetIP = true;
            }
        }
        public bool _IsSetIP
        {
            get { return _isSetIP; }
        }
        public string DeviceType
        {
            get { return _deviceType; }
            set
            {
                _deviceType = value;
                _isSetDeviceType = true;
            }
        }
        public bool _IsSetDeviceType
        {
            get { return _isSetDeviceType; }
        }
        public DateTime LoginDate
        {
            get
            {
                return _loginDate;
            }
            set
            {
                _loginDateNull = false;
                _isSetLoginDate = true;
                _loginDate = value;
            }
        }
        public bool IsLoginDateNull
        {
            get
            {
                return _loginDateNull;
            }
            set { _loginDateNull = value; }
        }
        public bool _IsSetLoginDate
        {
            get { return _isSetLoginDate; }
        }
    }
    [Serializable]
    public class UserLoginHistoryData
    {
        private int _logID;
        private int _userID;
        private string _iP;
        private string _deviceType;
        private DateTime _loginDate;
        public int LogID
        {
            get { return _logID; }
            set { _logID = value; }
        }
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string IP
        {
            get { return _iP; }
            set { _iP = value; }
        }
        public string DeviceType
        {
            get { return _deviceType; }
            set { _deviceType = value; }
        }
        public DateTime LoginDate
        {
            get { return _loginDate; }
            set { _loginDate = value; }
        }
        public string LoginDateStr { get; set; }
    }
    [Serializable]
    public class UserLoginHistoryPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public UserLoginHistoryRow[] userLoginHistoryRow { get; set; }
    }
    /// <summary>
    /// ส่วนขยายคลาส UserLoginHistoryItemsPaging เพิ่ม RowRank
    /// </summary>
    [Serializable]
    public class UserLoginHistoryItems : UserLoginHistoryData
    {
        public int RowRank { get; set; }
    }
    /// <summary>
    /// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
    /// </summary>
    public class UserLoginHistoryItemsPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public UserLoginHistoryItems[] userLoginHistoryItems { get; set; }
    }
}

