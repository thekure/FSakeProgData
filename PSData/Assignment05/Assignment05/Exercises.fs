module Exercises

// 5.1 (see CSharpEx/Program.cs for second part)

let merge (lst1, lst2) =
    List.sort (lst1 @ lst2)
 
let e1 = merge ([3;5;12], [2;3;4;7])