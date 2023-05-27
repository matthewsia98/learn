from types import TracebackType
from typing import Generator, Optional, Type


class ContextManager:
    def __init__(self):
        print("__init__")

    def __enter__(self) -> str:
        print("__enter__")
        return "Hello World"

    def __exit__(
        self,
        exception_type: Optional[Type[BaseException]],
        exception_instance: Optional[BaseException],
        traceback: Optional[TracebackType],
    ):
        """
        If return True, exceptions will be ignored
        If return False, exceptions will be raised
        """
        print("__exit__")
        print(f"{exception_type=}")
        print(f"{exception_instance=}")
        print(f"{traceback=}")

        return True


with ContextManager() as cm:
    print(cm)
    raise RuntimeError("error")

print("out of context")


import contextlib


@contextlib.contextmanager
def context_manager() -> Generator[str, None, None]:
    print("__enter__")
    try:
        yield "Hello World"
    # __exit__ will always return False, exceptions will be raised
    # if we want to suppress exceptions, we will need to handle them
    except BaseException:
        pass
    finally:
        print("__exit__")


with context_manager() as cm:
    print(cm)
    raise RuntimeError("error")
print("out of context")
