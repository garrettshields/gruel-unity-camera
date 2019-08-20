# **About**

# **CameraController**
Type: `Component`  
Description: The `CameraController` component has a simple trait system that allows easily accessing different camera traits to add / change camera behaviours like letterboxing or applying camera shake.

## Included Camera traits:
* [CameraAspectUtility](#CameraAspectUtility)
* [CameraAttachables](#CameraAttachables)
* [CameraOrthographicScalar](#CameraOrthographicScalar)
* [CameraPanner](#CameraPanner)
* [CameraShake](#CameraShake)
* [CameraTracker](#CameraTracker)

## API
* Properties:
  * `CameraController` Instance
  * `float` OrthoSize
  * `Vector3` CameraPosition

* Methods:
  * SetPosition(`Vector3` position)
  * AddTrait(`CameraTrait` trait)
  * RemoveTrait(`CameraTrait` trait)
  * `T` GetTrait<`T`>()
  * `bool` TryGetTrait<`T`>(out `T` outTrait)

# **CameraAspectUtility**
Type: `Component`  
Description: This camera trait allows different aspect ratios to be enforced through letterboxing and pillarboxing.

## API
* Properties:
  * `UnityEngine.Camera` Camera
  * `bool` Letterbox
  * `bool` Pillarbox
  * `float` MinimumAspectRatio

# **CameraAttachables**
Type: `Component`  
Description: This camera trait provides a simple API to easily attach other GameObjects to the camera.

## API
* Methods:
  * Attach(`Transform` attachable, `Vector3` offset)
  * Detach(`Transform` attachable)

# **CameraOrthographicScalar**
Type: `Component`  
Description: This camera trait will automatically adjust the camera's orthographic size to provide a consistent number of pixels per unit (Ppu) even at different resolutions.

## API
* Properties:
  * `float` Ppu
  * `float` PpuScale

# **CameraPanner**
Type: `Component`  
Description: This camera trait provides an API to pan the camera around on an offset.

## API
* Methods:
  * Pan(`Vector3` endPosition, `AnimationCurve` curve)
  * Pan(`Vector3` endPosition, `AnimationCurve` curve, float duration)
  * Pan(`Vector3` startPosition, `Vector3` endPosition, `AnimationCurve` curve)
  * Pan(`Vector3` startPosition, `Vector3` endPosition, `AnimationCurve` curve, `float` duration)

# **CameraShake**
Type: `Component`  
Description: This camera trait allows shaking the camera on an offset using `CameraShakeData` assets.

CameraShake works by randomly generating an AnimationCurve based on the settings in the `CameraShakeData` passed in. Information for what each setting does can be found in the CameraShakeData section.

## API
* Methods:
  * Shake(`CameraShakeData` shakeData)

## **CameraShakeData**
Type: `ScriptableObject`  
Asset creation menu: `Create/Gruel/CameraShakeData ` 
Description: This is a scriptable object for storing data related to how a camera shake should behave.  

When calling the CameraShake trait's `Shake` method, a `CameraShakeData` asset must be passed in.

### Settings:
* Strength  
  This is the maximum radius that can be applied as an offset to the camera.
* DecreaseFactor  
  Strength will be decrease by this amount for each point in the shake curve.
* Points  
  The amount of points in the shake curve. The more points the more jittery the shake will be.
* Duration  
  How long the shake will last.

# **CameraTracker**
Type: `Component`  
**Description:** This camera trait provides an API to track a specified transform.  

## API
* Properties:
  * `Vector3` Offset

* Methods:
  * Track(`Transform` transformToTrack, `Vector3` offset)
  * StopTracking()