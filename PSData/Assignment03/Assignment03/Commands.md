# Commands

1. Copy Expr folder to dir
2. Run these commands:
```
mono ~/bin/fsharp/fslex.exe --unicode ExprLex.fsl

mono ~/bin/fsharp/fsyacc.exe --module ExprPar ExprPar.fsy

fsharpi -r ~/bin/fsharp/FsLexYacc.Runtime.dll Absyn.fs ExprPar.fs ExprLex.fs Parse.fs
```
