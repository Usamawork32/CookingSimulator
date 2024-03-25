using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BzKovSoft.ObjectSlicer.Samples
{
   
    public class SampleMouseSlicer : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public AudioSource Audio;
        public List<AudioClip> Auidos;
        public Transform CuttingDish, Raycast, Raycast1, Raycast2, Raycast3, Raycast4, Raycast5, Raycast6, Raycast7, Raycast8, Raycast9,Kniefrotate;
        public Camera mainCamera;
        public GameObject RotateButton, RotateButton1;
        public GameObject Cutbtn,ResetCutbtn;
        private bool input = true;
        private Vector3 initialPosition;
        Vector3 CuttingCotouineposition,hitpoint;

        private void Start()
        {
            ResetCutbtn.SetActive(true);
            RotateButton.SetActive(true);
            RotateButton1.SetActive(true);
        }
        private void Update()
        {
            //First RayCast
            RaycastHit hit1;
            if (Physics.Raycast(Raycast.position , -Raycast.up, out hit1, 1))
            {
                Debug.DrawRay(Raycast.position , -Raycast.up * hit1.distance, Color.white);
                lineRenderer.SetPosition(0, hit1.point + new Vector3(0, 0.03f, 0));
            }
            //Second RayCast
            RaycastHit hit2;
            if (Physics.Raycast(Raycast1.position, -Raycast1.up, out hit2, 1))
            {
                Debug.DrawRay(Raycast1.position, -Raycast1.up * hit1.distance, Color.red);
                lineRenderer.SetPosition(1, hit2.point + new Vector3(0, 0.03f, 0));
            }
            RaycastHit hit10;
            if (Physics.Raycast(Raycast2.position, -Raycast2.up, out hit10, 1))
            {
                Debug.DrawRay(Raycast2.position, -Raycast2.up * hit1.distance, Color.red);
                lineRenderer.SetPosition(2, hit10.point + new Vector3(0, 0.03f, 0));
            }
            //Third RayCast
            RaycastHit hit3;
            if (Physics.Raycast(Raycast3.position, -Raycast3.up, out hit3, 1))
            {
                Debug.DrawRay(Raycast3.position, -Raycast3.up * hit3.distance, Color.red);
                lineRenderer.SetPosition(3, hit3.point + new Vector3(0, 0.03f, 0));
            }
            //fourth RayCast
            RaycastHit hit4;
            if (Physics.Raycast(Raycast4.position, -Raycast4.up, out hit4, 1))
            {
                Debug.DrawRay(Raycast4.position, -Raycast4.up * hit4.distance, Color.green);
                lineRenderer.SetPosition(4, hit4.point + new Vector3(0, 0.03f, 0));

            }

            //Fifth RayCast
            RaycastHit hit5;
            if (Physics.Raycast(Raycast5.position, -Raycast5.up, out hit5, 1))
            {
                Debug.DrawRay(Raycast5.position , -Raycast5.up * hit5.distance, Color.blue);
                lineRenderer.SetPosition(6, hit5.point + new Vector3(0, 0.03f, 0));
            }

            //Sixth raycast
            RaycastHit hit6;
            if (Physics.Raycast(transform.position,-transform.up, out hit6, 1))
            {
                lineRenderer.enabled = true ;
                hitpoint = hit6.point;
                Debug.DrawRay(transform.position, -transform.up * hit6.distance, Color.yellow);
                lineRenderer.SetPosition(5, hit6.point+new Vector3(0,0.03f,0));


                if (hit6.transform.tag == "onion" || hit6.transform.tag == "lemon" || hit6.transform.tag == "potato" || hit6.transform.tag == "tomato" || hit6.transform.tag == "meat"||hit6.transform.name == "Cutting Board")
                {
                    Cutbtn.SetActive(true);
                }
                else
                {
                    Cutbtn.SetActive(false);
                }

            }
            else
            {
                // If the raycast doesn't hit anything, disable the LineRenderer
                lineRenderer.enabled = false;
            }
            //Seventh RayCast
            RaycastHit hit7;
            if (Physics.Raycast(Raycast6.position, -Raycast6.up, out hit7, 1))
            {
                Debug.DrawRay(Raycast6.position, -Raycast6.up * hit7.distance, Color.blue);
                lineRenderer.SetPosition(7, hit7.point + new Vector3(0, 0.03f, 0));
            }
            //Fifth RayCast
            RaycastHit hit8;
            if (Physics.Raycast(Raycast7.position, -Raycast7.up, out hit8, 1))
            {
                Debug.DrawRay(Raycast7.position, -Raycast7.up * hit8.distance, Color.blue);
                lineRenderer.SetPosition(8, hit8.point + new Vector3(0, 0.03f, 0));
            }
            //Fifth RayCast
            RaycastHit hit9;
            if (Physics.Raycast(Raycast8.position, -Raycast8.up, out hit9, 1))
            {
                Debug.DrawRay(Raycast8.position, -Raycast8.up * hit9.distance, Color.blue);
                lineRenderer.SetPosition(9, hit9.point + new Vector3(0, 0.03f, 0));
            }
            RaycastHit hit11;
            if (Physics.Raycast(Raycast9.position, -Raycast9.up, out hit11, 1))
            {
                Debug.DrawRay(Raycast9.position, -Raycast9.up * hit11.distance, Color.blue);
                lineRenderer.SetPosition(10, hit11.point + new Vector3(0, 0.03f, 0));
            }
            if (Input.touchCount > 0)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                touchDeltaPosition = -touchDeltaPosition;

                Vector3 newPosition = new Vector3(
                  Mathf.Clamp(transform.position.x + touchDeltaPosition.x * 0.001f, initialPosition.x - 0.25f, initialPosition.x + 0.25f),
                  initialPosition.y,
                  Mathf.Clamp(transform.position.z + touchDeltaPosition.y * 0.001f, initialPosition.z - 0.25f, initialPosition.z + 0.25f));

                transform.position = newPosition;
            }

            /*if (input)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    // Check for different touch phases as needed
                    if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {
                        Vector2 touchDeltaPosition = touch.deltaPosition;
                        MoveKnife(touchDeltaPosition);
                    }
                }
            }*/
            if(left || Right)
            {
                RotateObject();
            }

        }
        public void Ypositions()
        {
            initialPosition = PickNDrop.yposition;
        }
        /* void MoveKnife(Vector2 deltaPosition)
         {
             // Convert screen space to world space
             Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

             // Calculate a percentage of the screen height (adjust this value as needed)
             float screenPercentage = 0.90f;
             float screenHeight = Screen.height;
             float bottomHeight = screenHeight * screenPercentage;
             float screenPercentage1 = 0.10f;
             float bottomHeight1 = screenHeight * screenPercentage1;

             // Ensure the y-coordinate is clamped to the bottom 75% of the screen
             float clampedY = Mathf.Clamp(screenPos.y + deltaPosition.y, bottomHeight1, bottomHeight);

             // Convert the clamped position to world space
             Vector3 newPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x + deltaPosition.x, clampedY, screenPos.z));

             // Move the knife
             transform.position = newPosition;
         }*/
        void OnTriggerEnter(Collider other)
        {
            print("working");
            // Check if the other object has the IBzSliceableNoRepeat component
            if (other.transform.CompareTag("onion")|| other.transform.CompareTag("lemon") || other.transform.CompareTag("potato") || other.transform.CompareTag("tomato") || other.transform.CompareTag("meat"))
            {
                print("working");
                var sliceable = other.GetComponent<IBzSliceableNoRepeat>();

                if (sliceable != null)
                {
                    print("working2");
                    PerformSlice(sliceable);
                }
            }
        }

        void PerformSlice(IBzSliceableNoRepeat sliceable)
        {
            Vector3 rayOrigin = transform.position;

            // Set the direction of the ray to be downward
            Vector3 rayDirection = -transform.up;

            // Create the ray
            RaycastHit hits;
            Ray ray = new Ray(rayOrigin, rayDirection);
          
            
            if (Physics.Raycast(transform.position, -transform.up, out hits, 1))
            {
                Debug.DrawRay(transform.position, -transform.up * hits.distance, Color.green);
                // Access information about the hit object
                GameObject hitObject = hits.collider.gameObject;
                Debug.Log("Hit object: " + hitObject.name);

                var sliceId = SliceIdProvider.GetNewSliceId();
                var sliceableA =hitObject.transform.GetComponent<IBzSliceableNoRepeat>();
                Vector3 direction = Vector3.Cross(ray.direction, transform.forward);
                Plane plane = new Plane(direction, ray.origin);
                if (sliceableA != null)
                {
                    print("working5");
                    sliceableA.Slice(plane, sliceId, null);
                }
            }
            if (Physics.Raycast(transform.position +new Vector3(0,0,0.02f), -transform.up, out hits, 1))
            {
                Debug.DrawRay(transform.position, -transform.up * hits.distance, Color.green);
                // Access information about the hit object
                GameObject hitObject = hits.collider.gameObject;
                Debug.Log("Hit object: " + hitObject.name);

                var sliceId = SliceIdProvider.GetNewSliceId();
                var sliceableA = hitObject.transform.GetComponent<IBzSliceableNoRepeat>();
                Vector3 direction = Vector3.Cross(ray.direction, transform.forward);
                Plane plane = new Plane(direction, ray.origin);
                if (sliceableA != null)
                {
                    print("working5");
                    sliceableA.Slice(plane, sliceId, null);
                }
            }
            if (Physics.Raycast(transform.position + new Vector3(0, 0,-0.02f), -transform.up, out hits, 1))
            {
                Debug.DrawRay(transform.position, -transform.up * hits.distance, Color.green);
                // Access information about the hit object
                GameObject hitObject = hits.collider.gameObject;
                Debug.Log("Hit object: " + hitObject.name);

                var sliceId = SliceIdProvider.GetNewSliceId();
                var sliceableA = hitObject.transform.GetComponent<IBzSliceableNoRepeat>();
                Vector3 direction = Vector3.Cross(ray.direction, transform.forward);
                Plane plane = new Plane(direction, ray.origin);
                if (sliceableA != null)
                {
                    print("working5");
                    sliceableA.Slice(plane, sliceId, null);
                }
            }
        }
        public  void ONClickCutBtn()
        {
            input = false;
            CuttingCotouineposition = transform.position;
            StartCoroutine(Cutting());

        }
        IEnumerator Cutting()
        {
            Vector3 b = transform.position;
            Vector3 targetPos = hitpoint - new Vector3(0, 0.02f, 0);
            float duration = 1.0f; // Adjust the duration of the cut

            for (float elapsed = 0; elapsed < duration; elapsed += Time.deltaTime)
            {
                float t = elapsed / duration;
                transform.position = Vector3.Lerp(b, targetPos, t);
                yield return null;
            }
            Audio.clip = Auidos[0];
            Audio.Play();
            transform.position = targetPos;
            StartCoroutine(BackfromCutting());
        }

        IEnumerator BackfromCutting()
        {
            Vector3 b = transform.position;
            Vector3 targetPos = CuttingCotouineposition;
            float duration = 1.0f; // Adjust the duration of the return

            for (float elapsed = 0; elapsed < duration; elapsed += Time.deltaTime)
            {
                float t = elapsed / duration;
                transform.position = Vector3.Lerp(b, targetPos, t);
                yield return null;
            }

            transform.position = targetPos;
            input = true;
        }
        public void Resetcutbtn()
        {
            ResetCutbtn.SetActive(false);
            RotateButton.SetActive(false);
            RotateButton1.SetActive(false);
            Cutbtn.SetActive(false);
        }
        bool left=false;
        bool Right=false;
        public void RotationRightBtnClick()
        {
            Right = true;
        }
        public void RotationLeftBtnClick()
        {
            left = true;
        }
        public void topped()
        {
            left = false;
            Right = false;
        }
        private void RotateObject()
        {
            if (left)
            {
                transform.Rotate(-Vector3.up * 15 * Time.deltaTime);
            }
            if (Right)
            {
                transform.Rotate(Vector3.up * 15 * Time.deltaTime);
            }

        }
    }

}
