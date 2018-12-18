// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace NLU.DevOps.Demo
{
    using System.Composition;
    using Microsoft.Extensions.Configuration;
    using Models;

    [Export("demo", typeof(INLUServiceFactory))]
    public class DemoNLUServiceFactory : INLUServiceFactory
    {
        public INLUService CreateInstance(IConfiguration configuration, string settingsPath)
        {
            return new DemoNLUService(configuration["trainedUtterances"]);
        }
    }
}