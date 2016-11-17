# KBCustomNavigationMenu

This is a binding Project based on https://github.com/lminhtm/LMDropdownView.

### Usage

```
UITableView tableView = new UITableView();
var dropdownView = new KBDropdownView();
string[] strData = new string[] { "Menu Item 1", "Menu Item 2", "Menu Item 3" };
tableView.Frame = new CGRect(0, 0, this.View.Frame.Width, strData.Length * 44);
tableView.AlwaysBounceHorizontal = false;
tableView.AlwaysBounceVertical = false;
var source = new MenuTableSource(strData);
source.ItemSelected += (sender, e) => {
	LblSelectedMenuItem.Text = source.selectedString;
	dropdownView.Hide();
};
tableView.Source = source;
tableView.ReloadData();

var button = new UIButton(UIButtonType.Custom);
button.SetTitle("Click For Menu", UIControlState.Normal);
button.SetTitleColor(UIColor.Red, UIControlState.Normal);
button.Frame = new CGRect(0, 0, 100, 30);
this.NavigationItem.TitleView = button;
var origin = new CGPoint(0, this.NavigationController.NavigationBar.Frame.Height + 20);
button.TouchUpInside += (sender, e) => {
	if (dropdownView.CurrentState == KBDropdownViewState.DidOpen) {
		dropdownView.Hide();
	} else {
		dropdownView.ShowInView(this.View, tableView, origin);
	}
};
dropdownView.AnimationDuration = 0.5f;
dropdownView.AnimationBounceHeight = 0f;
```

###Menu Table Source
```
public class MenuTableSource : UITableViewSource
{
	string[] TableItems;
	string CellIdentifier = "TableCell";
	public string selectedString;
	public event EventHandler ItemSelected;

	public MenuTableSource(string[] items)
	{
		TableItems = items;
	}

	public override nint RowsInSection(UITableView tableview, nint section)
	{
		return TableItems.Length;
	}

	public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
	{
		UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
		string item = TableItems[indexPath.Row];

		//---- if there are no cells to reuse, create a new one
		if (cell == null) { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

		cell.TextLabel.Text = item;

		return cell;
	}

	public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
	{
		selectedString = TableItems[indexPath.Row];
		if (ItemSelected != null) {
			this.ItemSelected(this, new EventArgs());
		}
	}
}
```

###Output

![](https://github.com/guntidheerajkumar/KBCustomNavigationMenu/blob/master/Output.gif)
