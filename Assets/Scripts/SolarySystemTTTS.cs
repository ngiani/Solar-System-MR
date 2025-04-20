using Meta.WitAi.TTS.Data;
using Meta.WitAi.TTS.Utilities;
using System;
using System.Collections;
using UnityEngine;

public class SolarySystemTTTS : MonoBehaviour
{
    [SerializeField] TTSSpeaker ttSSpeaker;
    [SerializeField] string prhase;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        StartCoroutine(WaitForSpeak(prhase));
    }

    public void Stop()
    {
        ttSSpeaker.StopSpeaking();
    }

    IEnumerator WaitForSpeak(string phrase)
    {
        while (ttSSpeaker.IsPreparing)
        {
            yield return null;
        }

        ttSSpeaker.Speak(phrase);
    }

}
