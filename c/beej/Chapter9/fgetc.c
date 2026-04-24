#include  <stdio.h>


int main(void)
{
    FILE *fp;
    int c;

    fp = fopen("hello.txt", "r");

    // fgetc will return EOF on end-of-file
    while ((c = fgetc(fp)) != EOF)
    {
        printf("%c", c);
    }

    fclose(fp);
}
