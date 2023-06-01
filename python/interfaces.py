import abc
from abc import ABC, abstractmethod


class Interface(ABC):
    @abstractmethod
    def foo(self):
        pass

    @abstractmethod
    def bar(self):
        pass


class ConcreteInterface(Interface):
    def foo(self):
        print("Base.foo")

    def bar(self):
        print("Base.bar")


i = ConcreteInterface()
i.foo()
i.bar()


class AbstractClass(metaclass=abc.ABCMeta):
    @abc.abstractmethod
    def foo(self):
        pass

    def bar(self):
        print("AbstractClass.bar")


class ConcreteAbstractClass(AbstractClass):
    def foo(self):
        print("ConcreteAbstractClass.foo")


a = ConcreteAbstractClass()
a.foo()
a.bar()
