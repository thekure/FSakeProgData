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
