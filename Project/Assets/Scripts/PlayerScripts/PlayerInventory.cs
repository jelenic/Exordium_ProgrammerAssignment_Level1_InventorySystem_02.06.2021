using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{

    public List<Interactable> listOfInteractables;
    public GameObject interactPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (listOfInteractables.Any())
            {
                listOfInteractables.First().setInteract();
            }
        }
        else if (Input.GetKeyUp("e"))
        {
            if (listOfInteractables.Any())
            {
                listOfInteractables.First().setInteracted();
            }
        }
        if (listOfInteractables.Any())
        {
            interactPanel.SetActive(true);
        }
        else
        {
            interactPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("trigger on:" + collision.ToString());
        Interactable interactable = collision.GetComponent<Interactable>();
        if (collision.tag == "Interactable")
        {
            listOfInteractables.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("trigger off:" + collision.ToString());
        Interactable interactable = collision.GetComponent<Interactable>();
        if (collision.tag == "Interactable")
        {
            listOfInteractables.Remove(interactable);
        }
    }
}
