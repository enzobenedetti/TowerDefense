using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject pointSpherePrefab;
    [SerializeField] private GameObject towerPrefab;
    private GameObject pointShpere;
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        pointShpere = Instantiate(pointSpherePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "TowerPlace" && Money.Amount >= Tower.towerCost)
                {
                    GameObject tower = Instantiate(towerPrefab, hit.point, Quaternion.identity, transform);
                    tower.transform.position = new Vector3(hit.point.x, 1f, hit.point.z);
                    Money.Amount -= Tower.towerCost;
                }
            }
            
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                pointShpere.transform.position = hit.point;
                if (hit.transform.tag == "TowerPlace")
                {
                    if (Money.Amount >= Tower.towerCost)
                    {
                        pointShpere.GetComponent<MeshRenderer>().material.color = Color.blue;
                    }
                    else
                    {
                        pointShpere.GetComponent<MeshRenderer>().material.color = Color.gray;
                    }
                }
                else if (pointShpere) pointShpere.GetComponent<MeshRenderer>().material.color = Color.clear;
            }
        }
    }
}
