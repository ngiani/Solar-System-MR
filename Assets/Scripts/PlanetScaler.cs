using Oculus.Interaction;
using Oculus.Interaction.Samples;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlanetScaler : MonoBehaviour
{

    [SerializeField] float rescaleSpeed;
    [SerializeField] TwoGrabScaleTransformer twoGrabScaleTransformer;
    [SerializeField] PlanetViewer planetViewer;
    [SerializeField] PlanetRotator planetRotator;
    [SerializeField] Grabbable grabbable;
    [SerializeField] SolarySystemTTTS planetTTS;
    [SerializeField] SolarySystemTTTS systemTTS;

    SolarSystem sun;

    float planetViewScale = 0.8F;
    [SerializeField] float planetViewScaleThreshold = 0.6F;
    float systemViewScale;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        twoGrabScaleTransformer.StartedScaling.AddListener(OnStartedScaling);
        twoGrabScaleTransformer.EndScaling.AddListener(OnEndScaling);

        sun = FindAnyObjectByType<SolarSystem>();

        systemViewScale = transform.localScale.x;

    }

    private void OnEndScaling()
    {
        if (planetViewer.ViewMode == PlanetViewer.PlanetViewMode.SYSTEM)
        {
            if (transform.localScale.x >= planetViewScaleThreshold)
            {
                ScaleToPlanetScale();

                planetViewer.SetPlanetView();

                planetRotator.SetSelfGrabTargetTransform();

                sun.DisableSystemRotation();
                sun.HideNonSelectedPlanets();
                sun.DisableGrabColliders();

                systemTTS.Stop();
                planetTTS.Play();
            }

            else
            {

                ScaleToSystemScale();
                
                sun.EnableSystemRotation();
            }
        }

        else if (planetViewer.ViewMode == PlanetViewer.PlanetViewMode.PLANET)
        {
            if (transform.localScale.x < planetViewScaleThreshold)
            {
                ScaleToSystemScale();

                planetViewer.SetSystemView();

                planetRotator.SetSystemGrabTargetTransform();

                sun.EnableSystemRotation();
                sun.ShowNonSelectedPlanets();
                sun.EnableGrabColliders();
                sun.UnSelectPlanet();

                planetTTS.Stop();
            }

            else
            {
                ScaleToPlanetScale();
            }
        }

    }

    private void OnStartedScaling()
    {
        if (planetViewer.ViewMode == PlanetViewer.PlanetViewMode.SYSTEM)
        {
            sun.SetSelectedPlanet(this);

            sun.DisableSystemRotation();
        }


    }


    // Update is called once per frame
    void Update()
    {

    }

    void ScaleToPlanetScale()
    {
        StartCoroutine(ScaleUPToPlanetScale());
    }


    void ScaleToSystemScale()
    {

        StartCoroutine(ScaleBackToSystemScale());

    }


    void InterruptScaleBackToSystemScale()
    {

        StopCoroutine(ScaleBackToSystemScale());

    }

    IEnumerator ScaleUPToPlanetScale()
    {
        grabbable.enabled = false;

        float scale = transform.localScale.x;

        while (scale < planetViewScale)
        {


            scale += rescaleSpeed;
            transform.localScale = new Vector3(scale, scale, scale);

            yield return null;
        }

        grabbable.enabled = true;
    }

    IEnumerator ScaleBackToSystemScale()
    {
        grabbable.enabled = false;

        float scale = transform.localScale.x;

        while (scale > systemViewScale)
        {
            scale -= rescaleSpeed;
            transform.localScale = new Vector3(scale, scale, scale);

            yield return null;

        
        }

        grabbable.enabled = true;
    }

    public void TestEndScaling()
    {
        OnStartedScaling();

        transform.localScale = Vector3.one * planetViewScaleThreshold;

        OnEndScaling();
    }
}
