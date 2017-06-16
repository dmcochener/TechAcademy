import os
import shutil
from tkinter import *
import tkinter as tk
from tkinter import messagebox

# Access to the modules for this program
import movefile_main
import movefile_gui


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
            size = format_size(self,os.stat(cpath).st_size)
            tree.insert(parent, END, text=child, values=[cpath, 'file', size])

def format_size(self, size):
    KB = 1024.0
    MB = KB * KB
    GB = MB * KB
    if size >= GB:
        return '{:,.1f} GB'.format(size/GB)
    if size >= MB:
        return '{:,.1f} MB'.format(size/MB)
    if size >= KB:
        return '{:,.1f} KB'.format(size/KB)
    return '{} bytes'.format(size)

def Select(tree):
    selection = tree.selection()
    print (selection)
    path = []
    for i in selection:
        item = tree.item(i)
        print (item)
        value = item['values'][0]
        print(value)
        path.append(value)
    return path
    
def copy_file(self, treea, treeb):
    srcf = Select(treea)
    desf = Select(treeb)[0]
    for i in srcf:
        shutil.copy(i,desf)
        print("The file {} \nwas copied to {}.".format(i,desf))
    refresh(self,treea,treeb)
    
def move_file(self, treea, treeb):
    srcf = Select(treea)
    desf = Select(treeb)[0]
    try:
        for i in srcf:
            shutil.move(i,desf)
            print("The file {} \nwas moved to {}.".format(i,desf))
    except:
        messagebox.showerror("Cannot overwrite!",
                             "There was an error in trying to move one or more files.\nCannot replace existing files.")
        pass
    refresh(self,treea,treeb)
    

def reset(self, treea, treeb):
    for i in treea.get_children():
        treea.delete(i)
    pop_root(self,treea)
    for j in treeb.get_children():
        treeb.delete(j)
    pop_root(self,treeb)
    
def refresh(self,treea,treeb):
    reset(self,treea,treeb)
    treea.item(parent,open=True)
    treeb.item(parent,open=True)
        
    
    
if __name__ == '__main__':
    pass
