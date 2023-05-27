import abc


class Base(metaclass=abc.ABCMeta):
    @abc.abstractmethod
    def foo(self):
        raise NotImplementedError

    @abc.abstractmethod
    def bar(self):
        raise NotImplementedError


class Concrete(Base):
    def foo(self):
        print("Base.foo")

    # We forget to declare bar() again, and the metaclass complains.
    # def bar(self):
    #     print("Base.bar")


c = Concrete()
c.foo()
c.bar()
