using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyheath : MonoBehaviour
{
    public float heath;
    public float currentHeath;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHeath = heath;
    }

    // Update is called once per frame
    void Update()
    {
        if (heath < currentHeath)
        {
            currentHeath = heath;
            anim.SetTrigger("Attacked");
        }
        if (heath <= 0)
        {
            anim.SetBool("dead", true);
            Debug.Log("Enemy is dead");
            StartCoroutine(DisappearAfterDeath());
        }
    }

    private IEnumerator DisappearAfterDeath()
    {
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        Destroy(gameObject); // Destroy the enemy game object
    }
}