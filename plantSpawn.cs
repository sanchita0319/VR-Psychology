using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantSpawn : MonoBehaviour
{
    public GameObject targetPlant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Plant area entered");
       // Debug.Log(other.name);
        //Target.SetActive(true); // the method .SetActive(false) makes a gameObject disappear
        if (other.tag == "Player")
        {

            Debug.Log("player has entered plant trigger");
            targetPlant.SetActive(true); // the method .SetActive(false) makes a gameObject disappear
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
