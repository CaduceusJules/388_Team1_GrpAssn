using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    void Example()
    {
        // Move the object to the same position as the parent:
        transform.localPosition = new Vector3(0, 0, 0);

        // Get the y component of the position relative to the parent
        // and print it to the Console
        print(transform.localPosition.y);
    }
}