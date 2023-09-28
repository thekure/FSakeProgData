module Exercises

let sum n =
    List.fold (fun acc ele -> ele + acc) 0 [0..n]
    
let pow value exponent =
    let rec aux e acc =
        match e with
        | 0 -> acc
        | e -> aux (e-1) (acc*value)
    aux exponent 1

let pow2 value exponent =
    let rec aux e acc =
        match e with
        | 0 -> acc
        | e -> aux (e-1) (acc)
    aux exponent 1