using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;



public class Asteroid : MonoBehaviour
{

    private Move move;
    public TextMeshProUGUI points;
    public static float point;
    public AudioSource audioS;
    public AudioClip destroy;
    // Start is called before the first frame update
    void Start()
    {

        float y = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10f;
        transform.Rotate(Vector3.forward * Random.Range(-1,1));
        
        if(transform.position.x >= 140f)
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
        points.text = point.ToString("0000");
        if(point >= 1000)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if(transform.localScale.x >= 4f)
            {
                for(int i = 0; i < 2; i++)
                {
                    GameObject asteroid = (GameObject)Instantiate(gameObject, new Vector3(transform.position.x + (float)i, transform.position.y, transform.position.z + (float)i), transform.rotation);
                    asteroid.transform.localScale -= new Vector3(2f, 2f, 2f);
                }
            }
            Destroy(gameObject);
            audioS.PlayOneShot(destroy);
            point += 100;
        }
    }

    
}

