using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class TargetShooterScript : MonoBehaviour
{   
    //get access to camera for raytracing (raycast)
    [SerializeField] Camera cam;

    [SerializeField] Text scoreText;

    private float score = 0f;

    void Update(){
        //GetMouseButtonDown(0) is for the left mouse button
        if (Input.GetMouseButtonDown(0)) {
            // think of a box in the first quadrant of a math grid (x,y)
            // top left point is 0,1
            // top right point is 1,1
            // bottom left point is 0,0
            // bottom right point is 1,0
            // middle of screen is 0.5, 0.5
            Ray shotRay = cam.ViewportPointToRay(new Vector3(0.5f,0.5f));
            if (Physics.Raycast(shotRay, out RaycastHit hit)) {
                //gets targetscript from object we hit 
                TargetScript target = hit.collider.gameObject.GetComponent<TargetScript>();
                
                //if what we hit was a valid target (target component) and therefore returned a script to the object, then destroy the object
                if (target != null) {
                    // Hit() function made in TargetScript.cs
                    target.Hit();
                    score += 1;
                    //update scoreText each time a target is hit
                    scoreText.text = "Score: " + score.ToString();
                }
            }
        }

    }


}
