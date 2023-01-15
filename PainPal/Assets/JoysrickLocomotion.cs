using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using OVR;

public class JoysrickLocomotion : MonoBehaviour
{
    public Rigidbody player;
    [SerializeField]
    public float speed=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var joysticAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
        float fixedY = player.position.y;

        player.position += (transform.right * joysticAxis.x + transform.forward * joysticAxis.y) * Time.deltaTime *
                           speed;
        player.position = new Vector3(player.position.x, fixedY, player.position.z);
    }
}
