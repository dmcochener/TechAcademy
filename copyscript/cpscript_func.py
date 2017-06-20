import os
import shutil
from tkinter import *
import tkinter as tk
from tkinter import messagebox
import time

# Access to the modules for this program
import cpscript_main
import cpscript_gui


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
    print(path)
    return path

##Function to check files in a folder and see if they've been
##modified in the last 24 hours
def check_mod(srcd):
    files = os.listdir(srcd)
    currtime = time.time()
    lastday = 24*60*60
    recmod = []
    for f in files:
        fullpath = os.path.join(srcd,f)
        modtime = os.path.getmtime(fullpath)
        if (modtime >= (currtime-lastday)):
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
    
def copy_files(self, treea, treeb):
    srcd = Select(treea)
    dest = Select(treeb)
    try:
        clear_dest(dest)
        recmod = check_mod(srcd)
        if recmod == []:
            messagebox.showinfo("No Files", "No files have been modified.")
        else:
            move_dest(recmod,dest)
            refresh(self,treea,treeb)
    except:
        messagebox.showerror("Error.","Something went wrong, exiting program.")
        self.master.destroy()
        os._exit(0)
       
def refresh(self,treea,treeb):
    for i in treea.get_children():
        treea.delete(i)
    pop_root(self,treea)
    for j in treeb.get_children():
        treeb.delete(j)
    pop_root(self,treeb)
    treea.item(parent,open=True)
    treeb.item(parent,open=True)
        
    
    
if __name__ == '__main__':
    pass
