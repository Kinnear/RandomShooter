using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
    	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Teleports the bullet to unseen location (For when it gets disabled)
    /// </summary>
    public void Teleport()
    {
        transform.position = new Vector3(1000.0f, 1000.0f);
    }

    public IEnumerator UpdateMovement(Vector3 StartingPos, float movingSpeed, Vector3 direction)
    {
        transform.position = StartingPos;
        transform.up = direction;

        float timePassed = 0.0f;
        Vector3 tempDisplacement = Vector3.zero;
        while (timePassed <= 3.0f)
        {
            timePassed += Time.deltaTime;
            tempDisplacement = (transform.up * movingSpeed) * Time.deltaTime;
            transform.position += tempDisplacement;

            yield return null;
        }

        Teleport();
        gameObject.SetActive(false);

        yield break;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        switch (other.tag)
        {
            case "Bullet":
                Teleport();
                gameObject.SetActive(false);
                other.GetComponent<Bullet>().timePassed = 3.0f;
                break;
        }
    }
}
