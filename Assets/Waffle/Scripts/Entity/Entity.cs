using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float health;
    public float Health => health;

    public void SetHealth(float target)
    {
        health = target;
    }

    protected virtual void Die()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
