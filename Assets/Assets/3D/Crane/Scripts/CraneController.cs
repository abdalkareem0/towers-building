using System;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public static CraneController Instance;

    [SerializeField]
    private Transform swingingBuilding;

    [SerializeField]
    private Transform tower;
    private int buildingIndex;

    public float LastXPosition;

    [SerializeField]
    private float maxDistance;

    [SerializeField]
    private float stepIncrease;

    [SerializeField]
    private float cameraSpeed;
    private void Awake()
    {
        Instance = this;
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swingingBuilding.gameObject.SetActive(false);

            if (buildingIndex < tower.childCount - 1)
            {
                var building = tower.GetChild(buildingIndex++);
                building.gameObject.SetActive(true);
                building.transform.position = swingingBuilding.position;
                building.transform.rotation = swingingBuilding.rotation;
            }
        }
    }
    public bool LandBuilding(Transform buildingTransform)
    {
        float distance = Mathf.Abs(buildingTransform.position.x - LastXPosition);
        bool accepted = distance < maxDistance;
        if (accepted)
        {
            UIManager.Instance.UpdateScore(1);
            LastXPosition = buildingTransform.position.x;

            //Move camera
            LeanTween.moveY(gameObject, transform.position.y + stepIncrease, cameraSpeed);
        }

        //Enable swinging building
        swingingBuilding.gameObject.SetActive(true);

        return accepted;
    }
}
