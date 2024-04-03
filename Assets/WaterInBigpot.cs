using UnityEngine;

public class WaterInBigpot : MonoBehaviour
{
    public Transform WaterTap;
    public bool BigPOtTrigger = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BigPot") && WaterTap.GetChild(0).gameObject.activeSelf && BigPOtTrigger)
        {
            Debug.Log("Filling water");
            InvokeFunction();
        }
    }

    public void InvokeFunction()
    {
        BigPOtTrigger = false;
        Invoke("Invokefunction", 1.5f);
    }
    public void Invokefunction()
    {
        StartCoroutine(BigPot3.Instance.LerpSkinnedMeshValue());

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BigPot"))
        {
            BigPOtTrigger = true;
        }
    }
}
