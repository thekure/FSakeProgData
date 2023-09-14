module Exercise_3_6

(*
    Use the expression parser from Parse.fs and the compiler scomp (from expressions
    to stack machine instructions) and the associated datatypes from Expr.fs, to deﬁne
    a function compString : string -> sinstr list that parses a string as an expression
    and compiles it to stack machine code.
*)

open Parse
open Expr
let compString str =
    (fromString str, []) ||> scomp