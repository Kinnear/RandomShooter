using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletMgr : MonoBehaviour {

    public List<Bullet> listOfBullets;
    public Bullet bulletPrefab;
    public int maxBullets;

    [SerializeField]
    int startingBulletSpeed;

    int bulletSpeed;
    public int BulletSpeed
    {
        set { bulletSpeed = value; }
        get { return bulletSpeed; }
    }

    // Use this for initialization
    void Start ()
    {
        listOfBullets = new List<Bullet>();

        // TEMPORARY
        bulletSpeed = startingBulletSpeed;

        Bullet newBullet = null;
        for (int i = 0; i < maxBullets; i++)
        {
            newBullet = Instantiate(bulletPrefab) as Bullet;
            listOfBullets.Add(newBullet);

            newBullet.Teleport();
            newBullet.shot = false;
        }
    }

    public void ShootBullet (float bulletSpeed, Vector3 Direction)
    {
        for (int i = 0; i < listOfBullets.Count; ++i)
        {
            if (listOfBullets[i].GetComponent <Bullet> ().shot == false)
            {
                listOfBullets[i].gameObject.SetActive (true);
                listOfBullets[i].GetComponent<Bullet>().shot = true;
                StartCoroutine(listOfBullets[i].UpdateMovement(transform.position, bulletSpeed, Direction));
                break;
            }
        }
    }
}
