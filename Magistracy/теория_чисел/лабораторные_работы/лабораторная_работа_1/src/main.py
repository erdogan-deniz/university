"""
Main entry point for the GCD calculation application.

This script initializes and launches the graphical user interface (GUI) 
for calculating the Greatest Common Divisor (GCD) of two integers. 
It imports necessary functions from the `calculations` and 
`graphical_user_interface` modules.

Usage:
Run this script to display the main application window where users can 
input two integers and calculate their GCD. The window dimensions can be 
specified as arguments to the `draw_window` function.

Example:
    python main.py

The application window will open with a width of 600 pixels and a height 
of 800 pixels.
"""

from calculations import *
from graphical_user_interface import *

if __name__ == "__main__":
    draw_window(600, 800)