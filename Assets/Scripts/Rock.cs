using UnityEngine;

public class Rock : Weapon
{

    public Rigidbody2D rb;
    [SerializeField] public Vector2 force;

    public override void Move() 
    {
        rb.AddForce(force);
    }

    public override void OnHitWith(Character obj)
    {
        if (obj is Player)
        obj.TakeDamage(this.damage);
    }

    void Start()
    {
        damage = 30;
        force = new Vector2(GetShootDirection() * 90, 400);
        Move(); 
    }
}
