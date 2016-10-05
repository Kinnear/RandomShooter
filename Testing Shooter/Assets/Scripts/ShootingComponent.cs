using UnityEngine;
using System.Collections;

public class ShootingComponent : MonoBehaviour
{
    private BulletMgr bulletManager;

    [SerializeField]
    private float timeBetweenShot;

    // Use this for initialization
    void Awake()
    {
        bulletManager = GetComponent<BulletMgr>();
    }

    void Start ()
    {
        StartCoroutine(AutoShoot());

    }

    IEnumerator AutoShoot()
    {
        while (true)
        {
            bulletManager.ShootBullet(bulletManager.BulletSpeed, transform.up);
            yield return new WaitForSeconds(timeBetweenShot);
            yield return null;
        }
    }
}
