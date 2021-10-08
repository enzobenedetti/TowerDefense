using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "TowerPlace")
                {
                    GameObject tower = Instantiate(towerPrefab, hit.point, Quaternion.identity, transform);
                    tower.transform.position = new Vector3(hit.point.x, 1f, hit.point.z);
                }
            }
            
        }
    }
}
