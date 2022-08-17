using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Building : MonoBehaviour
{
    private bool landed = false;
    private Rigidbody rigidBody;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!landed)
        {
            landed = true;
            var landedInRange = CraneController.Instance.LandBuilding(transform);
            if (landedInRange)
                LeanTween.delayedCall(1, () =>
                {
                    rigidBody.isKinematic = true;
                });
            else
            {
                LeanTween.delayedCall(3, () => gameObject.SetActive(false));
            }
        }
    }
}