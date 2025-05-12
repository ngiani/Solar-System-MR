using UnityEngine;

public class SunViewer : MonoBehaviour, ICelestalBodyViewer
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

        Show();
    }
    // Update is called once per frame
    void Update()
    {

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
}
