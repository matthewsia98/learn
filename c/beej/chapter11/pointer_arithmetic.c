#include <stdio.h>
#include <string.h>


size_t my_strlen(char *s);


int main(void)
{
    // Adding to Pointers
    int a[5] = {11, 22, 33, 44, 55};
    int *p = &a[0];  // Or "int *p = a;" works just as well
    printf("%d\n", *p);
    /*
    In short, if you have a pointer to a type, adding one to the pointer
    moves to the next item of that type directly after it in memory.
    C knows that p is a pointer to an int . So it knows the sizeof an int and it
    knows to skip that many bytes to get to the next int after the first one!
    */
    printf("%d\n", *(p+1));

    for (int i = 0; i < 5; i++) {
        printf("%d\n", *(a + i));  // Same as a[i]!
    }

    // Changing Pointers
    int b[] = {11, 22, 33, 44, 55, 999};
    p = b;
    while (*p != 999) {
        printf("%d\n", *p);
        p++;
    }

    // Subtracting Pointers
    char *s = "Hello, World!\n";
    printf("%ld\n", strlen(s));
    printf("%ld\n", my_strlen(s));
}

/*
But we can also subtract two pointers to find the difference between them,
e.g. we can calculate how many int s there are between two int* s.
The catch is that this only works within a single array
if the pointers point to anything else, you get undefined behavior.
*/
size_t my_strlen(char *s)
{
    char *p = s;

    while (*p != '\0') {
        p++;
    }

    return p - s;
}
