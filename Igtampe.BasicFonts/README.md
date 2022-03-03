# BasicFonts
BasicFonts draws text using slightly altered DF data stored on a [Dictionary On Disk](https://github.com/igtampe/DictionaryOnDisk) file with a Bfnt Extension. It comes with a singular class which handles everything. 

![Example](https://github.com/igtampe/BasicRender/blob/master/Images/BasicFonts/HelloWorld.png?raw=true)<br/>
*Hello World!*

The following properties and methods are there:

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

## Clock
BasicFont also includes a clock, with two clock fonts (Regular, and wide). It's visible here in the [BasicClock example](https://github.com/igtampe/BasicRender/tree/master/Igtampe.BasicClockExample)
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
