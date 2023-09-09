(* Programming language concepts for software developers, 2012-02-17 *)

(* Evaluation, checking, and compilation of object language expressions *)
(* Stack machines for expression evaluation                             *) 

(* Object language expressions with variable bindings and nested scope *)
// I HAVE DELETED A LOT OF FUNCTIONS WE DIDN'T NEED FOR ASSIGNMENT 1
module Intcomp1
// CHANGED
type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr
  | Prim of string * expr * expr;;

(* Some closed expressions: *)

let e1 = Let(["z", CstI 17], Prim("+", Var "z", Var "z"));;
let e2 = Let(["z", CstI 17], Prim("+", Let(["z", CstI 22], Prim("*", CstI 100, Var "z")), Var "z"));;
let e3 = Let(["z", Prim("-", CstI 5, CstI 4)], Prim("*", CstI 100, Var "z"));;
let e4 = Prim("+", Prim("+", CstI 20, Let(["z", CstI 17], Prim("+", Var "z", CstI 2))), CstI 30);;
let e5 = Prim("*", CstI 2, Let(["x", CstI 3], Prim("+", Var "x", CstI 4)));;

let e6 = Let(["z", Var "x"], Prim("+", Var "z", Var "x"));;
let e7 = Let(["z", CstI 3], Let(["y", Prim("+", Var "z", CstI 1)], Prim("+", Var "z", Var "y")));;
let e8 = Let(["z", Let(["x", CstI 4], Prim("+", Var "x", CstI 5))], Prim("*", Var "z", CstI 2));;
let e9 = Let(["z", CstI 3], Let(["y", Prim("+", Var "z", CstI 1)], Prim("+", Var "x", Var "y")));;
let e10 = Let(["z", Prim("+", Let(["x", CstI 4], Prim("+", Var "x", CstI 5)), Var "x")], Prim("*", Var "z", CstI 2));;

(* ---------------------------------------------------------------------- *)

(* Evaluation of expressions with variables and bindings *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;
// REVISED eval
let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x
    | Let([], e) -> eval e env
    | Let([x, erhs], e) -> let xval = eval erhs env
                           let env' = (x, xval)::env
                           eval e env'
    | Let((x, erhs)::xs, e) -> let xval = eval erhs env
                               let env' = (x, xval)::env
                               eval (Let(xs, e)) env'
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _            -> failwith "unknown primitive";;

let run e = eval e [];;
let res = List.map run [e1;e2;e3;e4;e5;e7];;  (* e6 has free variables *)

let ec1 = Let([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", CstI 2))], Prim("+", Var "x1", Var "x2"));;
let ec1v = run ec1;;

(* ---------------------------------------------------------------------- *)

(* Closedness *)

// let mem x vs = List.exists (fun y -> x=y) vs;;

let rec mem x vs = 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr;;

(* Checking whether an expression is closed.  The vs is 
   a list of the bound variables.  *)

(* Free variables *)

(* Operations on sets, represented as lists.  Simple but inefficient;
   one could use binary trees, hashtables or splaytrees for
   efficiency.  *)

(* union(xs, ys) is the set of all elements in xs or ys, without duplicates *)

let rec union (xs, ys) = 
    match xs with 
    | []    -> ys
    | x::xr -> if mem x ys then union(xr, ys)
               else x :: union(xr, ys);;

(* minus xs ys  is the set of all elements in xs but not in ys *)

let rec minus (xs, ys) = 
    match xs with 
    | []    -> []
    | x::xr -> if mem x ys then minus(xr, ys)
               else x :: minus (xr, ys);;

(* Find all variables that occur free in expression e *)
// REVISED freevars (might not work properly..?)
let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x  -> [x]
    | Let([], e) -> freevars e
    | Let([x, erhs], e) -> union (freevars erhs, minus (freevars e, [x]))
    | Let((x, erhs)::xs, e) -> union (freevars erhs, minus (freevars (Let(xs, e)), [x])) //[fst xs.Head]
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2);;

(* Alternative definition of closed *)
// TEST FOR freevars
let closed2 e = (freevars e = []);;
let freeVarsRes = List.map closed2 [e1;e2;e3;e4;e5;e6;e7;e8;e9;e10];;
let ec1fvFalse = Let([("x1", Prim("+", CstI 5, CstI 7)); ("x3", Prim("*", Var "x1", CstI 2))], Prim("+", Var "x1", Var "x2"));;
let freeVarsRes2 = List.map closed2 [ec1;ec1fvFalse];;

(* ---------------------------------------------------------------------- *)

(* Compilation to target expressions with numerical indexes instead of
   symbolic variable names.  *)

type texpr =                            (* target expressions *)
  | TCstI of int
  | TVar of int                         (* index into runtime environment *)
  | TLet of texpr * texpr               (* erhs and ebody                 *)
  | TPrim of string * texpr * texpr;;

(* Map variable name to variable index at compile-time *)

let rec getindex vs x = 
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x=y then 0 else 1 + getindex yr x;;

(* Compiling from expr to texpr *)
// REVISED tcomp (might not work properly..?)
let rec tcomp (e : expr) (cenv : string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x  -> TVar (getindex cenv x)
    | Let([], e) -> tcomp e cenv
    | Let([x, erhs], e) -> let cenv1 = x :: cenv 
                           TLet(tcomp erhs cenv, tcomp e cenv1)
    | Let((x, erhs)::xs, e) -> let cenv1 = x :: cenv 
                               TLet(tcomp erhs cenv, tcomp (Let(xs, e)) cenv1)
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv);;

(* Evaluation of target expressions with variable indexes.  The
   run-time environment renv is a list of variable values (ints).  *)
// MODIFIED FOR TESTING (changed to order of 'e' and 'renv')
let rec teval (renv : int list) (e : texpr) : int =
    match e with
    | TCstI i -> i
    | TVar n  -> List.item n renv
    | TLet(erhs, ebody) -> 
      let xval = teval renv erhs
      let renv1 = xval :: renv 
      teval renv1 ebody 
    | TPrim("+", e1, e2) -> teval renv e1 + teval renv e2
    | TPrim("*", e1, e2) -> teval renv e1 * teval renv e2
    | TPrim("-", e1, e2) -> teval renv e1 - teval renv e2
    | TPrim _            -> failwith "unknown primitive";;

(* Correctness: eval e []  equals  teval (tcomp e []) [] *)
// TEST FOR tcomp
let trun e = tcomp e [];;
let tres = (List.map trun [e1;e2;e3;e4;e5;e7]) |> List.map (teval []);;
let tres2 = trun ec1 |> teval [];;

(* ---------------------------------------------------------------------- *)

(* Storing intermediate results and variable bindings in the same stack *)

type sinstr =
  | SCstI of int                        (* push integer           *)
  | SVar of int                         (* push variable from env *)
  | SAdd                                (* pop args, push sum     *)
  | SSub                                (* pop args, push diff.   *)
  | SMul                                (* pop args, push product *)
  | SPop                                (* pop value/unbind var   *)
  | SSwap;;                             (* exchange top and next  *)
 
let rec seval (inss : sinstr list) (stack : int list) =
    match (inss, stack) with
    | ([], v :: _) -> v
    | ([], [])     -> failwith "seval: no result on stack"
    | (SCstI i :: insr,          stk) -> seval insr (i :: stk) 
    | (SVar i  :: insr,          stk) -> seval insr (List.item i stk :: stk) 
    | (SAdd    :: insr, i2::i1::stkr) -> seval insr (i1+i2 :: stkr)
    | (SSub    :: insr, i2::i1::stkr) -> seval insr (i1-i2 :: stkr)
    | (SMul    :: insr, i2::i1::stkr) -> seval insr (i1*i2 :: stkr)
    | (SPop    :: insr,    _ :: stkr) -> seval insr stkr
    | (SSwap   :: insr, i2::i1::stkr) -> seval insr (i1::i2::stkr)
    | _ -> failwith "seval: too few operands on stack";;


(* A compile-time variable environment representing the state of
   the run-time stack. *)

type stackvalue =
  | Value                               (* A computed value *)
  | Bound of string;;                   (* A bound variable *)

(* Compilation to a list of instructions for a unified-stack machine *)

let rec scomp (e : expr) (cenv : stackvalue list) : sinstr list =
    match e with
    | CstI i -> [SCstI i]
    | Var x  -> [SVar (getindex cenv (Bound x))]
    | Let([], ebody) ->
          scomp ebody cenv @ [SSwap; SPop]
    | Let([x, erhs], ebody) ->
          scomp erhs cenv @ scomp ebody (Bound x :: cenv) @ [SSwap; SPop]
    | Let((x, erhs)::xs, ebody) ->
          scomp erhs cenv @ scomp (Let(xs, ebody)) (Bound x :: cenv) @ [SSwap; SPop]
    | Prim("+", e1, e2) -> 
          scomp e1 cenv @ scomp e2 (Value :: cenv) @ [SAdd] 
    | Prim("-", e1, e2) -> 
          scomp e1 cenv @ scomp e2 (Value :: cenv) @ [SSub] 
    | Prim("*", e1, e2) -> 
          scomp e1 cenv @ scomp e2 (Value :: cenv) @ [SMul] 
    | Prim _ -> failwith "scomp: unknown operator";;

let s1 = scomp e1 [];;
let s2 = scomp e2 [];;
let s3 = scomp e3 [];;
let s5 = scomp e5 [];;

let assemble (sILst : sinstr list) : int list =
    let rec aux lst acc = 
        match lst with
        | [] -> acc
        | SCstI x::xs -> aux xs (0::x::acc)
        | SVar x::xs -> aux xs (1::x::acc)
        | SAdd::xs -> aux xs (2::acc)
        | SSub::xs -> aux xs (3::acc)
        | SMul::xs -> aux xs (4::acc)
        | SPop::xs -> aux xs (5::acc) 
        | SSwap::xs -> aux xs (6::acc)
    aux sILst [];;

(* Output the integers in list inss to the text file called fname: *)

let intsToFile (inss : int list) (fname : string) = 
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text);;

(* -----------------------------------------------------------------  *)