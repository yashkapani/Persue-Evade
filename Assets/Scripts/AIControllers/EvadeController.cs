using UnityEngine;
using System.Collections;

namespace AISandbox {
	[RequireComponent(typeof (IActor))]
	public class PursuitController : MonoBehaviour {
		private IActor _actor;
		public SimpleActor _target_actor;
		public SpriteRenderer sprite_target;
		private float act_dist;
		private void Awake() {
			_actor = GetComponent<IActor>();
			
			
		}
		
		private void FixedUpdate() {
			//sprite_target.transform.position =(Vector2)_target_actor.transform.position + (_target_actor.Velocity *3);
			Vector2 target = sprite_target.transform.position; // change this;
			
			Vector2 direction = (Vector2)gameObject.transform.position - target;
			direction.Normalize ();
			
			Vector2 desired_velocity = direction * _actor.MaxSpeed;
			Vector2 steering = desired_velocity - _actor.Velocity;
			steering.Normalize ();
			act_dist = Mathf.Sqrt (Mathf.Pow ((target.x - gameObject.transform.position.x), 2) + Mathf.Pow ((target.y - gameObject.transform.position.y), 2));
			float speed = Mathf.Sqrt (Mathf.Pow (_actor.Velocity.x, 2) + Mathf.Pow (_actor.Velocity.y, 2));
			float t = act_dist/speed;
			if (t == 0)
				Application.LoadLevel (Application.loadedLevel);
			sprite_target.transform.position = ((Vector2)_target_actor.transform.position + (_target_actor.Velocity *t));
			//	sprite_target.transform.position =
			//float x_axis = 0.0f;    // FIXME
			//  float y_axis = 0.0f;    // FIXME
			
			
			//Application.LoadLevel (Application.loadedLevel);
			// Pass all parameters to the character control script.
			_actor.SetInput( steering.x, steering.y );
		}
	}
}