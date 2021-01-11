using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpiderTrialControl : MonoBehaviour
{
    public GameObject Return;
    public GameObject plant, pot, waterArea, panel; // PUT INT SPIDER AREA
    public Transform spot1, spot2, spot3;
    private Renderer rend;
    public Material red, blue;
    private Animator anim;

    public static int trial = 0;
    public static bool nextTrial = true;

    public static int numTrials = 24;
    int halfTrials = numTrials / 2;
    int thirdTrials = numTrials / 3;
    int fourthTrials = numTrials / 4;

    // public GameObject[] pots = new GameObject[numTrials];
    public List<bool> redOrBlue = new List<bool>();

    public List<int> rLocation = new List<int>();
    public List<int> bLocation = new List<int>();

    public List<bool> spidersAppear = new List<bool>();
    // Start is celled before the first frame update
    void Start()
    {
        anim = panel.GetComponent<Animator>();
        rend = pot.gameObject.GetComponent<Renderer>();
        //red OR blue
        for (int i = 0; i < numTrials; i++)
        {
            if (i < halfTrials) redOrBlue.Add(true);
            else redOrBlue.Add(false);
        }
        //red locations
        for (int i = 0; i < halfTrials; i++)
        {
            if (i < thirdTrials / 2) rLocation.Add(0);
            else if (i >= thirdTrials / 2 && i < thirdTrials) rLocation.Add(1);
            else if (i >= thirdTrials) rLocation.Add(2);
        }
        //blue locations
        bLocation.AddRange(rLocation);
        for (int i = 0; i < rLocation.Count; i++)
        {
            if (rLocation[i] == 0) ; // print("true");
            //else print(false);
        }
        //spidersAppear
        for (int i = 0; i < halfTrials; i++)
        {
            //if (i < fourthTrials) spidersAppear.Add(true);
            //else spidersAppear.Add(false);
        }
    }
    public void passTrial(int seed)
    {
        //spiderArea.SetActive(false);

        int chooseColor = (int)Random.Range(0.0f, redOrBlue.Count);
        int location;
        int appear;
        //red chosen
        if (redOrBlue[chooseColor])
        {
            rend.material = red;
            //choose random Location
            location = (int)Random.Range(0.0f, rLocation.Count);
            switch (rLocation[location])
            {
                case 0:
                    plant.transform.position = spot1.position;
                    //print("0");
                    break;
                case 1:
                    plant.transform.position = spot2.position;
                    //print("1");
                    break;
                case 2:
                    plant.transform.position = spot3.position;
                    /// print("2");
                    break;
            }
            rLocation.Remove(rLocation[location]);
        }

        //blue chosen 
        else
        {
            rend.material = blue;
            // print("blue");
            //choose random Location
            location = (int)Random.Range(0.0f, bLocation.Count);
            switch (bLocation[location])
            {
                case 0:
                    plant.transform.position = spot1.position;
                    //print("blue 0");
                    break;
                case 1:
                    plant.transform.position = spot2.position;
                    //print("blue 1");
                    break;
                case 2:
                    plant.transform.position = spot3.position;
                    //print("blue 2");
                    break;
            }

            appear = (int)Random.Range(0.0f, spidersAppear.Count);
            //CHANGE THE COLLIDER SIZE FOR HALF OF THESE TRIALS
            //if (spidersAppear[appear])
             //   spiderArea.SetActive(true);

            //else spiderArea.SetActive(false);
            //bLocation.Remove(bLocation[location]);
            //spidersAppear.Remove(spidersAppear[appear]);

        }
        redOrBlue.Remove(redOrBlue[chooseColor]);

    }
    //returning to the center
    private void OnTriggerEnter(Collider other)
    {
        if (nextTrial)
        {
            print("The status of nextTrial: " + nextTrial);
            nextTrial = false;
            waterTrigger.check = true;
            print("The Updated status of nextTrial: " + nextTrial);
            StartCoroutine(spiderTrialChange());


        }
    }

    IEnumerator spiderTrialChange()
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(1f);
        trial++;
        passTrial(trial);
        //spiders.SetActive(false);
        //Debug.Log("Next Trial" + nextTrial);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

        Return.SetActive(nextTrial);
        if (Input.GetKeyDown("space"))
        {
            anim.Play("FadeOut");
            //print(trial);
        }
        print("next trial: " + nextTrial);
    }
}
