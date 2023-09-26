using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System.Collections.Generic;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class CreditScoringService
    {
        public List<CreditScoring> GetCreditScoring(int caseTypeID = 0) 
        {
            List<CreditScoring> creditScore = new List<CreditScoring>();
            ScoreTopicCollection_Base scoreTopic = new ScoreTopicCollection_Base(CSystems.ProcessID);
            ScoreTopicRow[] topicRow = null;
            if (caseTypeID > 0)
            {
                topicRow = scoreTopic.GetByJFCaseTypeID(caseTypeID);
            }
            else {
                topicRow = scoreTopic.GetAll();
            }  
            if (topicRow.Length > 0) 
            {                
                foreach (var item in topicRow)
                {
                    CreditScoring creditData = new CreditScoring();  
                    //set ScoreTopic
                    creditData.ScoreTopic = new ScoreTopicData { 
                        TopicID = item.TopicID,
                        Topic = item.Topic,
                        JFCaseTypeID = item.JFCaseTypeID,
                        Score = item.Score,
                        IsActive = item.IsActive,
                        IsOnlyOne = item.IsOnlyOne
                    };
                    //get ScoreChoice
                    ScoreChoiceCollection_Base scoreChoice = new ScoreChoiceCollection_Base(CSystems.ProcessID);
                    creditData.ScoreChoice = scoreChoice.GetByTopicID(item.TopicID);
                    scoreChoice.Dispose();
                    creditScore.Add(creditData);
                }
            }      
            return creditScore;
        }

    }
}
