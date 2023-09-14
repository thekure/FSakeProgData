module Assignment02.answers

open Intcomp1

let intsToFile (inss : int list) (fname : string) = 
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text);;

(* -----------------------------------------------------------------  *)

let sinstrToInt instr =
    match instr with
    | SCstI i -> [0; i]
    | SVar i -> [1; i]
    | SAdd -> [2]
    | SSub -> [3]
    | SMul -> [4]
    | SPop -> [5]
    | SSwap -> [6]
    | _ -> failwith "unknown instruction"
    
let assemble instrList =
    List.fold (fun acc instr -> acc @ (sinstrToInt instr)) [] instrList
    
assemble s1

// 3.2 regex: ^(b*ab+)*b*a?$

