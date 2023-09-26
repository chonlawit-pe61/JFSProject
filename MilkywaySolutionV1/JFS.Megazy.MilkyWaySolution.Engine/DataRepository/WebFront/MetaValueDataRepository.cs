using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class MetaValueDataRepository: CaseProjectMetaData
    {
        public MetaValueDataRepository()
        {
            caseProjectSchedule = null;
        }
        public CaseProjectSchedule[] caseProjectSchedule { get; set; }
        public CaseProjectParticipant caseProjectParticipant { get; set; }
        public ProjectProponentData projectProponent { get; set; }
        public ProjectResultAttachVideo projectResultAttachVideo { get; set; }
    }
    public class CaseProjectSchedule
    {
        public string Time { get; set; }
        public string Activity { get; set; }
        public string Lecturer { get; set; }
        public bool IsBreak { get; set; }
    }
    public class ProjectProponentData
    {
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Line { get; set; }
    }
    public class CaseProjectParticipant
    {
        public CaseProjectParticipant() {
            participantofficers = null;
            participantLecturers = null;
        }
        public ParticipantOfficer[] participantofficers { get; set; }
        public ParticipantLecturer[] participantLecturers { get; set; }
        public int Participant { get; set; }
        public int Observer { get; set; }
    }

    public class ParticipantOfficer
    {
        public string OfficerName { get; set; }
        public string Responsibility { get; set; }
    }
    public class ParticipantLecturer
    {
        public string LecturerName { get; set; }
        public string Subject { get; set; }
        public string Time { get; set; }
    }

    public class ProjectResultAttachVideo
    {
        public string URLVideo { get; set; }
        public string VideoName { get; set; }
        public string Description { get; set; }
    }

}
