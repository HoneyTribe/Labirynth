using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InControl
{
	public class KeyboardProfile1 : CustomInputDeviceProfile
	{
		public KeyboardProfile1()
		{
			Name = "Keyboard";
			Meta = "A keyboard profile for 1 player.";
			
			SupportedPlatforms = new[]
			{
				"Windows",
				"Mac",
				"Linux"
			};
			
			Sensitivity = 1.0f;
			LowerDeadZone = 0.0f;
			
			ButtonMappings = new[]
			{
				new InputControlMapping
				{
					Handle = "Action",
					Target = InputControlType.RightTrigger,
					Source = KeyCodeButton( KeyCode.RightShift )
				},
				new InputControlMapping
				{
					Handle = "Action2",
					Target = InputControlType.RightBumper,
					Source = KeyCodeButton( KeyCode.RightAlt )
				},
				new InputControlMapping
				{
					Handle = "Menu",
					Target = InputControlType.Back,
					Source = KeyCodeButton( KeyCode.Escape )
				},
				new InputControlMapping
				{
					Handle = "Pause",
					Target = InputControlType.Start,
					Source = KeyCodeButton( KeyCode.Return )
				}
			};
			
			AnalogMappings = new[]
			{
				new InputControlMapping
				{
					Handle = "Go Left",
					Target = InputControlType.RightStickLeft,
					Source = KeyCodeButton( KeyCode.LeftArrow )
				},
				new InputControlMapping
				{
					Handle = "Go Right",
					Target = InputControlType.RightStickRight,
					Source = KeyCodeButton( KeyCode.RightArrow )
				},
				new InputControlMapping
				{
					Handle = "Go Down",
					Target = InputControlType.RightStickDown,
					Source = KeyCodeButton( KeyCode.DownArrow )
				},
				new InputControlMapping
				{
					Handle = "Go Up",
					Target = InputControlType.RightStickUp,
					Source = KeyCodeButton( KeyCode.UpArrow )
				}
			};
		}
	}
}

