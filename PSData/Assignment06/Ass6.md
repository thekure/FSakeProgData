# Assignment 6

## Exercise 7.1 

*Download microc.zip* from the book homepage, unpack it to a folder MicroC, and *build the micro-C interpreter* as explained in *README.TXT step (A)*.
Run the *fromFile parser* on the micro-C example in *source file ex1.c*. In your solution to the exercise, *include the abstract syntax tree* and *indicate its parts: declarations, statements, types and expressions*.

*Run the interpreter on some of the micro-C examples provided*, such as those in source files *ex1.c* and *ex11.c*. Note that both *take an integer n as input*. The former program prints the numbers from n down to 1; the latter finds all solutions to the n-queens problem.

## Exercise 7.2

*Write and run a few more micro-C programs* to understand the use of *arrays*, *pointer arithmetics*, and *parameter passing*. Use the micro-C implementation in **Interp.fs** and the associated lexer and parser to run your programs, *as in Exercise 7.1*.

Be careful: there is *no type checking in the micro-C interpreter* and nothing prevents you from overwriting arbitrary store locations by mistake, causing your program to produce unexpected results. (The type system of real C would catch some of those mistakes at compile time).

- (i) Write a micro-C program containing a *function void arrsum(int n, int arr[], int *sump)* that computes and *returns the sum of the first n elements of the given array arr*. The result must be returned through the *sump pointer*. The program’s main function must create an array holding the four numbers *7, 13, 9, 8*, call function arrsum on that array, and print the result using micro-C’s non-standard print statement.
(Remember that MicroC is very limited compared to actual C: You cannot use initializers in variable declarations like “int i=0;” but must use a dec- laration followed by a statement, as in “int i; i=0;” instead; there is no for-loop (unless you implement one, see Exercise 7.3); and so on.)
Also remember to initialize all variables and array elements; this doesn’t happen automatically in micro-C or C.
- (ii) Write a micro-C program containing a function *void squares(int n, int arr[])* that, given n and an array arr of length n or more fills arr[i] with i*i for i= 0,...,n−1.
(Your main function should allocate an array holding up to 20 integers, call function squares to fill the array with n square numbers (where n ≤ 20 is given as a parameter to the main function), then call function arrsum above to compute the sum of the n squares, and print the sum.)
- (iii) Write a micro-C program containing a function *void histogram(int n, int ns[], int max, int freq[])* which fills array freq the frequencies of the numbers in array ns. More precisely, when the function returns, element freq[c] must equal the number of times that value c appears among the first n elements of arr, for 0<=c<=max. You can assume that all numbers in ns are between 0 and max, inclusive.
(For example, if your main function creates an array arr holding the seven numbers 1 2 1 1 1 2 0 and calls histogram(7, arr, 3, freq), then afterwards freq[0] is 1, freq[1] is 4, freq[2] is 2, and freq[3] is 0. Of course, freq must be an array with at least four elements. What happens if it is not? The array freq should be declared and allocated in the main func- tion, and passed to histogram function. It does not work correctly (in micro-C or C) to stack-allocate the array in histogram and somehow return it to the main function. Your main function should print the contents of array freq after the call.)

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