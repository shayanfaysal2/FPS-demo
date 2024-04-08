using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPos;
    public float shootSpeed;
    public Animator gunAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        gunAnim.SetTrigger("shoot");
        GameObject newBullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * shootSpeed * Time.deltaTime;
        Destroy(newBullet, 2);
    }
}
