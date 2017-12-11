using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public enum Type {speedBoost, shield, oneUp};
    public Type powerupType;
    public Sprite[] images;
    
    // Use this for initialization
	void Start ()
    {
        switch (powerupType)
        {
            case Type.speedBoost:
                gameObject.GetComponent<SpriteRenderer>().sprite = images[0];
                break;
            case Type.shield:
                gameObject.GetComponent<SpriteRenderer>().sprite = images[1];
                break;
            case Type.oneUp:
                gameObject.GetComponent<SpriteRenderer>().sprite = images[2];
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("We hit a powerup!");
        switch (powerupType)
        {
            case Type.speedBoost:
                other.GetComponent<PlayerControl>().speed*=2;
                break;
            case Type.shield:

                break;
            case Type.oneUp:
                //player gains one health
                break;
            default:
                break;
        }        
        Destroy(this.gameObject);
    }
}
