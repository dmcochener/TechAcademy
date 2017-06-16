from tkinter import *
import tkinter as tk
from tkinter import ttk

#Access to other related modules
import movefile_main
import movefile_func

def load_gui(self):

    ## Define and grid top labels for trees
    lbl_treea = tk.Label(self.master, text = 'Source File Directory: ')
    lbl_treeb = tk.Label(self.master, text = 'Destination File Directory: ')

    lbl_treea.grid(row=0, column=0, padx=(30,0), pady=(15,10), sticky='nw')
    lbl_treeb.grid(row=0, column=4, padx=(0,30), pady=(15,10), sticky='ne')

    ## Define and grid treeviews and scroll bars
    #Need to add functionality later
    vsba = ttk.Scrollbar(orient=VERTICAL)
    hsba = ttk.Scrollbar(orient=HORIZONTAL)
    vsbb = ttk.Scrollbar(orient=VERTICAL)
    hsbb = ttk.Scrollbar(orient=HORIZONTAL)
    trvw_treea = ttk.Treeview(self.master, columns=("path","type","size"),
                                   displaycolumns="size",
                                   yscrollcommand=lambda f,l: movefile_func.autoscroll(vsba,f,l),
                                   xscrollcommand=lambda f,l: movefile_func.autoscroll(hsba,f,l))
    trvw_treea.grid(row=1, column=0, columnspan=2, padx=(30,0), pady=(10,10), sticky='nw')
    trvw_treeb = ttk.Treeview(self.master, columns=("path","type","size"),
                                   displaycolumns="size",
                                   yscrollcommand=lambda f,l: movefile_func.autoscroll(vsbb,f,l),
                                   xscrollcommand=lambda f,l: movefile_func.autoscroll(hsbb,f,l))
    trvw_treeb.grid(row=1, column=3, columnspan=2, padx=(0,30), pady=(10,10), sticky='ne')

    vsba['command'] = trvw_treea.yview
    hsba['command'] = trvw_treea.xview
    vsbb['command'] = trvw_treeb.yview
    hsbb['command'] = trvw_treeb.xview

    vsba.grid(row=1, column=2, sticky='w')
    hsba.grid(row=2, column=0, columnspan=2, sticky='n')
    vsbb.grid(row=1, column=5, sticky='w')
    hsbb.grid(row=2, column=3, columnspan=2, sticky='n')

    # setup column headings
    trvw_treea.heading('#0', text='Directory Structure', anchor='w')
    trvw_treea.heading('size', text='File Size', anchor='w')
    trvw_treea.column('size', stretch=0, width=125)
    trvw_treeb.heading('#0', text='Directory Structure', anchor='w')
    trvw_treeb.heading('size', text='File Size', anchor='w')
    trvw_treeb.column('size', stretch=0, width=125)

    #Populate trees on open
    trvw_treea.bind('<<<TreeviewOpen>>>', movefile_func.pop_root(self, trvw_treea))
    trvw_treeb.bind('<<<TreeviewOpen>>>', movefile_func.pop_root(self, trvw_treeb))


    ## Define and grid buttons
    btn_copy = tk.Button(self.master, width=15, height=3, text='Duplicate',
                         command=lambda: movefile_func.copy_file(self,trvw_treea,trvw_treeb))
    btn_copy.grid(row=3, column=0, padx=(30,10), pady=(15,20), sticky='sw')
    btn_move = tk.Button(self.master, width=15, height=3, text='Move',
                         command=lambda: movefile_func.move_file(self,trvw_treea,trvw_treeb))
    btn_move.grid(row=3, column=1, padx=(30,10), pady=(15,20), sticky='sw')
    btn_cancel = tk.Button(self.master, width=15, height=3, text='Cancel',
                           command=lambda: movefile_func.reset(self,trvw_treea,trvw_treeb))
    btn_cancel.grid(row=3, column=3, padx=(10,30), pady=(15,20), sticky='se')
    btn_exit = tk.Button(self.master, width=15, height=3, text='Exit',
                              command=lambda:movefile_func.ask_quit(self))
    btn_exit.grid(row=3, column=4, padx=(10,30), pady=(15,20), sticky='se')
    


if __name__ == '__main__':
    pass
