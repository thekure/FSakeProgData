
(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111); ("l", 0)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;

(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr

let e1 = CstI 17;;
let e2 = Prim("+", CstI 3, Var "a");;
let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | If (e1, e2, e3) -> if (eval e1 env) <> 0  then (eval e2 env) else (eval e3 env) //bound to == which seems weird
    | Prim (ope, e1, e2) -> 
          let i1 = eval e1 env
          let i2 = eval e2 env
          match ope with
          | "+" -> i1 + i2
          | "-" -> i1 - i2
          | "*" -> i1 * i2
          | "max" -> max i1 i2
          | "min" -> min i1 i2
          | "==" -> if i1 = i2 then 1 else 0
          | _ -> failwith "unkown primitive"


let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

let maxExp = Prim ("max", CstI 3, CstI 4)
let minExp = Prim ("min", CstI 3, CstI 4)
let equalNoExp = Prim ("==", CstI 3, CstI 4)
let equalYesExp = Prim ("==", CstI 15, CstI 15)


let ifExp = If(Var "l", CstI 11, CstI 22)


type aexpr = 
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr

//Expression 1 :  v - (w + z) 
let aexprExp1 = Sub (Var "v", (Add (Var "w", Var "z" )))
// 2 *  (v - (w + z))
let aexprExp2 = Mul (CstI 2, (Sub (Var "v", Add(Var "w", Var "z"))))
// x + y + z + v
let aexprExp3 = Add(Add(Add(Var "x", Var "y"), Var "z"), Var "v")

let rec fmt (e: aexpr) : string = 
  match e with
  | CstI n -> string n 
  | Var s -> s
  | Add (e1 , e2) -> "(" + (fmt e1) + " + " + fmt e2 + ")"
  | Mul (e1 , e2) -> "(" + (fmt e1) + " * " + fmt e2 + ")"
  | Sub (e1 , e2) -> "(" + (fmt e1) + " - " + fmt e2 + ")"


let rec simplify (e: aexpr) : aexpr = 
  match e with
  | CstI n -> CstI n 
  | Var s -> Var s
  | Add (e1, CstI 0) | Sub (e1 , CstI 0) | Mul(e1, CstI 1)-> simplify e1
  | Add (CstI 0, e2) | Mul (CstI 1, e2) -> simplify e2
  | Mul (_, CstI 0) | Mul(CstI 0, _)  -> CstI 0
  | Sub(e1,e2) when e1 = e2 -> CstI 0
  //Now check for if we should simplify the root
  | Add(e1,e2) when simplify e1 = CstI 0 || simplify e2 = CstI 0 -> simplify (Add(simplify e1, simplify e2))
  | Sub(e1,e2) when simplify e2 = CstI 0 -> simplify (Sub(simplify e1, simplify e2))
  | Mul(e1, e2) when ((simplify e1 = CstI 1) || (simplify e2 = CstI 1)) || ((simplify e1 = CstI 0) || (simplify e2 = CstI 0)) -> simplify (Mul(simplify e1, simplify e2))
  //Else just simplyfy content
  | Add(e1, e2) -> Add (simplify e1, simplify e2)
  | Mul(e1, e2) -> Mul (simplify e1, simplify e2)
  | Sub(e1, e2) -> Sub (simplify e1, simplify e2)



let simplifyThis = Add (Var "x", CstI 0)
let simplifyThis2 = Mul (Add (CstI 1, CstI 0), Add (Var "x", CstI 0))


//Write an F# function to perform symbolic differentiation of simple arithmetic expressions (such as aexpr) with respect to a single variable.

let rec symDiff (e: aexpr) (variable: string) : aexpr = 
  match e with
  | CstI _ -> CstI 0
  | Var v when v = variable -> CstI 1
  | Var _ -> CstI 0
  | Add (e1, e2) -> Add ((symDiff e1 variable), (symDiff e2 variable))
  | Sub (e1, e2) -> Sub ((symDiff e1 variable), (symDiff e2 variable))
  | Mul (e1, e2) -> Add (Mul((symDiff e1 variable), e2), Mul(e1, (symDiff e2 variable)))
  