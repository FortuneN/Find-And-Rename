namespace FR.Core
{
	public delegate void Started(object sender, StartedEventArgs e);

	public delegate void Status(object sender, StatusEventArgs e);

	public delegate void Progress(object sender, ProgressEventArgs e);

	public delegate void Stopped(object sender, StoppedEventArgs e);
}
