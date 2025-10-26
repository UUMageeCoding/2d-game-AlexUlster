using UnityEngine;
public class DestroyOnCollision : MonoBehaviour
{

    public ParticleSystem GemCollectParticle;

   private void OnTriggerEnter2D (Collider2D other)
   {
       if (other.gameObject.CompareTag("Player"))
       {

            Instantiate(GemCollectParticle, transform.position, transform.rotation);
            Destroy(gameObject);
       }
   }
}