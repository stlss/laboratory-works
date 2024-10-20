from graphviz import Digraph


class DecisionTree(object):
    def __init__(self, dictionary):
        self.dictionary = dictionary

    def get_digraph(self):
        return _get_digraph(self.dictionary)

    def get_leaf_number(self):
        return _get_leaf_number(self.dictionary)

    def predict(self, d):
        return _predict(self.dictionary, d)


def _get_digraph(tree, parent_name=None, graph=None, edge_label=None, path=""):
    if graph is None:
        graph = Digraph(format='png')
        graph.attr('graph', rankdir='TB')

    if isinstance(tree, dict):
        node_name = list(tree.keys())[0]
        node_label = node_name
        graph.attr('node', shape='ellipse', style='filled', color='lightblue2', fontname="Helvetica")
    else:
        node_name = str(tree)
        node_label = node_name
        graph.attr('node', shape='ellipse', style='filled', color='yellow', fontname="Helvetica")

    unique_node_id = f"{path}_{node_name}"

    if parent_name is not None:
        graph.node(unique_node_id, label=node_label)
        graph.edge(parent_name, unique_node_id, label=edge_label)
    else:
        graph.node(unique_node_id, label=node_label)

    if isinstance(tree, dict):
        attribute = list(tree.keys())[0]

        items = list(tree[attribute].items())
        items.sort(key=lambda x: float(x[0].split(' - ')[0]))

        for value, subtree in items:
            new_path = f"{path}_{attribute}_{value}"
            _get_digraph(subtree, parent_name=unique_node_id, graph=graph, edge_label=str(value), path=new_path)

    return graph


def _get_leaf_number(tree):
    if isinstance(tree, str):
        return 1

    number = 0
    for key, subtree in tree.items():
        number += _get_leaf_number(subtree)

    return number


def _predict(tree, d):
    d_value = d[list(tree.keys())[0]]
    tree_value = list(tree.values())[0]

    if d_value not in tree_value:
        return None

    tree = tree_value[d_value]

    if isinstance(tree, str):
        return tree

    return _predict(tree, d)
