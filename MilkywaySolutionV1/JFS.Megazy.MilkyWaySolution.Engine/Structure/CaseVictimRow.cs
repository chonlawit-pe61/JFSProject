using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseVictimRow
	{
		private int _victimID;
		private bool _isSetVictimID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _hasContact;
		private bool _isSetHasContact = false;
		private bool _hasContactNull = true;
		private string _additionalContactInfo;
		private bool _isSetAdditionalContactInfo = false;
		private bool _hasMitigate;
		private bool _isSetHasMitigate = false;
		private bool _hasMitigateNull = true;
		private string _additionalMitigateInfo;
		private bool _isSetAdditionalMitigateInfo = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private bool _addressIDNull = true;
		private string _victimDisputantName;
		private bool _isSetVictimDisputantName = false;
		private string _victimDisputantTelNo;
		private bool _isSetVictimDisputantTelNo = false;
		private int _victimDisputantAge;
		private bool _isSetVictimDisputantAge = false;
		private bool _victimDisputantAgeNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int VictimID
		{
			get { return _victimID; }
			set { _victimID = value;
			      _isSetVictimID = true; }
		}
		public bool _IsSetVictimID
		{
			get { return _isSetVictimID; }
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
		public bool HasContact
		{
			get
			{
				return _hasContact;
			}
			set
			{
				_hasContactNull = false;
				_isSetHasContact = true;
				_hasContact = value;
			}
		}
		public bool IsHasContactNull
		{
			get {
				 return _hasContactNull; }
			set { _hasContactNull = value; }
		}
		public bool _IsSetHasContact
		{
			get { return _isSetHasContact; }
		}
		public string AdditionalContactInfo
		{
			get { return _additionalContactInfo; }
			set { _additionalContactInfo = value;
			      _isSetAdditionalContactInfo = true; }
		}
		public bool _IsSetAdditionalContactInfo
		{
			get { return _isSetAdditionalContactInfo; }
		}
		public bool HasMitigate
		{
			get
			{
				return _hasMitigate;
			}
			set
			{
				_hasMitigateNull = false;
				_isSetHasMitigate = true;
				_hasMitigate = value;
			}
		}
		public bool IsHasMitigateNull
		{
			get {
				 return _hasMitigateNull; }
			set { _hasMitigateNull = value; }
		}
		public bool _IsSetHasMitigate
		{
			get { return _isSetHasMitigate; }
		}
		public string AdditionalMitigateInfo
		{
			get { return _additionalMitigateInfo; }
			set { _additionalMitigateInfo = value;
			      _isSetAdditionalMitigateInfo = true; }
		}
		public bool _IsSetAdditionalMitigateInfo
		{
			get { return _isSetAdditionalMitigateInfo; }
		}
		public int AddressID
		{
			get
			{
				return _addressID;
			}
			set
			{
				_addressIDNull = false;
				_isSetAddressID = true;
				_addressID = value;
			}
		}
		public bool IsAddressIDNull
		{
			get {
				 return _addressIDNull; }
			set { _addressIDNull = value; }
		}
		public bool _IsSetAddressID
		{
			get { return _isSetAddressID; }
		}
		public string VictimDisputantName
		{
			get { return _victimDisputantName; }
			set { _victimDisputantName = value;
			      _isSetVictimDisputantName = true; }
		}
		public bool _IsSetVictimDisputantName
		{
			get { return _isSetVictimDisputantName; }
		}
		public string VictimDisputantTelNo
		{
			get { return _victimDisputantTelNo; }
			set { _victimDisputantTelNo = value;
			      _isSetVictimDisputantTelNo = true; }
		}
		public bool _IsSetVictimDisputantTelNo
		{
			get { return _isSetVictimDisputantTelNo; }
		}
		public int VictimDisputantAge
		{
			get
			{
				return _victimDisputantAge;
			}
			set
			{
				_victimDisputantAgeNull = false;
				_isSetVictimDisputantAge = true;
				_victimDisputantAge = value;
			}
		}
		public bool IsVictimDisputantAgeNull
		{
			get {
				 return _victimDisputantAgeNull; }
			set { _victimDisputantAgeNull = value; }
		}
		public bool _IsSetVictimDisputantAge
		{
			get { return _isSetVictimDisputantAge; }
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
	}
	[Serializable]
	public class CaseVictimData
	{
		private int _victimID;
		private int _caseID;
		private bool _hasContact;
		private string _additionalContactInfo;
		private bool _hasMitigate;
		private string _additionalMitigateInfo;
		private int _addressID;
		private string _victimDisputantName;
		private string _victimDisputantTelNo;
		private int _victimDisputantAge;
		private DateTime _modifiedDate;
		public int VictimID
		{
			get{ return _victimID; }
			set{ _victimID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public bool HasContact
		{
			get{ return _hasContact; }
			set{ _hasContact = value; }
		}
		public string AdditionalContactInfo
		{
			get{ return _additionalContactInfo; }
			set{ _additionalContactInfo = value; }
		}
		public bool HasMitigate
		{
			get{ return _hasMitigate; }
			set{ _hasMitigate = value; }
		}
		public string AdditionalMitigateInfo
		{
			get{ return _additionalMitigateInfo; }
			set{ _additionalMitigateInfo = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public string VictimDisputantName
		{
			get{ return _victimDisputantName; }
			set{ _victimDisputantName = value; }
		}
		public string VictimDisputantTelNo
		{
			get{ return _victimDisputantTelNo; }
			set{ _victimDisputantTelNo = value; }
		}
		public int VictimDisputantAge
		{
			get{ return _victimDisputantAge; }
			set{ _victimDisputantAge = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseVictimPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseVictimRow[] caseVictimRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseVictimItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseVictimItems : CaseVictimData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseVictimItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseVictimItems[] caseVictimItems { get; set; }
	}
}

