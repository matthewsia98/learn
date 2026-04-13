#include <stdio.h>
#include <stdbool.h>

int main(void)
{
    int i = -1;
    int m = 5;
    int r = i % m;
    printf("%d %% %d = %d\n", i, m, r);
    
    int n = 7;
    printf("%d is %s\n", n, n%2 == 0? "even" : "odd");

    printf("sizeof n = %zu\n", sizeof n);
    printf("sizeof 3.14 = %zu\n", sizeof 3.14);

    char *s = "Hello, World!\n";
    printf("sizeof s = %zu\n", sizeof s);

    printf("sizeof(char) = %zu\n", sizeof(char));
    printf("sizeof(char *) = %zu\n", sizeof(char *));
    printf("sizeof(bool) = %zu\n", sizeof(bool));
    printf("sizeof(int) = %zu\n", sizeof(float));
    printf("sizeof(long) = %zu\n", sizeof(long));
    printf("sizeof(float) = %zu\n", sizeof(int));
    printf("sizeof(double) = %zu\n", sizeof(double));
}
