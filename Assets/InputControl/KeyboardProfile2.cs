using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InControl
{
	public class KeyboardProfile2 : CustomInputDeviceProfile
	{
		public KeyboardProfile2()
		{
			Name = "Keyboard";
			Meta = "A keyboard profile for 2 player.";
			
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
					Target = InputControlType.LeftTrigger,
					Source = KeyCodeButton( KeyCode.Space )
				},
				new InputControlMapping
				{
					Handle = "Action2",
					Target = InputControlType.LeftBumper,
					Source = KeyCodeButton( KeyCode.LeftAlt )
				},
				new InputControlMapping
				{
					Handle = "Menu",
					Target = InputControlType.Select,
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
					Source = KeyCodeButton( KeyCode.A )
				},
				new InputControlMapping
				{
					Handle = "Go Right",
					Target = InputControlType.RightStickRight,
					Source = KeyCodeButton( KeyCode.D )
				},
				new InputControlMapping
				{
					Handle = "Go Down",
					Target = InputControlType.RightStickDown,
					Source = KeyCodeButton( KeyCode.S )
				},
				new InputControlMapping
				{
					Handle = "Go Up",
					Target = InputControlType.RightStickUp,
					Source = KeyCodeButton( KeyCode.W )
				}
			};
		}
	}
}

