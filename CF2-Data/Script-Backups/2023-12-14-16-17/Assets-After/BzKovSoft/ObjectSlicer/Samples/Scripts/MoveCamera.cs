using UnityEngine;

namespace BzKovSoft.ObjectSlicer.Samples
{
	/// <summary>
	/// Camera movement controller
	/// </summary>
	public class MoveCamera : MonoBehaviour
	{
		public float TurnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
		public float MoveSpeed = 4.0f;      // Speed of the camera going back and forth

		private float yaw = 0f;
		private float pitch = 0f;

		void Update()
		{
			var camera = Camera.main.gameObject.transform;

			Vector3 move = Vector3.zero;
			if (ControlFreak2.CF2Input.GetKey(KeyCode.W))
				move += MoveSpeed / 100f * Vector3.forward;
			if (ControlFreak2.CF2Input.GetKey(KeyCode.S))
				move += MoveSpeed / 100f * Vector3.back;
			if (ControlFreak2.CF2Input.GetKey(KeyCode.A))
				move += MoveSpeed / 100f * Vector3.left;
			if (ControlFreak2.CF2Input.GetKey(KeyCode.D))
				move += MoveSpeed / 100f * Vector3.right;
			if (ControlFreak2.CF2Input.GetKey(KeyCode.Q))
				move += MoveSpeed / 100f * Vector3.down;
			if (ControlFreak2.CF2Input.GetKey(KeyCode.E))
				move += MoveSpeed / 100f * Vector3.up;

			if (ControlFreak2.CF2Input.GetKey(KeyCode.LeftShift))
				move *= 5;

			if (Mathf.Abs(move.sqrMagnitude) > Mathf.Epsilon)
				camera.Translate(move, Space.Self);

			if (ControlFreak2.CF2Input.GetMouseButton(1))
			{
				yaw += ControlFreak2.CF2Input.GetAxis("Mouse X");
				pitch -= ControlFreak2.CF2Input.GetAxis("Mouse Y");
				camera.eulerAngles = new Vector3(TurnSpeed * pitch, TurnSpeed * yaw, 0.0f);
			}
		}
	}
}