#include <stdio.h>
#include <stdlib.h>
#include <locale.h>

int main(void)
{
    int r;
    do {
        r = rand() % 100;
        printf("%d\n", r);
    } while (r != 99);  // repeat until 99 comes up

    int i = 0;

    printf("While loop\n");
    while (i < 10) {
        printf("i = %d\n", i);
        i++;
    }

    printf("For loop\n");
    for (i = 0; i < 10; i++) {
        printf("i = %d\n", i);
    }

    int j;
    for (i = 0, j = 0; i < 10; i++, j = 2*i) {
        printf("i = %d, j = %d\n", i, j);
    }

    /*
    for (;;) {
        printf("Forver loop\n");
    }
    */

    int x = 1;
    switch (x) {
        case 1:
            printf("1\n");
            // fall through to next case
        case 2:
            printf("2\n");
            break;
        default:
            printf("default\n");
    }
}
