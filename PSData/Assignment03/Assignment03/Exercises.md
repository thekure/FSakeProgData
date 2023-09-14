# PLC Exercises

## 3.3

#### Rules:

```
Rule A: Main ::= Expr EOF 

Rule B: Expr ::= NAME

Rule C:       | CSTINT

Rule D:       | MINUS CSTINT

Rule E:       | LPAR Expr RPAR

Rule F:       | LET NAME EQ Expr IN Expr END

Rule G:       | Expr TIMES Expr

Rule H:       | Expr PLUS Expr

Rule I:       | Expr MINUS Expr
```


#### let z = (17) in z + 2 * 3 end EOF

```
RULE A: Expr EOF

RULE F: LET NAME EQ Expr IN Expr END EOF

RULE H: LET NAME EQ Expr IN Expr PLUS Expr END EOF

RULE G: LET NAME EQ Expr IN Expr PLUS Expr TIMES Expr END EOF

RULE C: LET NAME EQ Expr IN Expr PLUS Expr TIMES CSTINT END EOF

RULE C: LET NAME EQ Expr IN Expr PLUS CSTINT TIMES CSTINT END EOF

RULE B: LET NAME EQ Expr IN NAME PLUS CSTINT TIMES CSTINT END EOF

RULE E: LET NAME EQ LPAR Expr RPAR IN CSTINT PLUS CSTINT TIMES CSTINT END EOF

RULE C: LET NAME EQ LPAR CSTINT RPAR IN CSTINT PLUS CSTINT TIMES CSTINT END EOF

let z = Expr in Expr end EOF

```

## 3.4

## 3.5

#### Output from fsharpi:

```
1. fromString "1 + 2 * 3";;
-  val it : Absyn.expr = Prim ("+", CstI 1, Prim ("*", CstI 2, CstI 3))

2. fromString "1 - 2 - 3";; 
- val it : Absyn.expr = Prim ("-", Prim ("-", CstI 1, CstI 2), CstI 3)

3. fromString "1 + -2";; 
- val it : Absyn.expr = Prim ("+", CstI 1, CstI -2)

4. fromString "x++";; 
- System.Exception: parse error near line 1, column 3

5. fromString "1 + 1.2";;
-  System.Exception: Lexer error: illegal symbol near line 1, column 6

6. fromString "1 + ";; 
- System.Exception: parse error near line 1, column 4

7. fromString "let z = (17) in z + 2 * 3 end";; 
- val it : Absyn.expr =
    Let ("z", CstI 17, Prim ("+", Var "z", Prim ("*", CstI 2, CstI 3)))

8. fromString "let z = 17) in z + 2 * 3 end";; 
- System.Exception: parse error near line 1, column 11

9. fromString "let in = (17) in z + 2 * 3 end";; 
- System.Exception: parse error near line 1, column 6

10. fromString "1 + let x=5 in let y=7+x in y+y end + x end";;
- val it : Absyn.expr =
  Prim
    ("+", CstI 1,
     Let
       ("x", CstI 5,
        Prim
          ("+",
           Let
             ("y", Prim ("+", CstI 7, Var "x"), Prim ("+", Var "y", Var "y")),
           Var "x")))
```





















