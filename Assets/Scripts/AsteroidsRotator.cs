using UnityEngine;

public class AsteroidsRotator : MonoBehaviour
{
    [SerializeField] private float selfRotationSpeed;
    [SerializeField] private Vector3 axis;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis * Time.deltaTime * selfRotationSpeed);
    }
}
