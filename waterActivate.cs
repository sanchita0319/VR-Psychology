using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterActivate : MonoBehaviour
{
    public AudioSource audio;
    public GameObject can;
    public static bool isWatering = false;
    public bool first;

    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        first = true;
        audio.volume = 0.1f;
    }
    //do people water quickly?
    IEnumerator waterStop()
    {
        while (audio.volume > 0.1)
        {
            yield return new WaitForSeconds(0.07f);
            audio.volume -= 0.01f;
        }
        audio.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        //print(can.transform.rotation.eulerAngles.x - 180);
        if (can.transform.rotation.eulerAngles.x - 180 < 0 && can.transform.rotation.eulerAngles.x - 180 > -170)
        {
            water.SetActive(true);
            isWatering = true;
            if(first)
            {
                audio.Play();
                audio.volume = 0.1f;
                first = false;
            }
            
        }
        else
        {
            water.SetActive(false);
            isWatering = false;
            StartCoroutine(waterStop());
            first = true;
        }

    }
}
