from game_state.game_state import print_game_states


class GameSolution(object):
    def __init__(self, init_game_state, game_states, trajectory=None, fail_reason='Неизвестно'):
        self.init_game_state = init_game_state
        self.game_states = game_states
        self.trajectory = trajectory
        self.fail_reason = fail_reason

    def print_results(self):
        print('Изначальное состояние игры:')
        self.init_game_state.print()
        print()

        game_states_len = len(self.game_states)

        if self.trajectory is None:
            print('Решение не было найдено.')
            print(f'Причина: "{self.fail_reason}".')
            print(f'Всего рассмотрено состояний игры - {game_states_len}.')
            return

        trajectory_len = len(self.trajectory)
        efficiency = trajectory_len / game_states_len * 100

        print(f'Всего рассмотрено состояний игры - {game_states_len}.')
        print(f'Размер траектории решения - {trajectory_len}.')
        print(f'Эффективность поиска решения - {"{:.2f}".format(efficiency)}%.')

    def print_trajectory(self):
        if self.trajectory is None:
            print('Траектория решения отсутствует.')
            return

        print('Траектория решения:\n')
        print_game_states(self.trajectory)
