using UnityEngine;

public class SpawnConsumable : MonoBehaviour
{
    public GameObject item;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
