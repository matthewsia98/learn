#include <stdio.h>


int main(void)
{
    typedef int antelope;  // Make "antelope" an alias for "int"
    antelope x = 10;       // Type "antelope" is the same as type "int"
    printf("antelope x = %d\n", x);

    typedef int bagel, mushroom;  // These are all "int"
    bagel a = 1;
    mushroom b = 2;
    printf("bagel a = %d\nmushroom b = %d\n", a, b);


    struct animal {
        char *name;
        int leg_count, speed;
    };
    struct animal y = {
        .name = "y"
    };
    printf("%s\n", y.name);

    // original name      new name
    //            |         |
    //            v         v
    //      |-----------| |----|
    typedef struct animal animal;
    animal z = {
        .name = "z"
    };
    printf("%s\n", z.name);

    // Anonymous struct! It has no name!
    //         |
    //         v
    //      |----|
    typedef struct {
        int x, y;
    } point;
    point p = {.x=20, .y=40};
    printf("%d, %d\n", p.x, p.y);

    typedef int five_ints[5];
    five_ints arr = {1, 2, 3, 4, 5};
    for (int i = 0; i < 5; i++)
    {
        printf("%d", arr[i]);
    }
}
