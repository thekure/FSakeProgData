// File Intro/SimpleExpr.java
// Java representation of expressions as in lecture 1
// sestoft@itu.dk * 2010-08-29

import java.util.Map;
import java.util.HashMap;

// abstract class Expr { 
//   abstract public int eval(Map<String,Integer> env);
//   abstract public String fmt();
//   abstract public String fmt2(Map<String,Integer> env);
// }

// class CstI extends Expr { 
//   protected final int i;

//   public CstI(int i) { 
//     this.i = i; 
//   }

//   public int eval(Map<String,Integer> env) {
//     return i;
//   } 

//   public String fmt() {
//     return ""+i;
//   }

//   public String fmt2(Map<String,Integer> env) {
//     return ""+i;
//   }
// }

// class Var extends Expr { 
//   protected final String name;

//   public Var(String name) { 
//     this.name = name; 
//   }

//   public int eval(Map<String,Integer> env) {
//     return env.get(name);
//   } 

//   public String fmt() {
//     return name;
//   } 

//   public String fmt2(Map<String,Integer> env) {
//     return ""+env.get(name);
//   } 

// }

// class Prim extends Expr { 
//   protected final String oper;
//   protected final Expr e1, e2;

//   public Prim(String oper, Expr e1, Expr e2) { 
//     this.oper = oper; this.e1 = e1; this.e2 = e2;
//   }

//   public int eval(Map<String,Integer> env) {
//     if (oper.equals("+"))
//       return e1.eval(env) + e2.eval(env);
//     else if (oper.equals("*"))
//       return e1.eval(env) * e2.eval(env);
//     else if (oper.equals("-"))
//       return e1.eval(env) - e2.eval(env);
//     else
//       throw new RuntimeException("unknown primitive");
//   } 

//   public String fmt() {
//     return "(" + e1.fmt() + oper + e2.fmt() + ")";
//   } 

//   public String fmt2(Map<String,Integer> env) {
//     return "(" + e1.fmt2(env) + oper + e2.fmt2(env) + ")";
//   } 

// }

abstract class Expr {
  abstract public String toString();

  abstract public Integer eval(Map<String, Integer> env0);

  abstract public Expr simplify();

}

class CstI extends Expr {
  protected final int val;

  public CstI(int n) {
    val = n;
  }

  @Override
  public String toString() {
    return Integer.toString(val);
  }

  @Override
  public Integer eval(Map<String, Integer> env) {
    return val;
  }

  @Override
  public Expr simplify() {
    return this;
  }

}

class Var extends Expr {
  protected final String var;

  public Var(String var) {
    this.var = var;
  }

  @Override
  public String toString() {
    return var;
  }

  @Override
  public Integer eval(Map<String, Integer> env) {
    return env.get(var);
  }

  @Override
  public Expr simplify() {
    return this;
  }

}

abstract class Binop extends Expr {
  // abstract public Expr simplify();
}

class Add extends Binop {
  protected final Expr[] tuple;

  public Add(Expr e1, Expr e2) {
    tuple = new Expr[] { e1, e2 };
  }

  @Override
  public String toString() {
    return "(" + tuple[0] + " + " + tuple[1] + ")";
  }

  @Override
  public Integer eval(Map<String, Integer> env) {
    return tuple[0].eval(env) + tuple[1].eval(env);
  }

  @Override
  public Expr simplify() {
    if (expIsZero(tuple[0])) {
      return tuple[1];
    } else if (expIsZero(tuple[1])) {
      return tuple[0];
    } else if (tuple[0] instanceof CstI && tuple[1] instanceof CstI) {
      return this;
    } else if (tuple[0] instanceof CstI) {
      return new Add(tuple[0], tuple[1].simplify());
    } else if (tuple[1] instanceof CstI) {
      return new Add(tuple[0].simplify(), tuple[1]);
    } else
      return this; // should not happen?
  }

  private boolean expIsZero(Expr e) {
    var sim = e.simplify();
    if (sim instanceof CstI) {
      return ((CstI) sim).val == 0;
    } else
      return false;
  }
}

class Mul extends Binop {
  protected final Expr[] tuple;

  public Mul(Expr e1, Expr e2) {
    tuple = new Expr[] { e1, e2 };
  }

  @Override
  public String toString() {
    return "(" + tuple[0] + " * " + tuple[1] + ")";
  }

  @Override
  public Integer eval(Map<String, Integer> env) {
    return tuple[0].eval(env) * tuple[1].eval(env);
  }

  @Override
  public Expr simplify() {
    if (expIsZero(tuple[0])) {
      return new CstI(0);
    } else if (expIsZero(tuple[1])) {
      return new CstI(0);
    } else if (expIsOne(tuple[0])) {
      return tuple[1];
    } else if (expIsOne(tuple[1])) {
      return tuple[0];
    } else if (tuple[0] instanceof CstI && tuple[1] instanceof CstI) {
      return this;
    } else if (tuple[0] instanceof CstI) {
      return new Mul(tuple[0], tuple[1].simplify());
    } else if (tuple[1] instanceof CstI) {
      return new Mul(tuple[0].simplify(), tuple[1]);
    } else
      return this; // should not happen?
  }

  public boolean expIsZero(Expr e) {
    var sim = e.simplify();
    if (sim instanceof CstI) {
      return ((CstI) sim).val == 0;
    } else
      return false;
  }

  public boolean expIsOne(Expr e) {
    var sim = e.simplify();
    if (sim instanceof CstI) {
      return ((CstI) sim).val == 1;
    } else
      return false;
  }

}

class Sub extends Binop {
  protected final Expr[] tuple;

  public Sub(Expr e1, Expr e2) {
    tuple = new Expr[] { e1, e2 };
  }

  @Override
  public String toString() {
    return "(" + tuple[0] + " - " + tuple[1] + ")";
  }

  @Override
  public Integer eval(Map<String, Integer> env) {
    return tuple[0].eval(env) - tuple[1].eval(env);
  }

  @Override
  public Expr simplify() {
    if (expIsZero(tuple[1])) {
      return tuple[0].simplify();
    } else if (tuple[0] instanceof CstI && tuple[1] instanceof CstI) {
      return this;
    } else if (tuple[0] instanceof CstI) {
      return new Sub(tuple[0], tuple[1].simplify());
    } else if (tuple[1] instanceof CstI) {
      return new Sub(tuple[0].simplify(), tuple[1]);
    } else
      return this; // should not happen?
  }

  private boolean expIsZero(Expr e) {
    var sim = e.simplify();
    if (sim instanceof CstI) {
      return ((CstI) sim).val == 0;
    } else
      return false;
  }

}

public class SimpleExpr {
  public static void main(String[] args) {
    // Expr e1 = new CstI(17);
    // Expr e2 = new Prim("+", new CstI(3), new Var("a"));
    // Expr e3 = new Prim("+", new Prim("*", new Var("b"), new CstI(9)),
    // new Var("a"));
    Map<String, Integer> env0 = new HashMap<String, Integer>();
    env0.put("z", 3);
    env0.put("x", 78);
    // env0.put("baf", 666);
    // env0.put("b", 111);

    // System.out.println("Env: " + env0.toString());

    // System.out.println(e1.fmt() + " = " + e1.fmt2(env0) + " = " + e1.eval(env0));
    // System.out.println(e2.fmt() + " = " + e2.fmt2(env0) + " = " + e2.eval(env0));
    // System.out.println(e3.fmt() + " = " + e3.fmt2(env0) + " = " + e3.eval(env0));

    Expr e = new Add(new CstI(17), new Var("z"));
    Expr e2 = new Mul((new Add(new CstI(17), new Var("z"))), new CstI(100));
    Expr e3 = new Sub(new Add(new CstI(17), new Var("z")), new Add(new CstI(17), new Var("z")));
    Expr e4 = new Mul(new CstI(2), new Mul(e, e2));
    Expr e5 = new Mul(new CstI(2), new Mul(e, new CstI(0)));
    Expr e6 = new Add(new CstI(17), new CstI(0));
    Expr e7 = new Mul(new CstI(2), new Mul(e, new CstI(1)));
    Expr e8 = new Mul(new CstI(22), new CstI(1));
    System.out.println(e.toString() + " = " + e.eval(env0));
    System.out.println(e2.toString() + " = " + e2.eval(env0));
    System.out.println(e3.toString() + " = " + e3.eval(env0));
    System.out.println(e4.toString() + " = " + e4.eval(env0));

    Expr e9 = new Mul(new Add(new CstI(1), new CstI(0)), new Add(new Var("x"), new CstI(0)));
    System.out.println((new CstI(10).simplify()));
    System.out.println(e5.simplify()); // 0
    System.out.println(e6.simplify()); // 17
    System.out.println(e7.simplify()); // 2 * (17 + z)
    System.out.println(e8.simplify()); // 22
    System.out.println(e9.simplify()); // "x"

  }
}