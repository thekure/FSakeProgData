void arrsum(int n, int arr[], int *sump) {
  int i;

  for (i = 0; i < n; i = i + 1)
  {
      *sump = *sump + arr[i]; 
  }
}

void main(int n){
    int arr[4];
    arr[0] = 7;
    arr[1] = 13;
    arr[2] = 9;
    arr[3] = 8;

    int* p;
    p = 0;

    arrsum(n,arr, &p);

    print p;
}