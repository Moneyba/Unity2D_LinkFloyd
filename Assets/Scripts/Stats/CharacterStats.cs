using UnityEngine;

public class CharacterStats : MonoBehaviour
{
   
    public int health = 5;
    public float backForce = 10;

    public event System.Action OnDeath;


    public virtual void Hit(Vector3 direction)
    {
        Vector3 backDirection = (direction).normalized;
        GetComponent<Rigidbody2D>().AddForce(backDirection * backForce);
        health--;
        if (health <= 0)
        {

            Die();

        }

    }

    public virtual void Die()
    {
        if (OnDeath != null)
        {
            OnDeath();
           
        }
    }
}
