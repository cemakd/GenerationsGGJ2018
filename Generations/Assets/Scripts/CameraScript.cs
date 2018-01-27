using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

   public GameObject player;       //Public variable to store a reference to the player game object
   public int triggery = 4;

   private float offsetx, offsety;         //Private variable to store the offset distance between the player and camera

   // Use this for initialization
   void Start()
   {
      //Calculate and store the offset value by getting the distance between the player's position and camera's position.
      offsetx = transform.position.x - player.transform.position.x;
      offsety = transform.position.y - player.transform.position.y;
   }

   // LateUpdate is called after Update each frame
   void LateUpdate()
   {
      if (Mathf.Abs(transform.position.y - player.transform.position.y) > triggery)
      {
         transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y +offsety, transform.position.z), 2*Time.deltaTime);

      }
      
      
         transform.position = new Vector3(player.transform.position.x + offsetx, transform.position.y, transform.position.z);
      
      // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
   }
}