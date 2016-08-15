// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SmuleClone
{
    [Register ("FirstViewController")]
    partial class FirstViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblWelcome { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView map { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLocation { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblWelcome != null) {
                lblWelcome.Dispose ();
                lblWelcome = null;
            }

            if (map != null) {
                map.Dispose ();
                map = null;
            }

            if (txtLocation != null) {
                txtLocation.Dispose ();
                txtLocation = null;
            }
        }
    }
}