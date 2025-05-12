using UnityEngine;

public class PlanetSelfRotator : MonoBehaviour
{
    [SerializeField] PlanetRotator planetRotator;
    [SerializeField] float selfRotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (!planetRotator.PlanetGrabRotationEnabled)
            transform.Rotate(0, Time.deltaTime * selfRotationSpeed, 0);
    }
}
