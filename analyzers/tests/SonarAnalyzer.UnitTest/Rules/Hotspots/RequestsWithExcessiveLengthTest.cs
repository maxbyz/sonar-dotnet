﻿/*
 * SonarAnalyzer for .NET
 * Copyright (C) 2015-2021 SonarSource SA
 * mailto: contact AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonarAnalyzer.Common;
using SonarAnalyzer.UnitTest.MetadataReferences;
using SonarAnalyzer.UnitTest.TestFramework;
using CS = SonarAnalyzer.Rules.CSharp;
using VB = SonarAnalyzer.Rules.VisualBasic;

namespace SonarAnalyzer.UnitTest.Rules
{
    [TestClass]
    public class RequestsWithExcessiveLengthTest
    {
        [TestMethod]
        [TestCategory("Rule")]
        [TestCategory("Hotspot")]
        public void RequestsWithExcessiveLength_CS() =>
            Verifier.VerifyAnalyzer(@"TestCases\Hotspots\RequestsWithExcessiveLength.cs",
                new CS.RequestsWithExcessiveLength(AnalyzerConfiguration.AlwaysEnabled),
                GetAdditionalReferences());

        [TestMethod]
        [TestCategory("Rule")]
        [TestCategory("Hotspot")]
        public void RequestsWithExcessiveLength_CS_CustomValues() =>
            Verifier.VerifyAnalyzer(@"TestCases\Hotspots\RequestsWithExcessiveLength_CustomValues.cs",
                new CS.RequestsWithExcessiveLength(AnalyzerConfiguration.AlwaysEnabled) { FileUploadSizeLimit = 42 },
                GetAdditionalReferences());

#if NET
        [TestMethod]
        [TestCategory("Rule")]
        [TestCategory("Hotspot")]
        public void RequestsWithExcessiveLength_Csharp9() =>
            Verifier.VerifyAnalyzerFromCSharp9Library(@"TestCases\Hotspots\RequestsWithExcessiveLength.CSharp9.cs",
                new CS.RequestsWithExcessiveLength(AnalyzerConfiguration.AlwaysEnabled),
                GetAdditionalReferences());
#endif

        [TestMethod]
        [TestCategory("Rule")]
        [TestCategory("Hotspot")]
        public void RequestsWithExcessiveLength_VB() =>
            Verifier.VerifyAnalyzer(@"TestCases\Hotspots\RequestsWithExcessiveLength.vb",
                new VB.RequestsWithExcessiveLength(AnalyzerConfiguration.AlwaysEnabled),
                GetAdditionalReferences());

        [TestMethod]
        [TestCategory("Rule")]
        [TestCategory("Hotspot")]
        public void RequestsWithExcessiveLength_VB_CustomValues() =>
            Verifier.VerifyAnalyzer(@"TestCases\Hotspots\RequestsWithExcessiveLength_CustomValues.vb",
                new VB.RequestsWithExcessiveLength(AnalyzerConfiguration.AlwaysEnabled) { FileUploadSizeLimit = 42 },
                GetAdditionalReferences());

        internal static IEnumerable<MetadataReference> GetAdditionalReferences() =>
            NuGetMetadataReference.MicrosoftAspNetCoreMvcCore(Constants.NuGetLatestVersion)
                .Concat(NuGetMetadataReference.MicrosoftAspNetCoreMvcViewFeatures(Constants.NuGetLatestVersion));
    }
}
