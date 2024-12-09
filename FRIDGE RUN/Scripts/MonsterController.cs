using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    //They need to know the player exists to chase them
    public PlayerMovement Target;
    //How fast do I move?
    public float Speed = 4;
    public float Health = 10;
    public float MaxHealth = 10;
    // public TextMeshPro HealthTxt
    public SpriteRenderer HealthBar;
    public SpriteRenderer HealthBG;

    //My rigidbody
    public Rigidbody2D RB;

    void Start()
    {
        //If I don't have the player assigned, use their static variable to find them
        if (Target == null) Target = PlayerMovement.Player;
    }

    void Update()
    {
        float w = (Health/ MaxHealth) * HealthBG.transform.localScale.x;
        HealthBar.transform.localScale = new Vector3(w, 0.5f, 1);
        // HealthTxt.text = "Health: " + Health;
        //If there is no player, don't chase
        if (Target == null) return;

        //Calculate what direction the player is in
        Vector3 offset = Target.transform.position - transform.position;
        //Normalize the direction to make it always add up to 1, then multiply it by my speed
        RB.velocity = offset.normalized * Speed;

        //The code for the player getting caught by me is in the PlayerMovement script
    }

    //If I get hit by a bullet. . .
    public void GetShot()
    {
        //Be destroyed
        Health--;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

    }
}