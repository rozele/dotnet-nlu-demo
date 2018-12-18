// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace NLU.DevOps.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;

    internal sealed class DemoNLUService : INLUService
    {
        public DemoNLUService(string trainedUtterances)
        {
            this.Utterances = new List<LabeledUtterance>();
            if (trainedUtterances != null)
            {
                this.Utterances.AddRange(
                    JsonConvert.DeserializeObject<IEnumerable<LabeledUtterance>>(trainedUtterances));
            }
        }

        public string TrainedUtterances => JsonConvert.SerializeObject(this.Utterances);

        private List<LabeledUtterance> Utterances { get; }

        public Task TrainAsync(IEnumerable<LabeledUtterance> utterances, CancellationToken cancellationToken)
        {
            this.Utterances.AddRange(utterances);
            return Task.CompletedTask;
        }

        public Task<LabeledUtterance> TestAsync(string utterance, CancellationToken cancellationToken)
        {
            var matchedUtterance = this.Utterances.FirstOrDefault(u => u.Text == utterance);
            return Task.FromResult(matchedUtterance ?? new LabeledUtterance(null, null, null));
        }

        public Task<LabeledUtterance> TestSpeechAsync(string speechFile, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CleanupAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }
    }
}
