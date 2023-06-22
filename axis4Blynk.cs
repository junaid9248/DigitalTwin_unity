using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class axis4Blynk : MonoBehaviour
{
    //public string url = "https://blynk.cloud/external/api/update?token=dmgTbJlV-BVjWDePZYVhIzEIyA5YZWJf&dataStreamId=4&value=";
    public string url2 = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=4&value=";
    public Slider mySlider;
    public Text myText;

    private float currentValue;
    private float previousValue= 0;
    private float diff;
    private int flag=0;
  
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
    public void RotateMe()
    { 
        open();
        currentValue = mySlider.value;
        Debug.Log("This is the current value" + currentValue);
        myText.text = mySlider.value.ToString();

        //url = "https://blynk.cloud/external/api/update?token=dmgTbJlV-BVjWDePZYVhIzEIyA5YZWJf&dataStreamId=4&value=" + (currentValue).ToString();
        url2 = "https://blynk.cloud/external/api/update?token=rg6ChEpH3GltPTbjgPxEOxpQeGsZ5Wrm&dataStreamId=4&value=" + (currentValue).ToString();

        if(currentValue>previousValue) {
            diff= currentValue - previousValue;
            
            transform.RotateAround(transform.position, transform.right, -((previousValue + diff) * Time.deltaTime));
            previousValue = this.currentValue;
            Debug.Log("This is the previous value: "+ previousValue +"This is the difference" + diff);
        }
        else{
            diff = previousValue-currentValue;
            transform.RotateAround(transform.position, transform.right, ((previousValue - diff) * Time.deltaTime));
            previousValue = this.currentValue;
            Debug.Log("This is the previous value: "+ previousValue +"This is the difference" + diff);
        }
        /*if (this.currentValue>previousValue)
        {
            diff= this.currentValue - previousValue;
        }
        
        /*if(previousValue==0){
            transform.RotateAround(transform.position, transform.right, -((diff) * Time.deltaTime));
             Debug.Log("This is the previous value: "+ previousValue +"This is the difference" + diff);
        }  
       
        if(this.currentValue>previousValue) {
            diff= this.currentValue - previousValue;
            
            transform.RotateAround(transform.position, transform.right, -((previousValue + diff) * Time.deltaTime));
            previousValue = this.currentValue;
            Debug.Log("This is the previous value: "+ previousValue +"This is the difference" + diff);
        }
        if(previousValue>this.currentValue){
            diff= previousValue-this.currentValue;
            transform.RotateAround(transform.position, transform.right, ((previousValue - diff) * Time.deltaTime));
            previousValue = this.currentValue;
             Debug.Log("This is the previous value: "+ previousValue +"This is the difference" + diff);
        }*/



/*if(previousValue>this.currentValue){
            diff= previousValue-this.currentValue;
            //flag=1;
        }*/
      




        /*if (diff >= 1)
        {
            if(flag==0){
            transform.RotateAround(transform.position, transform.right, - 2*((this.currentValue) * Time.deltaTime));
            previousValue = this.currentValue;
            Debug.Log("This is the previous value" +previousValue);
            }
            if(flag==1){
                transform.RotateAround(transform.position, transform.right, 2*((this.currentValue)* Time.deltaTime));
            previousValue = this.currentValue;
            Debug.Log("This is the previous value" + previousValue);
            flag=0;
            }
        }*/

    } 
  
   void Start()
    {
        //Debug.Log(previousValue);
        
        mySlider.onValueChanged.AddListener(delegate{
            
           RotateMe();
           
        });

    }


}