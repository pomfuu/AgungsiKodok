using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public static ParallaxBackground instance;
    public void Awake()
    {
        instance = this; 
    }

    private Transform theCam;
    public Transform sky, treeLine;
    [Range(0f, 1f)]
    public float parallaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {

    }

    public void MoveBackground()
    {
        sky.position = new Vector3(theCam.position.x, theCam.position.y, sky.position.z);
        treeLine.position = new Vector3(
            theCam.position.x * parallaxSpeed,
            theCam.position.y, 
            treeLine.position.z
            );
    }
}
