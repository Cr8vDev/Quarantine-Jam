using UnityEngine;

namespace Objects
{
  public class Character : MonoBehaviour
  {
    public float health = 100f;

    private void Update()
    {
      if (IsDead())
      {
        Destroy(gameObject);
      }
    }

    private bool IsDead()
    {
      return health <= 0;
    }

    // TODO make player take damage
    // public void TakeDamage(float amount)
    // {
    //   health -= amount;
    // }
  }
}