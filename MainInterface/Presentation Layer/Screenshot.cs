using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainInterface.Presentation_Layer
{
    class ScreenShot
    {
        public static void CaptureImage(Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle, string FilePath)
        {
            using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                }
                bitmap.Save(FilePath, ImageFormat.Bmp);
            }
        }
    }
}
