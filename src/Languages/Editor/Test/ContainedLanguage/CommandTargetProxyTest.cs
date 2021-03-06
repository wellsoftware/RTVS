﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.Languages.Editor.Services;
using Microsoft.Markdown.Editor.ContainedLanguage;
using Microsoft.R.Components.Controller;
using Microsoft.UnitTests.Core.XUnit;
using Microsoft.VisualStudio.Editor.Mocks;
using NSubstitute;

namespace Microsoft.Languages.Editor.Test.ContainedLanguage {
    [ExcludeFromCodeCoverage]
    public class CommandTargetProxyTest {
        [Test]
        [Category.Languages.Contained]
        public void Test01() {
            var tv = new TextViewMock(new TextBufferMock(string.Empty, "text"));
            var proxy = CommandTargetProxy.GetProxyTarget(tv);
            object o = new object();

            proxy.Should().NotBeNull();
            ServiceManager.GetService<CommandTargetProxy>(tv).Should().Be(proxy);

            proxy.Status(Guid.Empty, 0).Should().Be(CommandStatus.NotSupported);
            proxy.Invoke(Guid.Empty, 0, null, ref o).Should().Be(CommandResult.NotSupported);

            var ct = Substitute.For<ICommandTarget>();
            ct.Status(Guid.Empty, 0).Returns(CommandStatus.Supported);

            CommandTargetProxy.SetCommandTarget(tv, ct);
            ServiceManager.GetService<CommandTargetProxy>(tv).Should().BeNull();

            proxy.Status(Guid.Empty, 0).Should().Be(CommandStatus.Supported);
        }
    }
}