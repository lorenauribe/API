﻿//<SNIPPET1>
using System;
using System.IO;

public class FileExample
{
    public static void Main()
    {
        // Create a temporary file
        string filePath = Path.GetTempFileName();
        Console.WriteLine($"Created a temp file at '{filePath}'.");

        // Create a new FileInfo object.
        FileInfo fInfo = new FileInfo(filePath);

        // Get the read-only value for a file.
        bool isReadOnly = fInfo.IsReadOnly;

        // Display whether the file is read-only.
        Console.WriteLine($"The file read-only value for '{fInfo.Name}' is {isReadOnly}.");

        // Set the file to read-only.        
        Console.WriteLine($"Setting the read-only value for '{fInfo.Name}' to true.");
        fInfo.IsReadOnly = true;

        // Get the read-only value for a file.
        isReadOnly = fInfo.IsReadOnly;

        // Display that the file is now read-only.
        Console.WriteLine($"The file read-only value for '{fInfo.Name}' is {isReadOnly}.");

        // Make the file mutable again so it can be deleted.
        fInfo.IsReadOnly = false;

        // Delete the temporary file.
        fInfo.Delete();
    }
}

// This code produces output similar to the following,
// though results may vary based on the computer, file structure, etc.:
//
// Created a temp file at 'C:\Users\UserName\AppData\Local\Temp\tmpB438.tmp'.
// The file read-only value for 'tmpB438.tmp' is False.
// Setting the read-only value for 'tmpB438.tmp' to true.
// The file read-only value for 'tmpB438.tmp' is True.
//
//</SNIPPET1>