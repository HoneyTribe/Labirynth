using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InControl
{
	public class KeyboardProfile1 : UnityInputDeviceProfile
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
					Target = InputControlType.Menu,
					Source = KeyCodeButton( KeyCode.Escape )
				},
				new InputControlMapping
				{
					Handle = "Pause",
					Target = InputControlType.Start,
					Source = KeyCodeButton( KeyCode.F1 )
				}
			};
			
			AnalogMappings = new[]
			{
				new InputControlMapping
				{
					Handle = "Arrow Keys X",
					Target = InputControlType.RightStickX,
					Source = KeyCodeAxis( KeyCode.LeftArrow, KeyCode.RightArrow )
				},
				new InputControlMapping
				{
					Handle = "Arrow Keys Y",
					Target = InputControlType.RightStickY,
					Source = KeyCodeAxis( KeyCode.DownArrow, KeyCode.UpArrow )
				}
			};
		}
	}
}

