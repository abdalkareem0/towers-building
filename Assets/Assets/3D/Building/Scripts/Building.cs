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
            var landedInRange = CaneController.Instance.LandBuilding(transform);
            if (landedInRange)
                rigidBody.isKinematic = true;
        }
    }
}