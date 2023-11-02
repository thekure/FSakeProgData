# Assignment 07

## Exercise 8.1

Download *microc.zip* from the book homepage, unpack it to a folder MicroC, and *build the micro-C compiler as explained in README.TXT step (B)*.

- (i) As a warm-up, *compile one of the micro-C examples provided*, such as that in source file *ex11.c*, then *run it using the abstract machine implemented in Java*, as described also in step (B) of the README file. When run with command line argument 8, the program prints the 92 solutions to the eight queens problem: how to place eight queens on a chessboard so that none of them can attack any of the others.

- (ii) Now compile the example micro-C programs *ex3.c* and *ex5.c* using functions *compileToFile and fromFile* from *ParseAndComp.fs* as above.

Study the generated symbolic bytecode. *Write up the bytecode in a more structured way* with *labels* only at the beginning of the line (as in this chapter). *Write the corresponding micro-C code* to the right of the stack machine code. Note that *ex5.c* has a nested scope (a block { ... } inside a function body); *how is that visible in the generated code?*

Execute the compiled programs using *java Machine ex3.out 10* and similar. Note that these micro-C programs require a command line argument (an integer) when they are executed.

*Trace the execution using java Machinetrace ex3.out 4*, and *explain the stack contents and what goes on in each step of execution*, and *especially how the low-level bytecode instructions map to the higher-level features of micro-C*. You can capture the standard output from a command prompt (in a file ex3trace.txt) using the Unix-style notation:

```java
    java Machinetrace ex3.out 4 > ex3trace.txt
```

> ANSWERS:

For (i)

**First with fsharpi:**

```fsharp
> compileToFile (fromFile "ExC/ex11.c") "ExC/ex11.out";;
    val it : Machine.instr list =
        [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; INCSP 1; INCSP 100;
        GETSP; CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; INCSP 100; GETSP;
        CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; GETBP; CSTI 2; ADD; CSTI 1;
        STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 103; ADD; LDI; GETBP;
        CSTI 2; ADD; LDI; ADD; CSTI 0; STI; INCSP -1; GETBP; CSTI 2; ADD; GETBP;
        CSTI 2; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0; Label "L3"; GETBP;
        CSTI 2; ADD; LDI; GETBP; CSTI 0; ADD; LDI; SWAP; LT; NOT; IFNZRO "L2";
        GETBP; CSTI 2; ADD; CSTI 1; STI; INCSP -1; GOTO "L5"; Label "L4"; GETBP;
        CSTI 204; ADD; LDI; GETBP; CSTI 2; ADD; LDI; ADD; GETBP; CSTI 305; ADD; LDI;
        GETBP; CSTI 2; ADD; LDI; ADD; CSTI 0; STI; STI; INCSP -1; GETBP; CSTI 2;
        ADD; ...]

> compile "ExC/ex11";;
    val it : Machine.instr list =
        [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; INCSP 1; INCSP 100;
        GETSP; CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; INCSP 100; GETSP;
        CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; GETBP; CSTI 2; ADD; CSTI 1;
        STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 103; ADD; LDI; GETBP;
        CSTI 2; ADD; LDI; ADD; CSTI 0; STI; INCSP -1; GETBP; CSTI 2; ADD; GETBP;
        CSTI 2; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0; Label "L3"; GETBP;
        CSTI 2; ADD; LDI; GETBP; CSTI 0; ADD; LDI; SWAP; LT; NOT; IFNZRO "L2";
        GETBP; CSTI 2; ADD; CSTI 1; STI; INCSP -1; GOTO "L5"; Label "L4"; GETBP;
        CSTI 204; ADD; LDI; GETBP; CSTI 2; ADD; LDI; ADD; GETBP; CSTI 305; ADD; LDI;
        GETBP; CSTI 2; ADD; LDI; ADD; CSTI 0; STI; STI; INCSP -1; GETBP; CSTI 2;
    ADD; ...]
```

Result as seen in ExC/ex11.out:
$$
24 19 1 5 25 15 1 15 1 15 100 14 0 99 2 15 100 14 0 99 2 15 100 14 0 99 2 15 100 14 0 99 2 13 0 2 1 0 1 12 15 -1 16 77 13 0 103 1 11 13 0 2 1 11 1 0 0 12 15 -1 13 0 2 1 13 0 2 1 11 0 1 1 12 15 -1 15 0 13 0 2 1 11 13 0 0 1 11 10 7 8 18 44 13 0 2 1 0 1 12 15 -1 16 148 13 0 204 1 11 13 0 2 1 11 1 13 0 305 1 11 13 0 2 1 11 1 0 0 12 12 15 -1 13 0 2 1 13 0 2 1 11 0 1 1 12 15 -1 15 0 13 0 2 1 11 0 2 13 0 0 1 11 3 10 7 8 18 103 13 0 1 1 13 0 2 1 0 1 12 12 15 -1 16 777 16 536 16 201 13 0 2 1 13 0 2 1 11 0 1 1 12 15 -1 13 0 2 1 11 13 0 0 1 11 10 7 8 17 284 13 0 103 1 11 13 0 2 1 11 1 11 18 256 13 0 204 1 11 13 0 2 1 11 13 0 1 1 11 2 13 0 0 1 11 1 1 11 16 258 0 1 18 280 13 0 305 1 11 13 0 2 1 11 13 0 1 1 11 1 1 11 16 282 0 1 16 286 0 0 18 186 13 0 2 1 11 13 0 0 1 11 10 7 8 17 408 13 0 406 1 11 13 0 1 1 11 1 13 0 2 1 11 12 15 -1 13 0 103 1 11 13 0 2 1 11 1 13 0 204 1 11 13 0 2 1 11 13 0 1 1 11 2 13 0 0 1 11 1 1 13 0 305 1 11 13 0 2 1 11 13 0 1 1 11 1 1 0 1 12 12 12 15 -1 13 0 1 1 13 0 1 1 11 0 1 1 12 15 -1 13 0 2 1 0 1 12 15 -1 15 0 16 534 13 0 1 1 13 0 1 1 11 0 1 2 12 15 -1 13 0 1 1 11 0 0 10 7 17 530 13 0 2 1 13 0 406 1 11 13 0 1 1 11 1 11 12 15 -1 13 0 103 1 11 13 0 2 1 11 1 13 0 204 1 11 13 0 2 1 11 13 0 1 1 11 2 13 0 0 1 11 1 1 13 0 305 1 11 13 0 2 1 11 13 0 1 1 11 1 1 0 0 12 12 12 15 -1 13 0 2 1 13 0 2 1 11 0 1 1 12 15 -1 15 0 16 532 15 0 15 0 15 0 13 0 1 1 11 13 0 0 1 11 10 7 8 17 562 13 0 1 1 11 0 0 6 8 16 564 0 0 18 184 13 0 1 1 11 13 0 0 1 11 10 7 17 773 15 1 13 0 407 1 0 1 12 15 -1 16 625 13 0 406 1 11 13 0 407 1 11 1 11 22 15 -1 13 0 407 1 13 0 407 1 11 0 1 1 12 15 -1 15 0 13 0 407 1 11 13 0 0 1 11 10 7 8 18 593 0 10 23 15 -1 13 0 1 1 13 0 1 1 11 0 1 2 12 15 -1 13 0 1 1 11 0 0 10 7 17 767 13 0 2 1 13 0 406 1 11 13 0 1 1 11 1 11 12 15 -1 13 0 103 1 11 13 0 2 1 11 1 13 0 204 1 11 13 0 2 1 11 13 0 1 1 11 2 13 0 0 1 11 1 1 13 0 305 1 11 13 0 2 1 11 13 0 1 1 11 1 1 0 0 12 12 12 15 -1 13 0 2 1 13 0 2 1 11 0 1 1 12 15 -1 15 0 16 769 15 0 15 -1 16 775 15 0 15 0 13 0 1 1 11 0 0 10 7 18 182 15 -406 21 0
$$

**Java run**
1. First we compile, then we run:
> java Machine ExC/ex11.out 8
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

    Ran 0.021 seconds

## Exercise8.3

This abstract syntax for preincrement ++e and predecrement--e was introduced in Exercise 7.4:
```fsharp
type expr =
    ...
  | PreInc of access   (* C/C++/Java/C#  ++i  or  ++a[e]  *)
  | PreDec of access   (* C/C++/Java/C#  --i  or  --a[e]  *)
```

Modify the compiler (function cExpr) to generate code for PreInc(acc) and PreDec(acc). To parse micro-C source programs containing these expressions, you also need to modify the lexer and parser.

It is tempting to expand ++e to the assignment expression e = e+1, but that would evaluate e twice, which is wrong. Namely, e may itself have a side effect, as in ++arr[++i].

Hence e should be computed only once. For instance, ++i should compile to something like this: <code to compute address of i>, DUP, LDI, CSTI 1, ADD, STI, where the address of i is computed once and then duplicated.

Write a program to check that this works. If you are brave, try it on expressions of the form ++arr[++i] and check that i and the elements of arr have the correct values afterwards.


## Exercise 8.4

Compile ex8.c and study the symbolic bytecode to see why it is so much slower than the handwritten 20 million iterations loop in prog1.
Compile ex13.c and study the symbolic bytecode to see how loops and condi- tionals interact; describe what you see.
In a later chapter we shall see an improved micro-C compiler that generates fewer extraneous labels and jumps.

## Exercise 8.5

Extend the micro-C language,the abstract syntax, the lexer,the parser, and the compiler to implement conditional expressions of the form (e1 ? e2 : e3).
The compilation of e1 ? e2 : e3 should produce code that evaluates e2 only if e1 is true and evaluates e3 only if e1 is false. The compilation scheme should be the same as for the conditional statement if (e1) e2 else e3, but expression e2 or expression e3 must leave its value on the stack top if evaluated, so that the entire expression e1 ? e2 : e3 leaves its value on the stack top.

## Exercise 8.6 

Extend the lexer, parser, abstract syntax and compiler to implement switch statements such as this one:

```c
switch (month) {
  case 1:
    { days = 31; }
  case 2:
    { days = 28; if (y%4==0) days = 29; }
  case 3:
    { days = 31; } 
}
```

Unlike in C, there should be no fall-through from one case to the next: after the last statement of a case, the code should jump to the end of the switch statement. The parenthesis after switch must contain an expression. The value after a case must be an integer constant, and a case must be followed by a statement block. A switch with n cases can be compiled using n labels, the last of which is at the very end of the switch. For simplicity, do not implement the break statement or the default branch.
