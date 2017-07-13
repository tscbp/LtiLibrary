namespace LtiLibrary.Core.Lti2
{
    public interface IToolProxyRegistrationRequest
    {
        /// <summary>
        /// The custom_ and ext_ parameters in Querystring format suitable for saving in the database.
        /// </summary>
        string CustomParameters { get; set; }
        /// <summary>
        /// The HTTP Method of the request
        /// </summary>
        string HttpMethod { get; set; }
        /// <summary>
        /// This is a URL to an LMS-specific CSS URL.  There are no standards that describe exactly what CSS classes, etc.
        /// should be in this CSS.  The Tool Provider should send its standard CSS URL that it would apply to its local tools.  
        /// The Tool Consumer should include styling for HTML tags to set font, color, etc 
        /// and also include its proprietary tags used to style its internal tools.
        /// In the absence of  a cross-LMS standard for CSS classes to allow a tool to look "built-in" with only one set of markup, 
        /// the launch_presentation_css_url gives Tool Providers a chance to adapt their look and feel across LMS systems to some degree.
        /// <para>
        /// Parameter: launch_presentation_css_url.
        /// Custom parameter substitution: n/a.
        /// Versions: 1.0, 1.1, 1.2, 2.0.
        /// Optional.
        /// </para>
        /// </summary>
        string LaunchPresentationCssUrl { get; set; }
        /// <summary>
        /// The value should be either ‘frame’, ‘iframe’ or ‘window’.  
        /// This field communicates the kind of browser window/frame where the Tool Consumer has launched the tool.
        /// <para>
        /// Parameter: launch_presentation_document_target.
        /// Custom parameter substitution: n/a.
        /// Versions: 1.0, 1.1, 1.2, 2.0.
        /// Recommended.
        /// </para>
        /// </summary>
        string LaunchPresentationDocumentTarget { get; set; }
        /// <summary>
        /// The height of the window or frame where the content from the tool will be displayed.
        /// <para>
        /// Parameter: launch_presentation_height.
        /// Custom parameter substitution: n/a.
        /// Versions: 1.0, 1.1, 1.2, 2.0.
        /// Recommended.
        /// </para>
        /// </summary>
        string LaunchPresentationHeight { get; set; }
        /// <summary>
        /// Language, country and variant as represented using the IETF Best Practices for Tags for Identifying Languages (BCP-47) 
        /// available at http://www.rfc-editor.org/rfc/bcp/bcp47.txt
        /// <para>
        /// Parameter: launch_presentation_locale.
        /// Custom parameter substitution: n/a.
        /// Versions: 1.0, 1.1, 1.2, 2.0.
        /// Optional.
        /// </para>
        /// </summary>
        string LaunchPresentationLocale { get; set; }
        /// <summary>
        /// This is the url to redirect to once ToolProxy creation is complete.  In addition, the Tool Provider must append
        /// status=success | failure
        /// tool_proxy_guid=globally unique identifier for the Tool Proxy
        /// <para>
        /// Parameter: launch_presentation_return_url.
        /// Custom parameter substitution: n/a.
        /// Versions: 1.0, 1.1, 1.2, 2.0.
        /// Required.
        /// </para>
        /// </summary>
        string LaunchPresentationReturnUrl { get; set; }
        /// <summary>
        /// The width of the window or frame where the content from the tool will be displayed.
        /// <para>
        /// Parameter: launch_presentation_width.
        /// Custom parameter substitution: n/a.
        /// Versions: 1.0, 1.1, 1.2, 2.0.
        /// Recommended.
        /// </para>
        /// </summary>
        string LaunchPresentationWidth { get; set; }
        /// <summary>
        /// For this request type, this parameter must be present and contain a value of 'ToolProxyRegistrationRequest'
        /// <para>
        /// Parameter: lti_message_type.
        /// Custom parameter substitution: n/a.
        /// Versions: 1.0, 1.1, 1.2, 2.0.
        /// Required.
        /// </para>
        /// </summary>
        string LtiMessageType { get; set; }
        /// <summary>
        /// This is the tool registration key. A single-use registration password is used when the TP submits the Tool Proxy to the TC. 
        /// This password should be valid for a few hours, which is enough to cover an extended interaction between the TC administrator
        /// and the TP deployment application.
        /// <para>
        /// Parameter: reg_key.
        /// Custom parameter substitution: n/a.
        /// Versions: 2.0.
        /// Required.
        /// </para>
        /// </summary>
        string RegistrationKey { get; set; }

        /// <summary>
        /// This is the tool registration password. A single-use registration password is used when the TP submits the Tool Proxy to the TC. 
        /// This password should be valid for a few hours, which is enough to cover an extended interaction between the TC administrator
        /// and the TP deployment application.
        /// <para>
        /// Parameter: reg_password.
        /// Custom parameter substitution: n/a.
        /// Versions: 2.0.
        /// Required.
        /// </para>
        /// </summary>
        string RegistrationPassword { get; set; }
        /// <summary>
        /// A comma-separated list of URI values for roles.  If this list is non-empty, 
        /// it should contain at least one role from the LIS System Role, LIS Institution Role, or LIS Context Role vocabularies.  
        /// The assumed namespace of these URIs is the LIS vocabulary of LIS Context Roles so Tool Consumers 
        /// can use the handles when the intent is to refer to an LIS context role.  
        /// If the Tool Consumer wants to include a role from another namespace, a fully-qualified URI should be used.  
        /// Usage of roles from non-LIS vocabularies is discouraged as it may limit interoperability.
        /// <para>
        /// Parameter: roles.
        /// Custom parameter substitution: n/a.
        /// Versions: 1.0, 1.1, 1.2, 2.0.
        /// Recommended.
        /// </para>
        /// </summary>
        string Roles { get; set; }
        /// <summary>
        /// This is a fully qualified URL pointing to the Tool Consumer Profile.  
        /// The Tool Provider should append the lti version as a parameter to this url: lti_version=ltiversion.
        /// If the lti_version is not specified or if the specified version is not explicitly supported 
        /// by the Tool Consumer then the Tool Consumer should return a profile for the newest version of LTI that they support.
        /// Note that the spec allows for a changing access token to be part of this url, so this value should not be persisted
        /// beyond the use of the current request.
        /// <para>
        /// Parameter: tc_profile_url.
        /// Custom parameter substitution: n/a.
        /// Versions: 2.0.
        /// Required.
        /// </para>
        /// </summary>
        string ToolConsumerProfileUrl { get; set; }
        /// <summary>
        /// Uniquely identifies the user. This should not contain any identifying information for the user.  
        /// Best practice is that this field should be a Tool Consumer-generated long-term “primary key” to the user record – not the “logical key". 
        /// <para>
        /// Parameter: user_id.
        /// Custom parameter substitution: n/a.
        /// Versions: 1.0, 1.1, 1.2, 2.0.
        /// Recommended.
        /// </para>
        /// </summary>
        string UserId { get; set; }
    }
}
