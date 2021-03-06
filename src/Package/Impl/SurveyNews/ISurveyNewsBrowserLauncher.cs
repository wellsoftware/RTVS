﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Microsoft.VisualStudio.R.Package.SurveyNews {
    internal interface ISurveyNewsBrowserLauncher {
        void Navigate(string url);
        void NavigateOnIdle(string url);
    }
}
