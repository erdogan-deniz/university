"""
Test module for the get_GCD function from the calculations module.

This module contains unit tests for the get_GCD function, which calculates 
the greatest common divisor (GCD) of two integers. The tests are designed 
to validate the correctness of the function across various input scenarios.

Imported modules:
- os: A module that provides a way of using operating system-dependent 
  functionality like reading or writing to the file system.
- pytest: A framework for writing and running tests.
- sys: A module that provides access to some variables used or maintained 
  by the interpreter and to functions that interact with the interpreter.

Constants:
- CALCULATIONS_PACKAGE_PATH (str): A relative path to the calculations
  package directory, used to import modules for testing.

Functions:
- test_get_GCD(a: int, b: int, result: int) -> None: Run tests for
  get_GCD function.

Usage:
To run the tests in this module, use the following command:
    pytest path/to/your/test_file.py
where test_file.py is the name of this file.

Parameters:
- a (int): The first integer input for GCD calculation.
- b (int): The second integer input for GCD calculation.
- result (int): The expected output from the get_GCD function
  for the given inputs a and b.

Test Cases:
- (1, 1) should return 1
- (999, 3) should return 3
- (1337, 228) should return 1
- (1071, 462) should return 21
- (123654789, 7) should return 1
"""

import os
import pytest

from sys import path

path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))

from data import CALCULATIONS_PACKAGE_PATH

path.append(CALCULATIONS_PACKAGE_PATH)

from calculations.functions import get_GCD


@pytest.mark.parametrize("a, b, result", [
    (1, 1, 1),
    (999, 3, 3),
    (1337, 228, 1),
    (1071, 462, 21),
    (123654789, 7, 1)
])


def test_get_GCD(a: int, b: int, result: int) -> None:
    """
    Test the get_GCD function for correctness.

    This function asserts that the output of get_GCD
    for  given inputs a and b matches the expected result.

    Parameters:
    - a (int): The first integer input for the GCD calculation.
    - b (int): The second integer input for the GCD calculation.
    - result (int): The expected output from the get_GCD
      function for the given inputs.

    Raises:
    AssertionError: If the actual output from get_GCD
                    does not equal the expected result.
    """

    assert get_GCD(a, b) == result