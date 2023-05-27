from typing import Any, Callable, Union


def decorator(func: Callable) -> Callable:
    print("Inside decorator")

    def wrapper(*args: int, **kwargs: Any) -> int:
        print("Inside wrapper")
        args_str = ", ".join([str(arg) for arg in args]) if args else ""
        kwargs_str = ", ".join([f"{k}={v}" for k, v in kwargs]) if kwargs else ""
        return_value = func(*args, **kwargs)
        print(f"{func.__name__}({args_str}{kwargs_str}) -> {return_value}")
        return return_value

    return wrapper


@decorator  # add_numbers = decorator(add_numbers)
def add_numbers(n1: int, n2: int) -> int:
    return n1 + n2


add_numbers(1, 2)


def decorator_decorator(*decorator_args, **decorator_kwargs) -> Callable:
    """
    Returns a decorator
    """
    print("Inside decorator_decorator")
    print(f"{decorator_args=}")
    print(f"{decorator_kwargs=}")

    def decorator(func: Callable) -> Callable:
        print("Inside decorator")

        def wrapper(*args: Union[int, float], **kwargs: Any) -> Union[float, str]:
            print("Inside wrapper")
            args_str = ", ".join([str(arg) for arg in args]) if args else ""
            kwargs_str = ", ".join([f"{k}={v}" for k, v in kwargs]) if kwargs else ""

            if args[1] == 0 and decorator_kwargs.get("strict"):
                return_value = "Cannot divide by 0"
            else:
                return_value = func(*args, **kwargs)
            print(f"{func.__name__}({args_str}{kwargs_str}) -> {return_value}")
            return return_value

        return wrapper

    return decorator


@decorator_decorator(
    strict=True
)  # divide_numbers = (decorator_decorator(*decorator_args, **decorator_kwargs))(divide_numbers)
def divide_numbers(n1: Union[int, float], n2: Union[int, float]) -> Union[float, str]:
    return n1 / n2


divide_numbers(1, 0)
divide_numbers(4, 2)
