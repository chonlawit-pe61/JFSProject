using Megazy.StarterKit.Engine.Dal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Megazy.StarterKit.Engine.Structure
{
    [Serializable]
    public class UserRenewTicketRow
    {
        private int _ticketID;
        private bool _isSetTicketID = false;
        private int _issueBy;
        private bool _isSetIssueBy = false;
        private DateTime _issueDate;
        private bool _isSetIssueDate = false;
        private bool _issueDateNull = true;
        private string _token;
        private bool _isSetToken = false;
        private DateTime _expireDate;
        private bool _isSetExpireDate = false;
        private bool _expireDateNull = true;
        private int _userID;
        private bool _isSetUserID = false;
        private string _email;
        private bool _isSetEmail = false;
        private string _renewType;
        private bool _isSetRenewType = false;
        [Required]
        public int TicketID
        {
            get { return _ticketID; }
            set
            {
                _ticketID = value;
                _isSetTicketID = true;
            }
        }
        public bool _IsSetTicketID
        {
            get { return _isSetTicketID; }
        }
        [Required]
        public int IssueBy
        {
            get { return _issueBy; }
            set
            {
                _issueBy = value;
                _isSetIssueBy = true;
            }
        }
        public bool _IsSetIssueBy
        {
            get { return _isSetIssueBy; }
        }
        [Required]
        public DateTime IssueDate
        {
            get { return _issueDate; }
            set
            {
                _issueDate = value;
                _issueDateNull = false;
                _isSetIssueDate = true;
            }
        }
        public bool IsIssueDateNull
        {
            get
            {
                return _issueDateNull;
            }
            set { _issueDateNull = value; }
        }
        public bool _IsSetIssueDate
        {
            get { return _isSetIssueDate; }
        }
        [Required]
        public string Token
        {
            get { return _token; }
            set
            {
                _token = value;
                _isSetToken = true;
            }
        }
        public bool _IsSetToken
        {
            get { return _isSetToken; }
        }
        [Required]
        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set
            {
                _expireDate = value;
                _expireDateNull = false;
                _isSetExpireDate = true;
            }
        }
        public bool IsExpireDateNull
        {
            get
            {
                return _expireDateNull;
            }
            set { _expireDateNull = value; }
        }
        public bool _IsSetExpireDate
        {
            get { return _isSetExpireDate; }
        }
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
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                _isSetEmail = true;
            }
        }
        public bool _IsSetEmail
        {
            get { return _isSetEmail; }
        }
        [Required]
        public string RenewType
        {
            get { return _renewType; }
            set
            {
                _renewType = value;
                _isSetRenewType = true;
            }
        }
        public bool _IsSetRenewType
        {
            get { return _isSetRenewType; }
        }
    }
    [Serializable]
    public class UserRenewTicketData
    {
        private int _ticketID;
        private int _issueBy;
        private DateTime _issueDate;
        private string _token;
        private DateTime _expireDate;
        private int _userID;
        private string _email;
        private string _renewType;
        public int TicketID
        {
            get { return _ticketID; }
            set { _ticketID = value; }
        }
        public int IssueBy
        {
            get { return _issueBy; }
            set { _issueBy = value; }
        }
        public DateTime IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value; }
        }
        public string IssueDateStr { get; set; }
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set { _expireDate = value; }
        }
        public string ExpireDateStr { get; set; }
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string RenewType
        {
            get { return _renewType; }
            set { _renewType = value; }
        }
    }
    [Serializable]
    public class UserRenewTicketPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public UserRenewTicketRow[] userRenewTicketRow { get; set; }
    }
    /// <summary>
    /// ส่วนขยายคลาส UserRenewTicketItemsPaging เพิ่ม RowRank
    /// </summary>
    [Serializable]
    public class UserRenewTicketItems : UserRenewTicketData
    {
        public int RowRank { get; set; }
    }
    /// <summary>
    /// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
    /// </summary>
    public class UserRenewTicketItemsPaging
    {
        public int totalPage { get; set; }
        public int totalRow { get; set; }
        public UserRenewTicketItems[] userRenewTicketItems { get; set; }
    }
}

