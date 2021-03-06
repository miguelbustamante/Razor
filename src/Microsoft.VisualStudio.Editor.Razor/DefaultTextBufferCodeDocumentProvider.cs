﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel.Composition;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.VisualStudio.Text;

namespace Microsoft.VisualStudio.Editor.Razor
{
    [System.Composition.Shared]
    [Export(typeof(TextBufferCodeDocumentProvider))]
    internal class DefaultTextBufferCodeDocumentProvider : TextBufferCodeDocumentProvider
    {
        private readonly RazorEditorFactoryService _editorFactoryService;

        [ImportingConstructor]
        public DefaultTextBufferCodeDocumentProvider(RazorEditorFactoryService editorFactoryService)
        {
            if (editorFactoryService == null)
            {
                throw new ArgumentNullException(nameof(editorFactoryService));
            }

            _editorFactoryService = editorFactoryService;
        }

        public override bool TryGetFromBuffer(ITextBuffer textBuffer, out RazorCodeDocument codeDocument)
        {
            if (textBuffer == null)
            {
                throw new ArgumentNullException(nameof(textBuffer));
            }

            if (_editorFactoryService.TryGetParser(textBuffer, out var parser) && parser.CodeDocument != null)
            {
                codeDocument = parser.CodeDocument;
                return true;
            }

            codeDocument = null;
            return false;
        }
    }
}
