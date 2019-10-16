using System.Collections.Generic;
using UnityEngine;

namespace Gruel.Camera {
	public class CameraSystem : MonoBehaviour {
		
#region Properties
#endregion Properties

#region Fields
		private static CameraSystem _instance;
		
		private static Dictionary<int, CameraController> _cameras = new Dictionary<int, CameraController>();
#endregion Fields

#region Indexer
		public CameraController this[int hash] {
			get {
				if (_cameras.ContainsKey(hash) == false) {
					Debug.LogError("CameraSystem.GetCamera: This camera doesn't exist in the system!");
					return null;
				}

				return _cameras[hash];
			}
		}
#endregion Indexer

#region Public Methods
		public void Init() {
			// Setup instance.
			if (_instance != null) {
				Debug.LogError("CameraSystem: There is already an instance of CameraSystem!");
				Destroy(gameObject);
			} else {
				_instance = this;
			}
		}

		public static void AddCamera(int hash, CameraController cameraController) {
			if (_cameras.ContainsKey(hash)) {
				Debug.LogError("CameraSystem.AddCamera: This camera already exists in the system!");
				return;
			}
			 
			_cameras.Add(hash, cameraController);
		}

		public static void RemoveCamera(int hash) {
			if (_cameras.ContainsKey(hash) == false) {
				Debug.LogError("CameraSystem.RemoveCamera: This camera doesn't exist in the system!");
				return;
			}

			_cameras.Remove(hash);
		}

		public static CameraController GetCamera(int hash) {
			if (_cameras.ContainsKey(hash) == false) {
				Debug.LogError("CameraSystem.GetCamera: This camera doesn't exist in the system!");
				return null;
			}

			return _cameras[hash];
		}
#endregion Public Methods

#region Private Methods
#endregion Private Methods

	}
}