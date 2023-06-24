using UnityEngine;

public class ParentsManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
