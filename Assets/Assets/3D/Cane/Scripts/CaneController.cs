using System;
using UnityEngine;

public class CaneController : MonoBehaviour
{
    public static CaneController Instance;

    [SerializeField]
    private Transform SwingingBuilding;

    [SerializeField]
    private Transform Tower;
    private int BuildingIndex;

    public float LastXPosition;

    [SerializeField]
    private float maxDistance;
    private void Awake()
    {
        Instance = this;
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwingingBuilding.gameObject.SetActive(false);

            if (BuildingIndex < Tower.childCount - 1)
            {
                var building = Tower.GetChild(BuildingIndex++);
                building.gameObject.SetActive(true);
                building.transform.position = SwingingBuilding.position;
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
            transform.Translate(Vector3.up * .8f);
        }

        //Enable swinging building
        SwingingBuilding.gameObject.SetActive(true);

        return accepted;
    }
}
