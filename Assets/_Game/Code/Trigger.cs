using UnityEngine;
public class DestroyOnCollision : MonoBehaviour
{
   private void OnTriggerEnter2D (Collider2D other)
   {
       if (other.gameObject.CompareTag("Player"))
       {
            Destroy(gameObject);
       }
   }
}