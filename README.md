# Picture Shop

As I understand it, you want to draw **picture box in layers** similar to the popular editing app. We'll make our own version and call it **PictureShop**. As Jimi commented, you need only one `PictureBox` and when you want to draw on  call its `Refresh` method. It responds by firing a `Paint` message and providing a `Graphics` canvas to draw on. So, if we have put the images in a `Layers` list of bitmaps, we can draw the layers on top of one another. Obviously there is a problem doing this, but it's a start.

[![layers without transparency][1]][1]

```
/// <summary>
/// Add layer, then refresh PictureBox to draw.
/// </summary>
private void onButtonDrawClick(object? sender, EventArgs e)
{
    switch ( _clickCount++ ) 
    {
        case 0:
            Layers.Add((Bitmap)Bitmap.FromFile(Path.Combine(ImageFolder, "Image1.png")));
            break;
        case 1:
            Layers.Add((Bitmap)Bitmap.FromFile(Path.Combine(ImageFolder, "Image2.png")));
        break;
    }
    pictureBox1.Refresh();
}

private List<Bitmap> Layers { get; } = new List<Bitmap>();
private void onPicturebox1Paint(object? sender, PaintEventArgs e)
{
    foreach (var bmp in Layers)
    {
        e.Graphics.DrawImage(bmp, pictureBox1.ClientRectangle);
    }
}
```

___

If we were using that "other" app, we would go to the top layer and probably use a magic wand to select around the top image, and make it transparent. To make **PictureShop** do something similar, have it replace pixels in the top image if the color falls within a range of values.

Now the Tolerance slider lets you adjust the amount or transparency before saving.

[![adjustable transparency][2]][2]

**Transparency method**

```
private Bitmap replaceColor(Bitmap bmp, Color targetColor, int tolerance)
{
    if(tolerance == 0) return bmp;
    var copy = new Bitmap(bmp);
    for (int x = 0; x < bmp.Width; x++)
    {
        for (int y = 0; y < copy.Height; y++)
        {
            Color pixelColor = copy.GetPixel(x, y);
            if (localIsWithinTolerance(pixelColor, targetColor, tolerance))
            {
                copy.SetPixel(x, y, Color.Transparent);
            }
        }
    }
    bool localIsWithinTolerance(Color pixelColor, Color targetColor, int tolerance)
    {
        return Math.Abs(pixelColor.R - targetColor.R) <= tolerance &&
                Math.Abs(pixelColor.G - targetColor.G) <= tolerance &&
                Math.Abs(pixelColor.B - targetColor.B) <= tolerance;
    }
    return copy;
}
```

**New paint method**

```
private void onPicturebox1Paint(object? sender, PaintEventArgs e)
{
    Bitmap bmp;
    for (int i = 0; i < Layers.Count; i++) 
    {
        switch (i)
        {
            case 0:
                bmp = Layers[i];
                break;
            case 1:
                bmp = replaceColor(Layers[i], Color.FromArgb(0xF0, 0xF0, 0xF0), trackBarTolerance.Value);
                break;
            default:
                return;
        }
        e.Graphics.DrawImage(bmp, pictureBox1.ClientRectangle);
    }
}
```

  [1]: https://i.stack.imgur.com/rvEyj.png
  [2]: https://i.stack.imgur.com/VlQoj.png