For lexing:     mono ~/bin/fsharp/fslex.exe --unicode <lexer>.fsl

For parsing:    mono ~/bin/fsharp/fsyacc.exe --module <module-name> <parser>.fsy


For mac:
Step for creating an executing a fsl file such that: fls -> fs -> exe
1. mono ~/bin/fsharp/fslex.exe --unicode <fileName>.fsl
2. fsharpc -r ~/bin/fsharp/FsLexYacc.Runtime.dll <newFsFile>.fs
3. mono <newExeFile>.exe

   
