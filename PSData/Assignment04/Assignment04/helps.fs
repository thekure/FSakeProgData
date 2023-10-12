let sum n = 
    let rec aux n acc =
        match n with
        | 0 -> acc
        | n -> aux (n-1) (acc+n)
    aux n 0;;

let pow n e =
    let rec aux n e acc =
        match e with
        | 0 -> acc
        | e -> aux n (e-1) (acc*n)
    aux n e 1;;

let dot3 n e =
    let rec aux n e acc =
       match e with
       | 0 -> acc
       | e -> aux n (e-1) (acc+(pow n e))
    aux n e 1;;