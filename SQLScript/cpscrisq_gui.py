from tkinter import *
import tkinter as tk
from tkinter import ttk

#Access to other related files
import cpscrisq_main
import cpscrisq_func

def load_gui(self):

    ## Define and grid top labels for trees
    lbl_treea = tk.Label(self.master, text = 'Source File Directory: ')
    lbl_treeb = tk.Label(self.master, text = 'Destination File Directory: ')

    lbl_treea.grid(row=0, column=0, padx=(30,0), pady=(15,10), sticky='nw')
    lbl_treeb.grid(row=0, column=3, padx=(0,30), pady=(15,10), sticky='ne')

    ## Define and grid treeviews and scroll bars
    #Need to add functionality later
    vsba = ttk.Scrollbar(orient=VERTICAL)
    vsbb = ttk.Scrollbar(orient=VERTICAL)
    trvw_treea = ttk.Treeview(self.master, columns=("path","type"),displaycolumns="",
                                   yscrollcommand=lambda f,l: cpscrisq_func.autoscroll(vsba,f,l))
    trvw_treea.grid(row=1, column=0, padx=(30,0), pady=(10,10), sticky='nw')
    trvw_treeb = ttk.Treeview(self.master, columns=("path","type"),
                                   displaycolumns="",
                                   yscrollcommand=lambda f,l: cpscrisq_func.autoscroll(vsbb,f,l))
    trvw_treeb.grid(row=1, column=3, padx=(0,30), pady=(10,10), sticky='ne')

    vsba['command'] = trvw_treea.yview
    vsbb['command'] = trvw_treeb.yview

    vsba.grid(row=1, column=1, sticky='w')
    vsbb.grid(row=1, column=2, sticky='e')

    # setup column heading and widths
    trvw_treea.heading('#0', text='Directory Structure', anchor='w')
    trvw_treea.column('#0', width = 300)
    trvw_treeb.heading('#0', text='Directory Structure', anchor='w')
    trvw_treeb.column('#0', width = 300)

    #Populate trees on open
    trvw_treea.bind('<<<TreeviewOpen>>>', cpscrisq_func.pop_root(self, trvw_treea))
    trvw_treeb.bind('<<<TreeviewOpen>>>', cpscrisq_func.pop_root(self, trvw_treeb))

    ## Define and grid label and entry box for last file check display
    lbl_date = tk.Label(self.master, text='Files Last Checked: ')
    entry_date = tk.Entry(self.master)
    lbl_date.grid(row=2, column=0, columnspan=2, padx=(20,0), pady=(10,10), sticky='ne')
    entry_date.grid(row=2, column=2, columnspan=2, padx=(5,20), pady=(10,10), sticky='nw')
    entry_date.insert(0,"Cannot access database") 
    
    ## Define and grid button
    btn_transfer = tk.Button(self.master, width=15, height=3, text='Check Files \nand Transfer',
                         command=lambda: cpscrisq_func.copy_files(self,trvw_treea,trvw_treeb,entry_date))
    btn_transfer.grid(row=3, column=0, columnspan=4, padx=(30,10), pady=(15,20), sticky='n')
       
    ## Create or start up database
    cpscrisq_func.create_db(self)
    cpscrisq_func.update_datedis(self,entry_date)


if __name__ == '__main__':
    pass
