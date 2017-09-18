using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.WCF
{
    class Applicant : IApplicant
    {

        #region Create_Logic_instances       
        private ApplicantEducationLogic GetApplicantEducationLogic()
        {
            return new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false)); 
        }
        private ApplicantJobApplicationLogic GetApplicantJobApplicationLogic()
        {
            return new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
        }

        private ApplicantProfileLogic GetApplicantProfileLogic() 
        {
            return new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
        }

        private ApplicantResumeLogic GetApplicantResumeLogic()
        {
            return new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
        }

        private ApplicantSkillLogic GetApplicantSkillLogic()
        {
            return new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
        }

        private ApplicantWorkHistoryLogic GetApplicantWorkHistoryLogic()
        {
            return new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
        }
        #endregion

        #region Add_Methods

        public void AddApplicantEducation(ApplicantEducationPoco[] items)
        {
            GetApplicantEducationLogic().Add(items);
        }

        public void AddApplicantJobApplication(ApplicantJobApplicationPoco[] items)
        {
            GetApplicantJobApplicationLogic().Add(items);
        }

        public void AddApplicantProfile(ApplicantProfilePoco[] items)
        {
            GetApplicantProfileLogic().Add(items);
        }

        public void AddApplicantResume(ApplicantResumePoco[] items)
        {
            GetApplicantResumeLogic().Add(items);
        }

        public void AddApplicantSkill(ApplicantSkillPoco[] items)
        {
            GetApplicantSkillLogic().Add(items);
        }

        public void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
        {
            GetApplicantWorkHistoryLogic().Add(items);
        }
        #endregion Add

        #region GetAll_Methods
        public List<ApplicantEducationPoco> GetAllApplicantEducation()
        {          
            return GetApplicantEducationLogic().GetAll();
        }

        public List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication()
        {
            return GetApplicantJobApplicationLogic().GetAll();
        }

        public List<ApplicantProfilePoco> GetAllApplicantProfile()
        {          
            return GetApplicantProfileLogic().GetAll();
        }

        public List<ApplicantResumePoco> GetAllApplicantResume()
        {           
            return GetApplicantResumeLogic().GetAll();
        }

        public List<ApplicantSkillPoco> GetAllApplicantSkill()
        {
            return GetApplicantSkillLogic().GetAll();
        }

        public List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory()
        {
           return GetApplicantWorkHistoryLogic().GetAll();
        }
        #endregion

        #region GetSingle_Methods
        public ApplicantEducationPoco GetSingleApplicantEducation(string Id)
        {
            return GetApplicantEducationLogic().Get(Guid.Parse(Id));
        }

        public ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id)
        {
           return GetApplicantJobApplicationLogic().Get(Guid.Parse(Id));
        }

        public ApplicantProfilePoco GetSingleApplicantProfile(string Id)
        {
           return GetApplicantProfileLogic().Get(Guid.Parse(Id));
        }

        public ApplicantResumePoco GetSingleApplicantResume(string Id)
        {
           return GetApplicantResumeLogic().Get(Guid.Parse(Id));
        }

        public ApplicantSkillPoco GetSingleApplicantSkill(string Id)
        {
            return GetApplicantSkillLogic().Get(Guid.Parse(Id));
        }

        public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id)
        {
            return GetApplicantWorkHistoryLogic().Get(Guid.Parse(Id));
        }
        #endregion

        #region Remove_Methods

        public void RemoveApplicantEducation(ApplicantEducationPoco[] items)
        {
            GetApplicantEducationLogic().Delete(items);
        }

        public void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items)
        {
            GetApplicantJobApplicationLogic().Delete(items);
        }

        public void RemoveApplicantProfile(ApplicantProfilePoco[] items)
        {
            GetApplicantProfileLogic().Delete(items);
        }

        public void RemoveApplicantResume(ApplicantResumePoco[] items)
        {
            GetApplicantResumeLogic().Delete(items);
        }

        public void RemoveApplicantSkill(ApplicantSkillPoco[] items)
        {
            GetApplicantSkillLogic().Delete(items);
        }

        public void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
        {
            GetApplicantWorkHistoryLogic().Delete(items);
        }
        #endregion

        #region Update_Methods

        public void UpdateApplicantEducation(ApplicantEducationPoco[] items)
        {
            GetApplicantEducationLogic().Update(items);            
        }

        public void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items)
        {
            GetApplicantJobApplicationLogic().Update(items);
        }

        public void UpdateApplicantProfile(ApplicantProfilePoco[] items)
        {
            GetApplicantProfileLogic().Update(items);
        }

        public void UpdateApplicantResume(ApplicantResumePoco[] items)
        {
            GetApplicantResumeLogic().Update(items);
        }

        public void UpdateApplicantSkill(ApplicantSkillPoco[] items)
        {
            GetApplicantSkillLogic().Update(items);
        }

        public void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
        {
            GetApplicantWorkHistoryLogic().Update(items);
        }
        #endregion
    }
}
