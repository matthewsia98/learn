def abstractmethod(func):
    func.__isabstractmethod__ = True
    return func


def get_abstract_methods(cls):
    abstract_methods = []
    while isinstance(cls, MyABC):
        for value in vars(cls).values():
            if getattr(value, "__isabstractmethod__", False):
                abstract_methods.append(value.__name__)
        cls = cls.__mro__[1]
    return abstract_methods


class MyABC(type):
    def __call__(cls, *args, **kwargs):
        print(f"MyABC.__call__({cls=}, {args=}, {kwargs=})")
        abstract_methods = get_abstract_methods(cls)
        if abstract_methods:
            raise TypeError(
                f"Can't instantiate abstract class {cls.__name__} with"
                f" abstract {'methods' if len(abstract_methods) > 1 else 'method'}: {', '.join(abstract_methods)}"
            )
        return super().__call__(*args, **kwargs)


class AbstractClass(metaclass=MyABC):
    @abstractmethod
    def foo(self):
        pass


class ConcreteClass(AbstractClass):
    pass


a = ConcreteClass()
