import numpy as np
from math import log2
from decision_tree.decision_tree import DecisionTree


def _entropy(target_col):
    elements, counts = np.unique(target_col, return_counts=True)
    entropy_value = 0

    for i in range(len(elements)):
        probability = counts[i] / np.sum(counts)
        entropy_value += -probability * log2(probability)

    return entropy_value


def _information_gain(data, split_attribute_name, target_name="target"):
    # Энтропия исходного набора данных
    total_entropy = _entropy(data[target_name])

    # Уникальные значения атрибута, по которому выполняется разбиение
    vals, counts = np.unique(data[split_attribute_name], return_counts=True)

    # Вычисляем взвешенную энтропию по подмножествам
    weighted_entropy = 0
    for i in range(len(vals)):
        subset = data[data[split_attribute_name] == vals[i]]
        subset_entropy = _entropy(subset[target_name])
        weighted_entropy += (counts[i] / np.sum(counts)) * subset_entropy

    # Информационный выигрыш
    return total_entropy - weighted_entropy


def _best_feature_to_split(data, target_name="target"):
    features = [column for column in data.columns if column != target_name]

    # Вычисляем информационный выигрыш для каждого признака
    info_gains = np.array([_information_gain(data, feature, target_name) for feature in features])

    # Возвращаем признак с максимальным информационным выигрышем
    best_feature_index = np.argmax(info_gains)
    return features[best_feature_index]


def _id3(data, original_data, features, target_feature, parent_node_class=None):
    if len(np.unique(data[target_feature])) <= 1:
        return np.unique(data[target_feature])[0]

    # Если набор данных пуст, вернуть класс родительского узла
    if len(data) == 0:
        return np.unique(original_data[target_feature])[
            np.argmax(np.unique(original_data[target_feature], return_counts=True)[1])]

    # Если больше нет признаков для разделения, вернуть класс родительского узла
    if len(features) == 0:
        return parent_node_class

    # В противном случае строим дерево

    # Выбираем класс родительского узла (наиболее частый)
    parent_node_class = np.unique(data[target_feature])[
        np.argmax(np.unique(data[target_feature], return_counts=True)[1])]

    # Выбираем наилучший признак для разделения
    best_feature = _best_feature_to_split(data, target_feature)

    # Создаем узел дерева решений
    tree = {best_feature: {}}

    # Удаляем лучший признак из списка
    features = [i for i in features if i != best_feature]

    # Строим дерево для каждой ветви
    for value in np.unique(data[best_feature]):
        sub_data = data[data[best_feature] == value]
        subtree = _id3(sub_data, original_data, features, target_feature, parent_node_class)
        tree[best_feature][value] = subtree

    return tree


def id3(data, target_feature):
    dictionary = _id3(data, data, data.columns[:-1], target_feature)
    tree = DecisionTree(dictionary)
    return tree
