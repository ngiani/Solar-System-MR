using UnityEngine;

public class AsteroidsViewer : MonoBehaviour
{

    [SerializeField] Animation anim;
    [SerializeField] AnimationClip[] clips;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var clip in clips)
        {
            anim.AddClip(clip, clip.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAsteroid()
    {
        anim.Stop();

        anim.Play(clips[0].name);
    }

    public void ShowAsteroid()
    {
        anim.Stop();

        anim.Play(clips[1].name);
    }
}
