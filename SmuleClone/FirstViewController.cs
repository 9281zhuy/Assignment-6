using System;
using System.Collections.Generic;
using CoreGraphics;
using CoreLocation;
using MapKit;
using UIKit;

namespace SmuleClone
{
	public partial class FirstViewController : UIViewController
	{
		protected FirstViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public string Username { get; set;}

		CLLocationManager locationManager = new CLLocationManager();



		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
				locationManager.RequestWhenInUseAuthorization();
			}

			map.MapType = MapKit.MKMapType.Standard;

			map.ShowsUserLocation = true;

			var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

			lblWelcome.Text += " " + appDelegate.Username;

			SetupPicker();

			SetupSegmentControl();

			SetLocationAnnotation();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private IList<string> locationList = new List<string>
		{
			"Marquette University",
			"Harley-Davidson Museum",
			"Miller Park",
			"Bradley Center"
		};

		private string selectedLocation;

		private void SetLocationAnnotation() 
		{
			CLLocationCoordinate2D geoLocation;

			switch (selectedLocation) 
			{
				case "Marquette University":
				default:
					geoLocation = new CLLocationCoordinate2D(43.038702, -87.929728);
					break;
				case "Harley-Davidson Museum":
					geoLocation = new CLLocationCoordinate2D(43.031892, -87.916508);
					break;
				case "Miller Park":
					geoLocation = new CLLocationCoordinate2D(43.028150, -87.971097);
					break;
				case "Bradley Center":
					geoLocation = new CLLocationCoordinate2D(43.043914, -87.917262);
					break;
					
			}

			map.AddAnnotation(new MKPointAnnotation()
			{
				Title = selectedLocation,
				Coordinate = geoLocation,
			});

			MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(5),
														 MilesToLongitudeDegrees(5, geoLocation.Latitude));
			map.Region = new MKCoordinateRegion(geoLocation, span);

		}

		private void SetupPicker() 
		{
			PickerModel model = new PickerModel(this.locationList);
			model.PickerChanged += (sender, e) =>
			{
				this.selectedLocation = e.SelectedValue;

			};

			UIPickerView picker = new UIPickerView();
			picker.ShowSelectionIndicator = true;
			picker.Model = model;

			UIToolbar toolbar = new UIToolbar();
			toolbar.BarStyle = UIBarStyle.Default;
			toolbar.Translucent = true;
			toolbar.SizeToFit();

			UIBarButtonItem btnDone = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (s, e) =>
			{
				this.txtLocation.Text = selectedLocation;
				this.txtLocation.ResignFirstResponder();
				SetLocationAnnotation();

			});

			toolbar.SetItems(new UIBarButtonItem[] { btnDone }, true);

			this.txtLocation.InputView = picker;

			this.txtLocation.InputAccessoryView = toolbar;

		}

		private void SetupSegmentControl()
		{
			int typesWidth = 260, typesHeight = 30, distnceFromBottom = 100;
			UISegmentedControl mapTypes = new UISegmentedControl(new
			CGRect((View.Bounds.Width - typesWidth) / 2, View.Bounds.Height - distnceFromBottom,
				   typesWidth, typesHeight)
			);
			mapTypes.InsertSegment("Road", 0, false);
			mapTypes.InsertSegment("Satellite", 1, false);
			mapTypes.InsertSegment("Hybrid", 2, false);
			mapTypes.SelectedSegment = 0;
			mapTypes.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;

			mapTypes.ValueChanged += (s, e) =>
			{
				switch (mapTypes.SelectedSegment)
				{
					case 0:
						map.MapType = MKMapType.Standard;
						break;
					case 1:
						map.MapType = MKMapType.Satellite;
						break;
					case 2:
						map.MapType = MKMapType.Hybrid;
						break;


				}
			};

			View.AddSubview(mapTypes);
		}
			public double MilesToLatitudeDegrees(double miles) 
			{
			double earthRadius = 3960.0;
			double radiansToDegrees = 180.0 / Math.PI;
			return (miles / earthRadius) * radiansToDegrees;

			
			}

		public double MilesToLongitudeDegrees(double miles, double atLatitude) 
			{
			double earthRadius = 3960.0;
			double degreesToRadians = Math.PI / 180.0;
			double radiansToDegrees = 180.0 / Math.PI;
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (miles / radiusAtLatitude) * radiansToDegrees;

			
			}

		}


	}


