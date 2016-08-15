using System;
using UIKit;

namespace SmuleClone
{

	public class LoginTextFieldDelegate : UITextFieldDelegate
	{
		public EventHandler<UITextField> OnShouldReturn;

		public override bool ShouldReturn(UITextField textField)
		{
			if (OnShouldReturn != null)
			{
				OnShouldReturn(this, textField);
			}

			return true;
		}
	}
}

