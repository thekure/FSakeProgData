# README
## Assignment 04

#### Exercise 4.1 (PLC)

[//]: # 
    (
        Get archive fun.zip from the homepage and unpack to directory Fun.
        It contains lexer and parser speciﬁcations and interpreter for a small 
        ﬁrst-order functional language. Generate and compile the lexer and 
        parser as described in README.TXT; parse and run some example programs 
        with ParseAndRun.fs.
    )
    
Running through README.txt produced these results:

A: val res : int = 12

B:

    fsyacc:

        building goto table...        time: 00:00:00.0023564
        returning tables.
        58 states
        6 nonterminals
        29 terminals
        26 productions
        #rows in action table: 58

    fslex:
        
        30 states

    e1: val e1 : Absyn.expr = Prim ("+", CstI 5, CstI 7)
    e2: val e2 : Absyn.expr = Let ("y", CstI 7, Prim ("+", Var "y", CstI 2))
    e3: val e3 : Absyn.expr = Letfun ("f", "x", Prim ("+", Var "x", CstI 7), Call (Var "f", CstI 2))

C: 

    run (fromString "5+7");;
    val it : int = 12

    run (fromString "let y = 7 in y + 2 end");;
    val it : int = 9

    run (fromString "let f x = x + 7 in f 2 end");;
    val it : int = 9


#### Exercise 4.2 (PLC)
[//]: # 
    (
    )

sum from 1000 .. 1

    run (fromString "let f n = if n = 0 then n else n + f (n-1) in f 1000 end");;

3 to the power of 8

    run (fromString "let f n = if n = 1 then n * 3 else 3 * f(n-1) in f 8 end");;

3 to the power of 0 + 3 to the power of 1 .. 11

    run (fromString "let f n = if n = 1 then n + 3 else 
    (let f m = if m = 1 then m * 3 else 3 * f(m-1) in f n end) + f(n-1)
    in f 11 end");;

1 to the power of 8 + 2 to the power of 8 .. 10
    
    run (fromString "let f n = if n = 1 then n else 
    (let f m = if m = 1 then m * n else n * f(m-1) in f 8 end) + f(n-1)
    in f 10 end");;

#### Exercise 4.3 (PLC)
[//]: #

    edited Absyn.fs 
    edited Fun.fs 

#### Exercise 4.4 (PLC)
[//]: #
    
    edited FunPar.fsy

#### Exercise 4.5 (PLC)
[//]: #

    edited FunLex.fsl
    edited FunPar.fsy
