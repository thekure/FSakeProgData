void squares(int n, int arr[])
{
    int i;
    for (i = 0; i < n; i = i + 1)
    {
        arr[i] = i * i;
    }
}

void arrsum(int n, int arr[], int *sump)
{
    int i;
    for (i = 0; i < n; i = i + 1)
    {
        *sump = *sump + arr[i];
    }
}

void main(int n)
{
    if (n < 21)
    {
        int arr[20];
        squares(n, arr);
        int* p;
        *p = 0;
        arrsum(n, arr, &p);
        print p;
    }
    else {
        int failure;
        failure = -500;
        print failure;
    }
}
