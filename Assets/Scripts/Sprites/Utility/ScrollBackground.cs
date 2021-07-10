using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class ScrollBackground : MonoBehaviour
{

    Material material;
    public int speed;

    void Start () {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        material = spriteRenderer.material;
    }

    void Update () {
        material.mainTextureOffset = new Vector2(material.mainTextureOffset.x + ((speed / 100.0f) * Time.deltaTime), material.mainTextureOffset.y);
    }
 
 /*
    void FixedUpdate () {
         //get target velocity
         //if you wish to replace target with a non-rigidbody object, this is the place
         float targetVelocity = target.velocity.x;
         //translate sprite according to target velocity
         this.transform.Translate (new Vector3 (-speed * targetVelocity, 0, 0) * Time.deltaTime);
         //set sprite is moving out of screen shift it to put clone in its place
         float width = getWidth ();
         if (targetVelocity > 0) {
             //shift right if player is moving right
             if (initPos - this.transform.localPosition.x > width) {
                 this.transform.Translate (new Vector3 (width, 0, 0)); 
             }
         } else {
             //shift left if player moving left
             if (initPos - this.transform.localPosition.x < 0) {
                 this.transform.Translate (new Vector3 (-width, 0, 0)); 
             }
         }
    }
*/

}
