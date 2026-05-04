#include <stdio.h>
#include <string.h>


void *my_memcpy(void *dest, void *src, size_t byte_count);


int main(void)
{
    char *s = "Goats!";
    char t[100];

    printf("%ld\n", strlen(s));

    void *res = memcpy(t, s, 7);  // Copy 7 bytes--including the NUL terminator!
    printf("address of t = %p\n", t);
    printf("address of s = %p\n", s);
    printf("%p\n", res);

    printf("%s\n", t);


    int a[] = {11, 22, 33};
    int b[3];
    memcpy(b, a, 3 * sizeof(int));
    for (int i = 0; i < 3; i++) {
        printf("%d\n", b[i]);
    }

    typedef struct {
        char *name;
        int leg_count;
    } animal;
    printf("sizeof(animal) = %ld\n", sizeof(animal));

    animal a1 = { .name = "a1" };
    animal a1_copy;
    my_memcpy(&a1_copy, &a1, sizeof(animal));
    printf("a1.name = %s\n", a1.name);
    printf("a1_copy.name = %s\n", a1_copy.name);
    a1.name = "new name";
    printf("a1.name = %s\n", a1.name);
    printf("a1_copy.name = %s\n", a1_copy.name);

    animal a2 = { .name = "a2" };
    animal a2_copy;
    a2_copy = a2;
    printf("a2.name = %s\n", a2.name);
    printf("a2_copy.name = %s\n", a2_copy.name);
    a2.name = "new name";
    printf("a2.name = %s\n", a2.name);
    printf("a2_copy.name = %s\n", a2_copy.name);
}

void *my_memcpy(void *dest, void *src, size_t byte_count)
{
    char *s = src, *d = dest;

    while (byte_count--) {
        *d++ = *s++;
    }

    return dest;
}
