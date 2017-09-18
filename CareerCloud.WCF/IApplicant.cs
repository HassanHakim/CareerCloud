using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.WCF
{
    [ServiceContract]
    interface IApplicant
    {
        #region ApplicantEducationPoco
        [OperationContract]
        void AddApplicantEducation(ApplicantEducationPoco[] items);

        [OperationContract]
        List<ApplicantEducationPoco> GetAllApplicantEducation();

        [OperationContract]
        ApplicantEducationPoco GetSingleApplicantEducation(string Id);

        [OperationContract]
        void RemoveApplicantEducation(ApplicantEducationPoco[] items);

        [OperationContract]
        void UpdateApplicantEducation(ApplicantEducationPoco[] items);
        #endregion

        #region ApplicantJobApplicationPoco
        [OperationContract]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] items);

        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();

        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id);

        [OperationContract]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items);

        [OperationContract]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items);
        #endregion

        #region ApplicantProfilePoco
        [OperationContract]
        void AddApplicantProfile(ApplicantProfilePoco[] items);

        [OperationContract]
        List<ApplicantProfilePoco> GetAllApplicantProfile();

        [OperationContract]
        ApplicantProfilePoco GetSingleApplicantProfile(string Id);

        [OperationContract]
        void RemoveApplicantProfile(ApplicantProfilePoco[] items);

        [OperationContract]
        void UpdateApplicantProfile(ApplicantProfilePoco[] items);
        #endregion

        #region ApplicantResumePoco
        [OperationContract]
        void AddApplicantResume(ApplicantResumePoco[] items);

        [OperationContract]
        List<ApplicantResumePoco> GetAllApplicantResume();

        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResume(string Id);

        [OperationContract]
        void RemoveApplicantResume(ApplicantResumePoco[] items);

        [OperationContract]
        void UpdateApplicantResume(ApplicantResumePoco[] items);
        #endregion

        #region ApplicantSkillPoco
        [OperationContract]
        void AddApplicantSkill(ApplicantSkillPoco[] items);

        [OperationContract]
        List<ApplicantSkillPoco> GetAllApplicantSkill();

        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkill(string Id);

        [OperationContract]
        void RemoveApplicantSkill(ApplicantSkillPoco[] items);

        [OperationContract]
        void UpdateApplicantSkill(ApplicantSkillPoco[] items);
        #endregion

        #region ApplicantWorkHistoryPoco
        [OperationContract]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);

        [OperationContract]
        List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();

        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id);

        [OperationContract]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);

        [OperationContract]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
        #endregion

    }
}
