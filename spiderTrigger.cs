using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderTrigger : MonoBehaviour
{
    public AudioSource audio; 
    public GameObject spiders;
    
    public static bool triggerHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator changeTrial()
    {

        yield return new WaitForSeconds(4f);
        TrialControl.nextTrial = true;
        Debug.Log(" Spiders Changed Bool!");
    }
    private void OnTriggerEnter(Collider other)
    {
        spiders.SetActive(true);
        audio.Play();
        StartCoroutine(changeTrial());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
