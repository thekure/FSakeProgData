# Ass4 ans

## 4.1

Done
<!--
    A)
      dotnet fsi Absyn.fs Fun.fs

      open Absyn;;
      open Fun;;
      let res = run (Prim("+", CstI 5, CstI 7));;
      #q;;

    B)
      ..\fsharp\fsyacc --module FunPar FunPar.fsy
      ..\fsharp\fslex --unicode FunLex.fsl
      dotnet fsi -r ../fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs   

      open Parse;;
      let e1 = fromString "5+7";;
      let e2 = fromString "let y = 7 in y + 2 end";;
      let e3 = fromString "let f x = x + 7 in f 2 end";;
      #q;;

    C)
      ..\fsharp\fsyacc --module FunPar FunPar.fsy
      ..\fsharp\fslex --unicode FunLex.fsl
      dotnet fsi -r ../fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs Fun.fs ParseAndRun.fs

      open ParseAndRun;;
      run (fromString "5+7");;
      run (fromString "let y = 7 in y + 2 end");;
      run (fromString "let f x = x + 7 in f 2 end");;
      #q;;

-->

## 4.2

..\fsharp\fsyacc --module FunPar FunPar.fsy

..\fsharp\fslex --unicode FunLex.fsl

dotnet fsi -r ../fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs Fun.fs ParseAndRun.fs

open ParseAndRun;;

run (fromString "let sum n = if n = 0 then 0 else n + sum (n-1) in sum 1000 end");;

run (fromString "let pow n = if n = 1 then 1 else 3 * pow n in pow 3 8 end");;

run (fromString "let dot3 n e = if e = 0 then 1 else n + (n * dot3 n (e-1)) in dot3 3 11 end");;

## 4.3