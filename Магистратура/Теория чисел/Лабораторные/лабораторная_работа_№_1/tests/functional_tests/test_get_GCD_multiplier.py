"""
Test module for the get_GCD_multiplier function from the calculations module.

This module contains unit tests for the get_GCD_multiplier function, which
calculates the multiplier. The tests are designed to validate the correctness
of the function across various input scenarios.

Imported modules:
- os: A module for importing father files.
- pytest: A framework for writing and running tests.
- sys: A module for manipulating Python's runtime environment.

Constants:
- CALCULATIONS_PACKAGE_PATH (str): A relative path to the calculations
  package directory, used to import modules for testing.

Functions:
- test_get_GCD_multiplier(a: int, b: int, result: int) -> None: Run tests for
  get_GCD_multiplier function.

Usage:
    To run the tests in this module, use the following command:
    pytest test_get_GCD_multiplier.py

Parameters:
- a (int): The first integer input for the GCD calculation.
- b (int): The second integer input for the GCD calculation.
- result (int): The expected output from the get_GCD_multiplier
  function for the given inputs a and b.

Test Cases:
- (1, 1) should return 1
- (999, 3) should return 332
- (1071, 462) should return 2
- (1337, 228) should return 5
- (123654789, 7) should return 17664969
"""

import os
import pytest

from sys import path

path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))

from data import CALCULATIONS_PACKAGE_PATH

path.append(CALCULATIONS_PACKAGE_PATH)

from calculations.functions import get_GCD_multiplier


@pytest.mark.parametrize("a, b, result", [
    (1, 1, 1),
    (999, 3, 332),
    (1071, 462, 2),
    (1337, 228, 5),
    (123654789, 7, 17664969)
])


def test_get_GCD_multiplier(a: int, b: int, result: int) -> None:
    """
    Test the get_GCD_multiplier function for correctness.

    This function asserts that the output of get_GCD_multiplier
    for  given inputs a and b matches the expected result.

    Parameters:
    - a (int): The first integer input for the GCD calculation.
    - b (int): The second integer input for the GCD calculation.
    - result (int): The expected output from the get_GCD_multiplier 
      function for the given inputs.

    Raises:
    AssertionError: If the actual output from get_GCD_multiplier
                    does not equal the expected result.
    """

    assert get_GCD_multiplier(a, b) == result