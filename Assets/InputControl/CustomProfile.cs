using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InControl
{
	public class CustomProfile : CustomInputDeviceProfile
	{
		public CustomProfile()
		{
			Name = "Custom profile";
			Meta = "Handles action not assigned to the device";
			
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
					Handle = "Action1",
					Target = InputControlType.Action1,
					Source = KeyCodeButton( KeyCode.Return )
				},
				new InputControlMapping
				{
					Handle = "Action2",
					Target = InputControlType.Action2,
					Source = MouseButton0
				},
				new InputControlMapping
				{
					Handle = "Action3",
					Target = InputControlType.Action3,
					Source = MouseButton1
				}
			};

			AnalogMappings = new InputControlMapping[0];
		}
	}
}

