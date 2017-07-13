using System.Runtime.Serialization;
using LtiLibrary.Core.Common;

namespace LtiLibrary.Core.Lti2
{
    public class ToolProxyRegistrationRequest : BasicRequest, IToolProxyRegistrationRequest
    {
        [DataMember(Name = LtiConstants.LaunchPresentationCssUrlParameter)]
        public string LaunchPresentationCssUrl
        {
            get => Parameters[LtiConstants.LaunchPresentationCssUrlParameter];
            set => Parameters[LtiConstants.LaunchPresentationCssUrlParameter] = value;
        }

        [DataMember(Name = LtiConstants.LaunchPresentationDocumentTargetParameter)]
        public string LaunchPresentationDocumentTarget
        {
            get => Parameters[LtiConstants.LaunchPresentationDocumentTargetParameter];
            set => Parameters[LtiConstants.LaunchPresentationDocumentTargetParameter] = value;
        }

        [DataMember(Name = LtiConstants.LaunchPresentationHeightParameter)]
        public string LaunchPresentationHeight
        {
            get => Parameters[LtiConstants.LaunchPresentationHeightParameter];
            set => Parameters[LtiConstants.LaunchPresentationHeightParameter] = value;
        }

        [DataMember(Name = LtiConstants.LaunchPresentationLocaleParameter)]
        public string LaunchPresentationLocale
        {
            get => Parameters[LtiConstants.LaunchPresentationLocaleParameter];
            set => Parameters[LtiConstants.LaunchPresentationLocaleParameter] = value;
        }

        [DataMember(Name = LtiConstants.LaunchPresentationReturnUrlParameter)]
        public string LaunchPresentationReturnUrl
        {
            get => Parameters[LtiConstants.LaunchPresentationReturnUrlParameter];
            set => Parameters[LtiConstants.LaunchPresentationReturnUrlParameter] = value;
        }

        [DataMember(Name = LtiConstants.LaunchPresentationWidthParameter)]
        public string LaunchPresentationWidth
        {
            get => Parameters[LtiConstants.LaunchPresentationWidthParameter];
            set => Parameters[LtiConstants.LaunchPresentationWidthParameter] = value;
        }

        [DataMember(Name = LtiConstants.LtiMessageTypeParameter)]
        public string LtiMessageType
        {
            get => Parameters[LtiConstants.LtiMessageTypeParameter];
            set => Parameters[LtiConstants.LtiMessageTypeParameter] = value;
        }

        [DataMember(Name = LtiConstants.RegistrationKeyParameter)]
        public string RegistrationKey
        {
            get => Parameters[LtiConstants.RegistrationKeyParameter];
            set => Parameters[LtiConstants.RegistrationKeyParameter] = value;
        }

        [DataMember(Name = LtiConstants.RegistrationPasswordParameter)]
        public string RegistrationPassword
        {
            get => Parameters[LtiConstants.RegistrationPasswordParameter];
            set => Parameters[LtiConstants.RegistrationPasswordParameter] = value;
        }

        [DataMember(Name = LtiConstants.RolesParameter)]
        public string Roles
        {
            get => Parameters[LtiConstants.RolesParameter];
            set => Parameters[LtiConstants.RolesParameter] = value;
        }

        [DataMember(Name = LtiConstants.ToolConsumerProfileUrlParameter)]
        public string ToolConsumerProfileUrl
        {
            get => Parameters[LtiConstants.ToolConsumerProfileUrlParameter];
            set => Parameters[LtiConstants.ToolConsumerProfileUrlParameter] = value;
        }

        [DataMember(Name = LtiConstants.UserIdParameter)]
        public string UserId
        {
            get => Parameters[LtiConstants.UserIdParameter];
            set => Parameters[LtiConstants.UserIdParameter] = value;
        }

        /// <summary>
        /// The custom_ and ext_ parameters in Querystring format suitable for saving in the database.
        /// </summary>
        public string CustomParameters
        {
            get
            {
                var customParameters = new UrlEncodingParser( "" );
                foreach ( var key in Parameters.AllKeys )
                {
                    if ( key.StartsWith( "custom_" ) || key.StartsWith( "ext_" ) )
                    {
                        customParameters.Add( key, Parameters[key] );
                    }
                }

                return customParameters.Count == 0 ? null : customParameters.ToString();
            }
            set
            {
                var customParameters = new UrlEncodingParser( value );
                foreach ( var key in customParameters.AllKeys )
                {
                    if ( key.StartsWith( "custom_" ) || key.StartsWith( "_ext" ) )
                    {
                        Parameters[key] = customParameters[key];
                    }
                }
            }
        }
    }
}
