using System.Collections.Generic;

namespace Player.Interfaces
{
    public enum InputManagerAxis
    {
        Horizontal,
        Vertical
    }

    public static class Input
    {
        public static readonly Dictionary<InputManagerAxis, string> InputDictionary = new Dictionary<InputManagerAxis, string>()
        {
            [InputManagerAxis.Horizontal] = "Horizontal",
            [InputManagerAxis.Vertical] = "Vertical",
        };
    }
}