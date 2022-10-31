using UnityEngine;

public class TargetHit : MonoBehaviour
{
    private new AudioSource audio;
    private new MeshCollider collider;
    private ShooterManager manager;
    private ShooterGun gun;
    private Animator animator;
    private bool targetSet = true;
    private void Awake()
    { 
        audio = GetComponent<AudioSource>();
        manager = GameObject.FindObjectOfType<ShooterManager>();
        gun = GameObject.FindObjectOfType<ShooterGun>();
        collider = GetComponentInChildren<MeshCollider>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Hit", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.reset && !targetSet)
        {
            reset();
        }
        hitCheck();
    }
    void hitCheck()
    {   //check if the raycast from the gunscript hit this target
        if (gun.hit.collider == collider && targetSet)
        {//does the loop if the target is set and hit by an object
            audio.Play();
            animator.SetBool("Hit", true);
            manager.targetCount--;
            targetSet = false;
        }
        //
        else return;
    }
    private void reset()
    {
        targetSet = true;
        animator.SetBool("Hit", false);
    }
}
