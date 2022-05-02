using System;
using UIKit;

namespace DiveLog;

public static partial class AccessibleSettings
{
	public static partial bool IsMovementEnabled()
    {
        return !UIAccessibility.IsReduceMotionEnabled;
    }
}
