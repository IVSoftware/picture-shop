
using System.Reflection;

namespace picture_shop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); 
            ImageFolder =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Images"
            );
            buttonDraw.Click += onButtonDrawClick;
            buttonSave.Click += (sender, e) => pictureBox1.Image?.Save(AppDataFolder);
            pictureBox1.Paint += onPicturebox1Paint;
            trackBarTolerance.ValueChanged += (sender, e) => pictureBox1.Refresh();
        }

        private int _clickCount = 0;
        string ImageFolder { get; } = Path.Combine( 
            AppDomain.CurrentDomain.BaseDirectory, 
            "Images");
        string AppDataFolder { get; } = Path.Combine( 
            Environment.GetFolderPath( 
                Environment.SpecialFolder.LocalApplicationData),
                Assembly.GetExecutingAssembly().GetName().Name,
                "Images");

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
                    labelTolerance.Visible = trackBarTolerance.Visible = true;
                    break;
            }
            pictureBox1.Refresh();
        }

        private List<Bitmap> Layers { get; } = new List<Bitmap>();
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
    }
}
