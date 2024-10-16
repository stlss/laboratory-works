from game_settings import *


def _is_prime(x):
    if x < 2:
        return False

    i = 2
    while i * i <= x:
        if x % i == 0:
            return False
        i += 1

    return True


def _calculate_p_value():
    x1 = rows * columns
    x2 = x1

    while True:
        if _is_prime(x1):
            return x1

        if _is_prime(x2):
            return x2

        x1 += 1
        x2 -= 1


_p = _calculate_p_value()
_mod = int(1e18 + 7)


def _calculate_hash(values):
    hash_ = 0
    p = _p

    for i in range(rows):
        for j in range(columns):
            hash_ += p * values[i][j] % _mod
            p = p * _p % _mod

    return hash_


class GameState(object):
    def __init__(self, values, moves=0, previous_game_state=None):
        self.values = values
        self.moves = moves
        self.previous_game_state = previous_game_state
        self.hash = _calculate_hash(values)

    def __str__(self):
        return '\n'.join([' '.join([str(x) for x in line]) for line in self.values])

    def __getitem__(self, indexes):
        return self.values[indexes[0]][indexes[1]]

    def __hash__(self):
        return self.hash

    def __eq__(self, other):
        return isinstance(other, GameState) and self.values == other.values

    def __lt__(self, other):
        return isinstance(other, GameState) and self.values < other.values

    def print(self):
        print(self)


def print_game_states(game_states):
    if len(game_states) == 0:
        return

    def print_game_state(num, game_state):
        print(f'{num})')
        game_state.print()

    print_game_state(1, game_states[0])

    for i in range(1, len(game_states)):
        print()
        print_game_state(i + 1, game_states[i])
