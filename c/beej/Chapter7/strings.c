#include <stdio.h>
#include <string.h>
#include <uchar.h>
#include <wchar.h>

size_t my_strlen(char * s);

int main(void)
{
    /*
    A string literal, similar to an integer literal, has its
    memory automatically managed by the compiler for you! With an integer, i.e. a fixed size piece of data,
    the compiler can pretty easily manage it. But strings are a variable-byte beast which the compiler tames
    by tossing into a chunk of memory, and giving you a pointer to it.
    This form points to wherever that string was placed. Typically, that place is in a land faraway from the
    rest of your program’s memory – read-only memory – for reasons related to performance & safety.
    */
    char *s = "Hello, World!";
    for (int i = 0; i < 13; i++)
    {
        printf("%c", s[i]);
    }
    // CANNOT mutate a string literal
    // s[0] = 'z';

    printf("\n");

    /*
    But declaring it as an array is different. The compiler doesn’t stow those bytes in another part of town,
    they’re right down the street. This one is a mutable copy of the string – one we can change at will:
    */
    char t[] = "Hello, World!";  // t is an array copy of the string
    for (int i = 0; i < 13; i++)
    {
        printf("%c", t[i]);
    }
    t[0] = 'z';
    printf("\n");

    for (int i = 0; i < 13; i++)
    {
        printf("%c", t[i]);
    }
    printf("\n");

    printf("s = \"%s\" is %zu bytes long\n", s, strlen(s));
    printf("s = \"%s\" is %zu bytes long\n", s, my_strlen(s));

    char *u = "\u274c";
    printf("u = \"%s\" is %zu bytes long\n", u, strlen(u));
    // UTF-8
    char *v = u8"\u274c";
    printf("v = \"%s\" is %zu bytes long\n", v, strlen(v));

    printf("sizeof(char) = %zu\n", sizeof(char));
    printf("sizeof(char *) = %zu\n", sizeof(char *));
    // UTF-16
    // char16_t *w = u"\u274c";
    printf("sizeof(char16_t) = %zu\n", sizeof(char16_t));
    printf("sizeof(char16_t *) = %zu\n", sizeof(char16_t *));
    // UTF-32
    // char32_t *x = U"\u274c";
    printf("sizeof(char32_t) = %zu\n", sizeof(char32_t));
    printf("sizeof(char32_t *) = %zu\n", sizeof(char32_t *));
    // Wide character string (platform-dependent size, often UTF-16 on Windows)
    // wchar_t *y = L"\u274c";
    printf("sizeof(wchar_t) = %zu\n", sizeof(wchar_t));
    printf("sizeof(wchar_t *) = %zu\n", sizeof(wchar_t *));

    char *a = t;
    printf("t = ");
    for (int i = 0; i < 13; i++)
    {
        printf("%c", t[i]);
    }
    a[0] = 'A';
    printf("\na = ");
    for (int i = 0; i < 13; i++)
    {
        printf("%c", a[i]);
    }
    printf("\nt = ");
    for (int i = 0; i < 13; i++)
    {
        printf("%c", t[i]);
    }

    char b[100];
    printf("\nt = ");
    for (int i = 0; i < 13; i++)
    {
        printf("%c", t[i]);
    }
    strcpy(b, t);
    printf("\nt = ");
    for (int i = 0; i < 13; i++)
    {
        printf("%c", t[i]);
    }
    b[0] = 'B';
    printf("\nb = ");
    for (int i = 0; i < 13; i++)
    {
        printf("%c", b[i]);
    }
    printf("\nt = ");
    for (int i = 0; i < 13; i++)
    {
        printf("%c", t[i]);
    }
}

size_t my_strlen(char *s)
{
    size_t count = 0;

    char null_byte = '\0';
    while (s[count] != null_byte)
    {
        count++;
    }

    return count;
}
