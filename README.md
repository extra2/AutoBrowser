# AutoBrowser
 
##### This project is in early state. It can be unstable.

**AutoBrowser** lets you automatize your browser using script language. The program is based on Selenium WebDriver.

Scripts are deviden into two sections: **init** and **program**.

# Docs
## init
At the beggining of your program you can use **init** command to enter initial browser settings. Avilable initial commands:

**debugconsole [on|off]** turns on/off debug console (default on)

**timeout [time_in_seconds]** sets timeout for pages to load and waiting time for elements if not found immediately (default 60)
## program
After **init** you can write your program script between **program** and **endprogram** (program section). Avilable commands are:

**goto [url]** - go to chosen url

**sendtext [search_by] [element] [text_to_send]** - sends text to selected element

**clickon [search_by] [element]** - clicks on selected element

**wait [time]** - wait for _time_ miliseconds

**waitfor [search_by] [element]** - wait for element untill it's visible

**loop [times]** - start a for loop for _times_ times. Should wnd with **endloop**

**ifvisible [search_by] [element]** - if item is visible. Ends with **endif**

**break** - break from current section. Doesn't dispose driver

**exit** - exit and dispose driver. Should be use at the end of the program

**_search_by_** options:

_i_ = id

_c_ = class name

_x_ = XPath

_n_ = name

_l_ = link text

_t_ = tag name
