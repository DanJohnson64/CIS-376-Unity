using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    //starting position for parallax game object
    Vector2 startingPosition;

    //Starting Z value for parallax game object
    float startingZ;

    /*
        The syntax => in Unity means to update without being required to be written in the update function
    */

    //How far the camera has moved from the starting position
    Vector2 cameraMoveSinceStart => (Vector2) cam.transform.position - startingPosition;

    // Distance this layer is from the target in Z value
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    // Decides which clipping plane to use from the Camera
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // Decides the strength of the parallax effect 
    float parallaxFactor => MathF.Abs(zDistanceFromTarget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //When the target moves, move the parallax object the same distance times a multiplier
        Vector2 newPosition = startingPosition + cameraMoveSinceStart * parallaxFactor;

        //The X/Y position changes based on target travel speed times the parallax factor, but Z stays the same
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
