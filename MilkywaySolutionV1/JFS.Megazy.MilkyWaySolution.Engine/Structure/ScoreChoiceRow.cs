using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ScoreChoiceRow
	{
		private int _choiceID;
		private bool _isSetChoiceID = false;
		private int _topicID;
		private bool _isSetTopicID = false;
		private bool _topicIDNull = true;
		private string _choice;
		private bool _isSetChoice = false;
		private double _score;
		private bool _isSetScore = false;
		private bool _scoreNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int ChoiceID
		{
			get { return _choiceID; }
			set { _choiceID = value;
			      _isSetChoiceID = true; }
		}
		public bool _IsSetChoiceID
		{
			get { return _isSetChoiceID; }
		}
		public int TopicID
		{
			get
			{
				return _topicID;
			}
			set
			{
				_topicIDNull = false;
				_isSetTopicID = true;
				_topicID = value;
			}
		}
		public bool IsTopicIDNull
		{
			get {
				 return _topicIDNull; }
			set { _topicIDNull = value; }
		}
		public bool _IsSetTopicID
		{
			get { return _isSetTopicID; }
		}
		public string Choice
		{
			get { return _choice; }
			set { _choice = value;
			      _isSetChoice = true; }
		}
		public bool _IsSetChoice
		{
			get { return _isSetChoice; }
		}
		public double Score
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
	}
	[Serializable]
	public class ScoreChoiceData
	{
		private int _choiceID;
		private int _topicID;
		private string _choice;
		private double _score;
		private DateTime _modifiedDate;
		private bool _isActive;
		public int ChoiceID
		{
			get{ return _choiceID; }
			set{ _choiceID = value; }
		}
		public int TopicID
		{
			get{ return _topicID; }
			set{ _topicID = value; }
		}
		public string Choice
		{
			get{ return _choice; }
			set{ _choice = value; }
		}
		public double Score
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
	}
	[Serializable]
	public class ScoreChoicePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ScoreChoiceRow[] scoreChoiceRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ScoreChoiceItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ScoreChoiceItems : ScoreChoiceData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ScoreChoiceItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ScoreChoiceItems[] scoreChoiceItems { get; set; }
	}
}

