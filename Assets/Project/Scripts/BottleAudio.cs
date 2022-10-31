using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BottleAudio : MonoBehaviour
{
    private BottleManager manager;
    internal AudioSource source;
    internal AudioClip clip;
    internal bool play = true;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<BottleManager>();
        source = GetComponent<AudioSource>();
        clip = source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.won)
        {
            if (play)
            {
                source.PlayOneShot(clip);
                play = false;
            }
        }
    }
}
