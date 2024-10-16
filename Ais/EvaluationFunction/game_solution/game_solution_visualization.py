import matplotlib.pyplot as plt
import networkx as nx


def _get_edges(game_states):
    edges = list()
    game_states_ = set()

    for game_state in game_states:
        while game_state not in game_states_ and game_state.previous_game_state is not None:
            game_states_.add(game_state)
            edges.append((game_state.previous_game_state, game_state))
            game_state = game_state.previous_game_state

    return edges


def _get_graph_node_colors(game_solution):
    nodes = game_solution.game_states
    edges = _get_edges(game_solution.game_states)

    graph = nx.DiGraph()

    graph.add_nodes_from(nodes)
    graph.add_edges_from(edges)

    trajectory = set(game_solution.trajectory)
    colors = ['green' if game_state in trajectory else 'yellow' for game_state in game_solution.game_states]

    return graph, colors


def draw_tree(game_solution, node_size, font_size, width, arrow_size):
    graph, node_colors = _get_graph_node_colors(game_solution)

    pos = nx.drawing.nx_pydot.graphviz_layout(graph, prog="dot")
    nx.draw(graph, pos,
            node_size=node_size, node_color=node_colors,
            font_size=font_size, font_color='black',
            width=width,
            arrowsize=arrow_size,
            with_labels=True,
            arrows=True,
            node_shape='s')

    plt.show()
