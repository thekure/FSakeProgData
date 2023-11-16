# ASSIGNMENT 9

## 10.1

### i)

* ADD: pops the top 2 values from the stack, and pushes the result to the stack.
* CSTI i: The next value in the program bytecode is pushed to the stack.
* NIL: For all intents and purposes, NIL is simply 0. This is why it evaluates to false. 0 is pushed to the stack.
* IFZERO: Evaluates whether or not the word v (which is secondmost on top of the stack) is equal to 0. If it is, it sets the next instruction of the program counter to be the next bytecode instruction. If it isn't, it skips that instruction. To properly make the comparison, the program checks whether or not v is an integer first.
* CONS: Behaves much like ADD, but instead of pushing the result of two values added together, it constructs an object from the two topmost values on the stack, holding both values, or pointers to these.
* CAR: CAR refers to the first of the two words in a block. This instruction creates a pointer to a word, from the value on top of the stack. If that value is 0, it prints an error message. Otherwise, it pushes the first word p[1] at the new word pointer, to the stack.
* SETCAR: This changes the value of the first word, in the word that is pointed to by p*.

### ii)

* Length can be used to see whether or not a free block will fit in a spot on the heap. By this operation >>2, we "discard" the color bits. We then use the & operator and a mask beginning with 6 zeroes (to account for the tag bits, the last two of which are always 00 (because we want to ensure that all heap blocks begin on an address that is a multipe of 4)), to find out how many unused bits are in the block. If the block for example has 8 zeroes before the first 1, we know that that block has room for anything of bitsize 8 or less.
* Color does the the same thing, except it extracts only the last 2 color bits.
* Paint uses the same trick with a mask, this time making sure that the first many bits remain unchanged, while changing the last two bits to the ones given in the color argument.

### iii)

#### 1)

Allocate is only used when creating a CONS cell, since this cell must be able to hold two arbitrary values. While ADD is sure to have space for the result, given that it takes to integer values, the machine knows that it has space for an integer after the operation. CONS must allocate space for the objects it needs to hold.

#### 2)

We believe that answer to be no, since collect is only called within allocate. If we are wrong, we would very much like to learn why!

### iv)

When an allocation fails after traversing the full length of the heap.

## 10.2

