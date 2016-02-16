﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cadru.Net.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Strings() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Cadru.Net.Resources.Strings", typeof(Strings).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The query string is not in a correct format..
        /// </summary>
        internal static string InvalidOperation_QueryStringParameterDictionaryParsing {
            get {
                return ResourceManager.GetString("InvalidOperation_QueryStringParameterDictionaryParsing", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The operation was cancelled..
        /// </summary>
        internal static string net_cancelled {
            get {
                return ResourceManager.GetString("net_cancelled", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The value cannot be null or empty..
        /// </summary>
        internal static string net_http_argument_empty_string {
            get {
                return ResourceManager.GetString("net_http_argument_empty_string", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Both &apos;Content-Length&apos; and &apos;Transfer-Encoding: chunked&apos; headers can not be specified at the same time..
        /// </summary>
        internal static string net_http_chunked_not_allowed_with_content_length {
            get {
                return ResourceManager.GetString("net_http_chunked_not_allowed_with_content_length", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to &apos;Transfer-Encoding: chunked&apos; header can not be used when content object is not specified..
        /// </summary>
        internal static string net_http_chunked_not_allowed_with_empty_content {
            get {
                return ResourceManager.GetString("net_http_chunked_not_allowed_with_empty_content", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The base address must be an absolute URI..
        /// </summary>
        internal static string net_http_client_absolute_baseaddress_required {
            get {
                return ResourceManager.GetString("net_http_client_absolute_baseaddress_required", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to An error occurred while sending the request..
        /// </summary>
        internal static string net_http_client_execution_error {
            get {
                return ResourceManager.GetString("net_http_client_execution_error", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Only &apos;http&apos; and &apos;https&apos; schemes are allowed..
        /// </summary>
        internal static string net_http_client_http_baseaddress_required {
            get {
                return ResourceManager.GetString("net_http_client_http_baseaddress_required", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set..
        /// </summary>
        internal static string net_http_client_invalid_requesturi {
            get {
                return ResourceManager.GetString("net_http_client_invalid_requesturi", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The request message was already sent. Cannot send the same request message multiple times..
        /// </summary>
        internal static string net_http_client_request_already_sent {
            get {
                return ResourceManager.GetString("net_http_client_request_already_sent", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Request for {0} was canceled..
        /// </summary>
        internal static string net_http_client_send_canceled {
            get {
                return ResourceManager.GetString("net_http_client_send_canceled", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to An error occurred while sending {0}. {1}.
        /// </summary>
        internal static string net_http_client_send_error {
            get {
                return ResourceManager.GetString("net_http_client_send_error", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Cannot write more bytes to the buffer than the configured maximum buffer size: {0}..
        /// </summary>
        internal static string net_http_content_buffersize_exceeded {
            get {
                return ResourceManager.GetString("net_http_content_buffersize_exceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Buffering more than {0} bytes is not supported..
        /// </summary>
        internal static string net_http_content_buffersize_limit {
            get {
                return ResourceManager.GetString("net_http_content_buffersize_limit", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The field cannot be longer than {0} characters..
        /// </summary>
        internal static string net_http_content_field_too_long {
            get {
                return ResourceManager.GetString("net_http_content_field_too_long", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The character set provided in ContentType is invalid. Cannot read content as string using an invalid character set..
        /// </summary>
        internal static string net_http_content_invalid_charset {
            get {
                return ResourceManager.GetString("net_http_content_invalid_charset", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The async operation did not return a System.Threading.Tasks.Task object..
        /// </summary>
        internal static string net_http_content_no_task_returned {
            get {
                return ResourceManager.GetString("net_http_content_no_task_returned", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The stream does not support writing..
        /// </summary>
        internal static string net_http_content_readonly_stream {
            get {
                return ResourceManager.GetString("net_http_content_readonly_stream", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The stream was already consumed. It cannot be read again..
        /// </summary>
        internal static string net_http_content_stream_already_read {
            get {
                return ResourceManager.GetString("net_http_content_stream_already_read", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Error while copying content to a stream..
        /// </summary>
        internal static string net_http_content_stream_copy_error {
            get {
                return ResourceManager.GetString("net_http_content_stream_copy_error", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The number of elements is greater than the available space from arrayIndex to the end of the destination array..
        /// </summary>
        internal static string net_http_copyto_array_too_small {
            get {
                return ResourceManager.GetString("net_http_copyto_array_too_small", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to A request message must be provided. It cannot be null..
        /// </summary>
        internal static string net_http_handler_norequest {
            get {
                return ResourceManager.GetString("net_http_handler_norequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Handler did not return a response message..
        /// </summary>
        internal static string net_http_handler_noresponse {
            get {
                return ResourceManager.GetString("net_http_handler_noresponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The inner handler has not been assigned..
        /// </summary>
        internal static string net_http_handler_not_assigned {
            get {
                return ResourceManager.GetString("net_http_handler_not_assigned", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The specified value is not a valid quoted string..
        /// </summary>
        internal static string net_http_headers_invalid_etag_name {
            get {
                return ResourceManager.GetString("net_http_headers_invalid_etag_name", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The specified value is not a valid &apos;From&apos; header string..
        /// </summary>
        internal static string net_http_headers_invalid_from_header {
            get {
                return ResourceManager.GetString("net_http_headers_invalid_from_header", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The header name format is invalid..
        /// </summary>
        internal static string net_http_headers_invalid_header_name {
            get {
                return ResourceManager.GetString("net_http_headers_invalid_header_name", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The specified value is not a valid &apos;Host&apos; header string..
        /// </summary>
        internal static string net_http_headers_invalid_host_header {
            get {
                return ResourceManager.GetString("net_http_headers_invalid_host_header", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Invalid range. At least one of the two parameters must not be null..
        /// </summary>
        internal static string net_http_headers_invalid_range {
            get {
                return ResourceManager.GetString("net_http_headers_invalid_range", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The format of value &apos;{0}&apos; is invalid..
        /// </summary>
        internal static string net_http_headers_invalid_value {
            get {
                return ResourceManager.GetString("net_http_headers_invalid_value", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to New-line characters in header values must be followed by a white-space character..
        /// </summary>
        internal static string net_http_headers_no_newlines {
            get {
                return ResourceManager.GetString("net_http_headers_no_newlines", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Misused header name. Make sure request headers are used with HttpRequestMessage, response headers with HttpResponseMessage, and content headers with HttpContent objects..
        /// </summary>
        internal static string net_http_headers_not_allowed_header_name {
            get {
                return ResourceManager.GetString("net_http_headers_not_allowed_header_name", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The given header was not found..
        /// </summary>
        internal static string net_http_headers_not_found {
            get {
                return ResourceManager.GetString("net_http_headers_not_found", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Cannot add value because header &apos;{0}&apos; does not support multiple values..
        /// </summary>
        internal static string net_http_headers_single_value_header {
            get {
                return ResourceManager.GetString("net_http_headers_single_value_header", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The format of the HTTP method is invalid..
        /// </summary>
        internal static string net_http_httpmethod_format_error {
            get {
                return ResourceManager.GetString("net_http_httpmethod_format_error", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to When using CookieUsePolicy.UseSpecifiedCookieContainer, the CookieContainer property must not be null..
        /// </summary>
        internal static string net_http_invalid_cookiecontainer {
            get {
                return ResourceManager.GetString("net_http_invalid_cookiecontainer", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The {0} property must be set to &apos;{1}&apos; to use this property..
        /// </summary>
        internal static string net_http_invalid_enable_first {
            get {
                return ResourceManager.GetString("net_http_invalid_enable_first", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to When using WindowsProxyUsePolicy.UseCustomProxy, the Proxy property must not be null..
        /// </summary>
        internal static string net_http_invalid_proxy {
            get {
                return ResourceManager.GetString("net_http_invalid_proxy", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to When using a non-null Proxy, the WindowsProxyUsePolicy property must be set to WindowsProxyUsePolicy.UseCustomProxy..
        /// </summary>
        internal static string net_http_invalid_proxyusepolicy {
            get {
                return ResourceManager.GetString("net_http_invalid_proxyusepolicy", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The read operation failed, see inner exception..
        /// </summary>
        internal static string net_http_io_read {
            get {
                return ResourceManager.GetString("net_http_io_read", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The write operation failed, see inner exception..
        /// </summary>
        internal static string net_http_io_write {
            get {
                return ResourceManager.GetString("net_http_io_write", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Type &apos;{0}.CopyToAsync()&apos; did not return a System.Threading.Tasks.Task object..
        /// </summary>
        internal static string net_http_log_content_no_task_returned_copytoasync {
            get {
                return ResourceManager.GetString("net_http_log_content_no_task_returned_copytoasync", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The &apos;q&apos; value is invalid: &apos;{0}&apos;..
        /// </summary>
        internal static string net_http_log_headers_invalid_quality {
            get {
                return ResourceManager.GetString("net_http_log_headers_invalid_quality", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Value for header &apos;{0}&apos; contains invalid new-line characters. Value: &apos;{1}&apos;..
        /// </summary>
        internal static string net_http_log_headers_no_newlines {
            get {
                return ResourceManager.GetString("net_http_log_headers_no_newlines", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Value &apos;{0}&apos; is not a valid email address. Error: {1}.
        /// </summary>
        internal static string net_http_log_headers_wrong_email_format {
            get {
                return ResourceManager.GetString("net_http_log_headers_wrong_email_format", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Response status code does not indicate success: {0} ({1})..
        /// </summary>
        internal static string net_http_message_not_success_statuscode {
            get {
                return ResourceManager.GetString("net_http_message_not_success_statuscode", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to This instance has already started one or more requests. Properties can only be modified before sending the first request..
        /// </summary>
        internal static string net_http_operation_started {
            get {
                return ResourceManager.GetString("net_http_operation_started", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Value &apos;{0}&apos; is not a valid Base64 string. Error: {1}.
        /// </summary>
        internal static string net_http_parser_invalid_base64_string {
            get {
                return ResourceManager.GetString("net_http_parser_invalid_base64_string", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The reason phrase must not contain new-line characters..
        /// </summary>
        internal static string net_http_reasonphrase_format_error {
            get {
                return ResourceManager.GetString("net_http_reasonphrase_format_error", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The specified value must be greater than {0}..
        /// </summary>
        internal static string net_http_value_must_be_greater_than {
            get {
                return ResourceManager.GetString("net_http_value_must_be_greater_than", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The value &apos;{0}&apos; is not supported for property &apos;{1}&apos;..
        /// </summary>
        internal static string net_http_value_not_supported {
            get {
                return ResourceManager.GetString("net_http_value_not_supported", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to The operation has timed out..
        /// </summary>
        internal static string net_timeout {
            get {
                return ResourceManager.GetString("net_timeout", resourceCulture);
            }
        }
    }
}
