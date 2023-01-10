using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> stringToAction = new Dictionary<string, Action>();
    private Vector3 newPosition;
    private bool keyword = false;

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
        InputSystem.DisableDevice(Keyboard.current);
        keyword = true;
        stringToAction[recognizedKeyword.text].Invoke();
    }


    private void Forward()
    {
        newPosition = transform.position + Camera.main.transform.forward * 2;
        this.gameObject.GetComponent<SoundWaves>().MyAction();
    }
    private void Back()
    {
        newPosition = transform.position - Camera.main.transform.forward * 2;
        this.gameObject.GetComponent<SoundWaves>().MyAction();
    }
    private void Right()
    {
        newPosition = transform.position + Camera.main.transform.right * 2;
        this.gameObject.GetComponent<SoundWaves>().MyAction();
    }
    private void Left()
    {
        newPosition = transform.position - Camera.main.transform.right * 2;
        this.gameObject.GetComponent<SoundWaves>().MyAction();
    }

    private void Update()
    {
        //if ((transform.position.x != newPosition.x) && (transform.position.z != newPosition.z))
        if ((transform.position.x != newPosition.x) && (transform.position.z != newPosition.z) && keyword)
        {
            Debug.Log(newPosition.y);
            newPosition.y = 0.6f;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, 7.0f * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, newPosition) < 0.1f)
        {
            keyword = false;
            InputSystem.EnableDevice(Keyboard.current);
        }
    }
}
