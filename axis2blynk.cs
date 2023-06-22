using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class axis2blynk : MonoBehaviour
{
    //public string url = "https://blynk.cloud/external/api/update?token=dmgTbJlV-BVjWDePZYVhIzEIyA5YZWJf&dataStreamId=2&value=";
    private string url2 = "https://blynk.cloud/external/api/get?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=2&value=";
    // public Slider mySlider;
    public Slider myslider2;
    public Text myText1;  
    public GameObject myCube;
    // Start is called before the first frame update
    void Start()
    {
        myslider2.onValueChanged.AddListener(delegate{
            RotateMe();
        });
    }
    public void open()
    {
        
        StartCoroutine(GetRequest(url2));
    }
 
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
 
        }
    }

    // Update is called once per frame
    public void RotateMe(){
        myText1.text = myslider2.value.ToString();
        //url = "https://blynk.cloud/external/api/update?token=dmgTbJlV-BVjWDePZYVhIzEIyA5YZWJf&dataStreamId=2&value=" + (myslider2.value).ToString();
        url2 = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=2&value=" + (myslider2.value).ToString();
        open();
        Debug.Log(myslider2.value/2);
        // myCube.transform.Rotate(0,0,-myslider2.value);
        transform.localEulerAngles = new Vector3(0, 0, myslider2.value/2);
    }
}
