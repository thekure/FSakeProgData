module Exercises

// 5.1 A)

let merge (lst1, lst2) =
    List.sort (lst1 @ lst2)
 
let e1 = merge ([3;5;12], [2;3;4;7])

// 5.1 B)
// See CSharpEx/Program.cs for second part.

// 5.7

// Edited TypedFun from line 143. Used line 180 and 181 as tests.

// 6.1

(*
    The function add takes two arguments, x being the first, the second is passed as the y argument 
    to f. When addtwo 5 evaluates, 5 becomes the y in the f call while 2 remains the x
    to the add call. x is never used. It is scoped in the innermost part of the evaluation,
    where it is irrelevant.
*)

