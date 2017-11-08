using UnityEngine;
using System.Collections;

namespace AISandbox {
    [RequireComponent(typeof (IActor))]
    public class ConstantController : MonoBehaviour {
        private IActor _actor;
		private float velocity = 10;

		private void Awake() {
            _actor = GetComponent<IActor>();
        }

        private void FixedUpdate() {
            
			float x_axis = 20;    // FIXME
			float y_axis =20;    // FIXME
			
			// Pass all parameters to the character control script.
			_actor.SetInput( x_axis, y_axis );
        }
    }
}