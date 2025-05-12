using UnityEngine;

public class TextWatchCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Quaternion lookRotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position, transform.up);

        transform.rotation = Quaternion.Euler(0, lookRotation.y, 0);
    }
}
