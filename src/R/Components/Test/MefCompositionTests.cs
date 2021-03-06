﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.ComponentModel.Composition.Hosting;
using FluentAssertions;
using Microsoft.R.Components.History;
using Microsoft.R.Components.InteractiveWorkflow;
using Microsoft.R.Components.PackageManager;
using Microsoft.R.Components.Search;
using Microsoft.UnitTests.Core.XUnit;
using Microsoft.VisualStudio.InteractiveWindow;

namespace Microsoft.R.Components.Test {
    /// <summary>
    /// These tests are basic markers that all required composition imports are available.
    /// </summary>
    public class MefCompositionTests : IDisposable {
        private readonly ExportProvider _exportProvider;

        public MefCompositionTests(RComponentsMefCatalogFixture mefCatalog) {
            _exportProvider = mefCatalog.CreateExportProvider();
        }

        [Test]
        public void SearchControlProvider() {
            _exportProvider.GetExportedValue<ISearchControlProvider>().Should().NotBeNull();
        }

        [Test]
        public void RHistoryProvider() {
            _exportProvider.GetExportedValue<IRHistoryProvider>().Should().NotBeNull();
        }

        [Test]
        public void RInteractiveWorkflowProvider() {
            _exportProvider.GetExportedValue<IRInteractiveWorkflowProvider>().Should().NotBeNull();
        }

        [Test]
        public void RHistoryVisualComponentContainerFactory() {
            _exportProvider.GetExportedValue<IRHistoryVisualComponentContainerFactory>().Should().NotBeNull();
        }

        [Test]
        public void InteractiveWindowComponentContainerFactory() {
            _exportProvider.GetExportedValue<IInteractiveWindowComponentContainerFactory>().Should().NotBeNull();
        }

        [Test]
        public void RPackageManagerVisualComponentContainerFactory() {
            _exportProvider.GetExportedValue<IRPackageManagerVisualComponentContainerFactory>().Should().NotBeNull();
        }

        [Test]
        public void InteractiveWindowFactoryService() {
            _exportProvider.GetExportedValue<IInteractiveWindowFactoryService>().Should().NotBeNull();
        }

        public void Dispose() {
            (_exportProvider as IDisposable)?.Dispose();
        }
    }
}
