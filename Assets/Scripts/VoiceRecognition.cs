using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> stringToAction = new Dictionary<string, Action>();
    private Vector3 newPosition;
    void Start()
    {
        newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        stringToAction.Add("forward", Forward);
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
        newPosition = transform.position + Camera.main.transform.forward * 2;
    }
    private void Back()
    {
        newPosition = transform.position - Camera.main.transform.forward * 2;
    }
    private void Right()
    {
        newPosition = transform.position + Camera.main.transform.right * 2;
    }
    private void Left()
    {
        newPosition = transform.position - Camera.main.transform.right * 2;
    }

    private void Update()
    {
        if ((transform.position.x != newPosition.x) && (transform.position.z != newPosition.z))
        {
            Debug.Log(newPosition.y);
            newPosition.y = 0.6f;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, 7.0f * Time.deltaTime);
        }
            
         
    }
}
