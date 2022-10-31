using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WGhit : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private ParticleSystem water;
    [SerializeField] private Vector3 growth;
    [SerializeField] private GameObject balloon;
    [SerializeField] private float maxPressure = 500f;
    private float builtPressure = 0f;
    [SerializeField] internal bool won;
    internal bool poppable = true;
    private void OnParticleCollision(GameObject other)
    {

        if(other.gameObject.name == water.name)
        {
            balloon.transform.localScale += growth;
            builtPressure++;

        }

    }

    private void Update()
    {
        pressureCheck();
    }
    void pressureCheck()
    {
        if(builtPressure == maxPressure && poppable)
        {
            poppable = false;
            m_AudioSource.transform.position = balloon.transform.position;
            m_AudioSource.Play();
            won = true;
            balloon.SetActive(false);
            Debug.Log("Water won");
        }

    }
}
