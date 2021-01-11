using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PsychTrials : MonoBehaviour
{
    private int colorIndex = 0;
    private int appearIndex = 0;

    public GameObject spiders; // this is how you allow scritps to reference gameobjects in your Unity project.
    public bool blueScene = true;
    public bool[] redOrBlue = new bool[24]; //needs to be randomly assorted
    public bool[] spidersAppearOrNot = new bool[12]; //need to be randomly assorted
    private bool spidersAppear = true;

    public GameObject pot;
    Renderer rend;
    public Material blue;
    public Material red;

    public GameObject player;
    public Transform start;

    public GameObject anim_obj;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = anim_obj.GetComponent<Animator>();

        rend = pot.gameObject.GetComponent<Renderer>();

        for(int i = 0; i < 12; i++)
        {
            redOrBlue[i] = true;
        }

        for(int i = 0; i < 6; i++)
        {
            spidersAppearOrNot[i] = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Spider trigger has been partially entered");
        //Target.SetActive(true); // the method .SetActive(false) makes a gameObject disappear
        if (other.tag == "water")
        {
            Debug.Log("Spider trigger has been entered");
            if(spidersAppear)
            {
                spiders.SetActive(true); // the method .SetActive(false) makes a gameObject disappear
                StartCoroutine(changePotScene());
            }
         
        }
    }


    IEnumerator changePotScene()
    {
        yield return new WaitForSeconds(2f);
        anim.Play("blackout");
        yield return new WaitForSeconds(2f);
        spiders.SetActive(false);

        if (redOrBlue[colorIndex])
        {
            //SceneManager.LoadScene("Red Pot");
            print("Red scene loaded");
            spidersAppear = false;
            rend.material = red;
            resetPlayer();
            colorIndex++;

        }

        else
        {
           // BlueSene
            print("Blue scene loaded");
            //still need to modify whether spiders appear
            rend.material = blue;
            resetPlayer();
            colorIndex++;
        }
        print("here");
        yield return new WaitForSeconds(1f);
        anim.Play("fadein");
    }

    void resetPlayer()
    {
        player.transform.position = start.position;
    }

    void Update()
    {
        
    }
}
