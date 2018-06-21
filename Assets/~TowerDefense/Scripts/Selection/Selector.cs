using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    public GameObject[] prefabs;
    public LayerMask layerMask;

    private GameObject[] instances;
    private Transform tower, hologram;
    private int currentTower;
    public void SelectTower(int index)
    {
        if(index < 0 || index > prefabs.Length)
        {
            return;
        }
        currentTower = index;
    }

    void GenerateInstances()
    {
        GameObject instance = instances[currentTower];
        if(instance == null)
        {
            instance = Instantiate(prefabs[currentTower]); // create new instance
            instance.transform.SetParent(transform); // Attach to parent

            // Find both sub-gameobjects
            tower = instance.transform.Find("Tower");
            hologram = instance.transform.Find("Hologram");

            // Disable both gameobjects
            tower.gameObject.SetActive(false);
            hologram.gameObject.SetActive(false);

            // Store new instance in array (for later use)
            instances[currentTower] = instance;
        }
    }

    void Start()
    {
        instances = new GameObject[prefabs.Length];
        SelectTower(0);
    }

    // Update is called once per frame
    void Update()
    {
        GenerateInstances();

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, 1000f, layerMask, QueryTriggerInteraction.Ignore))
        {
            Placable p = hit.transform.GetComponent<Placable>();
            if (p && !p.isPlaced)
            {
                GameObject gHolo = hologram.gameObject;
                GameObject gTower = tower.gameObject;

                if (!gHolo.activeSelf)
                    gHolo.SetActive(true);

                GameObject instance = instances[currentTower];
                instance.transform.position = p.transform.position;

                if (Input.GetMouseButtonDown(0))
                {
                    p.isPlaced = true;

                    gHolo.SetActive(false);
                    gTower.SetActive(true);

                    instances[currentTower] = null;
                }
            }
        }
    }
}
