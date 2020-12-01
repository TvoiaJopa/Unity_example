using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Ciontrol Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
	public const float baseSpeed = 6.0f;
	public float speed = 6.0f;
	private CharacterController _charController;
	public float gravity = -9.8f;
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);
		movement.y = gravity;
		
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
		
        
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

}
