﻿// Copyright 2023 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License

using Google.Cloud.Dlp.V2;
using Xunit;

namespace GoogleCloudSamples
{
    public class DeidentifyTableWithInfoTypesTests : IClassFixture<DlpTestFixture>
    {
        private DlpTestFixture _fixture;
        public DeidentifyTableWithInfoTypesTests(DlpTestFixture fixture) => _fixture = fixture;

        [Fact]
        public void TestDeidentifyTableWithInfoTypes()
        {
            var patientName = "Charles Dickens";
            var infoTypes = new InfoType[] { new InfoType { Name = "PERSON_NAME" } };
            var result = DeidentifyTableWithInfoTypes.DeidentifyTable(_fixture.ProjectId, infoTypes: infoTypes);
            var serializedResult = result.ToString();
            Assert.DoesNotContain(patientName, serializedResult);
            Assert.Contains("[PERSON_NAME]", serializedResult);
        }
    }
}