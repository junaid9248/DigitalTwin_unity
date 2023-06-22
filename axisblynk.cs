using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class axisblynk : MonoBehaviour
{
    //public string url = "https://blynk.cloud/external/api/update?token=dmgTbJlV-BVjWDePZYVhIzEIyA5YZWJf&dataStreamId=9&value=";
    private string url2 = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=9&value=";
    public Slider mySlider;
    public Text myText;
   

    public void open()
    {
   
        StartCoroutine(GetUpdateRequest(url2));

    }

    IEnumerator GetUpdateRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.timeout = 60;

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();  
            Debug.Log("This is upload progress 2" + webRequest.uploadProgress);

        } 
       
      
    }

 
    // Start is called before the first frame update
    void Start()
    {  
        mySlider.onValueChanged.AddListener(delegate {
            RotateMe();

        });

    }


    public void RotateMe(){

        open();
        transform.localEulerAngles = new Vector3(0, -mySlider.value, 0); 
        myText.text = (mySlider.value).ToString();
       
        url2 = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=9&value=" + (mySlider.value + 3).ToString();
        Debug.Log("Axis 1:" + mySlider.value);

    }
        
    
}
