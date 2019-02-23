using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class examp : MonoBehaviour {
    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));

        // Set some positions
        Vector3[] positions = new Vector3[2];
        positions[0] = new Vector3(0.0f, 4.0f, 0.0f);
        positions[1] = new Vector3(0.0f, 2.0f, 0.0f);
        //positions[2] = new Vector3(0.0f, -2.0f, 0.0f);
        lr.positionCount = positions.Length;
        lr.SetPositions(positions);
        GradientColorKey[] colorKeys = new GradientColorKey[3];

        colorKeys[0] = new GradientColorKey(Color.red, 0f);         //At 0% set to red
        colorKeys[1] = new GradientColorKey(Color.green, .5f);      //At 50% set to green
        colorKeys[2] = new GradientColorKey(Color.blue, 1f);        //At 100% set to blue

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0] = new GradientAlphaKey(1f, 0f);
        alphaKeys[1] = new GradientAlphaKey(1f, 1f);
        // A simple 2 color gradient with a fixed alpha of 1.0f.
        //float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(colorKeys, alphaKeys);
        lr.colorGradient = gradient;
    }
}
