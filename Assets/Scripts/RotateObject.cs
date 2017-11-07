﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

			void Update()
		{
			// Rotate the object around its local X axis at 1 degree per second
			transform.Rotate(Time.deltaTime, 10, 0);

			// ...also rotate around the World's Y axis
			transform.Rotate(0, Time.deltaTime, 0, Space.World);
		}
}

