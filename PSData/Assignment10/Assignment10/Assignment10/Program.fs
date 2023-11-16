module Program
// 11.1
// The original len function
let rec len xs =
    match xs with
    | [] -> 0
    | x::xr -> 1 + len xr

// The CPS version of len
let rec lenc (lst : 'a list) (id : int -> 'b) =
    match lst with
    | [] -> id 0
    | _::xs -> lenc xs (fun len -> id (len + 1))

// The tail-rec version of len
let rec leni (lst : int list) (acc : int) =
    match lst with
    | [] -> acc
    | _::xs -> leni xs (acc + 1)

// 11.2
// The original rev function
let rec rev xs =
    match xs with
    | [] -> []
    | x::xr -> rev xr @ [x]

// The CPS version of rev
let rec revc (lst : 'a list) (id : 'a list -> 'b) =
    match lst with
    | [] -> id []
    | x::xs -> revc xs (fun rlst -> id (rlst @ [x]))

// The tail-rec version of rev
let rec revi (lst : 'a list) (acc : 'a list) =
    match lst with
    | [] -> acc
    | x::xs -> revi xs (x::acc)

// 11.3
// The original prod function
let rec prod xs =
    match xs with
    | [] -> 1
    | x::xr -> x * prod xr

// The CPS version of prod
let rec prodc (lst : int list) (id : int -> int) =
    match lst with
    | [] -> id 1
    | x::xs -> prodc xs (fun res -> id (x * res))

// 11.4
// The improved version of prodc
let rec impprodc (lst : int list) (id : int -> int) =
    match lst with
    | [] -> id 1
    | 0::_ -> 0
    | x::xs -> prodc xs (fun res -> id (x * res))

// The tail-rec version of prod
let rec prodi xs acc =
    match xs with
    | [] -> acc
    | 0::_ -> 0
    | x::xr -> prodi xr (acc * x)