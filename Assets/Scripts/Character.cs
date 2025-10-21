using UnityEngine;

public abstract class Character : MonoBehaviour
{

    private int health;
    public int Health 
    { 
      get { return health; } 
      set { health = (value < 0 ? 0 : value); }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void Initialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} is initialed Health: {this.Health}");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} taken {damage} amounts of damage || Current Health is {Health}");

        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
