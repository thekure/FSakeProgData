(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

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

// Write examples

let e4 = Prim("==", CstI 5, CstI 6)
let e5 = Prim("min", CstI 10, CstI 2)
let e6 = Prim("max", CstI 17, CstI 16)


(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x
    | Prim(ope, e1, e2) ->
        let i1 = eval e1 env
        let i2 = eval e2 env
        match ope with
        | "+" -> i1 + i2
        | "-" -> i1 - i2
        | "*" -> i1 * i2
        | "==" -> if (i1 = i2) then 1 else 0
        | "min" -> min i1 i2
        | "max" -> max i1 i2
        | _ -> failwith "unknown primitive"
    | If(e1, e2, e3) ->
        match (eval e1 env) with
        | 0 -> eval e3 env
        | _ -> eval e2 env

eval e4 env
eval e5 env
eval e6 env

type aexpr =
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Sub of aexpr * aexpr
  | Mul of aexpr * aexpr
  
// v − (w + z) and 2 ∗ (v − (w + z)) and x + y + z + v

let ae1 = Sub (Var "v", Add (Var "w", Var "z"))
let ae2 = Mul (CstI 2, Sub (Var "v", Add (Var "w", Var "z")))
let ae3 = Add (Var"x", Add(Var "y", Add(Var "z", Var "v")))

let rec fmt aexpr =
    match aexpr with
    | CstI int -> string int
    | Var str -> str
    | Add (e1, e2) -> "(" + fmt e1 + " + " + fmt e2 + ")"
    | Sub (e1, e2) -> "(" + fmt e1 + " - " + fmt e2 + ")"
    | Mul (e1, e2) -> "(" + fmt e1 + " * " + fmt e2 + ")"
    
let rec simplify aexpr =
    match aexpr with
    | CstI int -> CstI int
    | Var str -> Var str
    | Add (e1, e2)
    | Sub (e1, e2)
    | Mul (e1, e2) ->
        let s1 = simplify e1
        let s2 = simplify e2
        match aexpr with
        | Add (_,_) ->
            match s1, s2 with
            | CstI 0, _ -> s2
            | _ , CstI 0 -> s1
            | _ -> Add (s1, s2)
        | Sub (_,_) ->
            match s1, s2 with
            | _ when s1 = s2 -> CstI 0
            | _ , CstI 0 -> s1
            | _ , _ -> Sub (s1, s2)
        | Mul (_,_) ->
            match s1, s2 with
            | CstI 1, _ -> s2
            | _ , CstI 1 -> s1
            | CstI 0 , _ 
            | _ , CstI 0 -> CstI 0
            | _ -> Mul (s1, s2)
        | _ -> CstI 666
        
let ae4 = Mul (CstI 1, CstI 0)
let ae5 = Mul (CstI 0, CstI 4)
let ae6 = Mul (CstI 5, CstI 1)
let ae7 = Mul (CstI 1, CstI 6)
let ae8 = Add (CstI 1, CstI 0)
let ae9 = Add (CstI 0, CstI 1)
let ae10 = Sub (CstI 5, CstI 5)
let ae11 = Sub (CstI 5, CstI 0)
let ae12 = Sub (CstI 0, CstI 5)
let ae13 = Add( CstI 5, Sub (CstI 0, CstI 5))
let ae14 = Mul( Add (CstI 0, CstI 5), CstI 2)

let ae15 = Mul(Add(CstI 1, CstI 0), Add(Var "x", CstI 0))
    
let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;
