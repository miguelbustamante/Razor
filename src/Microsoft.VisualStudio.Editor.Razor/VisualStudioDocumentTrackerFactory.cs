﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.VisualStudio.Text;

namespace Microsoft.VisualStudio.Editor.Razor
{
    internal abstract class VisualStudioDocumentTrackerFactory
    {
        public abstract VisualStudioDocumentTracker Create(ITextBuffer textBuffer);
    }
}
