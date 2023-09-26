using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseProjectRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _proposerTypeID;
		private bool _isSetProposerTypeID = false;
		private bool _proposerTypeIDNull = true;
		private string _proposerTypeOther;
		private bool _isSetProposerTypeOther = false;
		private bool _proposerTypeOtherNull = true;
		private string _projectNameLocation;
		private bool _isSetProjectNameLocation = false;
		private bool _projectNameLocationNull = true;
		private string _projectTitle;
		private bool _isSetProjectTitle = false;
		private bool _projectTitleNull = true;
		private string _proposerEN;
		private bool _isSetProposerEN = false;
		private bool _proposerENNull = true;
		private string _objectiveToHelp;
		private bool _isSetObjectiveToHelp = false;
		private bool _objectiveToHelpNull = true;
		private string _projectInAction;
		private bool _isSetProjectInAction = false;
		private bool _projectInActionNull = true;
		private string _portfolio;
		private bool _isSetPortfolio = false;
		private bool _portfolioNull = true;
		private string _projectObjective;
		private bool _isSetProjectObjective = false;
		private bool _projectObjectiveNull = true;
		private string _projectResult;
		private bool _isSetProjectResult = false;
		private bool _projectResultNull = true;
		private string _projectTarget;
		private bool _isSetProjectTarget = false;
		private bool _projectTargetNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isMapRecord = false;
			      _isSetCaseID = true; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		public int ProposerTypeID
		{
			get
			{
				return _proposerTypeID;
			}
			set
			{
				_proposerTypeIDNull = false;
				_isSetProposerTypeID = true;
				_proposerTypeID = value;
				_isMapRecord = false;
			}
		}
		public bool IsProposerTypeIDNull
		{
			get {
				 return _proposerTypeIDNull; }
			set { _proposerTypeIDNull = value; }
		}
		public Boolean _IsSetProposerTypeID
		{
			get { return _isSetProposerTypeID; }
		}
		public string ProposerTypeOther
		{
			get
			{
				return _proposerTypeOther;
			}
			set
			{
				_proposerTypeOtherNull = false;
				_isSetProposerTypeOther = true;
				_proposerTypeOther = value;
				_isMapRecord = false;
			}
		}
		public bool IsProposerTypeOtherNull
		{
			get {
				 return _proposerTypeOtherNull; }
			set { _proposerTypeOtherNull = value; }
		}
		public Boolean _IsSetProposerTypeOther
		{
			get { return _isSetProposerTypeOther; }
		}
		public string ProjectNameLocation
		{
			get
			{
				return _projectNameLocation;
			}
			set
			{
				_projectNameLocationNull = false;
				_isSetProjectNameLocation = true;
				_projectNameLocation = value;
				_isMapRecord = false;
			}
		}
		public bool IsProjectNameLocationNull
		{
			get {
				 return _projectNameLocationNull; }
			set { _projectNameLocationNull = value; }
		}
		public Boolean _IsSetProjectNameLocation
		{
			get { return _isSetProjectNameLocation; }
		}
		public string ProjectTitle
		{
			get
			{
				return _projectTitle;
			}
			set
			{
				_projectTitleNull = false;
				_isSetProjectTitle = true;
				_projectTitle = value;
				_isMapRecord = false;
			}
		}
		public bool IsProjectTitleNull
		{
			get {
				 return _projectTitleNull; }
			set { _projectTitleNull = value; }
		}
		public Boolean _IsSetProjectTitle
		{
			get { return _isSetProjectTitle; }
		}
		public string ProposerEN
		{
			get
			{
				return _proposerEN;
			}
			set
			{
				_proposerENNull = false;
				_isSetProposerEN = true;
				_proposerEN = value;
				_isMapRecord = false;
			}
		}
		public bool IsProposerENNull
		{
			get {
				 return _proposerENNull; }
			set { _proposerENNull = value; }
		}
		public Boolean _IsSetProposerEN
		{
			get { return _isSetProposerEN; }
		}
		public string ObjectiveToHelp
		{
			get
			{
				return _objectiveToHelp;
			}
			set
			{
				_objectiveToHelpNull = false;
				_isSetObjectiveToHelp = true;
				_objectiveToHelp = value;
				_isMapRecord = false;
			}
		}
		public bool IsObjectiveToHelpNull
		{
			get {
				 return _objectiveToHelpNull; }
			set { _objectiveToHelpNull = value; }
		}
		public Boolean _IsSetObjectiveToHelp
		{
			get { return _isSetObjectiveToHelp; }
		}
		public string ProjectInAction
		{
			get
			{
				return _projectInAction;
			}
			set
			{
				_projectInActionNull = false;
				_isSetProjectInAction = true;
				_projectInAction = value;
				_isMapRecord = false;
			}
		}
		public bool IsProjectInActionNull
		{
			get {
				 return _projectInActionNull; }
			set { _projectInActionNull = value; }
		}
		public Boolean _IsSetProjectInAction
		{
			get { return _isSetProjectInAction; }
		}
		public string Portfolio
		{
			get
			{
				return _portfolio;
			}
			set
			{
				_portfolioNull = false;
				_isSetPortfolio = true;
				_portfolio = value;
				_isMapRecord = false;
			}
		}
		public bool IsPortfolioNull
		{
			get {
				 return _portfolioNull; }
			set { _portfolioNull = value; }
		}
		public Boolean _IsSetPortfolio
		{
			get { return _isSetPortfolio; }
		}
		public string ProjectObjective
		{
			get
			{
				return _projectObjective;
			}
			set
			{
				_projectObjectiveNull = false;
				_isSetProjectObjective = true;
				_projectObjective = value;
				_isMapRecord = false;
			}
		}
		public bool IsProjectObjectiveNull
		{
			get {
				 return _projectObjectiveNull; }
			set { _projectObjectiveNull = value; }
		}
		public Boolean _IsSetProjectObjective
		{
			get { return _isSetProjectObjective; }
		}
		public string ProjectResult
		{
			get
			{
				return _projectResult;
			}
			set
			{
				_projectResultNull = false;
				_isSetProjectResult = true;
				_projectResult = value;
				_isMapRecord = false;
			}
		}
		public bool IsProjectResultNull
		{
			get {
				 return _projectResultNull; }
			set { _projectResultNull = value; }
		}
		public Boolean _IsSetProjectResult
		{
			get { return _isSetProjectResult; }
		}
		public string ProjectTarget
		{
			get
			{
				return _projectTarget;
			}
			set
			{
				_projectTargetNull = false;
				_isSetProjectTarget = true;
				_projectTarget = value;
				_isMapRecord = false;
			}
		}
		public bool IsProjectTargetNull
		{
			get {
				 return _projectTargetNull; }
			set { _projectTargetNull = value; }
		}
		public Boolean _IsSetProjectTarget
		{
			get { return _isSetProjectTarget; }
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
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class CaseProjectData
	{
		private int _caseID;
		private int _proposerTypeID;
		private string _proposerTypeOther;
		private string _projectNameLocation;
		private string _projectTitle;
		private string _proposerEN;
		private string _objectiveToHelp;
		private string _projectInAction;
		private string _portfolio;
		private string _projectObjective;
		private string _projectResult;
		private string _projectTarget;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int ProposerTypeID
		{
			get{ return _proposerTypeID; }
			set{ _proposerTypeID = value; }
		}
		public string ProposerTypeOther
		{
			get{ return _proposerTypeOther; }
			set{ _proposerTypeOther = value; }
		}
		public string ProjectNameLocation
		{
			get{ return _projectNameLocation; }
			set{ _projectNameLocation = value; }
		}
		public string ProjectTitle
		{
			get{ return _projectTitle; }
			set{ _projectTitle = value; }
		}
		public string ProposerEN
		{
			get{ return _proposerEN; }
			set{ _proposerEN = value; }
		}
		public string ObjectiveToHelp
		{
			get{ return _objectiveToHelp; }
			set{ _objectiveToHelp = value; }
		}
		public string ProjectInAction
		{
			get{ return _projectInAction; }
			set{ _projectInAction = value; }
		}
		public string Portfolio
		{
			get{ return _portfolio; }
			set{ _portfolio = value; }
		}
		public string ProjectObjective
		{
			get{ return _projectObjective; }
			set{ _projectObjective = value; }
		}
		public string ProjectResult
		{
			get{ return _projectResult; }
			set{ _projectResult = value; }
		}
		public string ProjectTarget
		{
			get{ return _projectTarget; }
			set{ _projectTarget = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseProjectPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseProjectRow[] caseProjectRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseProjectItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseProjectItems : CaseProjectData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseProjectItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseProjectItems[] caseProjectItems { get; set; }
	}
}

