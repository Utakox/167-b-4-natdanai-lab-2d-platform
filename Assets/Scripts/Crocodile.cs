using UnityEngine;

public class Crocodile : Enemy, IShootable
{

    [SerializeField] float atkRange;
    public Player player;
    
    [field: SerializeField] public GameObject Bullet {get; set;}
    [field: SerializeField] public Transform ShootPoint {get; set;}

    public float ReloadTime {get; set;}
    public float WaitTime {get; set;}
    void Start()
    {
        base.Initialize(50);
        DamageHit = 30;

        //set atk
        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();

        WaitTime = 0.0f;
        ReloadTime = 5.0f;
    }

    private void FixedUpdate() 
    {
        WaitTime += Time.fixedDeltaTime;
        Behaviour();
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
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.InitWeapon(30, this);
            WaitTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
