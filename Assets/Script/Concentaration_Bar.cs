using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concentaration_Bar : MonoBehaviour {
    public Transform BarPosition;
    public float BarRange;
    public static float Bar_Range;
    // Use this for initialization
    void Start () {
        LineRenderer BarlineRenderer = gameObject.AddComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 UpVector = Vector3.up;// (0, 1, 0);
        //Vector3 m = Vector3.up;
        BarRange = TransformMapping.currentConcentrate;
        BarRange = BarRange / 2f;
        Bar_Range = BarRange;

        LineRenderer BarlineRenderer = GetComponent<LineRenderer>();
        if (BarRange >= 0.4f && BarRange < 0.5f)
        {
            UpVector *= ((((BarRange * 10) % 4) % 10) / 3f);
            Debug.Log(string.Format(" range: ") + BarRange + " YYYYYY: " + ((((BarRange * 10) % 4) % 10)) / 3f);
            Vector3[] positions = new Vector3[2];
            positions[0] = BarPosition.position;
            positions[1] = UpVector + BarPosition.position;

            Debug.Log(string.Format(" UpVector: ") + positions[1] + " BarPosition.position: " + BarPosition.position + " Range: " + (((BarRange * 10) % 4) % 10) / 3f);

            BarlineRenderer.positionCount = positions.Length;
            BarlineRenderer.SetPositions(positions);

            GradientColorKey[] colorKeys = new GradientColorKey[2];
            colorKeys[0] = new GradientColorKey(Color.blue, 0f);         //At 0% set to red
            colorKeys[1] = new GradientColorKey(Color.green, 1f);

            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0] = new GradientAlphaKey(1f, 0f);
            alphaKeys[1] = new GradientAlphaKey(1f, 1f);


            Gradient gradient = new Gradient();
            gradient.SetKeys(colorKeys, alphaKeys);
            BarlineRenderer.colorGradient = gradient;
        }
        else if (BarRange >= 0.5f && BarRange < 0.6f)
        {
            Vector3 MidVec = new Vector3(0, 0.3f, 0);
            Vector3 MidVector = MidVec + BarPosition.position;

            UpVector *= ((((BarRange * 10) % 5) % 10) / 3f);

            Vector3[] positions = new Vector3[3];
            positions[0] = BarPosition.position;
            positions[1] = MidVector;
            positions[2] = UpVector + MidVector;

            Debug.Log(string.Format(" MidVector: ") + positions[1] + " MidVec: " + positions[1] + " BarPosition.position: " + BarPosition.position);
            Debug.Log(string.Format(" UpVector: ") + positions[2] + " Range: " + (((BarRange * 10) % 5) % 10) / 3f);

            BarlineRenderer.positionCount = positions.Length;
            BarlineRenderer.SetPositions(positions);

            GradientColorKey[] colorKeys = new GradientColorKey[3];
            colorKeys[0] = new GradientColorKey(Color.blue, 0f);         //At 0% set to red
            colorKeys[1] = new GradientColorKey(Color.green, .5f);
            colorKeys[2] = new GradientColorKey(Color.yellow, 1f);


            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0] = new GradientAlphaKey(1f, 0f);
            alphaKeys[1] = new GradientAlphaKey(1f, 1f);


            Gradient gradient = new Gradient();
            gradient.SetKeys(colorKeys, alphaKeys);
            BarlineRenderer.colorGradient = gradient;
        }
        else if (BarRange >= 0.6f && BarRange < 0.7f)
        {
            Vector3 MidVec = new Vector3(0, 0.3f, 0);
            Vector3 MidVector = MidVec + BarPosition.position;
            Vector3 QuVec = new Vector3(0, 0.6f, 0);
            Vector3 QuVector = QuVec + BarPosition.position;

            UpVector *= ((((BarRange * 10) % 6) % 10) / 3f);

            Vector3[] positions = new Vector3[4];
            positions[0] = BarPosition.position;
            positions[1] = MidVector;
            positions[2] = QuVector;
            positions[3] = UpVector + QuVector;

            Debug.Log(string.Format(" MidVector: ") + positions[1] + " MidVec: " + positions[1] + " QuVector: " + positions[2] + " BarPosition.position: " + BarPosition.position);
            Debug.Log(string.Format(" UpVector: ") + positions[3] + " Range: " + (((BarRange * 10) % 6) % 10) / 3f);

            BarlineRenderer.positionCount = positions.Length;
            BarlineRenderer.SetPositions(positions);

            GradientColorKey[] colorKeys = new GradientColorKey[4];
            colorKeys[0] = new GradientColorKey(Color.blue, 0f);         //At 0% set to red
            colorKeys[1] = new GradientColorKey(Color.green, .3f);
            colorKeys[2] = new GradientColorKey(Color.yellow, .6f);
            colorKeys[3] = new GradientColorKey(Color.red, 1f);


            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0] = new GradientAlphaKey(1f, 0f);
            alphaKeys[1] = new GradientAlphaKey(1f, 1f);


            Gradient gradient = new Gradient();
            gradient.SetKeys(colorKeys, alphaKeys);
            BarlineRenderer.colorGradient = gradient;
        }
        else { }
        
    }
}
