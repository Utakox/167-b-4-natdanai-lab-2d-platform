using UnityEngine;

public class Crocodile : Enemy
{

    [SerializeField] float atkRange;
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialize(50);
        DamageHit = 30;

        //set atk
        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
    }


    public override void Behaviour()
    {
        Vector2 distance = transform.position - player.transform.position;

        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name} atk range!");
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log($"{this.name} shoots rock to the {player.name}");
    }

    private void FixedUpdate()
    {
        Behaviour();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
