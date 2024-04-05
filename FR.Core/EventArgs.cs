using System;

namespace FR.Core
{
	public class StartedEventArgs : EventArgs
	{
	}

	public class StatusEventArgs : EventArgs
	{
		public string Status { get; set; }
	}

	public class ProgressEventArgs : EventArgs
	{
		public bool Renamed { get; set; }
		public string OldPath { get; set; }
		public string OldName { get; set; }
		public string NewPath { get; set; }
		public string NewName { get; set; }
		public decimal ProgressPercent { get; set; }
		public string Issue { get; set; }
		public decimal TotalCount { get; set; }
		public decimal ProcessedCount { get; set; }
		public string OldPathRelative { get; set; }
	}

	public class StoppedEventArgs : EventArgs
	{
		public bool Cancelled { get; set; }
		public Exception Error { get; set; }
	}
}
