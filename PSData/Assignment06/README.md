# Assignment 6

## Exercise 7.1

> Answer: Running the code from the README.txt:
```fsharp
> fromFile "ExC/ex1.c";;
  val it : Absyn.program =
    Prog
      [Fundec
        (None, "main", [(TypI, "n")],
          Block
            [Stmt
              (While
                  (Prim2 (">", Access (AccVar "n"), CstI 0),
                  Block
                    [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));
                      Stmt
                        (Expr
                          (Assign
                              (AccVar "n",
                              Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
            Stmt (Expr (Prim1 ("printc", CstI 10)))])]

> run (fromFile "ExC/ex1.c") [17];;
  17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 
  val it : Interp.store = map [(0, 0)]

> run (fromFile "ExC/ex5.c");;     
  val it : (int list -> Interp.store) = <fun:Invoke@3236>

> run (fromFile "ExC/ex11.c") [8];;
  1 5 8 6 3 7 2 4 
  1 6 8 3 7 4 2 5 
  1 7 4 6 8 2 5 3 
  1 7 5 8 2 4 6 3 
  2 4 6 8 3 1 7 5 
  2 5 7 1 3 8 6 4 
  2 5 7 4 1 8 6 3 
  2 6 1 7 4 8 3 5 
  2 6 8 3 1 4 7 5 
  2 7 3 6 8 5 1 4 
  2 7 5 8 1 4 6 3 
  2 8 6 1 3 5 7 4 
  3 1 7 5 8 2 4 6 
  3 5 2 8 1 7 4 6 
  3 5 2 8 6 4 7 1 
  3 5 7 1 4 2 8 6 
  3 5 8 4 1 7 2 6 
  3 6 2 5 8 1 7 4 
  3 6 2 7 1 4 8 5 
  3 6 2 7 5 1 8 4 
  3 6 4 1 8 5 7 2 
  3 6 4 2 8 5 7 1 
  3 6 8 1 4 7 5 2 
  3 6 8 1 5 7 2 4 
  3 6 8 2 4 1 7 5 
  3 7 2 8 5 1 4 6 
  3 7 2 8 6 4 1 5 
  3 8 4 7 1 6 2 5 
  4 1 5 8 2 7 3 6 
  4 1 5 8 6 3 7 2 
  4 2 5 8 6 1 3 7 
  4 2 7 3 6 8 1 5 
  4 2 7 3 6 8 5 1 
  4 2 7 5 1 8 6 3 
  4 2 8 5 7 1 3 6 
  4 2 8 6 1 3 5 7 
  4 6 1 5 2 8 3 7 
  4 6 8 2 7 1 3 5 
  4 6 8 3 1 7 5 2 
  4 7 1 8 5 2 6 3 
  4 7 3 8 2 5 1 6 
  4 7 5 2 6 1 3 8 
  4 7 5 3 1 6 8 2 
  4 8 1 3 6 2 7 5 
  4 8 1 5 7 2 6 3 
  4 8 5 3 1 7 2 6 
  5 1 4 6 8 2 7 3 
  5 1 8 4 2 7 3 6 
  5 1 8 6 3 7 2 4 
  5 2 4 6 8 3 1 7 
  5 2 4 7 3 8 6 1 
  5 2 6 1 7 4 8 3 
  5 2 8 1 4 7 3 6 
  5 3 1 6 8 2 4 7 
  5 3 1 7 2 8 6 4 
  5 3 8 4 7 1 6 2 
  5 7 1 3 8 6 4 2 
  5 7 1 4 2 8 6 3 
  5 7 2 4 8 1 3 6 
  5 7 2 6 3 1 4 8 
  5 7 2 6 3 1 8 4 
  5 7 4 1 3 8 6 2 
  5 8 4 1 3 6 2 7 
  5 8 4 1 7 2 6 3 
  6 1 5 2 8 3 7 4 
  6 2 7 1 3 5 8 4 
  6 2 7 1 4 8 5 3 
  6 3 1 7 5 8 2 4 
  6 3 1 8 4 2 7 5 
  6 3 1 8 5 2 4 7 
  6 3 5 7 1 4 2 8 
  6 3 5 8 1 4 2 7 
  6 3 7 2 4 8 1 5 
  6 3 7 2 8 5 1 4 
  6 3 7 4 1 8 2 5 
  6 4 1 5 8 2 7 3 
  6 4 2 8 5 7 1 3 
  6 4 7 1 3 5 2 8 
  6 4 7 1 8 2 5 3 
  6 8 2 4 1 7 5 3 
  7 1 3 8 6 4 2 5 
  7 2 4 1 8 5 3 6 
  7 2 6 3 1 4 8 5 
  7 3 1 6 8 5 2 4 
  7 3 8 2 5 1 6 4 
  7 4 2 5 8 1 3 6 
  7 4 2 8 6 1 3 5 
  7 5 3 1 6 8 2 4 
  8 2 4 1 7 5 3 6 
  8 2 5 3 1 7 4 6 
  8 3 1 6 2 5 7 4 
  8 4 1 3 6 2 7 5 
  val it : Interp.store =
    map
      [(0, 8); (1, 0); (2, 9); (3, -999); (4, 0); (5, 0); (6, 0); (7, 0); (8, 0);
      ...]
```

> Abstract syntax tree for the following function:
```fsharp
void main(int n) {
  while (n > 0) {
    print n;
    n = n - 1;
  }
  println;
}
```
Prog
(1) [Fundec
(None, "main", [(TypI, "n")],
(2)   Block
(3)     [Stmt
(While
(4)           (Prim2 (">", Access (AccVar "n"), CstI 0),
(5)           Block
(6)             [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));  
(7)               Stmt
(Expr
(Assign
(AccVar "n",
Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
(8)      Stmt (Expr (Prim1 ("printc", CstI 10)))])]

(1) Function declaration with return type of None, a name of "main" and input of a list containing variable pairings (our case, only one of (TypI, string) )
(2) Body of the function, is a statement (which contains a list of statements)
(3) While statement
(4) Expression of Variable "n" being greater than CstI 0 (type Integer)
(5) Body of while-statement (also statement and also a list of statements)
(6) Statement (Expression statement) with an expression inside that prints the lookup value (expression) of variable n (type integer)
(7) Statement with an expression that assigns (statement) variable n to the expression n-1 (type integer)
(8) Another statement similar to the print from before but with print**c** instead of print**i** which parses the type int to type char thus making CstI 10 = "\n"

## Exercise 7.2

### i

> Answer in ExC/ex72i.c

After running:
> run(fromFile "ExC/ex72i.c") [2];;
20 val it : Interp.store =
map
[(0, 2); (1, 7); (2, 13); (3, 9); (4, 8); (5, 1); (6, 20); (7, 2); (8, 1);
...]

### ii

> Answer for in ExC/ex72ii.c

After running:
> run(fromFile "ExC/ex72ii.c")[10];;
285 val it : Interp.store =
map
[(0, 10); (1, 0); (2, 1); (3, 4); (4, 9); (5, 16); (6, 25); (7, 36);
(8, 49); ...]

### iii

> Answer in ExC/ex72iii.c

After running the program:
> run(fromFile "ExC/ex72iii.c")[3];;
1
4
2
0
val it : Interp.store =
map
[(0, 3); (1, 1); (2, 2); (3, 1); (4, 1); (5, 1); (6, 2); (7, 0); (8, 1);
...]

## Exercise 7.3 

Edited CPar.fsy in lines 17, 103, 110
Edited CPar.fsl in line 31

New code with for loops can be found in ExC/ex73i.c, ExC/ex73ii.c and ExC/ex73iii.c

## Exercise 7.4 

Edited Absyn.fs in lines 20 and 21
Edited Interp.fs from lines 161 to 166

## Exercise 7.5

Edited CPar.fsy in lines 21, 32, 139 and 140
Edited CPar.fsl in lines 54 and 56