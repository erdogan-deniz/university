import numpy as np
import matplotlib.pyplot as plt

from typing import Callable


def lotka_volterra(
    y: tuple, a: float, b: float, c: float, d: float
) -> np.array:
    """Уравнение Лотки-Вольтерра."""

    y1: float | None = None
    y2: float | None = None

    y1, y2 = y

    dy_dt: list = [y1 * (a - b * y2), -y2 * (c - d * y1)]

    return np.array(dy_dt)


def runge_kutt_4th_order(
    func: Callable,
    y0: list,
    t: np.array,
    a: float,
    b: float,
    c: float,
    d: float,
) -> np.array:
    """Метод Рунге-Кутты 4-го порядка."""

    n: int = len(t)
    y: np.array = np.zeros((n, len(y0)))

    y[0] = y0

    for indx in range(n - 1):
        dt: float = t[indx + 1] - t[indx]
        k1: np.array = func(y[indx], t[indx], a, b, c, d)
        k2: np.array = func(
            y[indx] + 0.5 * dt * k1, t[indx] + 0.5 * dt, a, b, c, d
        )
        k3: np.array = func(
            y[indx] + 0.5 * dt * k2, t[indx] + 0.5 * dt, a, b, c, d
        )
        k4: np.array = func(y[indx] + dt * k3, t[indx] + dt, a, b, c, d)
        y[indx + 1]: float = y[indx] + (dt / 6) * (k1 + 2 * k2 + 2 * k3 + k4)

    return y


def draw_plots(
    func: Callable,
    y0: list,
    t: np.array,
    a: float,
    b: float,
    c: float,
    d: float,
) -> None:
    """Отрисовка графиков."""

    solution: np.array = runge_kutt_4th_order(func, y0, t, a, b, c, d)

    plt.figure(figsize=(12, 6))

    plt.subplot(1, 2, 1)
    plt.xlabel("Время (дни)")
    plt.ylabel("Население")
    plt.title("Динамика населения с течением времени")

    plt.plot(t, solution[:, 0], label="Жертв (y1)", color="blue")
    plt.plot(t, solution[:, 1], label="Хищников (y2)", color="red")
    plt.legend()

    plt.subplot(1, 2, 2)
    plt.xlabel("Популяция жертв (y1)")
    plt.ylabel("Популяция хищников (y2)")
    plt.title("Фазовая диаграмма (хищник против жертвы)")

    plt.plot(solution[:, 0], solution[:, 1], color="green")
    plt.legend()

    plt.tight_layout()
    plt.show()
