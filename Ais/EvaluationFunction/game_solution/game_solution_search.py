from evaluation_function.evaluation_function import calculate_evaluation_function_value
import game_state.game_state_provider as game_state_provider
from heapq import heappush, heappop
from game_solution.game_solution import GameSolution

_final_game_state = game_state_provider.get_final_game_state()


def _get_game_solution_trajectory(final_game_state):
    game_state = final_game_state
    trajectory = [game_state]

    while game_state.previous_game_state is not None:
        game_state = game_state.previous_game_state
        trajectory.append(game_state)

    trajectory.reverse()
    return trajectory


def find_game_solution(init_game_state, k_g=1, k_h=1, max_iterations=1e5):
    def create_tree_leaves_item(game_state_):
        return calculate_evaluation_function_value(game_state_, k_g, k_h), game_state_

    tree_leaves = [create_tree_leaves_item(init_game_state)]
    tree_vertices = {init_game_state}
    iterations = 1

    while len(tree_leaves) != 0 and iterations <= max_iterations:
        game_state = heappop(tree_leaves)[1]

        if game_state == _final_game_state:
            trajectory = _get_game_solution_trajectory(game_state)

            return GameSolution(init_game_state=init_game_state,
                                game_states=tree_vertices,
                                trajectory=trajectory,
                                fail_reason=None)

        next_game_states = game_state_provider.get_next_game_states(game_state)

        for next_game_state in next_game_states:
            if next_game_state not in tree_vertices:
                heappush(tree_leaves, create_tree_leaves_item(next_game_state))
                tree_vertices.add(next_game_state)

        iterations += 1

    fail_reason = 'Рассмотрены все возможные состояния игры' if len(tree_vertices) <= max_iterations else \
        'Превышено максимально число итераций поиска игры'

    return GameSolution(init_game_state=init_game_state,
                        game_states=tree_vertices,
                        trajectory=None,
                        fail_reason=fail_reason)
