#include <stdio.h>


int main(void)
{
    FILE *fp;
    char s[1024]; // big enough to hold any line
    int linecount = 0;

    fp = fopen("quote.txt", "r");

    // fgets returns NULL on end-of-file or error
    // If the buffer’s not big enough to read in an entire line,
    // it’ll just stop reading mid-line,
    // and the next call to fgets() will continue reading the rest of the line
    while (fgets(s, sizeof s, fp) != NULL)
    {
        printf("%d: %s", ++linecount, s);
    }

    fclose(fp);
}
