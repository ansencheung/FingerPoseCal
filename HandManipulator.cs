using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using UnityEngine;

public class HandManipulator : MonoBehaviour
{
    public Transform hand;

    // public Finger indexAngles;
    // public Finger middleAngles;
    // public Finger ringAngles;
    // public Finger pinkyAngles;
    // public Thumb thumbAngles;

    [Range(-45f,45f)]
    public float[] indexAngles = new float[]{0,0,0,0};
    [Range(-45f,45f)]
    public float[] middleAngles = new float[]{0,0,0,0};
    [Range(-45f,45f)]
    public float[] ringAngles = new float[]{0,0,0,0};
    [Range(-45f,45f)]
    public float[] pinkyAngles = new float[]{0,0,0,0};
    [Range(-45f,45f)]
    public float[] thumbAngles = new float[]{0,0,0};


    Transform index;
    Transform middle;
    Transform ring;
    Transform pinky;
    Transform thumb;


    // [Serializable]
    // public class Thumb{
    //     public float meta;
    //     public float proximal;
    //     public float distal;
    // }

    // [Serializable]
    // public class Finger{
    //     public float meta;
    //     public float proximal;
    //     public float intermediate;
    //     public float distal;
    // }

    private String[] names = new string[] {"meta", "proximal", "intermediate", "distal"};

    // Start is called before the first frame update
    void Start()
    {

        // index = hand.Find("L_Wrist/L_IndexMetacarpal");
        // middle = hand.Find("L_Wrist/L_MiddleMetacarpal");
        // ring = hand.Find("L_Wrist/L_RingMetacarpal");
        // pinky = hand.Find("L_Wrist/L_LittleMetacarpal");
        // thumb = hand.Find("L_Wrist/L_ThumbMetacarpal");
            index = hand.Find("L_IndexMetacarpal/L_IndexProximal");
            Debug.Log(index != null ? "Index joint found!" : "Index joint not found!");

            middle = hand.Find("L_MiddleMetacarpal/L_MiddleProximal");
            Debug.Log(middle != null ? "Middle joint found!" : "Middle joint not found!");

            ring = hand.Find("L_RingMetacarpal/L_RingProximal");
            Debug.Log(ring != null ? "Ring joint found!" : "Ring joint not found!");

            pinky = hand.Find("L_LittleMetacarpal/L_LittleProximal");
            Debug.Log(pinky != null ? "Pinky joint found!" : "Pinky joint not found!");

            thumb = hand.Find("L_ThumbMetacarpal/L_ThumbProximal");
            Debug.Log(thumb != null ? "Thumb joint found!" : "Thumb joint not found!");
            indexAngles = new float[] { -45f, -45f, -45f, 0f }; // Index finger
            middleAngles = new float[] { -45f, -45f, -45f, 0f }; // Middle finger
            ringAngles = new float[] { -45f, -45f, -45f, 0f };    // Ring finger
            pinkyAngles = new float[] { -45f, -45f, -45f, 0f };   // Pinky finger
            thumbAngles = new float[] { -45f, -45f, 0f };      // Thumb
    }

    // Update is called once per frame
    void Update()
    {   
        updateFinger(index, indexAngles);
        updateFinger(middle, middleAngles);
        updateFinger(ring, ringAngles);
        updateFinger(pinky, pinkyAngles);
        updateFinger(thumb, thumbAngles);

        
    }

    public void updateFinger(Transform meta,float[] angles ){
        Transform joint = meta.transform;
        for (int i = 0; i < angles.Length-1; i++){
            joint.rotation = Quaternion.Euler(angles[i],0,0);
            joint = joint.GetChild(0);
        }
    }

    public void updateHand(float[] thumb,
                        float[] index,
                        float[] middle,
                        float[] ring,
                        float[] pinky)
    {
        indexAngles = index;
        middleAngles = middle;
        ringAngles = ring;
        pinkyAngles = pinky;
        thumbAngles = thumb;
    }

}
