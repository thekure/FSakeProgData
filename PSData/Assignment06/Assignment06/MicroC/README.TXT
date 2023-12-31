Compiling and loading the micro-C evaluator and parser (MicroC/README.TXT)
--------------------------------------------------------------------------

Archive microc.zip contains the files used in points A, B and C below.


A. Generating and compiling the lexer and parser for micro-C, and
   loading the interpreter for micro-C.

   WIN: 
   fslex --unicode CLex.fsl 
   fsyacc --module CPar CPar.fsy
   fsharpi -r ~/fsharp/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs
   
   MAC: 
   mono ~/bin/fsharp/fslex.exe --unicode CLex.fsl
   mono ~/bin/fsharp/fsyacc.exe --module CPar CPar.fsy
   fsharpi -r ~/bin/fsharp/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs
   
   open ParseAndRun;;
   fromFile "./ExC/ex1.c";;
   run (fromFile "./ExC/ex1.c") [17];;
   run (fromFile "./ExC/ex5.c");;
   run (fromFile "./ExC/ex11.c") [8];;
   run (fromFile "./ExC/ex73i.c") [4];;


B. To compile and use the micro-C compiler

   mono ~/bin/fsharp/fslex.exe --unicode CLex.fsl
   mono ~/bin/fsharp/fsyacc.exe --module CPar CPar.fsy
   fsharpi -r ~/bin/fsharp/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs   

   open ParseAndComp;;
   compileToFile (fromFile "./ExC/ex11.c") "./ExC/ex11.out";;
   compile "./ExC/ex11";;
   #q;;

The Java stack machine:

   javac Machine.java
   java Machine ex11.out 8

The C stack machine
   gcc machine.c
   ./a.out ex11.out 8

C. To compile and use the backwards (continuation-based) micro-C compiler:

   mono ~/bin/fsharp/fslex.exe --unicode CLex.fsl
   mono ~/bin/fsharp/fsyacc.exe --module CPar CPar.fsy
   fsharpi -r ~/bin/fsharp/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Contcomp.fs ParseAndContcomp.fs   

   open ParseAndContcomp;;
   contCompileToFile (fromFile "ex11.c") "ex11.out";;
   compile "ex11";;
   #q;;

   javac Machine.java
   java Machine ex11.out 8


D. Build the backwards micro-C compiler as a command-line program microcc

   mono ~/bin/fsharp/fslex.exe --unicode CLex.fsl
   mono ~/bin/fsharp/fsyacc.exe --module CPar CPar.fsy
   fsharpc --standalone -r ~/bin/fsharp/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Contcomp.fs MicroCC.fs -o microcc.exe

   mono microcc.exe ex11.c

   javac Machine.java
   java Machine ex11.out 8
