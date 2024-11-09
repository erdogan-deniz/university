"""
Test module for the get_gcd function from the calculations module.

This module contains unit tests for the get_gcd function, which calculates
the greatest common divisor of two integers. The tests are designed
to validate the correctness of the function across various input scenarios.

FUNCTIONS:
    test_get_gcd(a_number: int, b_number: int, result: int) -> None: Run
    tests for get_gcd function.

USAGE:
    pytest test_get_gcd.py

TEST CASES:
- (1, 1) should return 1
- (999, 3) should return 3
- (1337, 228) should return 1
- (1071, 462) should return 21
- (123654789, 7) should return 1
"""

import os

import pytest

from sys import path

path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), "..")))

from test_data import CALCULATIONS_PACKAGE_PATH

path.append(CALCULATIONS_PACKAGE_PATH)

from calculations.calc_functions import get_gcd


@pytest.mark.parametrize(
    "a_number, b_number, result",
    [
        (1, 1, 1),
        (999, 3, 3),
        (1337, 228, 1),
        (1071, 462, 21),
        (123654789, 7, 1),
    ],
)
def test_get_gcd(a_number: int, b_number: int, result: int) -> None:
    """
    Test the get_gcd function for correctness.

    This function asserts that the output of get_gcd for  given
    inputs a_number and b_number matches the expected result.

    PARAMETERS:
        a_number (int): The first integer input for the GCD calculation.

        b_number (int): The second integer input for the GCD calculation.

        result (int): The expected output from the get_gcd
                      function for the given inputs.

    RAISES:
        AssertionError: If the actual output from get_gcd
                        does not equal the expected result.
    """

    assert get_gcd(a_number, b_number) == result
