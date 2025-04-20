using UnityEngine;

public class PlanetViewer : MonoBehaviour
{
    public enum PlanetViewMode { SYSTEM, PLANET}

    private PlanetViewMode viewMode = PlanetViewMode.SYSTEM;
    public PlanetViewMode ViewMode => viewMode;

    [SerializeField] Animation anim;
    [SerializeField] AnimationClip[] clips;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var clip in clips)
        {
            anim.AddClip(clip, clip.name);
        }

        viewMode = PlanetViewMode.SYSTEM;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlanetView()
    {
        viewMode = PlanetViewMode.PLANET;
    }

    public void SetSystemView()
    {
        viewMode = PlanetViewMode.SYSTEM;
    }

    public void HidePlanet()
    {
        anim.Stop();

        anim.Play(clips[0].name);

        Debug.Log("STARTED PLAYING " + clips[0].name);
    }

    public void ShowPlanet()
    {
        anim.Stop();

        anim.Play(clips[1].name);

        Debug.Log("STARTED PLAYING" + clips[1].name);
    }
}
