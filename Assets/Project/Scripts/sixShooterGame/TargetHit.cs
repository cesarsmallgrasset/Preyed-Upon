using UnityEngine;

public class TargetHit : MonoBehaviour
{
    [SerializeField] GameObject target1;
    [SerializeField] GameObject target2;
    [SerializeField] GameObject target3;
    [SerializeField] GameObject target4;
    [SerializeField] GameObject target5;
    [SerializeField] GameObject target6;




    GameObject[] targets = new GameObject[6];

    private void Awake()
    {
        targets[0] = target1;
        targets[1] = target2;
        targets[2] = target3;
        targets[3] = target4;
        targets[4] = target5;
        targets[5] = target6;
    }


    private void Update()
    {
        Debug.Log("" + targets[0]);
    }
        



}
