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
    Is the third one as expected?
    Yes and no, depends on how smart you are. 2/3 of our group made the naive and wrong assumption, while
    one member (the big genius) nailed it. So he insists that it behaves as expected, while our bruised egos
    maintains the opposite. Here follows our logic tho:

    The function add takes one arguments, x 
    f also takes one argument, y. 
    When addtwo 5 evaluates, 5 becomes the y in the f call while 2 remains the x
    to the add call. The x that is 77 is never used. It is scoped in the innermost part of the evaluation,
    where it is irrelevant.
    
    Explain result of last one:
    
    Getting a closure as we are still expecting a second input - that is, what is y? Right now y is a 
    function that still needs an input - thus the instruction is still valid, just does not evaluate 
    to a numerical result.
*)



