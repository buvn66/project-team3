using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Animator animator;
    public GameObject weaponObject; // Tham chiếu đến GameObject của vũ khí
    private bool isRolling = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isRolling)
            {
                StartRolling();
            }
            else
            {
                StopAnimation();
            }
        }
    }

    void StartRolling()
    {
        animator.SetTrigger("Roll");
        isRolling = true;
        weaponObject.SetActive(false);
    }

    void StopAnimation()
    {
        animator.SetTrigger("Stop");
        isRolling = false;
        weaponObject.SetActive(true);
        StartCoroutine(DestroyAfterDelay(3f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Đợi 5 giây
        Destroy(gameObject); // Hủy đối tượng
    }
}
