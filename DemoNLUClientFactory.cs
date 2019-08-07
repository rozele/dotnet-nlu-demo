// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace NLU.DevOps.Demo
{
    using System.Composition;
    using Microsoft.Extensions.Configuration;
    using Models;

    [Export("demo", typeof(INLUClientFactory))]
    public class DemoNLUClientFactory : INLUClientFactory
    {
        public INLUTrainClient CreateTrainInstance(IConfiguration configuration, string settingsPath)
        {
            return new DemoNLUClient(configuration["trainedUtterances"]);
        }

        public INLUTestClient CreateTestInstance(IConfiguration configuration, string settingsPath)
        {
            return new DemoNLUClient(configuration["trainedUtterances"]);
        }
    }
}
