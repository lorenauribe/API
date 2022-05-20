﻿module round4

// <Snippet3>
open System

let values = [| 2.125; 2.135; 2.145; 3.125; 3.135; 3.145 |]
for value in values do
    printfn $"{value} --> {Math.Round(value, 2, MidpointRounding.AwayFromZero)}"
// The example displays the following output:
//       2.125 --> 2.13
//       2.135 --> 2.13
//       2.145 --> 2.15
//       3.125 --> 3.13
//       3.135 --> 3.14
//       3.145 --> 3.15
// </Snippet3>