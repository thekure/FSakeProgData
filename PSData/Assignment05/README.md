# Assignment 5

PLC: 5.1, 5.7, 6.1, 6.2, 6.3, 6.4 and 6.5

## 5.1

A)
See Exercises.fs

B)
See CSharpEx/Program.cs for second part.

## 5.7

Edited TypedFun from line 144. Used line 180 and 181 as tests.


## 6.1

``` fsharp

let add x = let f y = x+y in f end
in add 2 5 end

  > let e1 = run(fromString "let add x = let f y = x + y in f end in add 2 5  end");;
    val e1 : HigherFun.value = Int 7

let add x = let f y = x+y in f end
in let addtwo = add 2
   in addtwo 5 end
end

  > let e2 = run(fromString "let add x = let f y = x+y in f end in let addtwo = add 2 in addtwo 5 end end");;
    val e2 : HigherFun.value = Int 7


let add x = let f y = x+y in f end
  in let addtwo = add 2
    in let x = 77 in addtwo 5 end //X is outside? Not tied to anything
    end 
end

  > let e3 = run(fromString "let add x = let f y = x + y in f end in let addtwo = add 2 in let x = 77 in addtwo 5 end end end");;
    val e3 : HigherFun.value = Int 7


let add x = let f y = x+y in f end
in add 2 end

  Expecting a function. Got:
  > let e4 = run(fromString "let add x = let f y = x + y in f end in add 2 end");;
      val e4 : HigherFun.value =
          Closure
            ("f", "y", Prim ("+", Var "x", Var "y"),
            [("x", Int 2);
              ("add",
              Closure
                ("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"),
                  []))])

```

### Is the third one as expected?

    Yes and no, depends on how smart you are. 2/3 of our group made the naive and wrong assumption, while
    one member (the big genius) nailed it. So he insists that it behaves as expected, while our bruised egos
    maintains the opposite. Here follows our logic tho:

    The function add takes one arguments, x 
    f also takes one argument, y. 
    When addtwo 5 evaluates, 5 becomes the y in the f call while 2 remains the x
    to the add call. The x that is 77 is never used. It is scoped in the innermost part of the evaluation,
    where it is irrelevant.
    
### Explain result of last one:
    
    Getting a closure as we are still expecting a second input - that is, what is y? Right now y is a 
    function that still needs an input - thus the instruction is still valid, just does not evaluate 
    to a numerical result.

## 6.2

Look in files Absyn.fs and HigherFun.fs

> let e1 = fromString "fun x -> 2 * x";;
  - val e1 : Absyn.expr = Fun ("x", Prim ("*", CstI 2, Var "x"))
> let e2 = fromString "let y = 22 in fun z -> z + y end" ;;
  - val e2 : Absyn.expr = Let ("y", CstI 22, Fun ("z", Prim ("+", Var "z", Var "y")))


Now with eval:
> let e1 = run(fromString "fun x -> 2*x");;
  - val e1 : HigherFun.value = Clos ("x", Prim ("*", CstI 2, Var "x"), [])
> let e2 = run(fromString "let y = 22 in fun z -> z+y end");;
  - val e2 : HigherFun.value = Clos ("z", Prim ("+", Var "z", Var "y"), [("y", Int 22)])

## 6.3

Look in files FunLex.fsl and FunPar.fsy

> Solutions:
  1 > let e1 = run(fromString "let add x = fun y -> x + y in add 2 5 end");;
      - val e1 : HigherFun.value = Int 7

  2 > let e2 = run(fromString "let add = fun x -> fun y -> x+y in add 2 5 end");;
      - val e2 : HigherFun.value = Int 7

## 6.4

Look at tree1.jpg and tree2.jpg in project root folder. 

## 6.5

### 1:

> Answers:
 
    1. > inferType (fromString "let f x = 1 in f f end");;
            - val it : string = "int"
    2. > inferType (fromString "let f g = g g in f end");;
            - System.Exception: type error: circularity
              g is not defined and results in a loop; call f with g -> *call g with g*
    3. > inferType (fromString "let f x = let g y = y in g false end in f 42 end");;
            - val it : string = "bool"
    4. > inferType (fromString "let f x = let g y = if true then y else x in g false end in f 42 end");;
            - System.Exception: type error: bool and int
            If-branches have to have the same return value
    5. > inferType (fromString "let f x = let g y = if true then y else x in g false end in f true end");;
            - val it : string = "bool"

### 2: 

We did unfortunately not complete this part of the question.
