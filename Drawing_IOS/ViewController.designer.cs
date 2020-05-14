// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Drawing_IOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView mainImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView tempImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lbl != null) {
                lbl.Dispose ();
                lbl = null;
            }

            if (mainImageView != null) {
                mainImageView.Dispose ();
                mainImageView = null;
            }

            if (tempImageView != null) {
                tempImageView.Dispose ();
                tempImageView = null;
            }
        }
    }
}