import game_state.game_state_provider as game_state_provider
from game_settings import *

_final_game_state = game_state_provider.get_final_game_state()


def _calculate_g_value(game_state):
    g = 0

    for i in range(rows):
        for j in range(columns):
            if game_state[i, j] != _final_game_state[i, j]:
                g += 1

    return g


def _calculate_h_value(game_state):
    h = game_state.moves
    return h


def calculate_evaluation_function_value(game_state, k_g, k_h):
    g, h = _calculate_g_value(game_state), _calculate_h_value(game_state)
    return g * k_g + k_h * h
