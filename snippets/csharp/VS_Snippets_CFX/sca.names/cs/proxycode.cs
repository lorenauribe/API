﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.WCF.Documentation", ConfigurationName="HelloWorld")]
public interface HelloWorld
{

    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.WCF.Documentation/HelloWorld/SampleMethod", ReplyAction="http://Microsoft.WCF.Documentation/HelloWorld/SampleMethodResponse")]
    string SampleMethod(string msg);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface HelloWorldChannel : HelloWorld, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class HelloWorldClient : System.ServiceModel.ClientBase<HelloWorld>, HelloWorld
{

    public HelloWorldClient()
    {
    }

    public HelloWorldClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {
    }

    public HelloWorldClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public HelloWorldClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public HelloWorldClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
    {
    }

    public string SampleMethod(string msg)
    {
        return base.Channel.SampleMethod(msg);
    }
}
