using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrigger : MonoBehaviour
{
    // public static bool triggerHit = false;
    // Start is called before the first frame update
    public static bool check;
    void Start()
    {
        check = true;
    }
    IEnumerator changeTrial()
    {
        yield return new WaitForSeconds(4f);
        TrialControl.nextTrial = true;
        Debug.Log("Watering Changed Bool!");
    }
    private void OnTriggerStay(Collider other)
    {
        print("inside the collider");
        if (waterActivate.isWatering && check)
        {
            check = false;
            StartCoroutine(changeTrial());   
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
