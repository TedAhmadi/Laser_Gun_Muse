using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.VR;
using UnityEngine.XR;

public class HandGunDamage : MonoBehaviour {

    [SerializeField] public static Vector3 corsurePosition, tempPosition, currentPosition;

    [SerializeField] public static Vector3 head;

    [SerializeField] public static Vector3 corsureRotation;

    //Spawn_Cube SpawnCube;
    AudioSource gunsound;
    public float LaserGunRange;
    
    void start()
    {
        //SpawnCube = new Spawn_Cube();

        //randTarget = Random.Range(0, 9);
        //randTarget1 = Random.Range(0, 9);
        //randTarget2 = Random.Range(0, 9);

        gunsound = new AudioSource();
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

    void Update () {

        gunsound = GetComponent<AudioSource>();
        corsurePosition = transform.position ;
        tempPosition = transform.position;

        corsurePosition = InputTracking.GetLocalPosition(XRNode.RightHand);
        head = InputTracking.GetLocalPosition(XRNode.Head);

        //corsurePosition += new Vector3(0f,0f,.3f);

        corsureRotation.x = InputTracking.GetLocalRotation(XRNode.RightHand).eulerAngles.x;
        corsureRotation.y = InputTracking.GetLocalRotation(XRNode.RightHand).eulerAngles.y;
        corsureRotation.z = InputTracking.GetLocalRotation(XRNode.RightHand).eulerAngles.z;

        Vector3 UpVector = Quaternion.Euler(corsureRotation) * Vector3.forward;

        Vector3 MidcorsureVec = UpVector / 5f;
        corsurePosition += MidcorsureVec;
        Debug.Log(string.Format(" UpVectorUpVector: ") + UpVector);

        currentPosition = corsurePosition + tempPosition;
        LaserGunRange = TransformMapping.currentConcentrate;

        //forwardVector *= LaserGunRange;
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        //Vector3 UpVector = Vector3.up;// (0, 1, 0);


        if (Concentaration_Bar.Bar_Range >= 0.4f && Concentaration_Bar.Bar_Range < 0.5f)
        {
            UpVector *= ((((Concentaration_Bar.Bar_Range * 10) % 4) % 10) / 3f);
            
            Vector3[] positions = new Vector3[2];
            positions[0] = currentPosition;
            positions[1] = UpVector + currentPosition;

            lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);

            GradientColorKey[] colorKeys = new GradientColorKey[2];
            colorKeys[0] = new GradientColorKey(Color.blue, 0f);         //At 0% set to red
            colorKeys[1] = new GradientColorKey(Color.green, 1f);

            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0] = new GradientAlphaKey(1f, 0f);
            alphaKeys[1] = new GradientAlphaKey(1f, 1f);

            Gradient gradient = new Gradient();
            gradient.SetKeys(colorKeys, alphaKeys);
            lineRenderer.colorGradient = gradient;
        }
        else if (Concentaration_Bar.Bar_Range >= 0.5f && Concentaration_Bar.Bar_Range < 0.6f)
        {
            Vector3 MidforVec = UpVector / 6f;
            //Vector3 MidVec = new Vector3(0, 0.3f, 0);
            Vector3 MidVector =  MidforVec + currentPosition;

            UpVector *= ((((Concentaration_Bar.Bar_Range * 10) % 5) % 10) / 3f);

            Vector3[] positions = new Vector3[3];
            positions[0] = currentPosition;
            positions[1] = MidVector;
            positions[2] = UpVector + MidVector;

            lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);

            GradientColorKey[] colorKeys = new GradientColorKey[3];
            colorKeys[0] = new GradientColorKey(Color.blue, 0f);         //At 0% set to red
            colorKeys[1] = new GradientColorKey(Color.green, .5f);
            colorKeys[2] = new GradientColorKey(Color.yellow, 1f);

            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0] = new GradientAlphaKey(1f, 0f);
            alphaKeys[1] = new GradientAlphaKey(1f, 1f);

            Gradient gradient = new Gradient();
            gradient.SetKeys(colorKeys, alphaKeys);
            lineRenderer.colorGradient = gradient;
        }
        else if (Concentaration_Bar.Bar_Range >= 0.6f && Concentaration_Bar.Bar_Range < 0.7f)
        {
            //Vector3 MidVec = new Vector3(0, 0.3f, 0);
            Vector3 MidforVec = UpVector / 6f;
            Vector3 MidVector = MidforVec + currentPosition;
            //Vector3 QuVec = new Vector3(0, 0.6f, 0);
            Vector3 QuforVec = UpVector / 3f;
            Vector3 QuVector = QuforVec + currentPosition;

            UpVector *= ((((Concentaration_Bar.Bar_Range * 10) % 6) % 10) / 3f);

            Vector3[] positions = new Vector3[4];
            positions[0] = currentPosition;
            positions[1] = MidVector;
            positions[2] = QuVector;
            positions[3] = UpVector + QuVector;

            lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);

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
            lineRenderer.colorGradient = gradient;
        }
        else { }

        //lineRenderer.SetPosition(0, currentPosition);
        //lineRenderer.SetPosition(1, forwardVector + currentPosition);
        //Debug.Log(string.Format(" LaserGunRange: ") + LaserGunRange);
        RaycastHit Shot;
        if (Physics.Raycast(currentPosition, UpVector, out Shot, LaserGunRange))
        {
            TargetScore10 target1 = Shot.transform.GetComponent<TargetScore10>();
            TargetScore20 target2 = Shot.transform.GetComponent<TargetScore20>();
            TargetScore30 target3 = Shot.transform.GetComponent<TargetScore30>();
            TargetScore40 target4 = Shot.transform.GetComponent<TargetScore40>();
            TargetScore50 target5 = Shot.transform.GetComponent<TargetScore50>();
            TargetScore60 target6 = Shot.transform.GetComponent<TargetScore60>();
            TargetScore70 target7 = Shot.transform.GetComponent<TargetScore70>();
            TargetScore80 target8 = Shot.transform.GetComponent<TargetScore80>();
            TargetScore90 target9 = Shot.transform.GetComponent<TargetScore90>();
            TargetScore100 target10 = Shot.transform.GetComponent<TargetScore100>();

            Rigidbody hit = Shot.transform.GetComponent<Rigidbody>();


            //Debug.Log(string.Format(" actTarget: ") + randTarget+"   "+ randTarget1 + "   "+ randTarget2);
            if (target1 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target1.transform.position, 5.0f, 3.0f); target1.Die(ActTarget.actTarget); }
            else if (target2 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target2.transform.position, 5.0f, 3.0f); target2.Die(ActTarget.actTarget); }
            else if (target3 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target3.transform.position, 5.0f, 3.0f); target3.Die(ActTarget.actTarget); }
            else if (target4 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target4.transform.position, 5.0f, 3.0f); target4.Die(ActTarget.actTarget); }
            else if (target5 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target5.transform.position, 5.0f, 3.0f); target5.Die(ActTarget.actTarget); }
            else if (target6 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target6.transform.position, 5.0f, 3.0f); target6.Die(ActTarget.actTarget); }
            else if (target7 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target7.transform.position, 5.0f, 3.0f); target7.Die(ActTarget.actTarget); }
            else if (target8 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target8.transform.position, 5.0f, 3.0f); target8.Die(ActTarget.actTarget); }
            else if (target9 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target9.transform.position, 5.0f, 3.0f); target9.Die(ActTarget.actTarget); }
            else if (target10 != null)
            { gunsound.Play(); hit.AddExplosionForce(-1000.0f, target10.transform.position, 5.0f, 3.0f); target10.Die(ActTarget.actTarget); }
            else { }
        }       
	}
}
