def decorator(func):
    print("Inside decorator")

    def wrapper(*args, **kwargs):
        print("Inside wrapper")
        print(f"{args=}")
        print(f"{kwargs=}")

        print("Calling", func.__name__)
        return_value = func(*args, **kwargs)
        print(f"{func.__name__} returned {return_value}")
        return return_value

    return wrapper


@decorator  # add_numbers = decorator(add_numbers)
def add_numbers(n1, n2):
    return n1 + n2


add_numbers(1, 2)


def decorator_with_args(*decorator_args, **decorator_kwargs):
    print("Inside decorator_with_args")
    print(f"{decorator_args=}")
    print(f"{decorator_kwargs=}")

    def decorator(func):
        print("Inside decorator")

        def wrapper(*args, **kwargs):
            print("Inside wrapper")
            print(f"{args=}")
            print(f"{kwargs=}")

            if args[1] == 0 and decorator_kwargs.get("strict"):
                print("Cannot divide by 0")
            else:
                print("Calling", func.__name__)
                return_value = func(*args, **kwargs)
                print(f"{func.__name__} returned {return_value}")
                return return_value

        return wrapper

    return decorator


@decorator_with_args(
    strict=True
)  # divide_numbers = (decorator_with_args(*args, **kwargs))(divide_numbers)
def divide_numbers(n1, n2):
    return n1 / n2


divide_numbers(1, 0)
divide_numbers(4, 2)
