using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class Inbox
    {
        public int InboxID { get; set; }
    }
    public class InboxDetail : Inbox
    {
        public bool IsRead { get; set; }
        public string MessageType { get; set; }
        public string Subject { get; set; }
        public string ExternalLink { get; set; }
        public bool IsActive { get; set; }
        public string PublishDate { get; set; }
        public int UserID { get; set; }
    }


    public class InboxDataRequest : InboxData
    {
        public int[] UserID { get; set; }
        public InboxDetailData detailData { get; set; }
    }
}
