![The Toolkit Logo](https://cdn.discordapp.com/attachments/335464035921428480/734308914786598912/BasicRender.png "BasicRender Toolkit Logo")

The BasicRender Toolkit is a set of class libraries that make it easy to display graphics on a console screen. Three Libraries are included, and can all be downloaded over at the release page.

This project also includes a small demo program. After a neat little BasicWindow, it tells the very very tiny 8 line story of a man who insulted an AI for the last time. It includes exactly one landscape I drew in henja that came out ~~horrible~~ great.
![And so the man died. The end.](https://cdn.discordapp.com/attachments/335464035921428480/734309006390067330/68747470733a2f2f6d656469612e646973636f72646170702e6e65742f6174746163686d656e74732f373333383835333235.png "And so the man died. The end.")

Below is a nice bit of documentation on each class. Each method also has XML documentation so you don't have to have this markdown document open.

## BasicRender
The titular library that includes two static classes with a few useful functions:

### Draw
Draw includes tools for drawing on screen.
|Method|Result|
|-|-|
|Sprite()|Renders a character or bit of text with the specified color, and either at the current position, or a specified position|
|Block()|Renders a block on screen of the specified color either at the current position, or a specified position|
|Box()|Renders a box on screen of specified color, lenght, and width, at specified posotion|
|Row()|Renders a row of the speicifed color of specified length, either at current or specified position|
|ClearLine()|Clears a line with the console background color|
|CenterText()|Centers text on the screen at current or speciifed row, with current or specified color|

### RenderUtils
Utilities that help in rendering stuff on screen. Though, it's also useful in general.
|Method|Result|
|-|-|
|Sleep()|Holds execution of a program for the specified miliseconds|
|Pause()|Holds execution of a program until the user hits a key|
|Echo()|A shortcut to Console.Write() or Console.WriteLine() depending on if you specify to linebreak|
|SetPos()|Sets the position of the console cursor on screen|
|Color()| Sets the color of the cursor writer. <br><br><b>Take note!</b><br> The one parameter version of this modifies the foreground (Text) Color, but the second one has Background first! <br>This is to match the standard command-line|
|Type()| "types" text on string one character at a time. Time between each character is either specified, or 5ms|


## BasicGraphics
BasicGraphics includes tools for drawing DrawFile (DF) and Hi-Color DrawFiles (HC) files (Both from disk, or directly as a resource, Or as its own type of internal class). These files can be edited by the [Henja2 Editor](https://github.com/igtampe/Henja2) (Which is still a bit of a mess which I need to fix up but ahaha). BasicGraphics depends on BasicRender. It has several classes, mentioned below.

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
A Static class that holds some utilities that are used by the graphic drawers, but it could also be useful for other reasons.
|Method|Result|
|-|-|
|ResourceToStringarray()|Gets a resource as an array of bytes, and turns it into an array of strings, where each index is a line|
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
Abstract class that holds the way to process DF file data. Its extended by BasicGraphicFromFile and BasicGraphicFromResource, which read their contents from a file or from a resource respectively.

|Method|Result|
|-|-|
|DrawColorString()|This method is publicly accessible in case a user wants to access it directly to draw a single line of DF data.<br><br> A ColorString is a string made up of ColorChars. Take a look at GraphicUtils's ColorCharToConsoleColor() method for a more in depth explination.|

### HiColorGraphic (And FromFile, FromResource)
Abstract class that holds the way to process HC file data. Its extended by HiColorGraphicFromFile and HiColorGraphicFromResource, which read their contents from a file or from a resource respectively.

|Method|Result|
|-|-|
|HiColorDraw()|This method is also publicly accessible in case a user wants to access it directly to draw a single line of HC data. <br><br>A string of HiColor Data is comprised of a string of 3 character bits, linked with a hyphen. The first two characters are ColorChars (one for background, the other for foreground), and the 3rd is a digit from 0 to 2, which indicates the gradient between the colorchars, with ░ as 0, ▒ as 1, ▓ as 2. <br><br> The following string holds a HiColor Rainbow `441-460-461-C61-CE0-CE1-CE2-EE2-E10-EA1-AE2-AE1-AA2-AB1-AB2-BB2-3B2-B31-3B2-3B1-3B0-331-932-392-992-192-912-190-110-512-152-551-D52-D51-D50-DD0-4D2-4D1-4D0-440`. This rainbow doesn't use dark yellow or dark green, along with a few shades of gray so there are a few colors that aren't visible here. According to this, there should be just about 50-55 _usable_ colors.|

### Cloud
Cloud is a DF graphic class which holds its own data. Its contents are the cloud graphic from AirportBoard's weather information.
Use it to draw a cute little cloud, and nothing else.

## BasicWindows 
BasicWindows is a very basic window generator utility. Windows are made up of a base background, header, and window elements. Windows can be closed by pressing CTRL+W, or by interacting with a window element that tells it to close. BasicWindows depends on BasicRender and BasicGraphics (because of the Image Window Element)

BasicWindows relies on the basic specifications laid out for ITOS.

### Window
Window is an abstract class that must be inherited to build actual windows. It still has most things a user would need. The only thing the user has to do is write a constructor that places in the needed window elements. Window has a variety of constructors, ranging from just title and dimensions, to basically every property. Feel free to play around with it.

<b>Take Note!</b>
When closing themselves, Windows will draw a box of the WindowClearColor. This build has it set to DarkCyan. Perhaps in the future I should have a constructor that can set this but the constructors by this point are huge so aaaaaaaaaaaaaaaaaaaaaaaaaaaa

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
|Box|Draws a box of a specified color on the window|
|Button|Interactable button that performs an action when a user hits Enter on it.<br>Button is an abstract element because a user must create a button with a tied Action() which occurs when a user hits enter.|
|CloseButton| Preconfigured button that when interacted with, will close the window.|
|Icon|Draws one of four 3x3 Icons: <br><br> ERROR: A red box with an X in the center <br> EXCLAMATION: A yellow box with an exclamation mark in the center.<br> INFORMATION: A blue box with an i in the center<br> QUESTION: A blue box with a question mark in the center.<br><br> This would probably be most useful for dialog boxes. I've found that using a DF file with an icon is far too large.|
|Image|A Window Element that can hold and draw a BasicGraphics Graphic on a window.|
|Label| A label that can draw text in a specific color. Label has been coded to also properly work with linebreaks.|

### HelloWorldWindow
This window is a tiny demo of what a window is. It says Hello.
