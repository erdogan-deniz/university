import numpy as np

solution_data: dict = {
    "a": 0.1,
    "c": 0.1,
    "d": 0.01,
    "b": 0.02,
    "y": [40, 9],
    # Временной диапозон интеграции:
    "t": np.linspace(0, 365, 1000),
}
