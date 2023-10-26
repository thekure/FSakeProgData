void histogram(int n, int ns[], int max, int freq[]){
    int count;
    int k;
    int val;
    int i;
    i = 0;
    while (i <= max){
        count = 0;
        k = 0;

        while (k < n){
            val = ns[k];
            if (i == val){
                count = count + 1;
            }
            k = k + 1;
        }
        freq[i] = count;
        i = i + 1;
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
    i = 0;
    while (i < size){
        print freq[i];
        println;
        i = i +1;
    }
}