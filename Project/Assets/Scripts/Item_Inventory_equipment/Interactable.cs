using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 0.7f;

    bool interacted = false;
    bool shouldInteract = false;

    private void Start()
    {
        interacted = false;
        shouldInteract = false;
    }

    public virtual void Interact()
    {
        Debug.Log("should interact now");
        interacted = true;
        shouldInteract = false;
    }

    private void Update()
    {
        if (!interacted && shouldInteract)
        {
            Interact();
            /*Debug.Log("should interact now");
            interacted = true;
            shouldInteract = false;*/
        }
    }

    public void setInteract()
    {
        shouldInteract = true;
    }

    public void setInteracted()
    {
        interacted = false;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //UnityEditor.Handles.color = Color.yellow;
        //UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.back, radius);
    }
}
