using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;

    public GameObject explosionEffect;
    public LineRenderer lineRenderer;
    private Transform _firePoint;
   
  

    // Start is called before the first frame update

    private void Awake()
    {
        _firePoint = transform.Find("firepoint");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if(bulletPrefab != null && _firePoint != null && shooter != null)
        {
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.transform.position, Quaternion.identity) as GameObject;
            MyBullet bulletComponent = myBullet.GetComponent<MyBullet>();

            if(shooter.transform.localScale.x < 0f)
            {
                //left
                bulletComponent.direction = Vector2.left;
            } else
            {
                bulletComponent.direction = Vector2.right;
            }

        } else
        {
            //Right
        }
    }

    public IEnumerator ShootWithRaycast()
    {
        if (explosionEffect != null && lineRenderer != null)
        {

            RaycastHit2D hitInfo = Physics2D.Raycast(_firePoint.position, -(_firePoint.right));

            if (hitInfo){

                Debug.Log("HERE::::" + hitInfo.collider);

                Instantiate(explosionEffect, hitInfo.point, Quaternion.identity);

                //Set line renderer
                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);



            } else
            {
                Debug.Log("AVERRRRR:::");
                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point + Vector2.left * 100);
            }

            lineRenderer.enabled = true;

            yield return null;

            lineRenderer.enabled = false;
        }
    }
}
