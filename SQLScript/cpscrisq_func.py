import os
import shutil
from tkinter import *
import tkinter as tk
from tkinter import messagebox
import time
from time import localtime
import sqlite3

# Access to the modules for this program
import cpscrisq_main
import cpscrisq_gui


def center(self,w,h):
    #get user's screen width and height
    screen_width = self.master.winfo_screenwidth()
    screen_height = self.master.winfo_screenheight()
    x= int((screen_width/2)-(w/2))
    y= int((screen_height/2)-(h/2))
    centerGeo = self.master.geometry('{}x{}+{}+{}'.format(w,h,x,y))
    return centerGeo

def ask_quit(self):
    #asks if ok to exit program
    if messagebox.askokcancel("Exit program", "Okay to exit application?"):
        self.master.destroy()
        os._exit(0)

def autoscroll(sbar, first, last):
    #Hide and show scrollbar as needed
    first, last = float(first), float(last)
    if first <= 0 and last >= 1:
        sbar.grid_remove()
    else:
        sbar.grid()
    sbar.set(first, last)

###================= main program functions =================

def pop_root(self,tree):
    self.path = os.getcwd()
    global parent
    parent = tree.insert('', END, text=self.path,
                              values=[self.path,'directory'])
    pop_tree(self, parent, self.path, os.listdir(self.path), tree)
    

def pop_tree(self, parent, fullpath, children, tree):       
    for child in children:
        cpath= os.path.join(fullpath, child).replace('\\','/')
        if os.path.isdir(cpath):
                # directory - only populate when expanded
                cid =tree.insert(parent, END, text=child, open=FALSE,
                                      values=[cpath, 'directory'])
                gpath= cpath.replace('/','\\')
                pop_tree(self,cid,gpath,os.listdir(gpath),tree)
        else:
            tree.insert(parent, END, text=child, values=[cpath, 'file'])

def Select(tree):
    selection = tree.selection()
    item = tree.item(selection)
    path = item['values'][0]
    return path,selection[0]

##Function to check files in a folder and see if they've been
##modified since the last check
def check_mod(srcd,lstchk):
    files = os.listdir(srcd)
    recmod = []
    for f in files:
        fullpath = os.path.join(srcd,f)
        modtime = os.path.getmtime(fullpath)
        if (modtime >= lstchk):
            recmod.append(fullpath)
    return recmod

##Function to clear the contents of the destination folder from the day before
def clear_dest(dest):
    if (os.path.isdir(dest)) & (os.listdir(dest)!= []):
        if messagebox.askokcancel("Purging Folder","Current files in destination folder will be deleted."):
            files = os.listdir(dest)
            for f in files:
                fullpath = os.path.join(dest,f)
                os.remove(fullpath)

##Function to move modified folders to the new folder for review
def move_dest(recmod,dest):
    count = 0
    for file in recmod:
        shutil.copy(file,dest)
        count += 1
    messagebox.showinfo("Transfer Complete","{} files copied into the destination folder".format(count))
    
def copy_files(self, treea, treeb, entry_date):
    srcd,sid = Select(treea)
    dest,did = Select(treeb)
    try:
        if (sid == parent) | (did == parent):
            messagebox.showerror("Selection Error","Parent Folder Cannot be Used\nfor Source or Destination.")
        else:
            clear_dest(dest)
            lstchk = get_lstchk(self)[0][1]
            recmod = check_mod(srcd,lstchk)
            if recmod == []:
                messagebox.showinfo("No Files", "No files have been modified.")
            else:
                move_dest(recmod,dest)
                # Made conscious decision here to only add timestamp when files have been modified since last check
                # Reduces number of database entries if someone pushes the check files repeatedly
                add_timestamp(self)
            refresh(self,treea,treeb,entry_date)
    except:
        messagebox.showerror("Error.","Something went wrong, exiting program.")
        self.master.destroy()
        os._exit(0)
       
def refresh(self,treea,treeb,entry_date):
    for i in treea.get_children():
        treea.delete(i)
    pop_root(self,treea)
    for j in treeb.get_children():
        treeb.delete(j)
    pop_root(self,treeb)
    treea.item(parent,open=True)
    treeb.item(parent,open=True)
    update_datedis(self,entry_date)
    

##================ SQLite functions ========================

def create_db(self):
    conn = sqlite3.connect('lastcheck.db')
    with conn:
        c = conn.cursor()
        c.execute("CREATE TABLE if not exists tbl_lastcheck(\
            ID INTEGER PRIMARY KEY AUTOINCREMENT, \
            date_stamp REAL, \
            date_display TEXT \
            );")
        conn.commit()
    conn.close()
    first_run(self)

def first_run(self):
    conn = sqlite3.connect('lastcheck.db')
    with conn:
        c = conn.cursor()
        c,count = count_records(c)
        if count < 1:
            c.execute("""INSERT INTO tbl_lastcheck (date_stamp, date_display) VALUES (?,?)""", (1497990879, '06/20/2017 01:34 PM'))
            conn.commit()
    conn.close()

def count_records(c):
    count= ''
    c.execute("""SELECT COUNT(*) FROM tbl_lastcheck""")
    count = c.fetchone()[0]
    return c,count

def get_lstchk(self):
    conn = sqlite3.connect('lastcheck.db')
    with conn:
        c = conn.cursor()
        c, count = count_records(c)
        c.execute("""SELECT ID FROM tbl_lastcheck""")
        index = c.fetchone()
        c.execute("""SELECT ID, date_stamp, date_display FROM tbl_lastcheck WHERE ID = {}""".format(count))
        varDate = c.fetchall()
        return varDate

def update_datedis(self, entry_date):
    disdate = get_lstchk(self)[0][2]
    entry_date.delete(0, END)
    entry_date.insert(0,disdate)

def add_timestamp(self):
    date_stamp = time.time()
    date_disp = time.strftime("%m/%d/%Y %I:%M %p", localtime(date_stamp))
    conn = sqlite3.connect('lastcheck.db')
    with conn:
        c = conn.cursor()
        c.execute("""INSERT INTO tbl_lastcheck (date_stamp, date_display) VALUES (?,?)""",(date_stamp, date_disp))
        conn.commit()
    conn.close()

    
if __name__ == '__main__':
    pass
