using UnityEngine;

public class FanController : MonoBehaviour
{
    public GameObject fanBlades;
    public float rotationSpeed = 100f;
    private bool isRotating = false;

    void Update()
    {
        if (isRotating)
        {
            fanBlades.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void ToggleFan()
    {
        isRotating = !isRotating;
    }
}
