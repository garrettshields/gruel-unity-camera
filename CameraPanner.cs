using System.Collections;
using Gruel.CoroutineUtils;
using UnityEngine;

namespace Gruel.Camera {
	public class CameraPanner : CameraTrait {
		
#region Fields
		[Header("CameraPanner")]
		[SerializeField] private Transform _panningTransform;

		private ManagedCoroutine _panCor;
#endregion Fields
		
#region Public Methods
		public void Pan(Vector3 endPosition, AnimationCurve curve) {
			_panCor?.Stop();
			_panCor = CoroutineRunner.StartManagedCoroutine(PanCor(
				_panningTransform.position,
				endPosition,
				curve,
				curve.keys[curve.length - 1].time
			));
		}
		
		public void Pan(Vector3 endPosition, AnimationCurve curve, float duration) {
			_panCor?.Stop();
			_panCor = CoroutineRunner.StartManagedCoroutine(PanCor(
				_panningTransform.position,
				endPosition,
				curve,
				duration
			));
		}
		
		public void Pan(Vector3 startPosition, Vector3 endPosition, AnimationCurve curve) {
			_panCor?.Stop();
			_panCor = CoroutineRunner.StartManagedCoroutine(PanCor(
				startPosition,
				endPosition,
				curve,
				curve.keys[curve.length - 1].time
			));
		}
		
		public void Pan(Vector3 startPosition, Vector3 endPosition, AnimationCurve curve, float duration) {
			_panCor?.Stop();
			_panCor = CoroutineRunner.StartManagedCoroutine(PanCor(
				startPosition,
				endPosition,
				curve,
				duration
			));
		}
#endregion Public Methods

#region Private Methods
		private IEnumerator PanCor(Vector3 startPosition, Vector3 endPosition, AnimationCurve curve, float duration) {
			var time = 0.0f;
			var curveDuration = curve.keys[curve.length - 1].time;
			while (time < duration) {
				var timeNormalized = time / duration;
				_panningTransform.localPosition = Vector3.LerpUnclamped(
					startPosition, 
					endPosition, 
					curve.Evaluate(Mathf.Lerp(0.0f, curveDuration, timeNormalized)));

				time += Time.deltaTime;
				yield return null;
			}

			_panningTransform.localPosition = endPosition;
		}
#endregion Private Methods

	}
}