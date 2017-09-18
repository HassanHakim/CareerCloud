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
    class System : ISystem
    {
        //For testing
        //public string GetCountryName()
        //{
        //    //  SystemCountryCodePoco poco = GetSystemCountryCodeLogic().Get("CAN       ");
        //    SystemCountryCodePoco poco = GetSystemCountryCodeLogic().Get("USA       ");
        //    return poco.Name;
        //}

        #region Create_Logic_Instances
        private SystemCountryCodeLogic GetSystemCountryCodeLogic()
        {
            return new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
        }
        private SystemLanguageCodeLogic GetSystemLanguageCodeLogic()
        {
            return new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
        }
        #endregion

        #region Add_Methods
        public void AddSystemCountryCode(SystemCountryCodePoco[] items)
        {
            GetSystemCountryCodeLogic().Add(items);
        }

        public void AddSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            GetSystemLanguageCodeLogic().Add(items);
        }
        #endregion

        #region GetAll_methods
        public List<SystemCountryCodePoco> GetAllSystemCountryCode()
        {
            return GetSystemCountryCodeLogic().GetAll();
        }
        public List<SystemLanguageCodePoco> GetAllSystemLanguageCode()
        {
            return GetSystemLanguageCodeLogic().GetAll();
        }
        #endregion

        #region GetSingle_Methods
        public SystemCountryCodePoco GetSingleSystemCountryCode(string Id)
        {
            return GetSystemCountryCodeLogic().Get(Id);
        }
        public SystemLanguageCodePoco GetSingleSystemLanguageCode(string Id)
        {
            return GetSystemLanguageCodeLogic().Get(Id);
        }
        #endregion

        #region Remomve_Methods
        public void RemoveSystemCountryCode(SystemCountryCodePoco[] items)
        {
            GetSystemCountryCodeLogic().Delete(items);
        }
        public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            GetSystemLanguageCodeLogic().Delete(items);
        }
        #endregion

        #region Update_Methods
        public void UpdateSystemCountryCode(SystemCountryCodePoco[] items)
        {
            GetSystemCountryCodeLogic().Update(items);
        }
        public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            GetSystemLanguageCodeLogic().Update(items);
        }
    
        #endregion
    }
}
