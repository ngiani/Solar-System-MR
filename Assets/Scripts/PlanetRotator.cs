using Oculus.Interaction;
using System;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    [SerializeField] private float systemRotationSpeed;
    [SerializeField] private float selfRotationSpeed;
    [SerializeField] private MyOneGrabRotateTransformer oneGrabRotateTransformer;
    [SerializeField] private PlanetViewer planetViewer;

    private SolarSystem sun;
    private Transform system;

    float planetGrabRotationSpeed;
    bool planetGrabRotationEnabled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oneGrabRotateTransformer.StartRotating.AddListener(OnStartRotating);
        oneGrabRotateTransformer.EndRotating.AddListener(OnEndRotating);

        sun = FindAnyObjectByType<SolarSystem>();
        system = GameObject.Find("System").transform;
    }

    private void OnEndRotating()
    {
        Debug.Log("END ROTATION");

        Debug.Log("GET VIEW MODE " +  planetViewer.ViewMode.ToString());
        
        if (planetViewer.ViewMode == PlanetViewer.PlanetViewMode.SYSTEM)
        {
            sun.EnableSystemRotation();
        }
            

        else if (planetViewer.ViewMode == PlanetViewer.PlanetViewMode.PLANET)
            planetGrabRotationEnabled = false;
    }

    private void OnStartRotating()
    {
        Debug.Log("START ROTATION");

        Debug.Log("GET VIEW MODE " + planetViewer.ViewMode.ToString());

        if (planetViewer.ViewMode == PlanetViewer.PlanetViewMode.SYSTEM)
        {
            sun.DisableSystemRotation();

        }
            

        else if (planetViewer.ViewMode == PlanetViewer.PlanetViewMode.PLANET)
            planetGrabRotationEnabled = true;
    }


    public void SetSelfGrabTargetTransform()
    {
        oneGrabRotateTransformer.SetTargetTransform(transform);
    }

    public void SetSystemGrabTargetTransform()
    {
        oneGrabRotateTransformer.SetTargetTransform(system);
    }


    // Update is called once per frame
    void Update()
    {
        if (planetViewer.ViewMode == PlanetViewer.PlanetViewMode.SYSTEM && sun.SystemRotationEnabled)
            transform.RotateAround(sun.transform.position, sun.transform.up, Time.deltaTime * systemRotationSpeed);

        else if (!planetGrabRotationEnabled)
            transform.Rotate(0, Time.deltaTime * selfRotationSpeed, 0);
    }


}
