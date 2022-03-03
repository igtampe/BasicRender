# BasicWindows 
BasicWindows is a very basic window generator utility. Windows are made up of a base background, header, and window elements. Windows can be closed by pressing CTRL+W, or by interacting with a window element that tells it to close. BasicWindows depends on BasicRender and BasicGraphics (because of the Image Window Element), and BasicFonts for some special windows (including the Guru Meditaion Error). BasicWindow's design is based on the ones I made for ITOS.

![Example](https://github.com/igtampe/BasicRender/blob/master/Images/BasicWindows/Overscan.png?raw=true)<br/>
*A Sample of BasicWindows from the BasicRender demo, showing an overscanned window, and a dialogbox*

## Window
Window is a class that can be extended to build actual windows, or provided with WindowElements to execute. Window has a variety of constructors, ranging from just title and dimensions, to basically every property. Feel free to play around with it.

<b>Take Note!</b>
When closing themselves, Windows will draw a box of the WindowClearColor. Its a static variable set for all windows.

|Property|Description|
|-|-|
|WindowClearColor|Color the window will use to "close" itself.|
|Animated|Specifies whether the window is "animated"<br><br> If animated, the window will open/close by animating itself growing in scale 5% at a time from the top left corner.|
|Shadowed|Specifies whether the window is "Shadowed"<br><br> If shadowed, a black box skewed to the bottom right will be drawn as a "shadow"|
|LeftPos| Leftmost coordinate of this window|
|TopPos| Topmost coordinate of this window|
|Length| Length of this window|
|Height| Height of this window|
|Title| Title of this window|
|MainBG| Background Color of the window's body|
|HeaderBG| Background Color of the window's titlebar or header|
|HeaderFG| Foreground Color (Color of the text) of the window's titlebar or header|
|HeadPos| Position of the header/title text. One of three possibilities: Left, Center, or Right alligned.|
|HighlightedElement| Currently highlighted/selected Window Element|
|AllElements| Arraylist that holds all window elements on this window|

|Method|Result|
|-|-|
|Execute()|Executes the window, and returns once the window closes.|
|Redraw()|Redraws the window, without animations. Used when returning to a window, after another has drawn on top of it|
|Close()|Closes the window. Runs the Close animation if the window is animated|

## WindowElement (And Bundled Elements)
Abstract class that is the base for all WindowElements.

|Property|Description|
|-|-|
|NextElement|The next element. The window will move to this element when an interaction returns NEXT_ELEMENT (See OnKeyPress()).|
|PrevElement|The previous element. The window will move to this element when an interaction returns PREV_ELEMENT (See OnKeyPress()).|
|Parent|Parent window of this window element|
|LeftPos| Leftmost coordinate of this element, with reference to the Window's leftmost coordinate.|
|TopPos| Topmost coordinate of this element, with reference to the Window's Topmost coordinate.|
|Highlighted|Wether or not this element is highlighted. When modified, the element will redraw itself.|

|Method|Result|
|-|-|
|OnKeyPress()|Triggered when a user hits a key and the element is highlighted. Returns a KeyPressReturn, which can be one of 4 results: <br><br>NEXT_ELEMENT which tells the parent window to move on to the next element <br>PREV_ELEMENT which tells the parent window to move back to the previous element<br>NOTHING which tells the parent window to do nothing.<br>CLOSE: Which tells the window to close.|
|DrawElement()|Draws this element|

Below is a table with all included elements. WindowElement is a public abstract class, so you can also make more.<br><br>
<b>Take note!</b><br>
When drawing elements, a window doesn't take into account if the element bleeds out of the window! Be careful to measure how wide your windows need to be.

|Element|Description|
|-|-|
|BasicFontLabel|Draws text with a BasicFont. This is sorta beta so be careful.|
|Box|Draws a box of a specified color on the window|
|Button|Interactable button that performs an action when a user hits Enter on it.<br>Button is an abstract element because a user must create a new button class that holds the Action() which occurs when a user hits enter.|
|CloseButton| Preconfigured button that when interacted with, will close the window.|
|FlaggedCloseButton|Extends Close Button and adds a "flag" to indicate if it was activated.|
|Icon|Draws one of four 3x3 Icons: <br><br> ERROR: A red box with an X in the center <br> EXCLAMATION: A yellow box with an exclamation mark in the center.<br> INFORMATION: A blue box with an i in the center<br> QUESTION: A blue box with a question mark in the center.<br><br> This would probably be most useful for dialog boxes. I've found that using a DF file with an icon is far too large.|
|Image|A Window Element that can hold and draw a BasicGraphics Graphic on a window.|
|Label| A label that can draw text in a specific color. Label has been coded to also properly work with linebreaks.|
|LeftRightSelect|Allows a user to select an element from a specified list of strings by hitting left or right.|
|NumericalTextBox|TextBox that only allows numbers to be inputted (with a specified maximum value)|
|ProgressBar|Shows a Progressbar on the window with a given percentage|
|Slider|Shows a slider that can be moved left or right|
|Textbox|Allows a user to type in text|

## TickableWindow
TickableWindow is a window with Tickable elements, that ticks all elements every 250ms. It's basically exactly the same as a normal window except for that.

![Sample tickable window progressbar](https://github.com/igtampe/BasicRender/blob/master/Images/BasicWindows/Tickable.png?raw=true)<br/>
*A Sample Tickable window from the Demo, showing a progressbar*


|Method|Result|
|-|-|
|Tick()|Attempts to tick all elements. Returns false if an element has requested the window to close|

## TickableWindowElements (And Bndled Eements)
These are just elements that can tick if placed in a TickableWindow. If not then it just doesn't tick.

|Method|Result|
|-|-|
|Tick()|Ticks the element. Should return false if the ParentWindow should close.|

Below is a table with all included elements. TickableWindowElement is also a public abstract class, so you can make more.<br><br>
|Element|Description|
|-|-|
|Spinner|Generates a one character spinner with the following frames: |/-\. It spins every tick|
|Timer|Counts down from a provided time, assuming ticks occur every 250ms. Can be created with a ProgressBar to show remaining time on screen. Once time runs out, if set, will execute TimeUpWindow, then ask the ParentWindow to close.|

## DialogBox
DialogBox is a dynamically sizable, configurable window that shows a specified icon, specified button set, and provided text when executed, and returns a DialogBoxResult upon closing.

![ExceptionError](https://media.discordapp.net/attachments/335464035921428480/770415215035940884/unknown.png)
<br>*ShowExceptionError()*

|Static Method|Result|
|-|-|
|ShowDialogBox()|Creates, executes, and returns the result of a DialogBox|
|ShowExceptionError()|Creates and executes a dialogbox based on an exception, showing message and as much of the stacktrace as it can fit. The trace is stripped using StrippedStackTrace()|
|StrippedStackTrace()|Strips a stack trace of paths (IE Namespace Paths and Filename paths) so that its easier to display.|

## GuruMeditationErrorScreen
Draws over the entire screen and shows a STOP error (Using included STOP.df), along with exception details and stack trace (as much as it can fit). Can be flagged to use a StrippedStackTrace(). Also saves error info to Error.log <br><br>

![STOP error in Demo](https://media.discordapp.net/attachments/335464035921428480/770415195063320589/unknown.png)

<b>NOTE:</b><br>
Requires a minimum window size of 80x25. If its not met, it will fall back onto the error DialogBox. It also falls back if there's an error displaying itself.

## Included Windows:
There are a few windows included with BasicWindows. These are the following:

|Window|Description|
|-|-|
|HelloWorldWindow|This window is a tiny demo of what a window is. It says Hello.|
|ErrorWindow|Legacy window (46x8) that shows the first three lines of an error|

