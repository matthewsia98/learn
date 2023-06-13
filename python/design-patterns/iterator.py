class EvenNumberList:
    def __init__(self):
        pass

    def __iter__(self):
        self.n = 0
        return self

    def __next__(self):
        _next = 2 * self.n
        self.n += 1
        return _next


class OddNumberList:
    def __init__(self):
        pass

    def __iter__(self):
        self.n = 0
        return self

    def __next__(self):
        _next = 2 * self.n + 1
        self.n += 1
        return _next


l = EvenNumberList()
itr = iter(l)
print(l.__class__.__qualname__)
print(next(itr))

print("for loop")
for n in range(1, 11):
    print(f"{n=}", next(itr))


l = OddNumberList()
itr = iter(l)
print(l.__class__.__qualname__)
print(next(itr))

print("for loop")
for n in range(1, 11):
    print(f"{n=}", next(itr))
