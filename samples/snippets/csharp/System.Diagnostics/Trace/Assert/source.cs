﻿using System;
using System.Data;
using System.Diagnostics;

// <Snippet1>
// Create an index for an array.
protected int index;

protected void Method()
{
    // Perform some action that sets the index.

    // Test that the index value is valid.
    Trace.Assert(index > -1);
}
// </Snippet1>
