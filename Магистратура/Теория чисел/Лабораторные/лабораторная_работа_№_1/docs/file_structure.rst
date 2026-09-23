**Project File Structure**
===========================

**General Description**
-------------------------

This laboratory work is an implementation of the *Euclid algorithm* with a graphical interface.

You can:

- **docs** - an automatic project documentation

  - **build** - a folder of collected documentation

  - **source** - the folder is used to store the source documentation files needed to generate the documentation
  
  - **Makefile** - a file that allows you to manage the documentation assembly process

- **resources** - the folder with the project's side material

  - **files** - files for the operation of the program's functionality

  - **gifs** - gifs for the readme description

  - **photos** - photos for the project

- **src** - the folder with the development code

  - **calculations** - a package with the necessary functionality for calculations

  - **graphical_user_interface** - the package of the graphical component of the program

  - **main.py** - the starting point of the program

- **tests** - the project tests

- **.gitignore** - a text file that is used to specify files and directories that should be ignored during commits

- **poetry.lock** - providing fixed versions of packages that are used in the project

- **pyproject.toml** - a configuration file for project that is used to describe the project metadata

- **README.md** - a description of the project

- **setup.cfg** - the configuration file for **flake8**
