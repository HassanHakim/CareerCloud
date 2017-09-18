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
    interface ISystem
    {
        // for testing
        //[OperationContract]
        //string GetCountryName();

        #region SystemCountryCodePoco
        [OperationContract]
        void AddSystemCountryCode(SystemCountryCodePoco[] items);

        [OperationContract]
        List<SystemCountryCodePoco> GetAllSystemCountryCode ();

        [OperationContract]
        SystemCountryCodePoco GetSingleSystemCountryCode(string Id);

        [OperationContract]
        void RemoveSystemCountryCode(SystemCountryCodePoco[] items);

        [OperationContract]
        void UpdateSystemCountryCode(SystemCountryCodePoco[] items);
        #endregion

        #region SystemLanguageCodePoco
        [OperationContract]
        void AddSystemLanguageCode(SystemLanguageCodePoco[] items);

        [OperationContract]
        List<SystemLanguageCodePoco> GetAllSystemLanguageCode();

        [OperationContract]
        SystemLanguageCodePoco GetSingleSystemLanguageCode(string Id);

        [OperationContract]
        void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items);

        [OperationContract]
        void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items);
        #endregion


    }
}
