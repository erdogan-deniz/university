"""
Main entry point for the GCD calculation application.

This script initializes and launches the graphical user interface
for calculating the greatest common divisor of two integers.
It imports necessary functions from the `calculations` and
`graphical_user_interface` modules.

DESCRIPTION:
    Run this script to display the main application window where
    users can input two integers and calculate their GCD. The window
    dimensions can be specified as arguments to the `draw_window`
    function.

USAGE:
    poetry run python src/main.py
"""

from graphical_user_interface import draw_window

if __name__ == "__main__":
    draw_window(600, 800)
