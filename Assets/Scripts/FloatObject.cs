using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatObject : MonoBehaviour {

public Vector3 pos;

// animate the game object from -1 to +1 and back
    private float minimum = 0.007F;
    private float maximum =  -0.007F;

    // starting value for the Lerp
    static float t = 0.007f;


    void Update()
    {
        // animate the position of the game object...
        transform.position = new Vector3(Mathf.Lerp(transform.position.x-minimum, transform.position.x + maximum, t) , 2, transform.position.z);

        // .. and increate the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
