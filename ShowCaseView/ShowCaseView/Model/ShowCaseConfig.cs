namespace ShowCaseView.Model
{
	public class ShowCaseConfig
	{
		public string ViewText { get; set; }
		public VerticalPosition TextVerticalPosition { get; set; }
		public HorizontalPosition TextHorizontalPosition { get; set; }
	}

	public enum VerticalPosition
	{
		Top,
		Bottom
	}

	public enum HorizontalPosition
	{
		Left,
		Center,
		Right
	}
}
