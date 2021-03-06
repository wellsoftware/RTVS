﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.ComponentModel.Composition;
using System.Windows;
using Microsoft.R.Components.PackageManager.ViewModel;
using Microsoft.R.Components.Search;

namespace Microsoft.R.Components.Test.Fakes.Search {
    [Export(typeof(ISearchControlProvider))]
    internal class TestSearchControlProvider : ISearchControlProvider {
        public ISearchControl Create(FrameworkElement host, IRPackageManagerViewModel handler, SearchControlSettings settings) {
            return new TestSearchControl(handler, settings);
        }
    }
}
