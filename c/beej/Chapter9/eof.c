#include <stdio.h>


int main(void)
{
    int i = EOF;
    printf("%d\n", i);

    char c = EOF;
    printf("%d\n", c);

    unsigned char d = EOF;
    printf("%d\n", d);

    // unsigned char holds 0-255
    // -10 mod 256 = 246
    unsigned char a = -10;
    printf("%d\n", a);
}
