using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private Transform HeadTransform;
    public float PlayerSpeed;
    public int lives = 3;
    public float shootRate = 2f;
    public float nextShoot = 0f;
    public GameObject Bullet;
    private const float maxDistance = 25;
    public Image aim;
    public float charge;
    bool load;
    private Bullet bullet;

    public AudioSource audioS;
    public AudioClip shot;
    public AudioClip hurt;

    [SerializeField]
    private Sprite[] _spriteLives;

    [SerializeField]
    private Image _imageLives;
    // Start is called before the first frame update
    void Start()
    {
        HeadTransform = transform.Find("Main Camera");
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = new Vector3(HeadTransform.forward.x, 0f, HeadTransform.forward.z);
        forward.Normalize();
        
        transform.position += forward * Time.deltaTime * PlayerSpeed;
        
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

        _imageLives.sprite = _spriteLives[lives];

        RaycastHit Hit;
        if (Physics.Raycast(HeadTransform.position, HeadTransform.forward, out Hit, maxDistance))
        { 
            if(Hit.transform.gameObject.tag == "Asteroid" && Time.deltaTime <= 1f)
            {
                load = true;
            }
        }
        if (load)
        {
            charge += 1.7f * Time.deltaTime;
            if (charge >= 1)
            {
                charge = 0;
                Shoot();
                audioS.PlayOneShot(shot);
                load = false;
            }
        }
        aim.fillAmount = charge;
        if(lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            lives --;
            audioS.PlayOneShot(hurt);
        }
    }

    public void Shoot()
    {
        Vector3 forward = new Vector3(HeadTransform.forward.x, 0f, HeadTransform.forward.z);
        forward.Normalize();
        Ray ray = new Ray(HeadTransform.position, forward);
        Instantiate(Bullet, ray.GetPoint(1), Quaternion.LookRotation(forward));
    }

    
}
