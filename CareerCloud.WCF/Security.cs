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
    class Security : ISecurity
    {
        #region Create_Logic_Instances
        private SecurityLoginLogic GetSecurityLoginLogic()
        {
            return new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
        }

        private SecurityLoginsLogLogic GetSecurityLoginsLogLogic()
        {
            return new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
        }

        private SecurityLoginsRoleLogic GetSecurityLoginsRoleLogic()
        {
            return new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
        }
        private SecurityRoleLogic GetSecurityRoleLogic()
        {
            return new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
        }
        #endregion

        #region Add_Methods()
        public void AddSecurityLogin(SecurityLoginPoco[] items)
        {
            GetSecurityLoginLogic().Add(items);
        }

        public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            GetSecurityLoginsLogLogic().Add(items);
        }

        public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            GetSecurityLoginsRoleLogic().Add(items);
        }

        public void AddSecurityRole(SecurityRolePoco[] items)
        {
            GetSecurityRoleLogic().Add(items);
        }
        #endregion

        #region GetAll_Methods
        public List<SecurityLoginPoco> GetAllSecurityLogin()
        {
            return GetSecurityLoginLogic().GetAll();
        }

        public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
        {
            return GetSecurityLoginsLogLogic().GetAll();
        }

        public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole()
        {
            return GetSecurityLoginsRoleLogic().GetAll();
        }

        public List<SecurityRolePoco> GetAllSecurityRole()
        {
            return GetSecurityRoleLogic().GetAll();
        }
        #endregion

        #region GetSingle_Methods

        public SecurityLoginPoco GetSingleSecurityLogin(string Id)
        {
            return GetSecurityLoginLogic().Get(Guid.Parse(Id));
        }

        public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id)
        {
            return GetSecurityLoginsLogLogic().Get(Guid.Parse(Id));
        }

        public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id)
        {
            return GetSecurityLoginsRoleLogic().Get(Guid.Parse(Id));
        }

        public SecurityRolePoco GetSingleSecurityRole(string Id)
        {
            return GetSecurityRoleLogic().Get(Guid.Parse(Id));
        }
        #endregion

        #region Remove_Methods
        public void RemoveSecurityLogin(SecurityLoginPoco[] items)
        {
            GetSecurityLoginLogic().Delete(items);
        }

        public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            GetSecurityLoginsLogLogic().Delete(items);
        }

        public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            GetSecurityLoginsRoleLogic().Delete(items);
        }

        public void RemoveSecurityRole(SecurityRolePoco[] items)
        {
            GetSecurityRoleLogic().Delete(items);
        }
        #endregion

        #region Update_Methods
        public void UpdateSecurityLogin(SecurityLoginPoco[] items)
        {
            GetSecurityLoginLogic().Update(items);
        }

        public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            GetSecurityLoginsLogLogic().Update(items);
        }

        public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            GetSecurityLoginsRoleLogic().Update(items);
        }

        public void UpdateSecurityRole(SecurityRolePoco[] items)
        {
            GetSecurityRoleLogic().Update(items);
        }
        #endregion
    }
}
