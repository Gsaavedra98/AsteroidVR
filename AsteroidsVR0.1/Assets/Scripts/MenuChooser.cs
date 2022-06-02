using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuChooser : MonoBehaviour
{
    public Material active;
    public Material normal;
    public Image dot;

    bool start;
    bool exit;
    bool restart;
    float count;
    Vector3 maxScale = new Vector3(2f, 2f, 2f);
    Vector3 minScale = new Vector3(1f, 1f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 10f))
        {
            if(hit.transform.gameObject.name == "Start")
            {
                dot.transform.localScale = Vector3.Lerp(dot.transform.localScale, maxScale, 1f * Time.deltaTime);
                
                start = true;
                if (start)
                {
                    count += .5f * Time.deltaTime;
                    if(count >= 1f)
                    {
                        SceneManager.LoadScene(1);
                    }
                }
            }
            if (hit.transform.gameObject.name == "Exit")
            {
                dot.transform.localScale = Vector3.Lerp(dot.transform.localScale, maxScale, 1f * Time.deltaTime);
                
                exit = true;
                if (exit)
                {
                    count += .5f * Time.deltaTime;
                    if (count >= 1f)
                    {
                        Application.Quit();
                    }
                }
            }
            if (hit.transform.gameObject.name == "Restart")
            {
                dot.transform.localScale = Vector3.Lerp(dot.transform.localScale, maxScale, 1f * Time.deltaTime);

                restart = true;
                if (restart)
                {
                    count += .5f * Time.deltaTime;
                    if (count >= 1f)
                    {
                        SceneManager.LoadScene(1);
                    }
                }
            }
        }
        else
        {
            dot.transform.localScale = Vector3.Lerp(dot.transform.localScale, minScale, 1f * Time.deltaTime);
            count = 0f;
        }
        
    }
}
