using UnityEngine;

public class Balloon : MonoBehaviour
{

    //[SerializeField] private GameObject dart;
    //[SerializeField] private ParticleSystem PopEffect;
    //private DartGameManager dartGameManager;
    //private AudioSource popSound;

    //private void Awake()
    //{
    //    dartGameManager = GameObject.FindObjectOfType<DartGameManager>();
    //    popSound = gameObject.AddComponent<AudioSource>();
    //}


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name.Contains(dart.name))
    //    {
    //        dartGameManager.balloonsRemaining--;
    //        //insert animation
    //        popSound.Play();
    //        gameObject.SetActive(false);

    //        Debug.Log("Balloons remaining: " + dartGameManager.balloonsRemaining);
    //    }
    //}
    //private void Update()
    //{
    //    if (dartGameManager.setActive == true)
    //    {
    //        Debug.Log("Setting Active");
    //        gameObject.SetActive(true);
    //    }
                                                
    //}


    DartGameManager manager;
    new AudioSource audio;
    Animator balloonAnim;
    private void Awake()
    {
        manager = GameObject.FindObjectOfType<DartGameManager>();
        audio = GetComponent<AudioSource>();
        balloonAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        audio.clip = manager.popSound;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dart"))
        {
            manager.balloonsLeft--;
            audio.Play();
            this.gameObject.SetActive(false);
        }
    }
}
