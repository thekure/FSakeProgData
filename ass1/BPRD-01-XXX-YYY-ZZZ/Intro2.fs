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
// EXTENDED
type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

// OUR OWN CODE
let e4 = Prim("max", CstI 3, CstI 4);;
let e5 = Prim("min", CstI 3, CstI 4);;
let e6 = Prim("==", CstI 3, CstI 3);;
let e7 = Prim("==", CstI 3, CstI 4);;

let e8 = If(Var "a", CstI 11, CstI 22);;
let e81 = If(CstI 0, CstI 11, CstI 22);;

(* Evaluation within an environment *)
// EXTENDED
let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("max", e1, e2) -> let e1' = eval e1 env
                             let e2' = eval e2 env
                             if e1' > e2' then e1' else e2'
    | Prim("min", e1, e2) -> let e1' = eval e1 env
                             let e2' = eval e2 env
                             if e1' < e2' then e1' else e2'
    | Prim("==", e1, e2) -> let e1' = eval e1 env
                            let e2' = eval e2 env
                            if e1' = e2' then 1 else 0
    | Prim _            -> failwith "unknown primitive"
    | If(e1, e2, e3) -> if eval e1 env <> 0 then eval e2 env else eval e3 env;;

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

let e4v = eval e4 env;;
let e5v = eval e5 env;;
let e6v = eval e6 env;;
let e7v = eval e7 env;;

// OUR REWRITTEN eval FUNCTION
let rec eval2 e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim(ope, e1, e2) -> let e1' = eval e1 env
                           let e2' = eval e2 env
                           match ope with
                           | "+" -> e1' + e2'
                           | "*" -> e1' * e2'
                           | "-" -> e1' - e2'
                           | "max" -> if e1' > e2' then e1' else e2'
                           | "min" -> if e1' < e2' then e1' else e2'
                           | "==" -> if e1' = e2' then 1 else 0
                           | _ -> failwith "unknown primitive";;

// TEST FOR eval2
let e21v  = eval2 e1 env;;
let e22v1 = eval2 e2 env;;
let e22v2 = eval2 e2 [("a", 314)];;
let e23v  = eval2 e3 env;;

let e24v = eval2 e4 env;;
let e25v = eval2 e5 env;;
let e26v = eval2 e6 env;;
let e27v = eval2 e7 env;;

// TEST FOR If(_,_,_)
let e8v = eval e8 env;;

// EXERCISE 1.2 (OUR OWN CODE)
type aexpr = 
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr;;

let ae1 = Sub(Var "v", Add(Var "w", Var "z"));;
let ae2 = Mul(CstI 2, ae1);;
let ae3 = Add(Add(Add(Var "x", Var "y"), Var "z"), Var "v");;

let rec fmt (ae : aexpr) : string =
    match ae with
    | CstI x -> string x
    | Var s -> s
    | Add(ae1, ae2) -> "(" + fmt ae1 + " + " + fmt ae2 + ")"
    | Mul(ae1, ae2) -> "(" + fmt ae1 + " * " + fmt ae2 + ")"
    | Sub(ae1, ae2) -> "(" + fmt ae1 + " - " + fmt ae2 + ")";;

let ae1v = fmt ae1;;
let ae2v = fmt ae2;;
let ae3v = fmt ae3;;

let rec simplify (ae : aexpr) : aexpr =
    match ae with
    | CstI x -> CstI x
    | Var s -> Var s
    | Add(ae1, CstI 0) | Mul(ae1, CstI 1) | Sub(ae1, CstI 0) -> simplify ae1
    | Add(CstI 0, ae2) | Mul(CstI 1, ae2) -> simplify ae2
    | Mul(CstI 0, _) | Mul(_, CstI 0) -> CstI 0
    | Sub(ae1 , ae2) when ae1 = ae2 -> CstI 0
    | Add(ae1, ae2) when (ae1 <> CstI 0) || (ae2 <> CstI 0) -> Add(simplify ae1, simplify ae2)
    | Mul(ae1, ae2) when (ae1 <> CstI 1) || (ae2 <> CstI 1) || (ae1 <> CstI 0) || (ae2 <> CstI 0) -> Mul(simplify ae1, simplify ae2)
    | Sub(ae1, ae2) when (ae2 <> CstI 0) -> Mul(simplify ae1, simplify ae2)
    | Add(ae1, ae2) -> simplify (Add(simplify ae1, simplify ae2))
    | Mul(ae1, ae2) -> simplify (Mul(simplify ae1, simplify ae2))
    | Sub(ae1, ae2) -> simplify (Sub(simplify ae1, simplify ae2));;

let ae4 = Add(Var "x", CstI 0);;
let ae5 = Add(CstI 1, CstI 0);;
let ae6 = Mul(ae5, ae4);;
let ae7 = Add(CstI 1, CstI 1);;
let ae8 = Mul(CstI 2, CstI 2);;
let ae9 = Sub(CstI 3, CstI 1);;
let ae10 = Mul(Add(CstI 2, CstI 0), CstI 2);;

let simpAe4 = simplify ae4;;
let simpAe5 = simplify ae5;;
let simpAe6 = simplify ae6;;
let simpAe7 = simplify ae7;;
let simpAe8 = simplify ae8;;
let simpAe9 = simplify ae9;;
let simpAe10 = simplify ae10;;

// let rec symboDiff (ae : aexpr) : aexpr =