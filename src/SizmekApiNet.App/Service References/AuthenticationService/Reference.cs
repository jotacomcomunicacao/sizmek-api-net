﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SizmekApiNet.App.AuthenticationService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClientInfo", Namespace="http://api.eyeblaster.com/V1/DataContracts")]
    [System.SerializableAttribute()]
    public partial class ClientInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int AccountIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        private int TimeZoneField;
        
        private int UserIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int AccountID {
            get {
                return this.AccountIDField;
            }
            set {
                if ((this.AccountIDField.Equals(value) != true)) {
                    this.AccountIDField = value;
                    this.RaisePropertyChanged("AccountID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int TimeZone {
            get {
                return this.TimeZoneField;
            }
            set {
                if ((this.TimeZoneField.Equals(value) != true)) {
                    this.TimeZoneField = value;
                    this.RaisePropertyChanged("TimeZone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int UserID {
            get {
                return this.UserIDField;
            }
            set {
                if ((this.UserIDField.Equals(value) != true)) {
                    this.UserIDField = value;
                    this.RaisePropertyChanged("UserID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://api.eyeblaster.com/", ConfigurationName="AuthenticationService.IAuthenticationService")]
    public interface IAuthenticationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.eyeblaster.com/IAuthenticationService/ClientLogin", ReplyAction="http://api.eyeblaster.com/IAuthenticationService/ClientLoginResponse")]
        string ClientLogin(string username, string password, string applicationKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.eyeblaster.com/IAuthenticationService/ClientLogout", ReplyAction="http://api.eyeblaster.com/IAuthenticationService/ClientLogoutResponse")]
        void ClientLogout(string userSecurityToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.eyeblaster.com/IAuthenticationService/ClientImpersonation", ReplyAction="http://api.eyeblaster.com/IAuthenticationService/ClientImpersonationResponse")]
        string ClientImpersonation(string userSecurityToken, string username, string password);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://api.eyeblaster.com/message) of message GetClientInfoRequest does not match the default value (http://api.eyeblaster.com/)
        [System.ServiceModel.OperationContractAttribute(Action="http://api.eyeblaster.com/IAuthenticationService/GetClientInfo", ReplyAction="http://api.eyeblaster.com/IAuthenticationService/GetClientInfoResponse")]
        SizmekApiNet.App.AuthenticationService.GetClientInfoResponse GetClientInfo(SizmekApiNet.App.AuthenticationService.GetClientInfoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetClientInfoRequest", WrapperNamespace="http://api.eyeblaster.com/message", IsWrapped=true)]
    public partial class GetClientInfoRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://api.eyeblaster.com/message")]
        public string UserSecurityToken;
        
        public GetClientInfoRequest() {
        }
        
        public GetClientInfoRequest(string UserSecurityToken) {
            this.UserSecurityToken = UserSecurityToken;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetClientInfoResponse", WrapperNamespace="http://api.eyeblaster.com/message", IsWrapped=true)]
    public partial class GetClientInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://api.eyeblaster.com/message", Order=0)]
        public SizmekApiNet.App.AuthenticationService.ClientInfo ClientInfo;
        
        public GetClientInfoResponse() {
        }
        
        public GetClientInfoResponse(SizmekApiNet.App.AuthenticationService.ClientInfo ClientInfo) {
            this.ClientInfo = ClientInfo;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationServiceChannel : SizmekApiNet.App.AuthenticationService.IAuthenticationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationServiceClient : System.ServiceModel.ClientBase<SizmekApiNet.App.AuthenticationService.IAuthenticationService>, SizmekApiNet.App.AuthenticationService.IAuthenticationService {
        
        public AuthenticationServiceClient() {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ClientLogin(string username, string password, string applicationKey) {
            return base.Channel.ClientLogin(username, password, applicationKey);
        }
        
        public void ClientLogout(string userSecurityToken) {
            base.Channel.ClientLogout(userSecurityToken);
        }
        
        public string ClientImpersonation(string userSecurityToken, string username, string password) {
            return base.Channel.ClientImpersonation(userSecurityToken, username, password);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SizmekApiNet.App.AuthenticationService.GetClientInfoResponse SizmekApiNet.App.AuthenticationService.IAuthenticationService.GetClientInfo(SizmekApiNet.App.AuthenticationService.GetClientInfoRequest request) {
            return base.Channel.GetClientInfo(request);
        }
        
        public SizmekApiNet.App.AuthenticationService.ClientInfo GetClientInfo(string UserSecurityToken) {
            SizmekApiNet.App.AuthenticationService.GetClientInfoRequest inValue = new SizmekApiNet.App.AuthenticationService.GetClientInfoRequest();
            inValue.UserSecurityToken = UserSecurityToken;
            SizmekApiNet.App.AuthenticationService.GetClientInfoResponse retVal = ((SizmekApiNet.App.AuthenticationService.IAuthenticationService)(this)).GetClientInfo(inValue);
            return retVal.ClientInfo;
        }
    }
}