using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SolarSystem : MonoBehaviour
{
    bool systemRotationEnabled = true;
    public bool SystemRotationEnabled => systemRotationEnabled;

    [SerializeField] float selfRotationSpeed;
    [SerializeField] private PlanetViewer[] planets;
    [SerializeField] private AsteroidsViewer asteroids;
    [SerializeField] private SunViewer sunViewer;
    [SerializeField] private SolarySystemTTTS solarSystemTTS;
    [SerializeField] private Light pointLight;


    PlanetScaler selectedPlanet;
    bool hidden;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        solarSystemTTS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * selfRotationSpeed, 0);
    }

    public void SetSelectedPlanet(PlanetScaler planet)
    {
        selectedPlanet = planet;
    }

    public void UnSelectPlanet()
    {
        selectedPlanet = null;
    }

    public void HideNonSelectedPlanets()
    {
        if (hidden) return;

        foreach (PlanetViewer planet in planets)
        {
            if (!planet.gameObject.Equals(selectedPlanet.gameObject)) 
                planet.Hide();
        }

        asteroids.Hide();

        sunViewer.Hide();

        pointLight.enabled = false;

        hidden = true;
    }

    public void ShowNonSelectedPlanets()
    {
        if (!hidden) return;

        foreach (PlanetViewer planet in planets)
        {
            if (!planet.gameObject.Equals(selectedPlanet.gameObject))
                planet.Show();
        }

        sunViewer.Show();

        asteroids.Show();

        pointLight.enabled = true;

        hidden = false;
    }

    public void EnableSystemRotation()
    {
        systemRotationEnabled = true;
    }

    public void DisableSystemRotation()
    {
        systemRotationEnabled = false;
    }


    public void DisableGrabColliders()
    {
        GetComponent<Collider>().enabled = false;

        foreach (var planet in planets)
        {
            if (!planet.gameObject.Equals(selectedPlanet.gameObject))
                planet.GetComponent<Collider>().enabled = false;
        }
    }

    public void EnableGrabColliders()
    {
        GetComponent<Collider>().enabled = true;

        foreach (var planet in planets)
        {
            if (!planet.gameObject.Equals(selectedPlanet.gameObject))
                planet.GetComponent<Collider>().enabled = true;
        }
    }
}
