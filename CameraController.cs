using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gruel.Camera {
	public class CameraController : MonoBehaviour {
		
#region Properties
		public UnityEngine.Camera Camera => _camera;

		public float OrthoSize => _camera.orthographicSize;

		public Vector3 CameraPosition => _camera.transform.position;

		public bool Active {
			get => _active;
			set {
				_active = value;
				_camera.enabled = _active;
			}
		}
#endregion Properties

#region Fields
		[Header("Camera")]
		[SerializeField] private UnityEngine.Camera _camera;
		[SerializeField] private GameObject _cameraGameObject;
		
		[Header("Traits")]
		[FormerlySerializedAs("_cameraTraits")] [SerializeField] private CameraTrait[] _traitComponents;

		private bool _active = true;

		private List<CameraTrait> _traits;
#endregion Fields

#region Public Methods
		public void SetPosition(Vector3 position) {
			Debug.Log($"CameraController.SetPosition: {position.ToString()}");
		
			transform.position = position;
		}

		public void AddTrait(CameraTrait trait) {
			_traits.Add(trait);
		}

		public void RemoveTrait(CameraTrait trait) {
			_traits.Remove(trait);
		}
		
		public T GetTrait<T>() where T : CameraTrait {
			return _traits.OfType<T>().Select(trait => trait).FirstOrDefault();
		}

		public bool TryGetTrait<T>(out T outTrait) where T : CameraTrait {
			var type = typeof(T);
			outTrait = null;

			foreach (var trait in _traits) {
				if (trait.GetType() == type) {
					outTrait = (T)trait;
					return true;
				}
			}

			return false;
		}
#endregion Public Methods

#region Private Methods
		private void Awake() {
			// Add initial component traits.
			_traits = new List<CameraTrait>();

			for (int i = 0, n = _traitComponents.Length; i < n; i++) {
				AddTrait(_traitComponents[i]);
			}
		}
#endregion Private Methods

	}
}