# BasicRender
The titular library that includes two static classes with a few useful functions:

## Draw
Draw includes tools for drawing on screen.
<br><br><b>Take note!</b><br> 
When asking for positions, these methods use LeftPos and TopPos, or the leftmost coordinate, and topmost coordinate of the object.
<br><br><b>Also take note!</b><br> 
As of the most recent update, BasicRender supprots overscan. Making any requests that fall outside of the window will be rendered either partially, or not at all


|Method|Result|
|-|-|
|Sprite()|Renders a character or bit of text with the specified color, and either at the current position, or a specified position|
|Block()|Renders a block on screen of the specified color either at the current position, or a specified position|
|Box()|Renders a box on screen of specified color, lenght, and width, at specified posotion|
|Row()|Renders a row of the speicifed color of specified length, either at current or specified position|
|ClearLine()|Clears a line with the console background color|
|CenterText()|Centers text on the screen at current or speciifed row, with current or specified color|

## RenderUtils
Utilities that help in rendering stuff on screen. Though, they're also useful in general.
|Method|Result|
|-|-|
|Sleep()|Holds execution of a program for the specified miliseconds|
|Pause()|Holds execution of a program until the user hits a key|
|Echo()|A shortcut to Console.Write() or Console.WriteLine() depending on if you specify to linebreak|
|SetPos()|Sets the position of the console cursor on screen|
|Color()| Sets the color of the cursor writer. <br><br><b>Take note!</b><br> The one parameter version of this modifies the foreground (Text) Color, but the second one has Background first! <br>This is to match the Windows command line's Color command|
|Type()| "Types" text on screen one character at a time. Time between each character is either specified, or 5ms|

## DrawThread
A Thread that can be used to coordinate drawing in multi-threaded console applications using BasicRender. Technically it can be used to do *anything* sequentially between multiple threads.

|Method|Result|
|-|-|
|AddDrawTask()|Adds a task o the queue of pending tasks. Can also accept an Action and convert it to a Task|
|Start()|Starts the DrawThread|
|StopAsync()|Sends the stop signal. The thread will eventually get to it|
|Stop()|Sends the stop signal and waits for the thread to actually stop|

## Cycler
A small itty bitty class to help cycling between different strings. For instance, for a spinner ("/", "-", "\", "|"). Use Cycle() to advance the position on the cycle and return the next string in the array it holds.

## SpecialChars
Collection of constants with special characters available on the console, including the box characters. Includes a small writeleine to test all the characters
