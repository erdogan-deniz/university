"""
This module provides functions for calculating the greatest common divisor
of two integers using a modified version of the Euclidean algorithm.

FUNCTIONS:
    get_gcd_multiplier(a_number: int, b_number: int) -> int: Calculates the
    multiplier needed in the Euclidean algorithm.

    get_gcd(a_number: int, b_number: int) -> int: Computes the GCD of two
    integers.

EXAMPLE:
    from calculations import get_gcd

    print(get_gcd(30, 18))

    # Output: 6
"""


def get_gcd_multiplier(a_number: int, b_number: int) -> int:
    """
    Calculates the multiplier in the Euclidean algorithm.

    The function determines the multiplier needed to express the
    difference between the maximum and minimum of the two integers
    in terms of the minimum integer.

    ARGS:
        a_number (int): The first integer.

        b_number (int): The second integer.

    RETURNS:
        int: The multiplier for the smaller number of a pair of numbers of the
        Euclid algorithm, when multiplied by which the difference between the
        larger number of a pair of numbers of the Euclid algorithm and the
        product will be less than the smaller number of a pair of numbers of
        the Euclid algorithm.

    EXAMPLE:
        print(get_gcd_multiplier(30, 18))

        # Output: 1
    """

    gcd_multiplier: int = 1

    while (
        max(a_number, b_number) - min(a_number, b_number) * gcd_multiplier
    ) > min(
        a_number,
        b_number,
    ):
        gcd_multiplier += 1

    return gcd_multiplier


def get_gcd(a_number: int, b_number: int) -> int:
    """
    Calculate the greatest common divisor of two integers.

    This function uses a modified version of the Euclidean algorithm
    to compute the GCD of two integers by repeatedly reducing the
    larger integer until it equals zero.

    ARGS:
        a_number (int): The first integer.

        b_number (int): The second integer.

    RETURNS:
        int: The greatest common divisor of the two integers.

    EXAMPLE:
        print(get_gcd(30, 18))

        # Output: 6
    """

    while (
        max(a_number, b_number)
        - min(a_number, b_number) * get_gcd_multiplier(a_number, b_number)
    ) != 0:
        gcd_multiplier: int = get_gcd_multiplier(a_number, b_number)
        a_number, b_number = min(a_number, b_number), (
            max(a_number, b_number) - gcd_multiplier * min(a_number, b_number)
        )

    return a_number
