using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D {
	public class WallClimb : MonoBehaviour {

		public float max_climb_distance = 0f;
		public float remaining_climb_distance = 0f;
		private float climb_speed = 5f;
		private bool wall_contact = false;
		public LayerMask what_is_wall;

		private Transform wall_check;
		private float wall_check_radius = 0.2f;
		private PlatformerCharacter2D pc;
		private Vector2 last_position;
		private Rigidbody2D rb;

		// Use this for initialization
		void Start () {
			wall_check = transform.Find ("WallCheck");
			pc = GetComponent<PlatformerCharacter2D> ();
			rb = GetComponent<Rigidbody2D> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (pc.IsGrounded () && remaining_climb_distance != max_climb_distance) {
				remaining_climb_distance = max_climb_distance;
			}

			//check contact with wall
			Collider2D[] colliders = Physics2D.OverlapCircleAll(wall_check.position, wall_check_radius, what_is_wall);
			for (int i = 0; i < colliders.Length; i++) {
				if (colliders[i].gameObject != gameObject) {
					wall_contact = true;
				}
			}

			if (Input.GetKey (KeyCode.UpArrow) && remaining_climb_distance > 0 && wall_contact) {
				remaining_climb_distance -= climb_speed * Time.deltaTime;
				rb.velocity = new Vector2 (rb.velocity.x, climb_speed);
			}

			wall_contact = false;
		}

		public void UpgradeWallClimb(float amount = 1f) {
			max_climb_distance += amount;
		}
	}
}
