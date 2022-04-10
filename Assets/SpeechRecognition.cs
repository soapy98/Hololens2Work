using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class SpeechRecognition : MonoBehaviour, IMixedRealitySpeechHandler
{
    public GameObject cable;
    public GameObject controller;
    public ColorChange col;
    public GameObject end;
    public Vector3 origPos;
    // Start is called before the first frame update
    void Start()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealitySpeechHandler>(this);
        col = cable.GetComponent<ColorChange>();
        origPos = cable.transform.position;
    }
    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        float step = 2 * Time.deltaTime;
        switch (eventData.Command.Keyword.ToLower())
        {
            case "clockwise":
                cable.transform.position = Vector3.MoveTowards(cable.transform.position, end.transform.position, step);
                controller.transform.Rotate(0, 0, 1000 * Time.deltaTime);
                controller.GetComponent<ColorChange>().OnEyeGaze();
                break;
            case "anticlockwise":
                cable.transform.position = Vector3.MoveTowards(cable.transform.position, origPos, step);
                controller.transform.Rotate(0, 0, -1000 * Time.deltaTime);
                controller.GetComponent<ColorChange>().OffEyeGaze();
                break;
            case "hello":

                Debug.Log("Hello World");

                break;

            default:

                Debug.Log($"Unkown Option{eventData.Command.Keyword}");

                break;

        }

    }
}
