  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  4
    .locals init (int32 V_0,            // Initialise i
             int32 V_1,                 // Initialise least
             int32 V_2,                 // Initialise temp
             int32 V_3)                 // Initialise j
    IL_0000:  ldc.i4.0                  // Push (the int32) 0 to the stack
    IL_0001:  stloc.0                   // Pop stack **to** local variable (indexed by) 0 - that is i = 0
    IL_0002:  br.s       IL_0032        // Branch to specified instruction at IL_0032

    IL_0004:  ldloc.0                   // Load i onto stack
    IL_0005:  stloc.1                   // Pop stack **to** local variable (indexed by) 1 - that is least = i
    IL_0006:  ldloc.0                   // Load i onto stack
    IL_0007:  ldc.i4.1                  // Push 1 to the stack
    IL_0008:  add                       // Pop i and 1 and push i + 1 to the stack
    IL_0009:  stloc.3                   // Load j onto stcak
    IL_000a:  br.s       IL_001a        // Branch to specified instruction at IL_001a

    IL_000c:  ldarg.0                   // Load the first argument (0) which is arr
    IL_000d:  ldloc.3                   // Load local variable j
    IL_000e:  ldelem.i4                 // Load arr[j (as int32)] to the stack. That is, pop the stack and use as index for array
    IL_000f:  ldarg.0                   // Load the first argument (0) which is arr
    IL_0010:  ldloc.1                   // Load least onto stack
    IL_0011:  ldelem.i4                 // Load arr[least (as int32)] to the stack
    IL_0012:  bge.s      IL_0016        // Branch if greater to specified instruction at IL_0016

    IL_0014:  ldloc.3                   // Load local variable j
    IL_0015:  stloc.1                   // Pop stack **to** local variable (indexed by) 1 - that is least = j
    IL_0016:  ldloc.3                   // Load local variable j 
    IL_0017:  ldc.i4.1                  // Push (int32) 1 to stack
    IL_0018:  add                       // Pop, pop, add -> j + 1 to the stack
    IL_0019:  stloc.3                   // j = j + 1 (popped from stack)
    IL_001a:  ldloc.3                   // Load local variable j
    IL_001b:  ldarg.0                   // Load argument (0), arr
    IL_001c:  ldlen                     // Pop arr and push the length
    IL_001d:  conv.i4                   // Convice youself, that wauw, you've come this far! We're cheering for you. But no fo'real, Pop and convert to int32
    IL_001e:  blt.s      IL_000c        // Branch less than to specified instruction at IL_000c (or Bacon, Lettuce, Tomato)

    IL_0020:  ldarg.0                   // Load arg (0), arr
    IL_0021:  ldloc.0                   // Load local variable 0, that is i
    IL_0022:  ldelem.i4                 // Pop, pop, push arr[i]
    IL_0023:  stloc.2                   // Pop and push to temp -> temp = arr[i]
    IL_0024:  ldarg.0                   // Load arg (0), arr
    IL_0025:  ldloc.0                   // Load local variable 0, that is i
    IL_0026:  ldarg.0                   // Load arg (0), arr
    IL_0027:  ldloc.1                   // Load local varible (1), that is least
    IL_0028:  ldelem.i4                 // Pop pop push arr[least]
    IL_0029:  stelem.i4                 // Pop arr[least] and push into arr[i]
    IL_002a:  ldarg.0                   // Load arg (0), arr
    IL_002b:  ldloc.1                   // Load least
    IL_002c:  ldloc.2                   // Load temp
    IL_002d:  stelem.i4                 // Store pop at (least) pop (arr) pop -> arr[least] = temp
    IL_002e:  ldloc.0                   // Load local variable 0, that is i
    IL_002f:  ldc.i4.1                  // Push int32 1 to the stack
    IL_0030:  add                       // Pop, pop and add -> i + 1 
    IL_0031:  stloc.0                   // i = i + 1
    IL_0032:  ldloc.0                   // Load i
    IL_0033:  ldarg.0                   // Load arr
    IL_0034:  ldlen                     // Pop arr and push the length
    IL_0035:  conv.i4                   // Convert to int32
    IL_0036:  blt.s      IL_0004        // Branch if less than to specified instruction IL_0004

    IL_0038:  ret                       // Return from method
  } // end of method Selsort::SelectionSort