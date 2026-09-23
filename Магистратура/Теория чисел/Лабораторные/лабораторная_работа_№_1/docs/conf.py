import os
import sys

release = "v1.0"
author = "Deniz Erdogan"
project = "Laboratory Work № 1"
copyright = "2024, Deniz Erdogan"

extensions = [
    "sphinx.ext.autodoc",
    "sphinx.ext.viewcode",
    "sphinx.ext.napoleon",
]

language = "en"
html_theme = "furo"
html_logo = "../resources/photos/logo.jpg"


sys.path.insert(0, os.path.abspath("../tests"))
sys.path.insert(0, os.path.abspath("../tests/calculations_tests"))
sys.path.insert(0, os.path.abspath("../src"))
sys.path.insert(0, os.path.abspath("../src/calculations"))
sys.path.insert(0, os.path.abspath("../src/graphical_user_interface"))
