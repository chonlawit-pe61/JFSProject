using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class CreditScoring
    {
        public ScoreTopicData ScoreTopic { get; set; }
        public ScoreChoiceRow[] ScoreChoice { get; set; }
    }



    public class ScoreTopic 
    {
        public int TopicID { get; set; }
        public int JFCaseTypeID { get; set; }
        public string Topic { get; set; }
        public int Score { get; set; }
        
    }


    public class ScoreChoice
    {

        public int ChoiceID { get; set; }
        public int TopicID { get; set; }
        public string Choice { get; set; }
        public float Score { get; set; }
       

    }


}
