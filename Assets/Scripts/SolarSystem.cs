using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    bool systemRotationEnabled = true;
    public bool SystemRotationEnabled => systemRotationEnabled;

    [SerializeField] float selfRotationSpeed;

    PlanetScaler selectedPlanet;

    [SerializeField] PlanetViewer[] planets;
    [SerializeField] AsteroidsViewer asteroids;
    [SerializeField] SunViewer sun;
    [SerializeField] SolarySystemTTTS solarSystemTTS;

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
                planet.HidePlanet();
        }

        asteroids.HideAsteroid();

        sun.HideSun();

        hidden = true;
    }

    public void ShowNonSelectedPlanets()
    {
        if (!hidden) return;

        foreach (PlanetViewer planet in planets)
        {
            if (!planet.gameObject.Equals(selectedPlanet.gameObject))
                planet.ShowPlanet();
        }

        sun.ShowSun();

        asteroids.ShowAsteroid();

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
}
