void squares(int n, int arr[])
{
    int i;
    i = 0;
    while (i < n)
    {
        arr[i] = i * i;
        i = i + 1;
    }
}

void arrsum(int n, int arr[], int *sump)
{
    int i;
    i = 0;
    while (i < n)
    {
        *sump = *sump + arr[i];
        i = i + 1;
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
