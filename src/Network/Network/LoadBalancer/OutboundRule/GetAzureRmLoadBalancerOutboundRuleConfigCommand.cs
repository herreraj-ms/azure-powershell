// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerOutboundRuleConfig"), OutputType(typeof(PSOutboundRule))]
    public partial class GetAzureRmLoadBalancerOutboundRuleConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the load balancer resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSLoadBalancer LoadBalancer { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the outbound rule.")]
        public string Name { get; set; }


        public override void Execute()
        {
            base.Execute();

            if(!string.IsNullOrEmpty(this.Name))
            {
                var vOutboundRules =
                        this.LoadBalancer.OutboundRules.First(
                            resource =>
                                string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));
                WriteObject(vOutboundRules);
            }
            else
            {
                WriteObject(LoadBalancer.OutboundRules, true);
            }
        }
    }
}
