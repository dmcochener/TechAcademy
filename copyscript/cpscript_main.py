##Python Ver:     3.6
##
##Author:         Deanna Cochener
##
##Purpose:        Creates a GUI for checking recently modified files from
##                a selected folder and copying them to a selected folder.
##                Built as a drill for the Tech Academy.
##
##Tested OS:      This code was written and tested with Windows 7.

from tkinter import *
import tkinter as tk

# Import other modules for access
import cpscript_gui
import cpscript_func

# Create the basic window for the gui
class ParentWindow(Frame):
    def __init__(self,master, *args, **kwargs):
        Frame.__init__(self, master, *args, **kwargs)

        #define master frame configurations
        self.master = master
        self.master.minsize(680,400)
        self.master.maxsize(680,400)
        #Center the window on the screen
        cpscript_func.center(self, 680, 400)
        self.master.title("File Copy and Move")
        self.master.configure(bg='#999999')
        #catch if user clicks on upper 'X' to close
        self.master.protocol("WM_DELETE_WINDOW", lambda: cpscript_func.ask_quit(self))
        arg = self.master
        
        #load gui widget from module
        cpscript_gui.load_gui(self)

if __name__ == '__main__':
    root = tk.Tk()
    App = ParentWindow(root)
    root.mainloop()
