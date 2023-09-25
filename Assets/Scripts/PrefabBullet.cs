using UnityEngine;

public class PrefabBullet : MonoBehaviour
{
   public float life = 3;

   public Animator NormalmobAnimator;

   void Awake() 
   {
      Destroy(gameObject,life);
   }
   private void OnTriggerEnter2D(Collider2D collision) 
   {
      if (collision.CompareTag("mob"))
      {
         Destroy(collision.gameObject);
         Destroy(gameObject);
      }
      if (collision.CompareTag("Tank"))
      {}  
      if (collision.CompareTag("Player"))
      {}
      if (collision.CompareTag("environment"))
      {}
      if (collision.CompareTag("Ground"))
      {
         Destroy(gameObject);
      }
      else
      {
      }
   }
}
