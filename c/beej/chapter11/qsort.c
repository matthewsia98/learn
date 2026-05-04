#include <stdio.h>
#include <stdlib.h>


typedef struct {
    char *name;
    int leg_count;
} animal;


int compar(const void *elem1, const void *elem2)
{
    const animal *animal1 = elem1;
    const animal *animal2 = elem2;

    if (animal1->leg_count > animal2->leg_count) {
        return 1;
    }

    if (animal1->leg_count < animal2->leg_count) {
        return -1;
    }

    return 0;
}


int main(void)
{
    animal a[4] = {
        {.name="Dog", .leg_count=4},
        {.name="Monkey", .leg_count=2},
        {.name="Antelope", .leg_count=4},
        {.name="Snake", .leg_count=0},
    };

    qsort(a, 4, sizeof(animal), compar);

    for (int i = 0; i < 4; i++) {
        printf("%d: %s\n", a[i].leg_count, a[i].name);
    }
}
