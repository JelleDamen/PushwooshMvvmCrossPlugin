using System;

namespace SoToGo.Plugins.Pushwoosh.Touch.PushwooshSDK
{
	public enum PWSupportedOrientations {
		OrientationPortrait = 1 << 0,
		OrientationPortraitUpsideDown = 1 << 1,
		OrientationLandscapeLeft = 1 << 2,
		OrientationLandscapeRight = 1 << 3
	}
}

