"""
This module provides functions for calculating the Greatest Common Divisor (GCD)
of two integers using a modified version of the Euclidean algorithm.

Functions:
- get_GCD_multiplier(a: int, b: int) -> int: Calculates the multiplier needed
  in the Euclidean algorithm.
- get_GCD(a: int, b: int) -> int: Computes the GCD of two integers.

Usage example:

    from calculations import get_GCD

    print(get_GCD(30, 18))
    
    # Output: 6
"""

def get_GCD_multiplier(a: int, b: int) -> int:
    """
    Calculates the multiplier in the Euclidean algorithm.

    The function determines the multiplier needed to express the
    difference between the maximum and minimum of the two integers
    in terms of the minimum integer.

    Args:
        a (int): The first integer.
        b (int): The second integer.

    Returns:
        int: The multiplier for the smaller number of a pair of numbers of the Euclid
        algorithm, when multiplied by which the difference between the larger number
        of a pair of numbers of the Euclid algorithm and the product will be less than
        the smaller number of a pair of numbers of the Euclid algorithm.

    Example:
        get_GCD_multiplier(30, 18)

        # Output: 1
    """

    GCD_multiplier: int = 1

    while (max(a, b) -  min(a, b) * GCD_multiplier) > min(a, b):
        GCD_multiplier += 1
    
    return GCD_multiplier


def get_GCD(a: int, b: int) -> int:
    """
    Calculate the Greatest Common Divisor (GCD) of two integers.

    This function uses a modified version of the Euclidean algorithm
    to compute the GCD of two integers by repeatedly reducing the
    larger integer until it equals zero.

    Args:
        a (int): The first integer.
        b (int): The second integer.

    Returns:
        int: The greatest common divisor of the two integers.

    Example:
        print(get_GCD(30, 18))

        # Output: 6
    """

    while (max(a, b) - min(a, b) * get_GCD_multiplier(a, b)) != 0:
        GCD_multiplier: int = get_GCD_multiplier(a, b)
        a, b = min(a, b), (max(a, b) - GCD_multiplier * min(a, b))

    return a