using UnityEngine;

public class Vine : MonoBehaviour
{
    public Rigidbody2D vineBase;
    [SerializeField] private GameObject[] prefabVineSegs;
    [SerializeField] private GameObject prefabBaseSeg;
    [SerializeField] private GameObject prefabHookSeg;
    [Range(3, 32)] public int numLinks;

    void Start()
    {
        GenerateVine();
    }

    void GenerateVine()
    {
        Rigidbody2D prevBod = vineBase;
        GameObject newSeg;
        HingeJoint2D hj;

        for (int i = 0; i < numLinks -1; i++)
        { 
            int index = Random.Range(0, prefabVineSegs.Length);

            if (i == 0)
            {
                newSeg = Instantiate(prefabBaseSeg);
            }
            else
            {
                newSeg = Instantiate(prefabVineSegs[index]);
            }

            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;

            prevBod = newSeg.GetComponent<Rigidbody2D>();
        }

        newSeg = Instantiate(prefabHookSeg);
        newSeg.transform.parent = transform;
        newSeg.transform.position = transform.position;
        hj = newSeg.GetComponent<HingeJoint2D>();
        hj.connectedBody = prevBod;
    }
}
