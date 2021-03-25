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

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonarAnalyzer.Helpers;
using SonarAnalyzer.Rules.CSharp;
using SonarAnalyzer.Rules.SymbolicExecution;
using SonarAnalyzer.UnitTest.MetadataReferences;
using SonarAnalyzer.UnitTest.TestFramework;

namespace SonarAnalyzer.UnitTest.Rules
{
    [TestClass]
    public class ObjectsShouldNotBeDisposedMoreThanOnceTest
    {
        [DataTestMethod]
        [DataRow(ProjectType.Product)]
        [DataRow(ProjectType.Test)]
        [TestCategory("Rule")]
        public void ObjectsShouldNotBeDisposedMoreThanOnce(ProjectType projectType) =>
            Verifier.VerifyAnalyzer(@"TestCases\ObjectsShouldNotBeDisposedMoreThanOnce.cs",
                new SymbolicExecutionRunner(new ObjectsShouldNotBeDisposedMoreThanOnce()),
                ParseOptionsHelper.FromCSharp8,
#if NETFRAMEWORK
                TestHelper.ProjectTypeReference(projectType).Concat(NuGetMetadataReference.NETStandardV2_1_0));
#else
                TestHelper.ProjectTypeReference(projectType));
#endif

#if NET
        [TestMethod]
        [TestCategory("Rule")]
        public void ObjectsShouldNotBeDisposedMoreThanOnce_CSharp9() =>
            Verifier.VerifyAnalyzerFromCSharp9Console(@"TestCases\ObjectsShouldNotBeDisposedMoreThanOnce.CSharp9.cs", new SymbolicExecutionRunner(new ObjectsShouldNotBeDisposedMoreThanOnce()));
#endif
    }
}
