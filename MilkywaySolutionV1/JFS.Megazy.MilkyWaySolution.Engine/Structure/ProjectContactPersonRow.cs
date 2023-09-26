using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProjectContactPersonRow
	{
		private int _contactID;
		private bool _isSetContactID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _email;
		private bool _isSetEmail = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _faxNo;
		private bool _isSetFaxNo = false;
		private bool _isProjectCoordinator;
		private bool _isSetIsProjectCoordinator = false;
		private bool _isProjectCoordinatorNull = true;
		[Required]
		public int ContactID
		{
			get { return _contactID; }
			set { _contactID = value;
			      _isSetContactID = true; }
		}
		public bool _IsSetContactID
		{
			get { return _isSetContactID; }
		}
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
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value;
			      _isSetFirstName = true; }
		}
		public bool _IsSetFirstName
		{
			get { return _isSetFirstName; }
		}
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value;
			      _isSetLastName = true; }
		}
		public bool _IsSetLastName
		{
			get { return _isSetLastName; }
		}
		public string Email
		{
			get { return _email; }
			set { _email = value;
			      _isSetEmail = true; }
		}
		public bool _IsSetEmail
		{
			get { return _isSetEmail; }
		}
		public string TelephoneNo
		{
			get { return _telephoneNo; }
			set { _telephoneNo = value;
			      _isSetTelephoneNo = true; }
		}
		public bool _IsSetTelephoneNo
		{
			get { return _isSetTelephoneNo; }
		}
		public string FaxNo
		{
			get { return _faxNo; }
			set { _faxNo = value;
			      _isSetFaxNo = true; }
		}
		public bool _IsSetFaxNo
		{
			get { return _isSetFaxNo; }
		}
		public bool IsProjectCoordinator
		{
			get
			{
				return _isProjectCoordinator;
			}
			set
			{
				_isProjectCoordinatorNull = false;
				_isSetIsProjectCoordinator = true;
				_isProjectCoordinator = value;
			}
		}
		public bool IsIsProjectCoordinatorNull
		{
			get {
				 return _isProjectCoordinatorNull; }
			set { _isProjectCoordinatorNull = value; }
		}
		public bool _IsSetIsProjectCoordinator
		{
			get { return _isSetIsProjectCoordinator; }
		}
	}
	[Serializable]
	public class ProjectContactPersonData
	{
		private int _contactID;
		private int _caseID;
		private string _firstName;
		private string _lastName;
		private string _email;
		private string _telephoneNo;
		private string _faxNo;
		private bool _isProjectCoordinator;
		public int ContactID
		{
			get{ return _contactID; }
			set{ _contactID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public string FirstName
		{
			get{ return _firstName; }
			set{ _firstName = value; }
		}
		public string LastName
		{
			get{ return _lastName; }
			set{ _lastName = value; }
		}
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public string FaxNo
		{
			get{ return _faxNo; }
			set{ _faxNo = value; }
		}
		public bool IsProjectCoordinator
		{
			get{ return _isProjectCoordinator; }
			set{ _isProjectCoordinator = value; }
		}
	}
	[Serializable]
	public class ProjectContactPersonPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProjectContactPersonRow[] projectContactpersonRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProjectContactPersonItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProjectContactPersonItems : ProjectContactPersonData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProjectContactPersonItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProjectContactPersonItems[] projectContactpersonItems { get; set; }
	}
}

