﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.R.Components.Extensions;
using Microsoft.VisualStudio.ProjectSystem;
#if VS14
using Microsoft.VisualStudio.ProjectSystem.Designers;
#endif
#if VS15
using Microsoft.VisualStudio.ProjectSystem.Properties;
#endif
using Microsoft.VisualStudio.R.Package.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace Microsoft.VisualStudio.R.Package.ProjectSystem {
    internal static class IVsHierarchyExtensions {
        /// <summary>
        /// Returns EnvDTE.Project object for the hierarchy
        /// </summary>
        public static EnvDTE.Project GetDTEProject(this IVsHierarchy hierarchy) {
            VsAppShell.Current.AssertIsOnMainThread();
            object extObject;
            if (ErrorHandler.Succeeded(hierarchy.GetProperty(VSConstants.VSITEMID_ROOT, (int)__VSHPROPID.VSHPROPID_ExtObject, out extObject))) {
                return extObject as EnvDTE.Project;
            }
            return null;
        }

        /// <summary>
        /// Convenient way to get to the UnconfiguredProject from the hierarchy
        /// </summary>
        public static UnconfiguredProject GetUnconfiguredProject(this IVsHierarchy hierarchy) {
            VsAppShell.Current.AssertIsOnMainThread();
            IVsBrowseObjectContext context = hierarchy as IVsBrowseObjectContext;
            if (context == null) {
                EnvDTE.Project dteProject = hierarchy.GetDTEProject();
                if (dteProject != null) {
                    context = dteProject.Object as IVsBrowseObjectContext;
                }
            }

            return context?.UnconfiguredProject;
        }
    }
}
