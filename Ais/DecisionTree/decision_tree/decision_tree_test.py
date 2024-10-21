def test_decision_tree(tree, test_data, target_feature):
    accepts = 0
    nones = 0

    for i in range(test_data.shape[0]):
        record = dict(test_data.iloc[i])
        result = tree.predict(record)

        if result == record[target_feature]:
            accepts += 1

        if result is None:
            nones += 1

    return accepts, nones
