using UnityEngine;

public class Balloon : MonoBehaviour
{
    private DartGameManager gameManager;


    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<DartGameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dart")
        {
            gameManager.totalBalloons--;

            //to be tested, audio
            //moves the manager balloon audiosource to the balloon and triggers the pop sound
            gameManager.balloonSource.transform.position = this.gameObject.transform.position;
            gameManager.playSound = true;

            //  "Pops" the balloon
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        restart();
    }
    void restart()
    {
        if (gameManager.Lost) this.gameObject.SetActive(true);
        else return;
    }


}
