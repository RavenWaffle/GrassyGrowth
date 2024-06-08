using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float Health;
    public float health => Health;

    public void SetHealth(float target)
    {
        Health = target;
    }

    protected virtual void Die()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
