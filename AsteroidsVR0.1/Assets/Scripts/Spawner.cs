using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Asteroide;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 14; i++)
        {
            GameObject asteroide = (GameObject)Instantiate(Asteroide, new Vector3(Random.Range(-140f, 140f), 0f, Random.Range(-140f, 140f)), Quaternion.identity);
            if(asteroide.transform.position.x < 30f && asteroide.transform.position.x > 0f)
            {
                asteroide.transform.position = new Vector3(Random.Range(30f, 140f), 0f, asteroide.transform.position.z);
            }
            else if (asteroide.transform.position.x > -30f && asteroide.transform.position.x < 0f)
            {
                asteroide.transform.position = new Vector3(Random.Range(-140f, -30f), 0f, asteroide.transform.position.z);
            }
            if (asteroide.transform.position.z < 30f && asteroide.transform.position.z > 0f)
            {
                asteroide.transform.position = new Vector3(asteroide.transform.position.x, 0f, Random.Range(30f, 140f));
            }
            else if (asteroide.transform.position.z > -30f && asteroide.transform.position.z < 0f)
            {
                asteroide.transform.position = new Vector3(asteroide.transform.position.x, 0f, Random.Range(-140f, -30f));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
