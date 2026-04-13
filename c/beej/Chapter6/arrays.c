#include <stdio.h>

void foo(float f[]);

int main(void)
{
    float f[3] = {1, 2, 3};

    printf("sizeof f = %zu\n", sizeof f);
    printf("sizeof f[0] = %zu\n", sizeof f[0]);
    printf("sizeof f / sizeof f[0] = %zu\n", sizeof f / sizeof f[0]);

    foo(f);

    for (int i = 0; i < 3; i++) {
        printf("%f\n", f[i]);
    }
    
    f[0] = 3;
    f[1] = 1;
    f[2] = 4;

    for (int i = 0; i < 3; i++) {
        printf("%f\n", f[i]);
    }

    printf("sizeof(float) = %zu\n", sizeof(float));
    printf("sizeof(float[48]) = %zu\n", sizeof(float[48]));
}

void foo(float f[])
{
#pragma GCC diagnostic push
#pragma GCC diagnostic ignored "-Wsizeof-array-argument"
    // passing arrays into functions only passes a pointer to the first element
    // so prints sizeof float*
    printf("In foo, sizeof f = %zu\n", sizeof f);
    printf("sizeof(float *) = %zu\n", sizeof(float *));
#pragma GCC diagnostic pop
}
