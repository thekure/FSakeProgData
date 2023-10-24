# Assignment 6

## Exercise 7.1 

*Download microc.zip* from the book homepage, unpack it to a folder MicroC, and *build the micro-C interpreter* as explained in *README.TXT step (A)*.
Run the *fromFile parser* on the micro-C example in *source file ex1.c*. In your solution to the exercise, *include the abstract syntax tree* and *indicate its parts: declarations, statements, types and expressions*.

*Run the interpreter on some of the micro-C examples provided*, such as those in source files *ex1.c* and *ex11.c*. Note that both *take an integer n as input*. The former program prints the numbers from n down to 1; the latter finds all solutions to the n-queens problem.

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

*Write and run a few more micro-C programs* to understand the use of *arrays*, *pointer arithmetics*, and *parameter passing*. Use the micro-C implementation in **Interp.fs** and the associated lexer and parser to run your programs, *as in Exercise 7.1*.

Be careful: there is *no type checking in the micro-C interpreter* and nothing prevents you from overwriting arbitrary store locations by mistake, causing your program to produce unexpected results. (The type system of real C would catch some of those mistakes at compile time).

- (i) Write a micro-C program containing a *function void arrsum(int n, int arr[], int *sump)* that computes and *returns the sum of the first n elements of the given array arr*. The result must be returned through the *sump pointer*. The program’s main function must create an array holding the four numbers *7, 13, 9, 8*, call function arrsum on that array, and print the result using micro-C’s non-standard print statement.
(Remember that MicroC is very limited compared to actual C: You cannot use initializers in variable declarations like “int i=0;” but must use a declaration followed by a statement, as in “int i; i=0;” instead; there is no for-loop (unless you implement one, see Exercise 7.3); and so on.
Also remember to initialize all variables and array elements; this doesn’t happen automatically in micro-C or C.)

> Answer for (i):

(Code can also be found in ExC/ex72i.c)

```c
void arrsum(int n, int arr[], int *sump) {
  int i;
  int val;
  i = 0;
  while (i < n) {

    *sump = *sump + arr[i];
    i = i + 1;
  }
}

void main(int n){
    int arr[4];
    arr[0] = 7;
    arr[1] = 13;
    arr[2] = 9;
    arr[3] = 8;

    int* p;
    p = 0;

    arrsum(n,arr, &p);

    print p;
}
```

After running:
> run(fromFile "ExC/ex72i.c") [2];;
  20 val it : Interp.store =
    map
      [(0, 2); (1, 7); (2, 13); (3, 9); (4, 8); (5, 1); (6, 20); (7, 2); (8, 1);
      ...]

- (ii) Write a micro-C program containing a function *void squares(int n, int arr[])* that, given n and an array arr of length n or more fills arr[i] with i*i for i= 0,...,n−1.
(Your main function should allocate an array holding up to 20 integers, call function squares to fill the array with n square numbers (where n ≤ 20 is given as a parameter to the main function), then call function arrsum above to compute the sum of the n squares, and print the sum.)
> Answer for (ii):

(Code can also be found in ExC/ex72ii.c)

```c
void squares(int n, int arr[])
{
    int i;
    i = 0;
    int val;
    while (i < n)
    {
        val = i;
        arr[i] = val * val;
        i = i + 1;
    }
}

void arrsum(int n, int arr[], int *sump)
{
    int i;
    int val;
    i = 0;
    while (i < n)
    {
        *sump = *sump + arr[i];
        i = i + 1;
    }
}

void main(int n)
{
    int arr[20];
    if (n < 21)
    {
        squares(n, arr);
    }
    int *p;
    p = 0;
    arrsum(n, arr, &p);
    print p;
}

```

After running:
> run(fromFile "ExC/ex72ii.c")[10];;
  285 val it : Interp.store =
    map
      [(0, 10); (1, 0); (2, 1); (3, 4); (4, 9); (5, 16); (6, 25); (7, 36);
      (8, 49); ...]



- (iii) Write a micro-C program containing a function *void histogram(int n, int ns[], int max, int freq[])* which fills array freq the frequencies of the numbers in array ns. More precisely, when the function returns, element freq[c] must equal the number of times that value c appears among the first n elements of arr, for 0<=c<=max. You can assume that all numbers in ns are between 0 and max, inclusive.
(For example, if your main function creates an array arr holding the seven numbers 1 2 1 1 1 2 0 and calls histogram(7, arr, 3, freq), then afterwards freq[0] is 1, freq[1] is 4, freq[2] is 2, and freq[3] is 0. Of course, freq must be an array with at least four elements. What happens if it is not? The array freq should be declared and allocated in the main function, and passed to histogram function. It does not work correctly (in micro-C or C) to stack-allocate the array in histogram and somehow return it to the main function. Your main function should print the contents of array freq after the call.)

> Answer:
(Code can also be found in ExC/ex72iii.c)
Note to "if freq is not at least 'max'-amount of elements: when printing, the next *stack-element* will just be printed **(???)**

```c
void histogram(int n, int ns[], int max, int freq[]){
    int count;
    int k;
    int val;

    int i;
    i = 0;
    while (i <= max){
        count = 0;
        k = 0;

        while (k < n){
            val = ns[k];
            if (i == val){
                count = count + 1;
            }
            k = k + 1;
        }
        freq[i] = count;
        i = i + 1;
    }
}

void main(int max){
    int ns[7];
    ns[0] = 1;
    ns[1] = 2;
    ns[2] = 1;
    ns[3] = 1;
    ns[4] = 1;
    ns[5] = 2;
    ns[6] = 0;

    int size;
    size = max + 1;

    int freq[4]; //UNABLE TO SET FREQ[SIZE]????

    histogram(7,ns,max,freq);

    int i;
    i = 0;
    while (i < size){
        print freq[i];
        println;
        i = i +1;
    }
}
```

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
*Extend MicroC with a for-loop*, permitting for instance

```fsharp
    for (i=0; i<100; i=i+1)
    sum = sum+i;
```

To do this, you must *modify the lexer and parser specifications in *CLex.fsl** and **CPar.fsy**. You *may also extend the micro-C abstract syntax in *Absyn.fs** by *defining a new statement constructor Forloop in the stmt type*, and add a suitable case to the exec function in the *interpreter*.
But actually, with a modest amount of cleverness (highly recommended), *you do not need to introduce special abstract syntax for for-loops*, and need *not modify the interpreter at all*. Namely, a for-loop of the general form

```fsharp
for (e1; e2; e3)
  stmt
```

is equivalent to a block

```fsharp
{
e1;
  while (e2) {
    stmt
e3; }
}
```

Hence it suffices to let the semantic action { ... } in the parser construct abstract syntax using the existing Block, While, and Expr constructors from the stmt type.
Rewrite your programs from Exercise 7.2 to use for-loops instead of while-loops.

## Exercise 7.4 

Extend the micro-C abstract syntax in **Absyn.fs** with the *preincrement and predecrement operators* known from C, C++, Java, and C#:

```fsharp
type expr =
    ...
  | PreInc of access   (* C/C++/Java/C#  ++i  or  ++a[e]  *)
  | PreDec of access   (* C/C++/Java/C#  --i  or  --a[e]  *)
```

Note that the predecrement and preincrement operators work on lvalues, that is, variables and array elements, and more generally on any expression that evaluates to a location.
Modify the micro-C interpreter in **Interp.fs** to handle PreInc and PreDec. You will need to modify the *eval function*, and use the *getSto* and *setSto* store operations (**Sect. 7.3**).

## Exercise 7.5

Extend the micro-C lexer and parser to accept ++e and --e also, and to build the corresponding abstract syntax.
