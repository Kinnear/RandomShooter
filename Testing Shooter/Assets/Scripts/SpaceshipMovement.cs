using UnityEngine;
using System.Collections;
using CnControls;

public class SpaceshipMovement : MonoBehaviour {

	float speed = 0.5f;

	public EnumManager.PLAYER playerType = EnumManager.PLAYER.PLAYER_1;

	private float minY = 0.0f;
	private float maxY = 0.0f;

	private string playerTouchpadX = "";
	private string playerTouchpadY = "";
	private string playerJoystickX = "";
	private string playerJoystickY = "";

	void Start()
	{
		if(playerType == EnumManager.PLAYER.PLAYER_1)
		{
			minY = 0.0f;
			maxY = 0.5f;

			playerTouchpadX = "PlayerOneMovementX";
			playerTouchpadY = "PlayerOneMovementY";

			playerJoystickX = "PlayerOneShootingX";
			playerJoystickY = "PlayerOneShootingY";
		}
		else if(playerType == EnumManager.PLAYER.PLAYER_2)
		{
			minY = 0.5f;
			maxY = 1.0f;

			playerTouchpadX = "PlayerTwoMovementX";
			playerTouchpadY = "PlayerTwoMovementY";

			playerJoystickX = "PlayerTwoShootingX";
			playerJoystickY = "PlayerTwoShootingY";
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Use the Touchpad to manipulate the position here
		transform.position += new Vector3(CnInputManager.GetAxis(playerTouchpadX) * Time.deltaTime * speed, CnInputManager.GetAxis(playerTouchpadY)  * Time.deltaTime * speed, 0.0f);
		transform.position = new Vector3(
				Mathf.Clamp(transform.position.x,
				Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, Camera.main.nearClipPlane)).x,
				Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, Camera.main.nearClipPlane)).x),


				Mathf.Clamp(transform.position.y,
				Camera.main.ViewportToWorldPoint(new Vector3(0.0f, minY, Camera.main.nearClipPlane)).y,
				Camera.main.ViewportToWorldPoint(new Vector3(1.0f, maxY, Camera.main.nearClipPlane)).y)

			, transform.position.z);

		// Use the Joystick to rotate the player around to fire projectiles
		transform.eulerAngles = new Vector3(0.0f, 0.0f, -Mathf.Rad2Deg * Mathf.Atan2(CnInputManager.GetAxis(playerJoystickX), CnInputManager.GetAxis(playerJoystickY)));
	}
}
