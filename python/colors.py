# 8 COLORS
# (bg, fg)
colors_8 = {
    "black": (40, 30),
    "red": (41, 31),
    "green": (42, 32),
    "yellow": (43, 33),
    "blue": (44, 34),
    "magenta": (45, 35),
    "cyan": (46, 36),
    "white": (47, 37),
}

print("8 COLORS\n")

spacing = 2
max_length = max([len(color) for color in colors_8])
print(" " * max_length, end=" " * spacing)
for color in colors_8:
    print(color.center(max_length), end=" " * spacing)
print("\n")

text = "ABC"
for bg_color in colors_8:
    print(bg_color.ljust(max_length), end=" " * spacing)
    bg = colors_8.get(bg_color)[0]
    for fg_color in colors_8:
        fg = colors_8.get(fg_color)[1]
        print(f"\x1b[{bg};{fg}m{text.center(max_length)}\x1b[0m", end=" " * spacing)
    print("\n")

# 256 COLORS
# \x1b[38;5;${color}m
print("256 COLORS\n")
for i in range(256):
    bg = i
    print(f"Background: {bg}\n")
    for j in range(16):
        for k in range(16):
            fg = 16 * j + k
            print(f"\x1b[48;5;{bg};38;5;{fg}m{str(fg):^5}\x1b[0m", end=" " * spacing)
        print("\n\n")
    input("Continue?")
