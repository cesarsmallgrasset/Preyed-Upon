using UnityEngine;

public class Balloon : MonoBehaviour
{

    [SerializeField] private GameObject dart;
    [SerializeField] private DartGameManager dartGameManager;
    [SerializeField] private ParticleSystem PopEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(dart.name))
        {
            dartGameManager.balloonsRemaining--;
            ///PopEffect.Play();
            gameObject.SetActive(false);

            Debug.Log("Balloons remaining: " + dartGameManager.balloonsRemaining);
        }
    }
    private void Update()
    {
        if (dartGameManager.setActive == true)
        {
            Debug.Log("Setting Active");
            gameObject.SetActive(true);
        }
                                                
    }


}
