using UnityEngine;

namespace BzKovSoft.ObjectSlicer.Samples
{
	/// <summary>
	/// Mouse raycast to the object and slice it if hit
	/// </summary>
	public class SampleMouseSlicers : MonoBehaviour
	{
		void Update()
		{
			if (ControlFreak2.CF2Input.GetMouseButtonDown(0))
			{
				// if left mouse clicked, try slice this object

				Ray ray = Camera.main.ScreenPointToRay(ControlFreak2.CF2Input.mousePosition);
				RaycastHit[] hits = Physics.RaycastAll(ray, 100f);

				var sliceId = SliceIdProvider.GetNewSliceId();

				for (int i = 0; i < hits.Length; i++)
				{
					var sliceableA = hits[i].transform.GetComponentInParent<IBzSliceableNoRepeat>();

					Vector3 direction = Vector3.Cross(ray.direction, Camera.main.transform.right);
					Plane plane = new Plane(direction, ray.origin);

					if (sliceableA != null)
						sliceableA.Slice(plane, sliceId, null);
				}
			}
		}
	}
}