# Unity-Animation-Collection
# Repository for Animation Learning

This repository is designed to help you learn and practice various animation techniques using different tools and methodologies. Below is an outline of what this repository will include:

---

## 1. Sprite Animation

### **1.1. Types of Sprites**
#### **Sprite Picker**
- Explanation: A sprite picker is a tool or component that allows the user to select and use specific sprites from a sprite sheet.
- Implementation Example:
  - Unity: Using the `SpriteRenderer` and slicing a sprite sheet in the Sprite Editor.
  
#### **Sprite Sheets**
- Explanation: A single image containing multiple frames or sprites used for animation.
- Tools:
  - Unity's Sprite Editor.
  - External tools like Photoshop or Aseprite for creating sprite sheets.

#### **Single Sprites**
- Explanation: Using individual image files for each frame of an animation.
- Advantage: Easier to manage in small-scale projects.

---

### **1.2. Animating Sprites**
- **Frame-by-Frame Animation:**
  - Example: Changing the displayed sprite at each frame in Unity using the `Animator` component or through scripts.

- **Unity Animator Component:**
  - Create an `Animation` clip.
  - Drag and drop sprite frames into the timeline.

- **Script-Based Animation:**
```csharp
public class SpriteAnimator : MonoBehaviour
{
    public Sprite[] sprites;
    public float animationSpeed = 0.1f;
    private SpriteRenderer spriteRenderer;
    private int currentFrame;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("PlayAnimation", 0, animationSpeed);
    }

    void PlayAnimation()
    {
        currentFrame = (currentFrame + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[currentFrame];
    }
}
```

---

## 2. AnimationCurve

### **2.1. Understanding AnimationCurve**
- **Definition:** A tool for creating smooth animations over time, allowing custom control of how properties change.
- **Applications:**
  - Smooth transitions for movement, scaling, or rotation.
  - Timing adjustments for effects like bouncing or easing.

### **2.2. Using AnimationCurve in Unity**
```csharp
public class CurveAnimation : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = 2.0f;
    private Vector3 startPos;
    private Vector3 endPos;
    private float time;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.up * 5;
    }

    void Update()
    {
        time += Time.deltaTime / duration;
        float curveValue = curve.Evaluate(time);
        transform.position = Vector3.Lerp(startPos, endPos, curveValue);
        if (time > 1) time = 0; // Loop animation
    }
}
```
- **Tips:** Use Unity's built-in curve editor for precise control.

---

## 3. Spine Pro Animation

### **3.1. Setting Up Spine Pro**
- Download and install Spine Pro from [Esoteric Software](http://esotericsoftware.com/).
- Export animations to Unity using Spine's Unity runtime.

### **3.2. Creating Animations in Spine Pro**
- **Bones Setup:**
  - Create a skeleton and attach bones to your sprite.
- **Keyframe Animation:**
  - Define keyframes for bone transformations (position, rotation, scale).
- **Weight Painting:**
  - Use weight painting to control how sprites deform.

### **3.3. Importing Spine Animations into Unity**
1. Install the Spine Unity package.
2. Drag the `.json` or `.skel` file into Unity.
3. Use the `SkeletonAnimation` component to control the animation.

### **3.4. Spine Animation via Script**
```csharp
using Spine.Unity;

public class SpineAnimationController : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public string animationName;

    void Start()
    {
        skeletonAnimation.state.SetAnimation(0, animationName, true);
    }
}
```

---

### **Project Structure**
```plaintext
animation-repository/
├── Sprites/
│   ├── sprite-sheets/
│   └── single-sprites/
├── AnimationCurve/
│   ├── Scripts/
├── SpinePro/
│   ├── SpineAssets/
│   ├── UnityIntegration/
└── README.md
```

### **Resources**
- [Unity Documentation](https://docs.unity3d.com/)
- [Spine Pro Documentation](http://esotericsoftware.com/spine-in-unity)
- [AnimationCurve Tutorials](https://learn.unity.com/)

Feel free to add examples and expand this repository as you learn!
