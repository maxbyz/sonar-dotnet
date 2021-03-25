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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonarAnalyzer.Helpers;
using SonarAnalyzer.UnitTest.TestFramework;
using CS = SonarAnalyzer.Rules.CSharp;
using VB = SonarAnalyzer.Rules.VisualBasic;

namespace SonarAnalyzer.UnitTest.Rules
{
    [TestClass]
    public class FieldShadowsParentFieldTest
    {
        [TestMethod]
        [TestCategory("Rule")]
        public void FieldShadowsParentField_CS() =>
            Verifier.VerifyAnalyzer(@"TestCases\FieldShadowsParentField.cs", new CS.FieldShadowsParentField());

        [TestMethod]
        [TestCategory("Rule")]
        public void FieldShadowsParentField_VB() =>
            Verifier.VerifyAnalyzer(@"TestCases\FieldShadowsParentField.vb", new VB.FieldShadowsParentField());

        [TestMethod]
        [TestCategory("Rule")]
        public void FieldShadowsParentField_DoesNotRaiseIssuesForTestProject_CS() =>
            Verifier.VerifyNoIssueReportedInTest(@"TestCases\FieldShadowsParentField.cs", new CS.FieldShadowsParentField());

        [TestMethod]
        [TestCategory("Rule")]
        public void FieldShadowsParentField_DoesNotRaiseIssuesForTestProject_VB() =>
            Verifier.VerifyNoIssueReportedInTest(@"TestCases\FieldShadowsParentField.vb", new VB.FieldShadowsParentField());

#if NET
        [TestMethod]
        [TestCategory("Rule")]
        public void FieldShadowsParentField_CSharp9() =>
            Verifier.VerifyAnalyzerFromCSharp9Library(@"TestCases\FieldShadowsParentField.CSharp9.cs", new CS.FieldShadowsParentField());

        [TestMethod]
        [TestCategory("Rule")]
        public void FieldsShouldNotDifferByCapitalization_CShar9() =>
            Verifier.VerifyAnalyzerFromCSharp9Library(@"TestCases\FieldsShouldNotDifferByCapitalization.CSharp9.cs", new CS.FieldShadowsParentField());
#endif

        [DataTestMethod]
        [DataRow(ProjectType.Product)]
        [DataRow(ProjectType.Test)]
        [TestCategory("Rule")]
        public void FieldsShouldNotDifferByCapitalization_CS(ProjectType projectType) =>
            Verifier.VerifyAnalyzer(@"TestCases\FieldsShouldNotDifferByCapitalization.cs", new CS.FieldShadowsParentField(), TestHelper.ProjectTypeReference(projectType));

        [DataTestMethod]
        [DataRow(ProjectType.Product)]
        [DataRow(ProjectType.Test)]
        [TestCategory("Rule")]
        public void FieldsShouldNotDifferByCapitalization_VB(ProjectType projectType) =>
            Verifier.VerifyAnalyzer(@"TestCases\FieldsShouldNotDifferByCapitalization.vb", new VB.FieldShadowsParentField(), TestHelper.ProjectTypeReference(projectType));
    }
}
