import textwrap
from abc import ABC, abstractmethod


class Burger(ABC):
    @property
    def ingredients(self):
        pass

    @abstractmethod
    def prepare(self):
        pass


class CheeseBurger(Burger):
    @property
    def ingredients(self):
        return ["cheese", "beef patty"]

    def prepare(self):
        print("\nPreparing CheeseBurger")


class ChickenBurger(Burger):
    @property
    def ingredients(self):
        return ["chicken", "special sauce"]

    def prepare(self):
        print("\nPreparing ChickenBurger")


class VeggieBurger(Burger):
    @property
    def ingredients(self):
        return ["lettuce", "veggie patty"]

    def prepare(self):
        print("\nPreparing VeggieBurger")


class BurgerFactory:
    def create_burger(self, burger_type):
        match burger_type:
            case "cheese":
                return CheeseBurger()
            case "chicken":
                return ChickenBurger()
            case "veggie":
                return VeggieBurger()
            case _:
                raise ValueError(f"Invalid burger type: {burger_type}")


if __name__ == "__main__":
    prompt = textwrap.dedent(
        """
        Choose your sorting strategy:
            1) CheeseBurger
            2) ChickenBurger
            3) VeggieBurger

        """
    )

    burger_type = input(prompt)
    match burger_type:
        case "1":
            burger_type = "cheese"
        case "2":
            burger_type = "chicken"
        case "3":
            burger_type = "veggie"
        case _:
            raise ValueError(f"Invalid burger type: {burger_type}")

    factory = BurgerFactory()
    burger = factory.create_burger(burger_type)
    burger.prepare()

    print(f"\nCreated {type(burger).__name__} with ingredients:")
    print("\t" + "\n\t".join(burger.ingredients))
