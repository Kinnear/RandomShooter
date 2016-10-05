using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public bool shot;

    public float timePassed;

    private float bulletSpeed;
    public float BulletSpeed
    {
        set { bulletSpeed = value; }
        get { return bulletSpeed; }
    }

    // Use this for initialization
    void Start()
    {
        timePassed = 0.0f;
    }

    /// <summary>
    /// Teleports the bullet to unseen location (For when it gets disabled)
    /// </summary>
    public void Teleport ()
    {
        transform.position = new Vector3(1000.0f, 1000.0f);
    }

    public IEnumerator UpdateMovement(Vector3 StartingPos, float bulletSpeed, Vector3 direction)
    {
        transform.position = StartingPos;
        transform.up = direction;

        Vector3 tempDisplacement = Vector3.zero;
        while (timePassed <= 100.0f)
        {
            timePassed += Time.deltaTime;
            tempDisplacement = (transform.up * bulletSpeed) * Time.deltaTime;
            transform.position += tempDisplacement;

            yield return null;
        }

        Teleport();
        shot = false;

        yield break;
    }
}
