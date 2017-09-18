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
    class Company : ICompany
    {
        #region Create_Logic_instances       
        private CompanyDescriptionLogic GetCompanyDescriptionLogic()
        {
            return new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
        }

        private CompanyJobLogic GetCompanyJobLogic()
        {
            return new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
        }

        public CompanyJobDescriptionLogic GetCompanyJobDescriptionLogic()
        {
            return new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
        }

        public CompanyJobEducationLogic GetCompanyJobEducationLogic()
        {
            return new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
        }

        public CompanyJobSkillLogic GetCompanyJobSkillLogic()
        {
            return new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
        }

        public CompanyLocationLogic GetCompanyLocationLogic()
        {
            return new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
        }

        public CompanyProfileLogic GetCompanyProfileLogic()
        {
            return new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
        }
        #endregion

        #region Add_Methods
        public void AddCompanyDescription(CompanyDescriptionPoco[] items)
        {
            GetCompanyDescriptionLogic().Add(items);
        }

        public void AddCompanyJob(CompanyJobPoco[] items)
        {
            GetCompanyJobLogic().Add(items);
        }

        public void AddCompanyJobDescription(CompanyJobDescriptionPoco[] items)
        {
            GetCompanyJobDescriptionLogic().Add(items);
        }

        public void AddCompanyJobEducation(CompanyJobEducationPoco[] items)
        {
            GetCompanyJobEducationLogic().Add(items);
        }

        public void AddCompanyJobSkill(CompanyJobSkillPoco[] items)
        {
            GetCompanyJobSkillLogic().Add(items);
        }

        public void AddCompanyLocation(CompanyLocationPoco[] items)
        {
            GetCompanyLocationLogic().Add(items);
        }

        public void AddCompanyProfile(CompanyProfilePoco[] items)
        {
            GetCompanyProfileLogic().Add(items);
        }
        #endregion

        #region GetAll_Methods

        public List<CompanyDescriptionPoco> GetAllCompanyDescription()
        {
            return GetCompanyDescriptionLogic().GetAll();
        }

        public List<CompanyJobPoco> GetAllCompanyJob()
        {
            return GetCompanyJobLogic().GetAll();
        }

        public List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription()
        {
            return GetCompanyJobDescriptionLogic().GetAll();
        }

        public List<CompanyJobEducationPoco> GetAllCompanyJobEducation()
        {
            return GetCompanyJobEducationLogic().GetAll();
        }

        public List<CompanyJobSkillPoco> GetAllCompanyJobSkill()
        {
            return GetCompanyJobSkillLogic().GetAll();
        }

        public List<CompanyLocationPoco> GetAllCompanyLocation()
        {
            return GetCompanyLocationLogic().GetAll();
        }

        public List<CompanyProfilePoco> GetAllCompanyProfile()
        {
            return GetCompanyProfileLogic().GetAll();
        }
        #endregion

        #region GetSingle_Methods
        public CompanyDescriptionPoco GetSingleCompanyDescription(string Id)
        {
            return GetCompanyDescriptionLogic().Get(Guid.Parse(Id));
        }

        public CompanyJobPoco GetSingleCompanyJob(string Id)
        {
            return GetCompanyJobLogic().Get(Guid.Parse(Id));
        }

        public CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string Id)
        {
            return GetCompanyJobDescriptionLogic().Get(Guid.Parse(Id));
        }

        public CompanyJobEducationPoco GetSingleCompanyJobEducation(string Id)
        {
            return GetCompanyJobEducationLogic().Get(Guid.Parse(Id));
        }

        public CompanyJobSkillPoco GetSingleCompanyJobSkill(string Id)
        {
            return GetCompanyJobSkillLogic().Get(Guid.Parse(Id));
        }

        public CompanyLocationPoco GetSingleCompanyLocation(string Id)
        {
            return GetCompanyLocationLogic().Get(Guid.Parse(Id));
        }

        public CompanyProfilePoco GetSingleCompanyProfile(string Id)
        {
            return GetCompanyProfileLogic().Get(Guid.Parse(Id));
        }
        #endregion

        #region Remove_Methods
        public void RemoveCompanyDescription(CompanyDescriptionPoco[] items)
        {
            GetCompanyDescriptionLogic().Delete(items);
        }

        public void RemoveCompanyJob(CompanyJobPoco[] items)
        {
            GetCompanyJobLogic().Delete(items);
        }

        public void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] items)
        {
            GetCompanyJobDescriptionLogic().Delete(items);
        }

        public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] items)
        {
            GetCompanyJobEducationLogic().Delete(items);
        }

        public void RemoveCompanyJobSkill(CompanyJobSkillPoco[] items)
        {
            GetCompanyJobSkillLogic().Delete(items);
        }

        public void RemoveCompanyLocation(CompanyLocationPoco[] items)
        {
            GetCompanyLocationLogic().Delete(items);
        }

        public void RemoveCompanyProfile(CompanyProfilePoco[] items)
        {
            GetCompanyProfileLogic().Delete(items);
        }
        #endregion

        #region Update_Methods
        public void UpdateCompanyDescription(CompanyDescriptionPoco[] items)
        {
            GetCompanyDescriptionLogic().Update(items);
        }

        public void UpdateCompanyJob(CompanyJobPoco[] items)
        {
            GetCompanyJobLogic().Update(items);
        }

        public void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] items)
        {
            GetCompanyJobDescriptionLogic().Update(items);
        }

        public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items)
        {
            GetCompanyJobEducationLogic().Update(items);
        }

        public void UpdateCompanyJobSkill(CompanyJobSkillPoco[] items)
        {
            GetCompanyJobSkillLogic().Update(items);
        }

        public void UpdateCompanyLocation(CompanyLocationPoco[] items)
        {
            GetCompanyLocationLogic().Update(items);
        }

                    
        public void UpdateCompanyProfile(CompanyProfilePoco[] items)
        {
            GetCompanyProfileLogic().Update(items);
        }
        #endregion
    }
}
