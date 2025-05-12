using System.Collections;
using TMPro;
using UnityEngine;

public class PlanetViewer : MonoBehaviour, ICelestalBodyViewer
{
    public enum PlanetViewMode { SYSTEM, PLANET}

    private PlanetViewMode viewMode = PlanetViewMode.SYSTEM;
    public PlanetViewMode ViewMode => viewMode;

    [SerializeField] Animation anim;
    [SerializeField] AnimationClip[] clips;
    [SerializeField] GameObject planetName;
    [SerializeField] GameObject data;
    [SerializeField] Light pointLight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var clip in clips)
        {
            anim.AddClip(clip, clip.name);
        }

        viewMode = PlanetViewMode.SYSTEM;

        //Planets are initially hidden
        Show();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlanetView()
    {
        viewMode = PlanetViewMode.PLANET;

        data.SetActive(true);
        pointLight.enabled = true;
    }

    public void SetSystemView()
    {
        viewMode = PlanetViewMode.SYSTEM;

        data.SetActive(false);
        pointLight.enabled = false;
    }

    public void Hide()
    {
        anim.Stop();

        anim.Play(clips[0].name);
    }

    public void Show()
    {
        anim.Stop();

        anim.Play(clips[1].name);
    }


    public void ShowPlanetName()
    {
        planetName.SetActive(true);
    }

    public void HidePlanetName()
    {
        planetName.SetActive(false);
    }


}
