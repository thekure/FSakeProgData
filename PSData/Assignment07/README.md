# Assignment 07

## Exercise 8.1

> ANSWERS:

### For (i)

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

### For (ii)

#### **(A) Byte code generated from ex3:**
24      LDARGS
19 1 5  CALL    m a | main(m)

25      STOP        | // THIS WILL BE ADDED TO THE TOP OF THE STACK AFTER THE MAIN() CALL - ALLOW US TO BEAUTIFULLY EXIT THE PROGRAM

15 1    INCSP   m   | int i;

13      GETBP       |
0 1     CSTI    i   |
1       ADD         |
0 0     CSTI    i   |
12      STI         |
15 -1   INCSP   m   | i = 0;

16 43   GOTO    a   | //Go to the while-check

13      GETBP       | // INSTR NO. 18
0 1     CSTI    i   |
1       ADD         |
11      LDI         |
22      PRINTI      |
15 -1   INCSP   m   | print i;

13      GETBP       |
0 1     CSTI    i   |
1       ADD         |
13      GETBP       |
0 1     CSTI        |
1       ADD         |
11      LDI         |
0 1     CSTI    i   |
1       ADD         |
12      STI         |
15 -1   INCSP   m   | i = i + 1;

15 0    INCSP   m   |
13      GETBP       |
0 1     CSTI    i   |
1       ADD         |
11      LDI         |
13      GETBP       |
0 0     CSTI    i   |
1       ADD         |
11      LDI         |
7       LT          | (i < n) // push either 1 (if true) or 0 (if false) to the stack.

18 18   IFNZERO a   | WHILE() //We check the above expression and decide whether or not to enter the loop or not.

15 -1   INCSP   m   | // WE ARE NOW FINISHED WITH MAIN()
21 0    RET     m   | // AND RETURN TO 0 - NEXT INSTRUCTION IS 'STOP'

#### **(B) Byte code generated from ex5:**
24      LDARGS      |

19 1 5  CALL m a    | main(m)

25      STOP        |

15 1    INCSP m     | int r;

13      GETBP       |
0 1     CSTI i      |
1       ADD         |
13      GETBP       |
0 0     CSTI i      |
1       ADD         |
11      LDI         | //Get argument from main()
12      STI         |
15 -1   INCSP m     | r = n;

15 1    INCSP m     | int r;
13      GETBP       |
0 0     CSTI i      |
1       ADD         |
11      LDI         |

13      GETBP       |
0 2     CSTI i      | //Need two spaces, since the method requires two arguments
1       ADD         |
19 2 57 CALL m a    | square(m) //Call square with the latest two stored values; (value of r and then address of r)

15 -1   INCSP m     |
13      GETBP       |
0 2     CSTI i      |
1       ADD         |
11      LDI         |
22      PRINTI      |
15 -1   INCSP m     |
15 -1   INCSP m     | print r;

13      GETBP       |
0 1     CSTI i      |
1       ADD         |
11      LDI         |
22      PRINTI      |
15 -1   INCSP m     | print r;

15 -1   INCSP m     |
21 0    RET m       | // RETURN AFTER MAIN FUNCTION

13      GETBP       | // THIS IS THE ADDRESS OF THE CALL FUNCTION
0 1     CSTI i      |
1       ADD         |
11      LDI         |
13      GETBP       |
0 0     CSTI i      |
1       ADD         |
11      LDI         |
13      GETBP       |
0 0     CSTI i      |
1       ADD         |
11      LDI         |
3       MUL         |
12      STI         |
15 -1   INCSP m     | *rp = i * i;

15 0    INCSP m     |
21 1    RET m       | // RETURN AFTER SQUARE FUNCTION

**Traces can be found in ExC/ex3trace.txt**
The link between machinecode and C can be found above, specifically in the analysis of bytecode generated for ex3, 8.1.ii.A.

## Exercise 8.3

The solution can be found in Comp.fs lines 209 to 212, if you so desire.
The solution is tested by running the machine code generated from "ExC/ex8_3.c" and stored in the associated .out file. The machinecode generated is:

```c
24 19 1 5 25 15 1 13 0 1 1 0 0 12 15 -1 13 0 1 1 9 11 0 1 1 12 22 15 -1 13 0 1 1 11 22 15 -1 15 1 13 0 2 1 0 0 12 15 -1 13 0 2 1 9 11 0 1 2 12 22 15 -1 15 -2 21 0
```

The expected output from the file is three prints; 1 1 -1.

## Exercise 8.4

### (1)
Machine code for ExC/ex8.out (with a change from 20 mil to 500k)
24 19 0 5 25 15 1 13 0 0 1 0 500000 12 15 -1 16 35 13 0 0 1 13 0 0 1 11 0 1 2 12 15 -1 15 0 13 0 0 1 11 18 18 15 -1 21 -1

ExC/prog1.out (notice the 500k as well)
0 500000 16 7 0 1 2 9 18 4 25

The first is significantly longer with 46 instructions whereas the second only has 11. The first one makes superflous stack operations while the other is more effienct, this can be seen in their runtime 8.4 seconds vs 58 seconds (for 500.000 iterations).

### (2)
When using loops and conditional statements, the base pointer is thrown around. At the same time, in every iteration of the loop we need to allocate stack-space (and remove it) to the conditional statements and their variables - we find this inefficient.

## Exercise 8.5

Edited these files:

Absyn.fs    line 28
Comp.fs     lines 209-219
CLex.fsl    lines 83, 84, 
CPar.fsy    lines 17, 32, 142

## Exercise 8.6

Didn't get around to doing this one.
