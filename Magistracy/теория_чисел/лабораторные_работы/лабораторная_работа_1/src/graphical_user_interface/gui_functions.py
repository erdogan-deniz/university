"""
This module provides a graphical user interface for calculating.
The greatest common divisor of two integers. It allows users to enter
numbers, read them from a file, and save the numbers for calculations to a file.
The graphical interface is built using the Tkinter library and supports
background images.

CLASSES:
    Window: A custom Tkinter window that provides methods for setting the
    background, centering the window, creating files, and calculating GCD.

FUNCTIONS:
    read_file_numbers(window: Window, a_field: Entry, b_field: Entry) -> None:
    Reads two integers from a specified text file and updates the input fields.

    draw_window(window_height: int, window_width: int) -> None:
    Initializes and displays the main application window.

EXAMPLE:
    from graphical_user_interface import draw_window

    if __name__ == "__main__":
        draw_window(600, 800)
"""

from .gui_data import BACKGROUND_PATH

from PIL import Image, ImageFile, ImageTk

from calculations.calc_functions import get_gcd

from tkinter import Button, END, Entry, Label, Tk, messagebox
from tkinter.filedialog import askopenfilename, asksaveasfilename


class Window(Tk):
    """
    Custom Tkinter window for GCD calculation application.

    This class extends the Tk class to create a GUI that allows users to input
    two integers and calculate their GCD. It includes methods for setting a
    background image, centering the window on the screen, creating files to
    save input values, and displaying gcd results.

    ATTRIBUTES:
        a_number (int): The first integer input by the user.

        b_number (int): The second integer input by the user.

        width (int): The width of the window.

        height (int): The height of the window.

        background_image (object): The background image displayed in the window.
    """

    def __init__(self, height: int, width: int) -> None:
        """
        Sets initial values for class fields.

        ARGS:
            background_path (str): The file path to the background image.
        """

        super().__init__()

        self.width: int = width
        self.height: int = height
        self.a_number: int = None
        self.b_number: int = None
        self.background_image: object = None

    def set_background(self, background_path: str) -> None:
        """
        Sets the background image of the window.

        ARGS:
            background_path (str): The file path to the background image.
        """

        background: ImageFile = Image.open(background_path)
        self.background_image = ImageTk.PhotoImage(background)

        area: Label = Label(self, image=self.background_image)
        area.place(x=0, y=0, relwidth=1, relheight=1)

    def centering_windows(self) -> None:
        """
        Centers the window on the screen based on its dimensions.
        """

        max_window_width: int = self.winfo_screenwidth()
        max_window_height: int = self.winfo_screenheight()

        x_offset: int = (max_window_width // 2) - (self.width // 2)
        y_offset: int = (max_window_height // 2) - (self.height // 2)

        self.geometry(f"{self.width}x{self.height}+{x_offset}+{y_offset}")

    def create_file(self, a_field: Entry, b_field: Entry) -> None:
        """
        Creates a text file with the values from input fields.

        Prompts the user to specify a file path and saves the values of
        integers a_number and a_number into that file.

        ARGS:
            a_field (Entry): The entry widget for integer a_number.

            b_field (Entry): The entry widget for integer b_number.
        """

        file_path: str = asksaveasfilename(
            defaultextension=".txt",
            filetypes=[("Text files", "*.txt")],
        )

        if file_path:
            if not file_path.endswith(".txt"):
                messagebox.showerror("ERROR!", "File format is not '.txt'.")

        else:
            messagebox.showerror("ERROR!", "Incorrect file creating.")

        try:
            with open(file_path, "w") as file:
                try:
                    file.write(f"{a_field.get()} {b_field.get()}")

                    self.a_number, self.b_number = a_field.get(), b_field.get()

                    messagebox.showinfo("OK!", "The file has been created.")
                except Exception as error:
                    messagebox.showerror("ERROR!", f"{error}")

        except Exception as error:
            messagebox.showerror("ERROR!", f"{error}")

    def show_gcd(self, a_field: Entry, b_field: Entry) -> None:
        """
        Displays the GCD of two integers entered by the user.

        Retrieves integer values from input fields and calculates their GCD,
        displaying it in a message box.

        ARGS:
            a_field (Entry): The entry widget for integer a_number.

            b_field (Entry): The entry widget for integer b_number.
        """

        a_number: int = None
        b_number: int = None

        try:
            a_number = int(a_field.get())
            b_number = int(b_field.get())
        except Exception as error:
            messagebox.showerror("ERROR!", f"{error}")

        if (a_number is not None) and (b_number is not None):
            self.a_number = a_number
            self.b_number = b_number

            messagebox.showinfo(
                "GCD VALUE.",
                f"The GCD is {get_gcd(self.a_number, self.b_number)}.",
            )
        else:
            messagebox.showerror(
                "ERROR!",
                "Incorrect numbers, please input them.",
            )


def read_file_numbers(window: Window, a_field: Entry, b_field: Entry) -> None:
    """
    Reads two integers from a specified text file and updates input fields.

    Prompts the user to select a text file and extracts two integers from it,
    updating the corresponding entry widgets in the GUI.

    ARGS:
        window (Window): The main application window instance.

        a_field (Entry): The entry widget for integer a_number.

        b_field (Entry): The entry widget for integer b_number.
    """

    file_path: str = askopenfilename()

    if file_path:
        if not file_path.endswith(".txt"):
            messagebox.showerror(
                "ERROR!",
                "Please choose a correct file format (.txt).",
            )

    else:
        messagebox.showerror("ERROR!", "Incorrect file choose.")

    try:
        with open(file_path, "r", encoding="utf-8") as file:
            try:
                content: str = file.read()
                window.a_number, window.b_number = map(int, content.split())

                messagebox.showinfo("OK!", "The numbers have been extracted.")

                a_field.delete(0, END)
                a_field.insert(0, f"{window.a_number}")

                b_field.delete(0, END)
                b_field.insert(0, f"{window.b_number}")
            except Exception as error:
                messagebox.showerror("ERROR!", f"{error}")

    except Exception as error:
        messagebox.showerror("ERROR!", f"{error}")


def draw_window(window_heigth: int, window_width: int) -> None:
    """
    Initializes and displays the main application window.

    Sets up labels and buttons for user interaction and starts the main loop
    of the Tkinter application.

    ARGS:
        window_height (int): The height of the main application window.

        window_width (int): The width of the main application window.
    """

    main_window: Window = Window(window_heigth, window_width)

    main_window.title("LABORATORY WORK № 1")
    main_window.centering_windows()
    main_window.set_background(BACKGROUND_PATH)
    main_window.resizable(False, False)

    label_a: Label = Label(main_window, text="INPUT A:", width=10)
    label_a.place(
        x=(main_window.width // 2) - 90,
        y=(main_window.width // 2) - 210,
    )

    a_field: Entry = Entry(main_window, width=12)
    a_field.place(
        x=(main_window.width // 2) - 90,
        y=(main_window.width // 2) - 185,
    )

    label_b: Label = Label(main_window, text="INPUT B:", width=10)
    label_b.place(
        x=(main_window.width // 2) + 35,
        y=(main_window.width // 2) - 210,
    )

    b_field: Entry = Entry(main_window, width=12)
    b_field.place(
        x=(main_window.width // 2) + 35,
        y=(main_window.width // 2) - 185,
    )

    choose_file_button: Button = Button(
        main_window,
        text="CHOOSE FILE",
        command=lambda: read_file_numbers(main_window, a_field, b_field),
    )
    choose_file_button.place(
        x=(main_window.width // 2) - 30,
        y=(main_window.width // 2) - 275,
    )

    create_file_button: Button = Button(
        main_window,
        text="CREATE FILE",
        command=lambda: main_window.create_file(a_field, b_field),
        width=10,
    )
    create_file_button.place(
        x=(main_window.width // 2) - 90,
        y=(main_window.width // 2) - 140,
    )

    get_result_button: Button = Button(
        main_window,
        text="GET GCD",
        command=lambda: main_window.show_gcd(a_field, b_field),
        width=10,
    )
    get_result_button.place(
        x=(main_window.width // 2) + 35,
        y=(main_window.width // 2) - 140,
    )

    main_window.mainloop()
