using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class gb : MonoBehaviour
{
    //public string url = "https://blynk.cloud/external/api/update?token=dmgTbJlV-BVjWDePZYVhIzEIyA5YZWJf&dataStreamId=5&value=";
    public string url2 = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=5&value=";

    // public Slider mySlider;
    public Slider myslider2;
    public Text myText;  
    public GameObject myCube;
    [SerializeField] float actualValue;
    [SerializeField] float displayValue;
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
            Debug.Log("This is upload progress " + webRequest.uploadProgress);

        }
    }

    // Update is called once per frame
    public void RotateMe(){
        //myText.text = myslider2.value.ToString();
        actualValue = -92 + (myslider2.value);
        displayValue = (92 + actualValue);
        myText.text = displayValue.ToString();
        
        url2 = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=5&value=" + myslider2.value.ToString();
        open();

        
        transform.localEulerAngles = new Vector3(0, 0, actualValue);
    }
}
