using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_CaseDetailRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private string _subject;
		private bool _isSetSubject = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private bool _jFCaseTypeIDNull = true;
		private int _channelID;
		private bool _isSetChannelID = false;
		private bool _channelIDNull = true;
		private int _referenceCaseID;
		private bool _isSetReferenceCaseID = false;
		private bool _referenceCaseIDNull = true;
		private int _referenceMSCID;
		private bool _isSetReferenceMSCID = false;
		private bool _referenceMSCIDNull = true;
		private string _referenceMSCCODE;
		private bool _isSetReferenceMSCCODE = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _registerDate;
		private bool _isSetRegisterDate = false;
		private bool _registerDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _caseTypeName;
		private bool _isSetCaseTypeName = false;
		private string _caseTypeNameAbbr;
		private bool _isSetCaseTypeNameAbbr = false;
		private int _srcDepartmentID;
		private bool _isSetSrcDepartmentID = false;
		private bool _srcDepartmentIDNull = true;
		private string _srcDepartmentName;
		private bool _isSetSrcDepartmentName = false;
		private string _srcDepartmentNameAbbr;
		private bool _isSetSrcDepartmentNameAbbr = false;
		private int _referenceDepartmentID;
		private bool _isSetReferenceDepartmentID = false;
		private bool _referenceDepartmentIDNull = true;
		private int _ownProvinceID;
		private bool _isSetOwnProvinceID = false;
		private bool _ownProvinceIDNull = true;
		private string _ownDepartmentName;
		private bool _isSetOwnDepartmentName = false;
		private string _ownDepartmentNameAbbr;
		private bool _isSetOwnDepartmentNameAbbr = false;
		private string _departmentCode;
		private bool _isSetDepartmentCode = false;
		private string _srcProvinceName;
		private bool _isSetSrcProvinceName = false;
		private int _statusID;
		private bool _isSetStatusID = false;
		private bool _statusIDNull = true;
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private bool _workStepIDNull = true;
		private string _workStepName;
		private bool _isSetWorkStepName = false;
		private string _channelName;
		private bool _isSetChannelName = false;
		private int _casecategoryID;
		private bool _isSetCaseCategoryID = false;
		private bool _casecategoryIDNull = true;
		private int _caseSubcategoryID;
		private bool _isSetCaseSubCategoryID = false;
		private bool _caseSubcategoryIDNull = true;
		private string _otherCategory;
		private bool _isSetOtherCategory = false;
		private string _categoryName;
		private bool _isSetCategoryName = false;
		private string _caseSubcategoryName;
		private bool _isSetCaseSubCategoryName = false;
		private string _caseApplicationStatusName;
		private bool _isSetCaseApplicationStatusName = false;
		private string _ownProvinceName;
		private bool _isSetOwnProvinceName = false;
		private int _ownDepartmentID;
		private bool _isSetOwnDepartmentID = false;
		private bool _ownDepartmentIDNull = true;
		private int _srcProvinceID;
		private bool _isSetSrcProvinceID = false;
		private bool _srcProvinceIDNull = true;
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isSetCaseID = true; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		public string Subject
		{
			get { return _subject; }
			set { _subject = value;
			      _isSetSubject = true; }
		}
		public bool _IsSetSubject
		{
			get { return _isSetSubject; }
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
		public int ChannelID
		{
			get
			{
				return _channelID;
			}
			set
			{
				_channelIDNull = false;
				_isSetChannelID = true;
				_channelID = value;
			}
		}
		public bool IsChannelIDNull
		{
			get {
				 return _channelIDNull; }
			set { _channelIDNull = value; }
		}
		public bool _IsSetChannelID
		{
			get { return _isSetChannelID; }
		}
		public int ReferenceCaseID
		{
			get
			{
				return _referenceCaseID;
			}
			set
			{
				_referenceCaseIDNull = false;
				_isSetReferenceCaseID = true;
				_referenceCaseID = value;
			}
		}
		public bool IsReferenceCaseIDNull
		{
			get {
				 return _referenceCaseIDNull; }
			set { _referenceCaseIDNull = value; }
		}
		public bool _IsSetReferenceCaseID
		{
			get { return _isSetReferenceCaseID; }
		}
		public int ReferenceMSCID
		{
			get
			{
				return _referenceMSCID;
			}
			set
			{
				_referenceMSCIDNull = false;
				_isSetReferenceMSCID = true;
				_referenceMSCID = value;
			}
		}
		public bool IsReferenceMSCIDNull
		{
			get {
				 return _referenceMSCIDNull; }
			set { _referenceMSCIDNull = value; }
		}
		public bool _IsSetReferenceMSCID
		{
			get { return _isSetReferenceMSCID; }
		}
		public string ReferenceMSCCODE
		{
			get { return _referenceMSCCODE; }
			set { _referenceMSCCODE = value;
			      _isSetReferenceMSCCODE = true; }
		}
		public bool _IsSetReferenceMSCCODE
		{
			get { return _isSetReferenceMSCCODE; }
		}
		public DateTime CreateDate
		{
			get
			{
				return _createDate;
			}
			set
			{
				_createDateNull = false;
				_isSetCreateDate = true;
				_createDate = value;
			}
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public bool _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
		public DateTime RegisterDate
		{
			get
			{
				return _registerDate;
			}
			set
			{
				_registerDateNull = false;
				_isSetRegisterDate = true;
				_registerDate = value;
			}
		}
		public bool IsRegisterDateNull
		{
			get {
				 return _registerDateNull; }
			set { _registerDateNull = value; }
		}
		public bool _IsSetRegisterDate
		{
			get { return _isSetRegisterDate; }
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
		public string CaseTypeName
		{
			get { return _caseTypeName; }
			set { _caseTypeName = value;
			      _isSetCaseTypeName = true; }
		}
		public bool _IsSetCaseTypeName
		{
			get { return _isSetCaseTypeName; }
		}
		public string CaseTypeNameAbbr
		{
			get { return _caseTypeNameAbbr; }
			set { _caseTypeNameAbbr = value;
			      _isSetCaseTypeNameAbbr = true; }
		}
		public bool _IsSetCaseTypeNameAbbr
		{
			get { return _isSetCaseTypeNameAbbr; }
		}
		public int SrcDepartmentID
		{
			get
			{
				return _srcDepartmentID;
			}
			set
			{
				_srcDepartmentIDNull = false;
				_isSetSrcDepartmentID = true;
				_srcDepartmentID = value;
			}
		}
		public bool IsSrcDepartmentIDNull
		{
			get {
				 return _srcDepartmentIDNull; }
			set { _srcDepartmentIDNull = value; }
		}
		public bool _IsSetSrcDepartmentID
		{
			get { return _isSetSrcDepartmentID; }
		}
		public string SrcDepartmentName
		{
			get { return _srcDepartmentName; }
			set { _srcDepartmentName = value;
			      _isSetSrcDepartmentName = true; }
		}
		public bool _IsSetSrcDepartmentName
		{
			get { return _isSetSrcDepartmentName; }
		}
		public string SrcDepartmentNameAbbr
		{
			get { return _srcDepartmentNameAbbr; }
			set { _srcDepartmentNameAbbr = value;
			      _isSetSrcDepartmentNameAbbr = true; }
		}
		public bool _IsSetSrcDepartmentNameAbbr
		{
			get { return _isSetSrcDepartmentNameAbbr; }
		}
		public int ReferenceDepartmentID
		{
			get
			{
				return _referenceDepartmentID;
			}
			set
			{
				_referenceDepartmentIDNull = false;
				_isSetReferenceDepartmentID = true;
				_referenceDepartmentID = value;
			}
		}
		public bool IsReferenceDepartmentIDNull
		{
			get {
				 return _referenceDepartmentIDNull; }
			set { _referenceDepartmentIDNull = value; }
		}
		public bool _IsSetReferenceDepartmentID
		{
			get { return _isSetReferenceDepartmentID; }
		}
		public int OwnProvinceID
		{
			get
			{
				return _ownProvinceID;
			}
			set
			{
				_ownProvinceIDNull = false;
				_isSetOwnProvinceID = true;
				_ownProvinceID = value;
			}
		}
		public bool IsOwnProvinceIDNull
		{
			get {
				 return _ownProvinceIDNull; }
			set { _ownProvinceIDNull = value; }
		}
		public bool _IsSetOwnProvinceID
		{
			get { return _isSetOwnProvinceID; }
		}
		public string OwnDepartmentName
		{
			get { return _ownDepartmentName; }
			set { _ownDepartmentName = value;
			      _isSetOwnDepartmentName = true; }
		}
		public bool _IsSetOwnDepartmentName
		{
			get { return _isSetOwnDepartmentName; }
		}
		public string OwnDepartmentNameAbbr
		{
			get { return _ownDepartmentNameAbbr; }
			set { _ownDepartmentNameAbbr = value;
			      _isSetOwnDepartmentNameAbbr = true; }
		}
		public bool _IsSetOwnDepartmentNameAbbr
		{
			get { return _isSetOwnDepartmentNameAbbr; }
		}
		public string DepartmentCode
		{
			get { return _departmentCode; }
			set { _departmentCode = value;
			      _isSetDepartmentCode = true; }
		}
		public bool _IsSetDepartmentCode
		{
			get { return _isSetDepartmentCode; }
		}
		public string SrcProvinceName
		{
			get { return _srcProvinceName; }
			set { _srcProvinceName = value;
			      _isSetSrcProvinceName = true; }
		}
		public bool _IsSetSrcProvinceName
		{
			get { return _isSetSrcProvinceName; }
		}
		public int StatusID
		{
			get
			{
				return _statusID;
			}
			set
			{
				_statusIDNull = false;
				_isSetStatusID = true;
				_statusID = value;
			}
		}
		public bool IsStatusIDNull
		{
			get {
				 return _statusIDNull; }
			set { _statusIDNull = value; }
		}
		public bool _IsSetStatusID
		{
			get { return _isSetStatusID; }
		}
		public int WorkStepID
		{
			get
			{
				return _workStepID;
			}
			set
			{
				_workStepIDNull = false;
				_isSetWorkStepID = true;
				_workStepID = value;
			}
		}
		public bool IsWorkStepIDNull
		{
			get {
				 return _workStepIDNull; }
			set { _workStepIDNull = value; }
		}
		public bool _IsSetWorkStepID
		{
			get { return _isSetWorkStepID; }
		}
		public string WorkStepName
		{
			get { return _workStepName; }
			set { _workStepName = value;
			      _isSetWorkStepName = true; }
		}
		public bool _IsSetWorkStepName
		{
			get { return _isSetWorkStepName; }
		}
		public string ChannelName
		{
			get { return _channelName; }
			set { _channelName = value;
			      _isSetChannelName = true; }
		}
		public bool _IsSetChannelName
		{
			get { return _isSetChannelName; }
		}
		public int CaseCategoryID
		{
			get
			{
				return _casecategoryID;
			}
			set
			{
				_casecategoryIDNull = false;
				_isSetCaseCategoryID = true;
				_casecategoryID = value;
			}
		}
		public bool IsCaseCategoryIDNull
		{
			get {
				 return _casecategoryIDNull; }
			set { _casecategoryIDNull = value; }
		}
		public bool _IsSetCaseCategoryID
		{
			get { return _isSetCaseCategoryID; }
		}
		public int CaseSubCategoryID
		{
			get
			{
				return _caseSubcategoryID;
			}
			set
			{
				_caseSubcategoryIDNull = false;
				_isSetCaseSubCategoryID = true;
				_caseSubcategoryID = value;
			}
		}
		public bool IsCaseSubCategoryIDNull
		{
			get {
				 return _caseSubcategoryIDNull; }
			set { _caseSubcategoryIDNull = value; }
		}
		public bool _IsSetCaseSubCategoryID
		{
			get { return _isSetCaseSubCategoryID; }
		}
		public string OtherCategory
		{
			get { return _otherCategory; }
			set { _otherCategory = value;
			      _isSetOtherCategory = true; }
		}
		public bool _IsSetOtherCategory
		{
			get { return _isSetOtherCategory; }
		}
		public string CategoryName
		{
			get { return _categoryName; }
			set { _categoryName = value;
			      _isSetCategoryName = true; }
		}
		public bool _IsSetCategoryName
		{
			get { return _isSetCategoryName; }
		}
		public string CaseSubCategoryName
		{
			get { return _caseSubcategoryName; }
			set { _caseSubcategoryName = value;
			      _isSetCaseSubCategoryName = true; }
		}
		public bool _IsSetCaseSubCategoryName
		{
			get { return _isSetCaseSubCategoryName; }
		}
		public string CaseApplicationStatusName
		{
			get { return _caseApplicationStatusName; }
			set { _caseApplicationStatusName = value;
			      _isSetCaseApplicationStatusName = true; }
		}
		public bool _IsSetCaseApplicationStatusName
		{
			get { return _isSetCaseApplicationStatusName; }
		}
		public string OwnProvinceName
		{
			get { return _ownProvinceName; }
			set { _ownProvinceName = value;
			      _isSetOwnProvinceName = true; }
		}
		public bool _IsSetOwnProvinceName
		{
			get { return _isSetOwnProvinceName; }
		}
		public int OwnDepartmentID
		{
			get
			{
				return _ownDepartmentID;
			}
			set
			{
				_ownDepartmentIDNull = false;
				_isSetOwnDepartmentID = true;
				_ownDepartmentID = value;
			}
		}
		public bool IsOwnDepartmentIDNull
		{
			get {
				 return _ownDepartmentIDNull; }
			set { _ownDepartmentIDNull = value; }
		}
		public bool _IsSetOwnDepartmentID
		{
			get { return _isSetOwnDepartmentID; }
		}
		public int SrcProvinceID
		{
			get
			{
				return _srcProvinceID;
			}
			set
			{
				_srcProvinceIDNull = false;
				_isSetSrcProvinceID = true;
				_srcProvinceID = value;
			}
		}
		public bool IsSrcProvinceIDNull
		{
			get {
				 return _srcProvinceIDNull; }
			set { _srcProvinceIDNull = value; }
		}
		public bool _IsSetSrcProvinceID
		{
			get { return _isSetSrcProvinceID; }
		}
	}
	[Serializable]
	public class View_CaseDetailData
	{
		private int _caseID;
		private string _subject;
		private int _jFCaseTypeID;
		private int _channelID;
		private int _referenceCaseID;
		private int _referenceMSCID;
		private string _referenceMSCCODE;
		private DateTime _createDate;
		private DateTime _registerDate;
		private DateTime _modifiedDate;
		private string _caseTypeName;
		private string _caseTypeNameAbbr;
		private int _srcDepartmentID;
		private string _srcDepartmentName;
		private string _srcDepartmentNameAbbr;
		private int _referenceDepartmentID;
		private int _ownProvinceID;
		private string _ownDepartmentName;
		private string _ownDepartmentNameAbbr;
		private string _departmentCode;
		private string _srcProvinceName;
		private int _statusID;
		private int _workStepID;
		private string _workStepName;
		private string _channelName;
		private int _casecategoryID;
		private int _caseSubcategoryID;
		private string _otherCategory;
		private string _categoryName;
		private string _caseSubcategoryName;
		private string _caseApplicationStatusName;
		private string _ownProvinceName;
		private int _ownDepartmentID;
		private int _srcProvinceID;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public int ChannelID
		{
			get{ return _channelID; }
			set{ _channelID = value; }
		}
		public int ReferenceCaseID
		{
			get{ return _referenceCaseID; }
			set{ _referenceCaseID = value; }
		}
		public int ReferenceMSCID
		{
			get{ return _referenceMSCID; }
			set{ _referenceMSCID = value; }
		}
		public string ReferenceMSCCODE
		{
			get{ return _referenceMSCCODE; }
			set{ _referenceMSCCODE = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string CreateDateStr { get; set; }
		public DateTime RegisterDate
		{
			get{ return _registerDate; }
			set{ _registerDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string RegisterDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
		public string CaseTypeName
		{
			get{ return _caseTypeName; }
			set{ _caseTypeName = value; }
		}
		public string CaseTypeNameAbbr
		{
			get{ return _caseTypeNameAbbr; }
			set{ _caseTypeNameAbbr = value; }
		}
		public int SrcDepartmentID
		{
			get{ return _srcDepartmentID; }
			set{ _srcDepartmentID = value; }
		}
		public string SrcDepartmentName
		{
			get{ return _srcDepartmentName; }
			set{ _srcDepartmentName = value; }
		}
		public string SrcDepartmentNameAbbr
		{
			get{ return _srcDepartmentNameAbbr; }
			set{ _srcDepartmentNameAbbr = value; }
		}
		public int ReferenceDepartmentID
		{
			get{ return _referenceDepartmentID; }
			set{ _referenceDepartmentID = value; }
		}
		public int OwnProvinceID
		{
			get{ return _ownProvinceID; }
			set{ _ownProvinceID = value; }
		}
		public string OwnDepartmentName
		{
			get{ return _ownDepartmentName; }
			set{ _ownDepartmentName = value; }
		}
		public string OwnDepartmentNameAbbr
		{
			get{ return _ownDepartmentNameAbbr; }
			set{ _ownDepartmentNameAbbr = value; }
		}
		public string DepartmentCode
		{
			get{ return _departmentCode; }
			set{ _departmentCode = value; }
		}
		public string SrcProvinceName
		{
			get{ return _srcProvinceName; }
			set{ _srcProvinceName = value; }
		}
		public int StatusID
		{
			get{ return _statusID; }
			set{ _statusID = value; }
		}
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
		public string WorkStepName
		{
			get{ return _workStepName; }
			set{ _workStepName = value; }
		}
		public string ChannelName
		{
			get{ return _channelName; }
			set{ _channelName = value; }
		}
		public int CaseCategoryID
		{
			get{ return _casecategoryID; }
			set{ _casecategoryID = value; }
		}
		public int CaseSubCategoryID
		{
			get{ return _caseSubcategoryID; }
			set{ _caseSubcategoryID = value; }
		}
		public string OtherCategory
		{
			get{ return _otherCategory; }
			set{ _otherCategory = value; }
		}
		public string CategoryName
		{
			get{ return _categoryName; }
			set{ _categoryName = value; }
		}
		public string CaseSubCategoryName
		{
			get{ return _caseSubcategoryName; }
			set{ _caseSubcategoryName = value; }
		}
		public string CaseApplicationStatusName
		{
			get{ return _caseApplicationStatusName; }
			set{ _caseApplicationStatusName = value; }
		}
		public string OwnProvinceName
		{
			get{ return _ownProvinceName; }
			set{ _ownProvinceName = value; }
		}
		public int OwnDepartmentID
		{
			get{ return _ownDepartmentID; }
			set{ _ownDepartmentID = value; }
		}
		public int SrcProvinceID
		{
			get{ return _srcProvinceID; }
			set{ _srcProvinceID = value; }
		}
	}
	[Serializable]
	public class View_CaseDetailPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseDetailRow[] view_CaseDetailRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseDetailItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseDetailItems : View_CaseDetailData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseDetailItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseDetailItems[] view_CaseDetailItems { get; set; }
	}
}

