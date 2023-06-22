using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AXIS3BTOU : MonoBehaviour
{
    //private const string getURL = "https://blynk.cloud/external/api/get?token=dmgTbJlV-BVjWDePZYVhIzEIyA5YZWJf&dataStreamId=3&value=";
    private const string url2 = "https://blynk.cloud/external/api/get?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=3&value=";
    private int prev = 0;
    private int resp1 = 0;
    private string resp="0";

    public Slider mySlider;
    public Text myText;
    public GameObject myCube;

    // Start is called before the first frame update

    public void GenerateRequest()
    {
        StartCoroutine(ProcessRequest(url2));
    }

    private IEnumerator ProcessRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            request.timeout = 60;

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                //resp = request.downloadHandler.text;
                resp = request.downloadHandler.text;
                resp1 = int.Parse(resp);
                //Debug.Log("this is resp" + resp);


                if (prev != resp1)
                    Rotate();
                else
                    GenerateRequest();

            }
        }
    }

    public void Rotate(){
    
        mySlider.value = resp1;
        transform.localEulerAngles = new Vector3(0, 0, -mySlider.value);
    
        myText.text = resp1.ToString();

        prev = resp1;
        GenerateRequest();
    }

    // Update is called once per frame
    void Start()
    {
        GenerateRequest();
   
    }
}