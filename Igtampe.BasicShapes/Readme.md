# BasicShapes
BasicShapes is a *very basic* geometry drawing package that includes some basic classes and a renderer that uses BasicRender to draw.

![BasicShapes](https://raw.githubusercontent.com/igtampe/BasicRender/master/Images/BasicShapes/Shapes.png)<br/>
*The Sample used in the start of the BasicRender demo*

## Line
A Collection of two points (defined as PointF or Point) used to draw a straight line.

|Field|Description|
|-|-|
|P1| Leftmost point of the line (As Point)|
|P1F| Leftmost point of the line (As PointF)|
|P2| Rightmost point of the line (As Point)|
|P2F| Rightmost point of the line (as PointF)|
|Points| List of all points contained in this line (between P1 and P2).<br/><br/> These points are used to render, and are calculated using the slope with a resolution of 1 x coordinate per point|
|M|Slope of the line|
|DX| Int conversion of DFX|
|DXF| Difference in X of this line (as Float)|
|DY| Int conversion of DFY|
|DYF| Difference in Y of this line (as Float)|
|Length| Length of this line. Thank you Pythagoras|
|Center| Center of this line (as PointF)|

|Method|Description|
|-|-|
|ContainsPoint()|Checks if the list of points this line contains contains the given point|
|Intersects()|Checks if this line intersects with another line. It's probably horribly inefficient but eh.|

|Static Method|Description|
|-|-|
|TranslateLine()|Translates a line by a given DX and DY|
|P1ScaleLine()|Scales the line up from P1. This method is not supported by Curve|
|P2ScaleLine()|Scales the line up from P2. This method is not supported by Curve|
|CenterScaleLine()|Scales the line up from the center of the line|

## Curve
An extension of Line that calculates and can be used to render a curve around a center point with a given radius and starting and ending angle.
|Field|Description|
|-|-|
|Center|Center of the curve (as PointF)|
|R|Radius of the curve|
|A1|Start angle of this curve (Smallest)|
|A2|End angle of this curve (Largest)|
|Points| List of all points contained in this line (between P1 and P2).<br/><br/> These points are used to render, and are calculated using the radius and angles with a resolution of 0.5 degrees per point|

|Static Method|Description|
|-|-|
|TranslateCurve()|Translates a curve from one spot to another based on a given DX and DY|
|ScaleCurve()|Scales a curve around the center|

## Polygon
A collection of lines (lines or curves) to be drawn or filled by the renderer. 

|Field|Description|
|-|-|
|Lines|Lines that make up this polygon|
|Center|Center of this polygon (as PointF)|
|BoundingRectangle|A Rectangle that contains all of this polygon|

|Static Method|Description|
|-|-|
|TranslatePolygon()|Translates a polygon from one spot to another based on a given DX and DY|
|ScalePolygon()|Scales a polygon up or down based around its center. ScalePolygon() currently does not support polygons with curves|

## DrawShapes
DrawShapes is the renderer for shapes with BasicRender onto the console. It includes various static methods to handle this:

|Static Method|Description|
|-|-|
|DrawLine()|Draws a line. Includes overrides to generate the lines on the fly if necessary|
|DrawRectangle()|Draws a rectangle's outline|
|FillRectangle()|Shortcut to Draw.Box() from BasicRender.<br/><br/>We removed a couple other aliases but this one makes sense. Better to have function with Draw and Fill next to each other rather than have the functions miles apart.|
|DrawPolygon()|Draws a polygon's outline. Includes overrides to generate the polygons on the fly if necessary based on lines or points|
|FillPolygon()|Fills a polygon. Includes DrawPolygon's overrides|



## Vector Graphics File
Eventually we should make a vector based format for BasicRender using BasicShapes but that'll probably be another time
