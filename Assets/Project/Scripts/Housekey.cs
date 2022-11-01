using UnityEngine;

public class Housekey : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource key;
    float timer = 2f;
    private void Awake()
    {
        key = GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void Start()
    {
    }

    private void Update()
    {

        if(key.isPlaying)
        despawn(timer);


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameManager.hKeyCollected = true;
            key.Play();
            this.gameObject.SetActive(false);

        }


    }
    void despawn(float timer)
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {

        }
    }

}
