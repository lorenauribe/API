// <Snippet1>
open System

let baseUri = Uri "http://www.contoso.com/"
let myUri = Uri(baseUri,"catalog/shownew.htm?date=today")

printfn $"{myUri.Port}"
// </Snippet1>