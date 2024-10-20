import pandas as pd
from pprint import pprint

_all = 100
_train, _test = 80, 20

_original_df = pd.read_csv('data_provider/data.csv')
_modified_df = _original_df[(_original_df['sc_w'] > 0) & (_original_df['sc_h'] > 0)]
_cropped_modified_df = _modified_df[:_all]

_battery_power = 'Мощность батареи (mAh)'
_clock_speed = 'Частота процессора (gHz)'
_core_number = 'Число ядер процессора (n)'
_mega_pixels_sum = 'Число мегапикселей (n)'
_internal_memory = 'Объём встроенной памяти (gb)'
_random_access_memory = 'Объём оперативной памяти (mb)'
_screen_square = 'Площадь экрана (cm^2)'

_price_range = 'Ценовой диапазон'


def _get_battery_powers():
    return _cropped_modified_df['battery_power']


def _get_clock_speeds():
    return _cropped_modified_df['clock_speed']


def _get_core_numbers():
    return _cropped_modified_df['n_cores']


def _get_mega_pixels_sums():
    return _cropped_modified_df['fc'] + _cropped_modified_df['pc']


def _get_internal_memories():
    return _cropped_modified_df['int_memory']


def _get_random_access_memories():
    return _cropped_modified_df['ram']


def _get_screen_squares():
    return _cropped_modified_df['sc_w'] * _cropped_modified_df['sc_h']


def _get_price_ranges():
    return _cropped_modified_df['price_range'] + 1


def _to_ranges(values):
    shares = [0, 0.25, 0.5, 0.75, 1]
    quantiles = list(values.quantile(q=shares))
    ranges = [(quantiles[i - 1], quantiles[i]) for i in range(1, len(quantiles))]

    def value_to_range(value):
        for range_ in ranges:
            if range_[0] <= value < range_[1]:
                return range_
        return ranges[-1]

    def range_to_str(range_):
        return f'{"{:.2f}".format(range_[0])} - {"{:.2f}".format(range_[1])}'

    new_values = list(map(lambda x: range_to_str(value_to_range(x)), values))
    return new_values


def _to_str(values):
    return list(map(str, values))


def _get_data():
    d = dict()

    d[_battery_power] = _get_battery_powers()
    d[_clock_speed] = _get_clock_speeds()
    d[_core_number] = _get_core_numbers()
    d[_mega_pixels_sum] = _get_mega_pixels_sums()
    d[_internal_memory] = _get_internal_memories()
    d[_random_access_memory] = _get_random_access_memories()
    d[_screen_square] = _get_screen_squares()

    d[_price_range] = _get_price_ranges()

    to_range_columns = _battery_power, _clock_speed, _core_number, _mega_pixels_sum, _internal_memory, \
        _random_access_memory, _screen_square

    to_str_columns = _price_range,

    for column in to_range_columns:
        d[column] = _to_ranges(d[column])

    for column in to_str_columns:
        d[column] = _to_str(d[column])

    return pd.DataFrame(d)


_data = _get_data()
_train_data = _data[:_train]
_test_data = _data[_train:_test]


def get_train_data():
    return _train_data.copy()


def get_test_data():
    return _test_data.copy()


def print_unique_column_values():
    for column in _data.columns:
        print(column)

        unique_values = list(map(str, _data[column].unique()))

        if '-' in unique_values[0]:
            unique_values.sort(key=lambda x: float(x.split(' - ')[0]))
        if unique_values[0].isdigit():
            unique_values.sort(key=lambda x: int(x))

        pprint(unique_values)
        print()
