﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://microsoft.wcf.documentation", ClrNamespace="microsoft.wcf.documentation")]

namespace microsoft.wcf.documentation
{
    using System.Runtime.Serialization;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class SampleFault : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private string FaultMessageField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FaultMessage
        {
            get
            {
                return this.FaultMessageField;
            }
            set
            {
                this.FaultMessageField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://microsoft.wcf.documentation")]
public interface ISampleService
{

    [System.ServiceModel.OperationContractAttribute(Action="http://microsoft.wcf.documentation/ISampleService/SampleMethod", ReplyAction="http://microsoft.wcf.documentation/ISampleService/SampleMethodResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(microsoft.wcf.documentation.SampleFault), Action="http://microsoft.wcf.documentation/ISampleService/SampleMethodSampleFaultFault")]
    string SampleMethod(string msg);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ISampleServiceChannel : ISampleService, System.ServiceModel.IClientChannel
{
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class SampleServiceClient : System.ServiceModel.ClientBase<ISampleService>, ISampleService
{

    public SampleServiceClient()
    {
    }

    public SampleServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {
    }

    public SampleServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public SampleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public SampleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
    {
    }

    public string SampleMethod(string msg)
    {
        return base.Channel.SampleMethod(msg);
    }
}
