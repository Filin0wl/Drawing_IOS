using CoreGraphics;
using Foundation;
using System;
using System.Drawing;
using System.Linq;
using UIKit;

namespace Drawing_IOS
{
    public partial class ViewController : UIViewController
    {/*
        TempImageView tempImageView;
        MainImageView mainImageView;*/
        UIColor color = UIColor.Black;
        float brushWidth = 10.0f;
        float opacity = 1.0f;
        bool swiped = false;
        CGPoint lastPoint = CGPoint.Empty;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            tempImageView.Image = new UIImage();
            mainImageView.Image = new UIImage();


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                swiped = false;
                lastPoint = touch.LocationInView(this.View);
                lbl.Text = "tyuk";
            }
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            UITouch touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                swiped = true;
                CGPoint currentPoint = touch.LocationInView(this.View);
                DrawLine(lastPoint, currentPoint);

                lastPoint = currentPoint;
            }
        }
        public void DrawLine(CGPoint fromPoint, CGPoint toPoint)
        {
            UIGraphics.BeginImageContext(this.View.Frame.Size);
            CGContext context = UIGraphics.GetCurrentContext() as CGContext;
            if (context != null)
            {

               //tempImageView.Image.Draw(this.View.Bounds);
                tempImageView.Draw(this.View.Bounds);
                

                context.MoveTo(fromPoint.X, fromPoint.Y);
                context.AddLineToPoint(toPoint.X, fromPoint.Y);

                context.SetLineCap(CGLineCap.Round);
                context.SetBlendMode(CGBlendMode.Normal);
                context.SetLineWidth(brushWidth);
                context.SetStrokeColor(color.CGColor);

                context.StrokePath();

                tempImageView.Image = UIGraphics.GetImageFromCurrentImageContext();
                tempImageView.Alpha = opacity;
                UIGraphics.EndImageContext();

            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            if (!swiped)
            {
                DrawLine(lastPoint, lastPoint);

            }

            UIGraphics.BeginImageContext(mainImageView.Frame.Size);
            mainImageView.Image.Draw(this.View.Bounds, CGBlendMode.Normal, (nfloat)1.0);
            //mainImageView.Draw(this.View.Bounds);
            
            UIGraphics.EndImageContext();

            
        }
    }
}