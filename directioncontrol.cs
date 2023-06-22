using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class directioncontrol : MonoBehaviour
{
   
    [SerializeField] Behaviour blynk_to_unity;
    [SerializeField] Behaviour unity_to_blynk;
    //private string controlurl = "https://blynk.cloud/external/api/get?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=8&value=";
    private string updateControlurl = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=8&value=";
    private string getControlurl = "https://blynk.cloud/external/api/get?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=8&value=";
    private string resp="0";
    private int control1; 
    private bool tog=true;   
    [SerializeField] GameObject toggler;

   

    public void open()
    {
        StartCoroutine(GetRequest(updateControlurl));
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
           

        }
    }
    

    public void userToggle(bool tog)
    {
        open();
        if (tog == true)
        {
            
            blynk_to_unity.enabled = false;
            unity_to_blynk.enabled = true;

            updateControlurl = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=8&value=" + "1";
            open();
        }
        else
        {
         
            unity_to_blynk.enabled = false;
            blynk_to_unity.enabled = true;

            updateControlurl = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=8&value=" + "0";
            open();

        }
       


    }

   public void blynkToggle(bool tog)
    {
        if (tog == true)
        {
            blynk_to_unity.enabled = false;
            unity_to_blynk.enabled = true;

        }
        else
        {
            unity_to_blynk.enabled = false;
            blynk_to_unity.enabled = true;

        }
        //open();
    }





    void Start()
    {
    
        open();
        /*if (tog == true)
        {
            blynk_to_unity.enabled = false;
            unity_to_blynk.enabled = true;  

        }
        else
        {
            unity_to_blynk.enabled = false;
            blynk_to_unity.enabled = true;

        }*/

    }

    // Update is called once per frame
    void Update()
    {
        //open();
        //contfun();

    }
}
