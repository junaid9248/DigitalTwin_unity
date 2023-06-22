using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class gripper : MonoBehaviour
{
    private string url = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=6&value=";
    public Slider slider;
    public Text mytext;
    
    public GameObject gearRIGHT;
    public GameObject linkRIGHT;
    public GameObject geartogripRIGHT;
    public GameObject targetRIGHT;

    public GameObject gearLEFT;
    public GameObject linkLEFT;
    public GameObject geartogripLEFT;
    public GameObject targetLEFT;



    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(delegate {

            movement();
 
        });

    }

    // Update is called once per frame
    /*void Update()
    {
        movement();

    }*/

    public void open()
    {
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.timeout = 60;

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            Debug.Log("This is gripper upload progress: " + webRequest.uploadProgress);
        }
       
    }


    void gripperRotate(Quaternion targetvectorRIGHT, Quaternion targetvectorLEFT)
    {


        geartogripRIGHT.transform.rotation = Quaternion.Slerp(geartogripRIGHT.transform.rotation, targetvectorRIGHT, 1f);
        geartogripLEFT.transform.rotation = Quaternion.Slerp(geartogripLEFT.transform.rotation , targetvectorLEFT, 1f);

    }

    void movement()
    {
        open();
        mytext.text = (slider.value*3).ToString();
        url = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=6&value=" + (slider.value*3).ToString();
        
        
        //Quaternion currentRotationQ = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        //Quaternion.AngleAxis(180, Vector3.down);

        gearRIGHT.transform.localEulerAngles = new Vector3(0, 60-slider.value, 0);
        linkRIGHT.transform.localEulerAngles = new Vector3(0, 60-slider.value, 0);
        
        gearLEFT.transform.localEulerAngles =  new Vector3(0, -(60-slider.value), 0);
        linkLEFT.transform.localEulerAngles =  new Vector3(0, -(60-slider.value), 0);
        
        Vector3 vectorRIGHT = (targetRIGHT.transform.position - geartogripRIGHT.transform.position).normalized;
        Vector3 vectorLEFT = (targetLEFT.transform.position - geartogripLEFT.transform.position).normalized;


        //Converting vector3 angles to quaternion for interpolation
        Quaternion targetvectorRIGHT = Quaternion.Euler(vectorRIGHT);
        Quaternion targetvectorLEFT  = Quaternion.Euler(vectorLEFT);

        gripperRotate(targetvectorRIGHT, targetvectorLEFT);

        /*slider.onValueChanged.AddListener(delegate {
          
               gripperRotate(targetvectorRIGHT, targetvectorLEFT);

        });*/

    }
     

  
}



  
