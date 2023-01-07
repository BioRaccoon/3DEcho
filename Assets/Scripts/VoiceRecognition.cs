using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> stringToAction = new Dictionary<string, Action>();
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {

        newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        stringToAction.Add("walk", Forward);
        stringToAction.Add("left", Left);
        stringToAction.Add("right", Right);
        stringToAction.Add("back", Back);


        keywordRecognizer = new KeywordRecognizer(stringToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs recognizedKeyword)
    {
        Debug.Log(recognizedKeyword.text);
        stringToAction[recognizedKeyword.text].Invoke();
    }


    private void Forward()
    {
        //transform.Translate(0, 0, 1);
        Debug.Log("position" + transform.position);
        Debug.Log("camera.forward" + Camera.main.transform.forward);
        Debug.Log("time" + Time.deltaTime.ToString());

        newPosition = transform.position + Camera.main.transform.forward * 1;

        //transform.position = transform.position + Camera.main.transform.forward * 999999999 * Time.deltaTime;
        Debug.Log("position after calc" + transform.position);
    }
    private void Back()
    {

    }
    private void Right()
    {

    }
    private void Left()
    {

    }

    private void Update()
    {
        if ((transform.position.x != newPosition.x) && (transform.position.z != newPosition.z))
        {
            Debug.Log(newPosition.y);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, 5.0f * Time.deltaTime);
        }
            
         
    }
}
