using UnityEngine;

public class Housekey : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource key;
    private void Awake()
    {
        key = GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameManager.hKeyCollected = true;
            this.gameObject.SetActive(false);
            key.Play();
        }


    }

}
