
int[] xs = { 3, 5, 12 }; 
int[] ys = { 2, 3, 4, 7 };
    
int[] zs = Merge(xs, ys);

for (int i = 0; i < zs.Length; i++)
{
    Console.Write(zs[i] + " ");
}
Console.WriteLine("");

static int[] Merge(int[] xs, int[] ys)
{
    var list = new int[xs.Length + ys.Length];
    
    Array.Copy(xs, list, xs.Length);
    Array.Copy(ys, 0, list, xs.Length, ys.Length);
    Array.Sort(list);

    return list;
}