using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public float life = 20;
    float startinglife;

    // Start is called before the first frame update
    void Start()
    {
        startinglife = life;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            HitAlien(0.6f+Mathf.Pow(MilkGun.timeOfUse,2)/18);
        }
        if (other.tag=="LowEnergyLazer")
        {
            HitAlien(0.4f);
        }
        if (other.tag == "Death")
        {
            AlienDie();
        }
    }
    public void HitAlien(float damage)
    {
        life = life - damage;

        if (life <= 0)
        {
            AlienDie();
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, life / startinglife, life / startinglife, 1);
        }
    }
    public void AlienDie()
    {
        Destroy(gameObject);
    }
}
