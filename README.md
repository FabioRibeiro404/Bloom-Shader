
![Lusofona Logo grande](https://github.com/FabioRibeiro404/Bloom-Shader/assets/91754191/3a4e8d19-e6cb-42f2-a84e-011e15ef89db)

# Bloom Shader
---
Fábio Ribeiro (a22102432)

# Features
---
This bloom shader is customizable in terms of brightness and blur as well as brightness threshold.

### Bloom

https://github.com/FabioRibeiro404/Bloom-Shader/assets/91754191/5c1c4fc3-837c-4670-81b6-ec4ad9557c35

### Brightness Threshold
---


https://github.com/FabioRibeiro404/Bloom-Shader/assets/91754191/5998c77f-90ad-4335-85e2-ca90d0611e23

# Overview
---
This report follows the entire process of creating a Bloom post-process effect.
This document shows the development that was carried out throughout the project. As well as the way you can customize the blur and brightness effect in the camera. To better see the results press Play to test.


# Report
---
Firstly, I created a script that only affects the camera and to give the blur effect I needed to create the blur and add it to the original image.
After blurring the image, I made a slider to control the blurring of the image, but it was necessary to make changes to the script to avoid leaving the image with too many blocks.
With the blur more controlled, I created a public field to place the shader that I'm going to start making.
In the shader, initially, it was tested whether it was used in the script, using a function in the shader to change all colors to red.
After being successfully tested, adjustments were made to the shader to improve the blurring process.
For the bloom effect it is necessary to add the blur effect to the original image and brighten it, but if we brighten the image in each frame we end up with too much light. As a solution I needed a shader variable for the source.
In the current state, the entire image is under the effect of
blur and bloom, but we have many situations where you only want the brightest pixels and for that I used the brightness threshold to determine which pixels contribute to the bloom effect.




# References
---

Bloom Blurring Light (Jasper Flick):

https://catlikecoding.com/unity/tutorials/advanced-rendering/bloom/

Write Your Own Unity Custom Post Effects | Beginner Post Effects (Benjamin Swee - Custom Unity Shaders):

https://www.youtube.com/watch?v=ahplcYCmfG0

Custom shader fundamentals (Unity Documentation):

https://docs.unity3d.com/Manual/SL-VertexFragmentShaderExamples.html

Making Custom Blur, Frosted objects in Unity | Post Effects (Benjamin Swee - Custom Unity Shaders):

https://www.youtube.com/watch?v=-FrdBaY2wIA

Introduction to Shaders in Unity (Joseph Hocking):

https://www.kodeco.com/5671826-introduction-to-shaders-in-unity
