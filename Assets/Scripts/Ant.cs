using UnityEngine;

public class Ant : Enemy
{

    [SerializeField] Vector2 velocity;
    public Transform[] movePoints;
    
    void Start()
    {
        base.Initialize(20);

        DamageHit = 20;

        velocity = new Vector2(-1.0f, 0f);
    }

    public override void Behaviour()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (velocity.x < 0 && rb.position.x <= movePoints[0].position.x)
        {
            Flip();
        }

        if (velocity.x > 0 && rb.position.x >= movePoints[1].position.x)
        {
            Flip();
        }
    }
 

    private void FixedUpdate()
    {
        Behaviour();
    }

    public void Flip()
    {
        velocity.x *= -1;

        // Flip this image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
