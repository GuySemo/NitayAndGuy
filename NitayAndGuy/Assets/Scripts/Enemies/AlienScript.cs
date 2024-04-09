using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public float life = 20;
    float startinglife;
    [SerializeField] int pointsGive = 6;
    [SerializeField] AudioClip[] AlienAudio;
    [SerializeField] bool isBoss = false;
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

        AudioSource.PlayClipAtPoint(AlienAudio[Random.Range(0, AlienAudio.Length)], new Vector3(0, 0, -7));
        FindObjectOfType<ScoreCounter>().AddScore(Mathf.RoundToInt((Random.Range(pointsGive, pointsGive + 2)) / transform.localScale.x));
        if (isBoss)
        {
            FindObjectOfType<ScoreCounter>().Win();
        }
        Destroy(gameObject);
    }
}
