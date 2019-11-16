using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 8f;
	private Rigidbody rbody;
	private Character character;
	//private Animator animator;
	public float mouseSensitivity = 1f;
	void Start()
	{
		rbody = GetComponent<Rigidbody>();
		character = GetComponent<Character>();
		//animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (rbody.velocity.x != 0 || rbody.velocity.z != 0)
		{
			//animator.SetBool("isRunning", true);
			//footstepsAS.UnPause();
		}
		else
		{
			//animator.SetBool("isRunning", false);
			//footstepsAS.Pause();
		}
	}

	public void Move(float vertical, float horizontal)
	{
		Vector3 newVelocity = transform.forward * vertical * speed + transform.right * horizontal * speed;
		newVelocity.y = rbody.velocity.y;
		rbody.velocity = newVelocity;
		//footstepsAS.pitch = 0.8f;
		//animator.speed = 1;
	}

	public void CharacterAction()
	{
		character.Action();
	}
}
