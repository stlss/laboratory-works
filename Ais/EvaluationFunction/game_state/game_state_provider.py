from game_settings import *
from game_state.game_state import GameState
from copy import deepcopy
from random import randint


def get_final_game_state():
    ptr_number = [0]

    def get_number():
        ptr_number[0] += 1
        return ptr_number[0]

    values = [[get_number() for _ in range(columns)] for _ in range(rows)]
    values[-1][-1] = 0

    return GameState(values)


def _find_indexes_empty_cell(game_state):
    for i in range(rows):
        for j in range(columns):
            if game_state[i, j] == 0:
                return i, j


def _validate_indexes(indexes):
    return 0 <= indexes[0] < rows and 0 <= indexes[1] < columns


def _try_move(game_state, shifts):
    i1, j1 = _find_indexes_empty_cell(game_state)
    i2, j2 = i1 + shifts[0], j1 + shifts[1]

    if not _validate_indexes((i2, j2)):
        return False, game_state

    new_values = deepcopy(game_state.values)
    new_values[i1][j1] = game_state[i2, j2]
    new_values[i2][j2] = game_state[i1, j1]

    new_game_state = GameState(new_values, game_state.moves + 1, game_state)

    return True, new_game_state


def _try_move_left(game_state):
    return _try_move(game_state, (0, -1))


def _try_move_right(game_state):
    return _try_move(game_state, (0, 1))


def _try_move_top(game_state):
    return _try_move(game_state, (-1, 0))


def _try_move_bottom(game_state):
    return _try_move(game_state, (1, 0))


_move_functions = _try_move_top, _try_move_right, _try_move_bottom, _try_move_left


def get_random_game_state(moves=1000):
    game_state = get_final_game_state()

    for i in range(moves):
        index = randint(0, len(_move_functions) - 1)
        game_state = _move_functions[index](game_state)[1]

    game_state.previous_game_state = None
    return game_state


def get_incorrect_random_game_state(moves=1000):
    game_state = get_random_game_state(moves)

    new_values = game_state.values
    new_values[0][0], new_values[1][1] = new_values[1][1], new_values[0][0]

    new_game_state = GameState(new_values)
    return new_game_state


def get_next_game_states(game_state):
    move_results = [function(game_state) for function in _move_functions]
    game_states = [result[1] for result in move_results if result[0]]
    return game_states
