using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Proxy;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
	    public static ProxyOptions GetProxyOptions(this IConfigurationSection config)
	    {
		    // Host & AppendQuery properties will not bind correctly 
		    // due to objects being ctor sealed 
		    var proxyOptions = config.Get<ProxyOptions>();
		    proxyOptions.Host = HostString.FromUriComponent(config["Host"]);
		    proxyOptions.AppendQuery = QueryString.FromUriComponent(config["AppendQuery"]);
		    return proxyOptions;
	    }
    }
}
