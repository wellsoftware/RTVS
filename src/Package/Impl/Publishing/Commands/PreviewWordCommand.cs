﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.Markdown.Editor.Commands;
using Microsoft.R.Components.InteractiveWorkflow;
using Microsoft.VisualStudio.R.Package.Publishing.Definitions;
using Microsoft.VisualStudio.Text.Editor;

namespace Microsoft.VisualStudio.R.Package.Publishing.Commands {
    internal sealed class PreviewWordCommand : PreviewCommand {
        public PreviewWordCommand(ITextView textView, IRInteractiveWorkflowProvider workflowProvider)
            : base(textView, (int)MdPackageCommandId.icmdPreviewWord, workflowProvider) {
        }

        protected override string FileExtension {
            get { return "docx"; }
        }

        protected override PublishFormat Format {
            get { return PublishFormat.Word; }
        }
    }
}
