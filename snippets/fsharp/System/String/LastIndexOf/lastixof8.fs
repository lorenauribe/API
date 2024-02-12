module lastixof8.fs
//<snippet1>
// Sample for String.LastIndexOf(String, Int32, Int32)
open System

let br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-"
let br2 = "0123456789012345678901234567890123456789012345678901234567890123456"
let str = "Now is the time for all good men to come to the aid of their party."

let mutable start = str.Length-1
let last = start / 2 - 1
printfn $"All occurrences of 'he' from position {start} to {last}."
printfn $"{br1}{Environment.NewLine}{br2}{Environment.NewLine}{str}{Environment.NewLine}"
printf "The string 'he' occurs at position(s): "

let mutable at = 0
while (start > -1) && (at > -1) do
    let count = start - last //Count must be within the substring.
    at <- str.LastIndexOf("he", start, count)
    if at > -1 then
        printf $"{at} "
        start <- at - 1
printf $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}"
(*
This example produces the following results:
All occurrences of 'he' from position 66 to 32.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

The string 'he' occurs at position(s): 56 45
*)
//</snippet1>
