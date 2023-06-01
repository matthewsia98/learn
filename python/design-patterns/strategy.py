import json
import textwrap
from abc import ABC, abstractmethod
from typing import Any


class DictSortingStrategy(ABC):
    @abstractmethod
    def sort(self, dictionary: dict[Any, Any]) -> dict[Any, Any]:
        pass


class DictSortByKeyAscendingStrategy(DictSortingStrategy):
    def sort(self, dictionary: dict[Any, Any]) -> dict[Any, Any]:
        print("\nSorting by key ascending")
        return dict(sorted(dictionary.items()))


class DictSortByKeyDescendingStrategy(DictSortingStrategy):
    def sort(self, dictionary: dict[Any, Any]) -> dict[Any, Any]:
        print("\nSorting by key descending")
        return dict(sorted(dictionary.items(), reverse=True))


class DictSortByValueAscendingStrategy(DictSortingStrategy):
    def sort(self, dictionary: dict[Any, Any]) -> dict[Any, Any]:
        print("\nSorting by value ascending")
        return dict(sorted(dictionary.items(), key=lambda x: x[1]))


class DictSortByValueDescendingStrategy(DictSortingStrategy):
    def sort(self, dictionary: dict[Any, Any]) -> dict[Any, Any]:
        print("\nSorting by value descending")
        return dict(sorted(dictionary.items(), key=lambda x: x[1], reverse=True))


class Pokedex:
    pokemons = {
        1: "Bulbasaur",
        4: "Charmander",
        7: "Squirtle",
        2: "Ivysaur",
        5: "Charmeleon",
        8: "Wartortle",
        3: "Venusaur",
        6: "Charizard",
        9: "Blastoise",
    }

    def sort(self, strategy: DictSortingStrategy) -> dict[Any, Any]:
        return strategy.sort(self.pokemons)


if __name__ == "__main__":
    pokedex = Pokedex()

    print("POKEDEX\n")
    print(json.dumps(pokedex.pokemons, sort_keys=False, indent=4))

    prompt = textwrap.dedent(
        """
        Choose your sorting strategy:
            1) Sort by number (Ascending)
            2) Sort by number (Descending)
            3) Sort by name (Ascending)
            4) Sort by name (Descending)

        """
    )

    strategy = input(prompt)
    match strategy:
        case "1":
            strategy = DictSortByKeyAscendingStrategy()
        case "2":
            strategy = DictSortByKeyDescendingStrategy()
        case "3":
            strategy = DictSortByValueAscendingStrategy()
        case "4":
            strategy = DictSortByValueDescendingStrategy()
        case _:
            raise ValueError("Invalid strategy")

    sorted_pokedex = pokedex.sort(strategy)

    print("\nSORTED POKEDEX\n")
    print(json.dumps(sorted_pokedex, sort_keys=False, indent=4))
