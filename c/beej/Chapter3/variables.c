#include <stdio.h>
#include <stdbool.h>

int main(void)
{
    int i = 2;
    float f = 3.14;
    char *s = "Hello, World!";  // char * ("char pointer") is the string type

    printf("%s i = %d and f = %.2f!\n", s, i, f);

    int x = 1;
    if (x) {
        printf("x is true \nx = %d\n", x);
    }

    bool y = true;
    if (y) {
        printf("y is true \ny = %d\n"), y;
    }
}
