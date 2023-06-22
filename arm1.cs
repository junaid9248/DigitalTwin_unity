using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class arm1 : MonoBehaviour
{
    //public string url = "https://blynk.cloud/external/api/update?token=dmgTbJlV-BVjWDePZYVhIzEIyA5YZWJf&dataStreamId=3&value=";
    private string url2 = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=3&value=";
    // public Slider mySlider;
    public Slider myslider2;
    public Text myText;  
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
            webRequest.timeout = 60;

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            Debug.Log("This is upload progress 3 " + webRequest.uploadProgress);

        }

    }

    // Update is called once per frame
    public void RotateMe(){
        myText.text = myslider2.value.ToString();
        //url = "https://blynk.cloud/external/api/update?token=dmgTbJlV-BVjWDePZYVhIzEIyA5YZWJf&dataStreamId=3&value=" + myslider2.value.ToString();
        url2 = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=3&value=" + myslider2.value.ToString();
        open();
        Debug.Log(myslider2.value);
        // myCube.transform.Rotate(0,0,-myslider2.value);
        transform.localEulerAngles = new Vector3(0, 0, -myslider2.value);
    }
}
