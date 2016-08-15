using System;
using System.Collections.Generic;
using UIKit;

namespace SmuleClone
{
	public class PickerChangedEventArgs : EventArgs
	{
		public string SelectedValue {get; set;}
	}

	public class PickerModel: UIPickerViewModel
	{
		private readonly IList<string> values;

		public event EventHandler<PickerChangedEventArgs> PickerChanged;

		public PickerModel(IList<string> values)
		{
			this.values = values;
		}

		public override nint GetComponentCount (UIPickerView picker)
		{
			return 1;
		}

		public override nint GetRowsInComponent (UIPickerView picker, nint component)
		{
			return values.Count;
		}

		public override string GetTitle (UIPickerView picker, nint row, nint component)
		{
			return values[(int)(row)];
		}

		public override nfloat GetRowHeight (UIPickerView picker, nint component)
		{
			return 40f;
		}

		public override void Selected (UIPickerView picker, nint row, nint component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new PickerChangedEventArgs{SelectedValue = values[(int)row]});
			}
		}
	}
}

