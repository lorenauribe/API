using System;
using System.Data;
using System.Security.Principal;


public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>
UriBuilder myUri = new UriBuilder("http","www.contoso.com",8080,"index.htm","#top");

// </Snippet1>
 }
}
