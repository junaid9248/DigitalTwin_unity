using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class axis4_BtoU : MonoBehaviour
{
    //private string getURL = "https://blynk.cloud/external/api/get?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=4&value=";
    private string url2 = "https://blynk.cloud/external/api/get?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=4&value=";

    private string resp = "0";
    private int prev = 0;
    private int resp1 = 0;

    public GameObject myCube;
    public Slider mySlider;
    public Text myText;
    private float diff;
    private int flag = 0;

    // Start is called before the first frame update

    public void GenerateRequest()
    {
        StartCoroutine(ProcessRequest(url2));
    }

    private IEnumerator ProcessRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url2))
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
                Debug.Log("this is resp" + resp);


                if (prev != resp1)
                    Rotate();
                else
                    GenerateRequest();

            }
        }
    }

    public void Rotate()
    {
        mySlider.value = resp1;
        if (resp1 > prev)
        {
            diff = resp1-prev;
        }
        if (prev > resp1)
        {
            diff = prev - resp1;
            flag = 1;
        }
        Debug.Log("This is the difference" + diff);


        if (diff >= 1)
        {
            if (flag == 0)
            {
                transform.RotateAround(transform.position, transform.right, - ((resp1) * Time.deltaTime));
                prev = resp1;
                Debug.Log("This is the previous value" + prev);
            }
            if (flag == 1)
            {
                transform.RotateAround(transform.position, transform.right,  ((resp1) * Time.deltaTime));
                prev = resp1;
                Debug.Log("This is the previous value" + prev);
                flag = 0;
            }
        }
        myText.text = resp1.ToString();

        GenerateRequest();

    }

    // Update is called once per frame
    void Start()
    {
        GenerateRequest();
  
    }
}