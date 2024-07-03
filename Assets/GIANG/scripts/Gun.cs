using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform FirePos;
    public float TimeFire = 0.5f;
    public float FireForce = 1.0f;

    private float timeFire;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RotareGun();
        timeFire -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q) && timeFire < 0)
        {
            FireBall();
        }
    }
    
    void RotareGun()
    {
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) transform.localScale = new Vector3(1, -1, 0);
        else transform.localScale = new Vector3(1, 1, 0);
    }
    void FireBall()
    {
        timeFire = TimeFire;

        GameObject BulletTmp = Instantiate(bullet, FirePos.position, Quaternion.identity);

        rb = BulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * FireForce, ForceMode2D.Impulse);
    }
}
