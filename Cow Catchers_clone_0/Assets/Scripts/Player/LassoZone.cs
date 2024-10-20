using UnityEngine;

public class LassoZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lassoable"))
        {
            print("yeoch");
        }
    }
}
