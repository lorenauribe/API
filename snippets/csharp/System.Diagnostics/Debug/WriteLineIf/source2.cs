﻿using System;
using System.Data;
using System.Diagnostics;

public class Form3
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    static TraceSwitch generalSwitch = new TraceSwitch("General", "Entire Application");

    static public void MyErrorMethod(string category)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        Debug.WriteIf(generalSwitch.TraceError, "My error message. ");

        // Write a second message if the TraceSwitch level is set to Verbose.
        Debug.WriteLineIf(generalSwitch.TraceVerbose, "My second error message.", category);
    }
    // </Snippet1>
}
