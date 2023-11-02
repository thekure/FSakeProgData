void histogram(int n, int ns[], int max, int freq[]){
    int count;
    int k;
    int val;
    int i;

    for (i = 0; i <= max; i = i + 1)
    {
        count = 0;
        for(k = 0; k < n; k = k + 1)
        {
            val = ns[k];
            if (i == val){
                count = count + 1;
            }
        }
        freq[i] = count;
    }
}


void main(int max){
    int ns[7];
    ns[0] = 1;
    ns[1] = 2;
    ns[2] = 1;
    ns[3] = 1;
    ns[4] = 1;
    ns[5] = 2;
    ns[6] = 0;

    int size;
    size = max + 1;

    int freq[4]; //UNABLE TO SET FREQ[SIZE]????

    histogram(7,ns,max,freq);
    int i;
    for(i = 0; i < size; i = i + 1)
    {
        print freq[i];
        println;
    }
}