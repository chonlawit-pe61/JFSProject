using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ScoreTopicRow
	{
		private int _topicID;
		private bool _isSetTopicID = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private bool _jFCaseTypeIDNull = true;
		private string _topic;
		private bool _isSetTopic = false;
		private int _score;
		private bool _isSetScore = false;
		private bool _scoreNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private bool _isOnlyOne;
		private bool _isSetIsOnlyOne = false;
		private bool _isOnlyOneNull = true;
		[Required]
		public int TopicID
		{
			get { return _topicID; }
			set { _topicID = value;
			      _isSetTopicID = true; }
		}
		public bool _IsSetTopicID
		{
			get { return _isSetTopicID; }
		}
		public int JFCaseTypeID
		{
			get
			{
				return _jFCaseTypeID;
			}
			set
			{
				_jFCaseTypeIDNull = false;
				_isSetJFCaseTypeID = true;
				_jFCaseTypeID = value;
			}
		}
		public bool IsJFCaseTypeIDNull
		{
			get {
				 return _jFCaseTypeIDNull; }
			set { _jFCaseTypeIDNull = value; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		public string Topic
		{
			get { return _topic; }
			set { _topic = value;
			      _isSetTopic = true; }
		}
		public bool _IsSetTopic
		{
			get { return _isSetTopic; }
		}
		public int Score
		{
			get
			{
				return _score;
			}
			set
			{
				_scoreNull = false;
				_isSetScore = true;
				_score = value;
			}
		}
		public bool IsScoreNull
		{
			get {
				 return _scoreNull; }
			set { _scoreNull = value; }
		}
		public bool _IsSetScore
		{
			get { return _isSetScore; }
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
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public bool _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
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
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public bool IsOnlyOne
		{
			get
			{
				return _isOnlyOne;
			}
			set
			{
				_isOnlyOneNull = false;
				_isSetIsOnlyOne = true;
				_isOnlyOne = value;
			}
		}
		public bool IsIsOnlyOneNull
		{
			get {
				 return _isOnlyOneNull; }
			set { _isOnlyOneNull = value; }
		}
		public bool _IsSetIsOnlyOne
		{
			get { return _isSetIsOnlyOne; }
		}
	}
	[Serializable]
	public class ScoreTopicData
	{
		private int _topicID;
		private int _jFCaseTypeID;
		private string _topic;
		private int _score;
		private DateTime _modifiedDate;
		private bool _isActive;
		private bool _isOnlyOne;
		public int TopicID
		{
			get{ return _topicID; }
			set{ _topicID = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public string Topic
		{
			get{ return _topic; }
			set{ _topic = value; }
		}
		public int Score
		{
			get{ return _score; }
			set{ _score = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public bool IsOnlyOne
		{
			get{ return _isOnlyOne; }
			set{ _isOnlyOne = value; }
		}
	}
	[Serializable]
	public class ScoreTopicPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ScoreTopicRow[] scoreTopicRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ScoreTopicItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ScoreTopicItems : ScoreTopicData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ScoreTopicItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ScoreTopicItems[] scoreTopicItems { get; set; }
	}
}

