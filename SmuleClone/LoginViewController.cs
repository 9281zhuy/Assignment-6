using Foundation;
using System;
using UIKit;

namespace SmuleClone
{
    public partial class LoginViewController : UIViewController
    {
        
		public LoginViewController (IntPtr handle) : base (handle)
        {
			
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var textDelegate = new LoginTextFieldDelegate
			{
				OnShouldReturn = (sender, textField) =>
				{
					if (textField.Tag == txtUsername.Tag)
					{
						txtPassword.BecomeFirstResponder();
					}
					else if (textField.Tag == txtPassword.Tag)

					{
						txtPassword.ResignFirstResponder();

						if (txtPassword.Text == "4995" && txtUsername.Text.ToLower() == "ethan")

						{
							TabController tabViewController = this.Storyboard.InstantiateViewController("TabControllerID") as TabController;

							var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

							appDelegate.Username = txtUsername.Text;

							if (tabViewController != null)
								PresentViewController(tabViewController, true, null);


						}
						else
						{
							new UIAlertView("Access Denied!", "Enter a vaild username and password", null, "OK").Show();
						}
					}
				}
			};
			txtPassword.Delegate = textDelegate;
			txtUsername.Delegate = textDelegate;

		}
    }
}