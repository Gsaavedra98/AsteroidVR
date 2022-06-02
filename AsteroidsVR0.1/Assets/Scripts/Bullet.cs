using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 50f;
        if (transform.position.x >= 140f)
        {
            transform.position = new Vector3(-140f, 0f, transform.position.z);
        }
        else if (transform.position.x <= -140f)
        {
            transform.position = new Vector3(140f, 0f, transform.position.z);
        }
        else if (transform.position.z >= 140f)
        {
            transform.position = new Vector3(transform.position.x, 0f, -140f);
        }
        else if (transform.position.z <= -140f)
        {
            transform.position = new Vector3(transform.position.x, 0f, 140f);
        }
        StartCoroutine(DestroyBullet());
    }

    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
