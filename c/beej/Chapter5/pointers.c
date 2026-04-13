#include <stdio.h>


void increment(int *i);


int main(void)
{
    int i = 0;

    printf("The value of i is %d\n", i);
    printf("The address of i is %p\n", (void *)&i);

    increment(&i);

    printf("The value of i is %d\n", i);
    printf("The address of i is %p\n", (void *)&i);

    int *p = &i;
    printf("sizeof(int) = %zu\n", sizeof(int));
    printf("sizeof i = %zu\n", sizeof i);
    // p is type int *, so prints size of int pointer
    printf("sizeof p = %zu\n", sizeof p);
    // *p is type int, so prints size of int
    printf("sizeof *p = %zu\n", sizeof *p);
}


void increment(int *i)
{
    (*i)++;
}
