using UnityEngine;

public class WaterGunHit : MonoBehaviour
{
    [SerializeField] internal GameObject Balloon;
    [SerializeField] internal ParticleSystem water;
    [SerializeField] internal Vector3 IncrementationValues;
    internal float nbOfParticles = 0;
    internal float x,y,z;
    internal Vector3 itemSize;
    
    private void Awake()
    {
        itemSize = Balloon.transform.localScale;
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other == water)
        {
            //values being stored
            Balloon.transform.localScale += IncrementationValues;
            nbOfParticles++;
        }
    }
}
