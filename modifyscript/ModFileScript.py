##Python Ver:     3.6
##
##Author:         Deanna Cochener
##
##Purpose:        Creates a script for identifying text files modified in the
##                last 24 hours, and copies them to a folder for review.
##                Built as a drill for the Tech Academy python module.
##
##Tested OS:      This code was written and tested with Windows 7.

import os
from os import path
import shutil
import time

##Function to get the current directory and choose source and
##destination folders for the program
def get_direct():
    parent = os.getcwd()
    print(parent)
    direct = os.listdir(parent)
    print(direct)
    x = 0
    child = {}
    for item in direct:
        if os.path.isdir(item):
            child.update({x:item})
            x += 1
    if x < 2:
        print("There are not enough folders in the directory. Please create a new one.")
        quit()

    print("The folders available are:")
    print(child)
    try:
        fol1 = int(input("Please select the # of the folder you wish to use as your source folder: "))
        fol2 = int(input("Please select the # of the folder you wish to use as your destination folder: "))        
    except:
        print("Folders must be selected by numbers. Please try again.")
        get_direct()
              
    fol_path1 = child[fol1]
    fol_path2 = child[fol2]
    srcd = os.path.join(parent,fol_path1)
    dest = os.path.join(parent,fol_path2)
    return srcd,dest

##Function to clear the contents of the destination folder from the day before
def clear_dest(dest):
    files = os.listdir(dest)
    for f in files:
        fullpath = os.path.join(dest,f)
        os.remove(fullpath) 
    
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

##Function to move modified folders to the new folder for review
def move_dest(recmod,dest):
    count = 0
    for file in recmod:
        shutil.copy(file,dest)
        count += 1
    print("{} files copied into the destination folder".format(count))


##Main function to call others
def mainloop():
    srcd,dest = get_direct()
    clear_dest(dest)
    recmod = check_mod(srcd)
    move_dest(recmod,dest)
    
    

    

if __name__ == "__main__":
    mainloop()
