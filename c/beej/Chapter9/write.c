#include <stdio.h>


int main(void)
{
    FILE *fp;

    // Opening an existing file in "w" mode
    // will instantly truncate that file to 0 bytes
    // for a full overwrite.
    fp = fopen("output.txt", "w");

    fputc('B', fp);
    fputc('\n', fp);

    int x = 32;
    fprintf(fp, "x = %d\n",x );

    fprintf(stdout, "Hello, stdout!\n");
    fprintf(stderr, "Hello, stderr!\n");
    
    fputs("Hello, World!\n", fp);

    fclose(fp);


    fp = fopen("output.bin", "wb");
    
    unsigned char bytes[6] = {5, 37, 0, 88, 255, 12};

    /*
    Those two middle arguments to fwrite() are pretty odd.
    But basically what we want to tell the function is,
    “We have items that are this big, and we want to write that many of them.”
    */
    fwrite(bytes, sizeof(char), 6, fp);

    fclose(fp);


    fp = fopen("output.bin", "rb");

    unsigned char c;

    // fread() has the neat feature where it returns the number of bytes read, or 0 on EOF
    while (fread(&c, sizeof(char), 1, fp) > 0)
    {
        printf("%d\n", c);
    }

    fclose(fp);

    /*
    order of bytes depends on endianess of the system
    */
    unsigned short v = 0x1234;  // 2 bytes, 0x12 and 0x34
    fp = fopen("output2.bin", "wb");
    fwrite(&v, sizeof v, 1, fp);
    fclose(fp);
}
