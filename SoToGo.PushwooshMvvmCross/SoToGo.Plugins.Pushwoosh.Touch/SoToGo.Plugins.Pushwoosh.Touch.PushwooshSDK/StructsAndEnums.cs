using System;
using ObjCRuntime;

[Native]
public enum PWSupportedOrientations
{
	Portrait = 1 << 0,
	PortraitUpsideDown = 1 << 1,
	LandscapeLeft = 1 << 2,
	LandscapeRight = 1 << 3
}
