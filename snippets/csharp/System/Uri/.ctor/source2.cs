using System;
using System.Data;
using System.Security.Principal;
using System.IO;


public class Form1
{
 protected void Method()
 {
// <Snippet1>
Uri baseUri = new Uri("http://www.contoso.com");
 Uri myUri = new Uri(baseUri, "catalog/shownew.htm");

Console.WriteLine(myUri.ToString());

// </Snippet1>
 }
}
