#include <stdio.h>

int main(void)
{
    int *p = NULL;
    printf("The address of p is %p\n", (void *)p);
    printf("The value of p is %d\n", *p);
}
