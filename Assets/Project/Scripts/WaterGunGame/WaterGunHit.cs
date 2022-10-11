using UnityEngine;

public class WaterGunHit : MonoBehaviour
{
    private WaterGunManager manager;
    [SerializeField] internal GameObject Balloon;
    [SerializeField] internal ParticleSystem water;
    [SerializeField] internal Vector3 IncrementationValues;
    internal float nbOfParticles = 0;
    internal float x,y,z;
    internal Vector3 itemSize;
    
    private void Awake()
    {
        manager = GameObject.FindObjectOfType<WaterGunManager>();
        itemSize = Balloon.transform.localScale;
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.name == water.name)
        {
            //values being stored
            Balloon.transform.localScale += (IncrementationValues/1000);
            nbOfParticles++;

        }
    }
}
