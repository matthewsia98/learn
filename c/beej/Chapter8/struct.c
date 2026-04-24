#include <stdio.h>


struct car {
    char *name;
    float price;
    int speed;
};

struct car set_price(struct car c, float price)
{
    c.price = price;
    return c;
}

void set_price_ref(struct car *c, float price)
{
    c -> price = price;
}

int main(void)
{
    struct car x;

    x.name = "x";
    x.price = 99.99;
    x.speed = 7;

    printf("x.name = %s\n", x.name);
    printf("x.speed = %d\n", x.speed);
    printf("x.price = %f\n", x.price);

    struct car y = {
        .name = "y",
        .price = 123
    };

    printf("y.name = %s\n", y.name);
    printf("y.speed = %d\n", y.speed);
    printf("y.price = %f\n", y.price);

    struct car z = {
        .name = "z",
        .price = 1
    };

    printf("z.name = %s\n", z.name);
    printf("z.price = %f\n", z.price);

    struct car r = set_price(z, 2);
    printf("r.name = %s\n", r.name);
    printf("r.price = %f\n", r.price);
    printf("z.name = %s\n", z.name);
    printf("z.price = %f\n", z.price);

    set_price_ref(&z, 3);
    printf("z.name = %s\n", z.name);
    printf("z.price = %f\n", z.price);
}
