using UnityEngine;

public class SunViewer : MonoBehaviour
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

    public void HideSun()
    {
        anim.Stop();

        anim.Play(clips[0].name);
    }

    public void ShowSun()
    {
        anim.Stop();

        anim.Play(clips[1].name);
    }
}
