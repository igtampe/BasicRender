![The Toolkit Logo](https://cdn.discordapp.com/attachments/335464035921428480/734308914786598912/BasicRender.png "BasicRender Toolkit Logo")

The BasicRender Toolkit is a set of class libraries that make it easy to display graphics on a console screen. Three libraries are included, and can all be downloaded over at the release page.

This project also includes a small demo program. After a neat little BasicWindow, it tells the very very tiny 8 line story of a man who insulted an AI for the last time. It includes exactly one landscape I drew in [henja](https://github.com/igtampe/Henja3) that came out ~~horrible~~ great.
![And so the man died. The end.](https://cdn.discordapp.com/attachments/335464035921428480/734309006390067330/68747470733a2f2f6d656469612e646973636f72646170702e6e65742f6174746163686d656e74732f373333383835333235.png "And so the man died. The end.")

Below is a nice bit of documentation on each class. Each method also has XML documentation so you don't have to have this markdown document open.

## BasicRender
The titular library that includes two static classes with a few useful functions:

### Draw
Draw includes tools for drawing on screen.
<br><br><b>Take note!</b><br> 
When asking for positions, these methods use LeftPos and TopPos, or the leftmost coordinate, and topmost coordinate of the object.

|Method|Result|
|-|-|
|Sprite()|Renders a character or bit of text with the specified color, and either at the current position, or a specified position|
|Block()|Renders a block on screen of the specified color either at the current position, or a specified position|
|Box()|Renders a box on screen of specified color, lenght, and width, at specified posotion|
|Row()|Renders a row of the speicifed color of specified length, either at current or specified position|
|ClearLine()|Clears a line with the console background color|
|CenterText()|Centers text on the screen at current or speciifed row, with current or specified color|

### RenderUtils
Utilities that help in rendering stuff on screen. Though, they're also useful in general.
|Method|Result|
|-|-|
|Sleep()|Holds execution of a program for the specified miliseconds|
|Pause()|Holds execution of a program until the user hits a key|
|Echo()|A shortcut to Console.Write() or Console.WriteLine() depending on if you specify to linebreak|
|SetPos()|Sets the position of the console cursor on screen|
|Color()| Sets the color of the cursor writer. <br><br><b>Take note!</b><br> The one parameter version of this modifies the foreground (Text) Color, but the second one has Background first! <br>This is to match the Windows command line's Color command|
|Type()| "Types" text on screen one character at a time. Time between each character is either specified, or 5ms|

## BasicGraphics
BasicGraphics includes tools for drawing DrawFile (DF) and Hi-Color DrawFiles (HC) files (Both from disk, as a resource, or as its own type of internal class). These files can be edited by the [Henja3 Editor](https://github.com/igtampe/Henja3). BasicGraphics depends on BasicRender. It has several classes, mentioned below.

### Graphic
Abstract class that basically everything inherits either directly or indirectly.
|Property|Description|
|-|-|
|Contents|Data used to draw this graphic|
|Name|Name of this graphic|
|Width|Width of this graphic accessed via GetWidth()|
|Height|Height of this graphic accessed via GetHeight()|

|Method|Result|
|-|-|
|Draw()|Draws the graphic.<br><br><b>Take note!</b><br> the parameters LeftPos and TopPos refer to the leftmost, and topmost coordinate of the graphic!|

### GraphicUtils
A Static class that holds some utilities that are used by the graphic drawers, but that could also be useful for other reasons.
|Method|Result|
|-|-|
|ResourceToStringarray()|Gets a resource as an array of bytes, and turns it into an array of strings, where each index is a line of the resource's text. <br> Essentially, it's like File.ReadAllLines(), but for resources instead of files.|
|ColorCharToConsoleCholor()| Converts a ColorChar (a hexadecimal number) to a ConsoleColor. </br></br> ColorChars are based on the way the windows command line asks for colors. Below this is a table of ColorChars|

|Number|Color|
|-|-|
|0|Black|
|1|Blue|
|2|Green|
|3|Aqua|
|4|Red|
|5|Purple|
|6|Yellow|
|7|White|
|8|Gray|
|9|Light Blue|
|A|Light Green|
|B|Light Aqua|
|C|Light Red|
|D|Light Purple|
|E|Light Yellow|
|F|Bright White|


### BasicGraphic (And FromFile, FromResource)
Abstract class that holds the way to process DF file data. Its extended by BasicGraphicFromFile and BasicGraphicFromResource, which read their contents from a file and from a resource respectively.

|Method|Result|
|-|-|
|DrawColorString()|This method is publicly accessible in case a user wants to access it directly to draw a single line of DF data.<br><br> A ColorString is a string made up of ColorChars. Take a look at GraphicUtils's ColorCharToConsoleColor() method for a more in depth explination.|

### HiColorGraphic (And FromFile, FromResource)
Abstract class that holds the way to process HC file data. Its extended by HiColorGraphicFromFile and HiColorGraphicFromResource, which read their contents from a file and from a resource respectively.

|Method|Result|
|-|-|
|HiColorDraw()|This method is also publicly accessible in case a user wants to access it directly to draw a single line of HC data. <br><br>A string of HiColor Data is comprised of multiple 3 character long strings, linked with hyphens. The first two characters are ColorChars (one for background and one for foreground), and the 3rd is a digit from 0 to 2, which indicates the gradient between the colorchars, with ░ as 0, ▒ as 1, ▓ as 2. <br><br> The following string holds a HiColor Rainbow `441-460-461-C61-CE0-CE1-CE2-EE2-E10-EA1-AE2-AE1-AA2-AB1-AB2-BB2-3B2-B31-3B2-3B1-3B0-331-932-392-992-192-912-190-110-512-152-551-D52-D51-D50-DD0-4D2-4D1-4D0-440`. This rainbow doesn't use dark yellow or dark green, along with a few shades of gray so there are a few colors that aren't visible here. According to this, there should be just about 55-60 _usable_ colors.|

### Cloud
Cloud is a DF graphic class which holds its own data. Its contents are the cloud graphic from AirportBoard's weather information.<br>
Use it to draw a cute little cloud, and nothing else.

## BasicWindows 
BasicWindows is a very basic window generator utility. Windows are made up of a base background, header, and window elements. Windows can be closed by pressing CTRL+W, or by interacting with a window element that tells it to close. BasicWindows depends on BasicRender and BasicGraphics (because of the Image Window Element)

A BasicWindow Window's design is based on the ones I made for ITOS.

### Window
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

### WindowElement (And Bundled Elements)
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

### TickableWindow
TickableWindow is a window with Tickable elements, that ticks all elements every 250ms. It's basically exactly the same as a normal window except for that.

|Method|Result|
|-|-|
|Tick()|Attempts to tick all elements. Returns false if an element has requested the window to close|

### TickableWindowElements (And Bndled Eements)
These are just elements that can tick if placed in a TickableWindow. If not then it just doesn't tick.

|Method|Result|
|-|-|
|Tick()|Ticks the element. Should return false if the ParentWindow should close.|

Below is a table with all included elements. TickableWindowElement is also a public abstract class, so you can make more.<br><br>
|Element|Description|
|-|-|
|Spinner|Generates a one character spinner with the following frames: |/-\. It spins every tick|
|Timer|Counts down from a provided time, assuming ticks occur every 250ms. Can be created with a ProgressBar to show remaining time on screen. Once time runs out, if set, will execute TimeUpWindow, then ask the ParentWindow to close.|

### DialogBox
DialogBox is a dynamically sizable, configurable window that shows a specified icon, specified button set, and provided text when executed, and returns a DialogBoxResult upon closing.

|Static Method|Result|
|-|-|
|ShowDialogBox()|Creates, executes, and returns the result of a DialogBox|
|ShowExceptionError()|Creates and executes a dialogbox based on an exception, showing message and as much of the stacktrace as it can fit. The trace is stripped using StrippedStackTrace()|
|StrippedStackTrace()|Strips a stack trace of paths (IE Namespace Paths and Filename paths) so that its easier to display.|

![ExceptionError](https://media.discordapp.net/attachments/335464035921428480/770415215035940884/unknown.png)
<br>ShowExceptionError()

### GuruMeditationErrorScreen
Draws over the entire screen and shows a STOP error (Using included STOP.df), along with exception details and stack trace (as much as it can fit). Can be flagged to use a StrippedStackTrace(). Also saves error info to Error.log <br><br>

![STOP error in Demo](https://media.discordapp.net/attachments/335464035921428480/770415195063320589/unknown.png)

<b>NOTE:</b><br>
Requires a minimum window size of 80x25. If its not met, it will fall back onto the error DialogBox. It also falls back if there's an error displaying itself.

### Included Windows:
There are a few windows included with BasicWindows. These are the following:

|Window|Description|
|-|-|
|HelloWorldWindow|This window is a tiny demo of what a window is. It says Hello.|
|ErrorWindow|Legacy window (46x8) that shows the first three lines of an error|

## BasicFonts
BasicFonts draws text using slightly altered DF data stored on a [Dictionary On Disk](https://github.com/igtampe/DictionaryOnDisk) file with a Bfnt Extension. It comes with a singular class which handles everything. The following properties and methods are there:

|Property|Description|
|-|-|
|Name|Name of the font|
|Author|Author of the font|
|Width|Width of this font's characters|
|Height|Height of this font's characters|

|Method|Result|
|-|-|
|DrawText()|This method (and overloads) draws text onto the console screen, with default or specified leftpos, toppos, color, and spacing. Fonts can be drawn with any given foreground color.|

|Static Method|Result|
|-|-|
|LoadFromFile()|Loads a font from a BFnt file|
|LoadFromResource()|Loads a font from a BFnt File stored as a resource|

### Clock
BasicFont also includes a clock, with two clock fonts (Regular, and wide).
![WideClock](https://cdn.discordapp.com/attachments/335464035921428480/771588571294597120/unknown.png)

Clocks draw themselves asyncronously, and can be paused, resumed, or stopped once they are RunAsync(). When running asynchronously, only characters that need to be changed will be redrawn, from right to left.

The following properties are included with every clock:
|Property|Description|
|-|-|
|ClockFont|Readonly font that is used to display the clock. It's set when constructed. The font is required to have numbers 0-9, a colon (':'), and the letters 'a', 'p', and 'm'|
|HourAdjust|Property to move the hour of this clock a specified number ahead or behind. Used for timezones (Though the clock by default uses the timezone on the computer)|
|MilitaryTime|Property to use Military Time (24 hour time)|
|ShowSeconds|Property to display seconds|
|ShowDate|Property to show date on a line below the second hour number|
|BG|Color on the background (Clock must be fully redrawn to take effect)|
|FG|Color on the foreground (Clock must be fully redrawn to take effect)|
|Width|Calculated width of the rendered (or to be rendered) clock|
|Height|Calculated height of the rendered (or to be rendered) clock|

The following methods are included with every clock:
|Method|Description|
|-|-|
|PrepareRenderedDate()|Prepare the text for a rendered date (Publicly accessible just in case)|
|PrepareRenderedTime()|Prepare the text for a rendered time with all settings (publicly accessible just in case)|
|Init()|Initializes the values for Date and Time to be rendered. Isn't entirely necessary, but makes Width and Height properties valid without rendering the clock|
|Render()|Fully renders the clock|
|Rerender()|Renders only things that have changed. Rerenders the clock if time to be rendered is of a different length.|
|Stop()|Stops the clock if its running asynchronously|
|Pause()|Pauses the clock if its running asynchronously. I know it uses an obsolete method but its not because of concurrency or anything we *need to have it literally pause the clock pls I need it*|
|Resume()|Resumes the clock if its running asynchronosuly|
|RunAsync()|Starts drawing this clock asynchonously|

## BasicFont Editor
A Basic editor/packager for BasicFonts. Fonts can be created and saved, and each character can be individually edited in the bundled/dependency copy of Henja3. BasicFonts interprets White on Henja3 as transparent, and Black as colorable pixels when transforming DF data into BasicFont Character Data. While currently untested, putting any other colors should be preserved when transforming/writing the text.

The editor also brings up a Console Window, which is used to preview text when hitting the "Preview" menustrip item. I should probably make it look a little nicer though... Maybe someday.

The editor is meant to be an end product, and does not have anything aside from its forms. I dont think anything of use can be found here.
