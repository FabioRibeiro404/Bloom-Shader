![Lusofona Logo grande](https://github.com/FabioRibeiro404/Bloom-Shader/assets/91754191/3a4e8d19-e6cb-42f2-a84e-011e15ef89db)

# Bloom Shader
---
Fábio Ribeiro (a22102432)
 # What is a bloom shader?
---
Bloom is an effect that messes up an image by causing the color of pixels to spread to adjacent pixels. It's like blurring an image, but based on brightness. In this way, we could communicate very bright colors through the blur. It's similar to the way light can diffuse inside our eyes, which can become noticeable in the case of intense brightness, but it's mainly a non-realistic effect.
 # What was done
 ---
 - To create a bloom effect you first need to blur;
 -  First, I copied from the source to a temporary texture and then from that texture to the final destination;
 -  This method "RenderTexture" takes care of managing temporary textures for us, creating, caching and destroying them as appropriate for Unity;
 -  Downsampling;
 -  The easiest and fastest way to blur an image is to take advantage of the bilinear filtering built into the GPU;
 -  Using an intermediate texture of reduced size means that you are reducing the resolution of the source texture by half. After this step, I moved from the temporary texture to the destination texture, increasing it again to the original resolution;
 -  The result is a more pixelated and slightly blurrier image than the original;
 -  A better approach is to downsample several times, halving the resolution at each stage until the desired level is reached. In this way, all the pixels end up contributing to the final result;
 -  Box Sampling;
 -  The result is much smoother and has a much higher quality, but it is also much blurrier. This is mainly due to the increased sampling with the new 4×4 box filter. Because we're using the texel size of the source to position the sample points, we end up covering a large area, with a regular, blurry weight distribution;
 -  Bloom effect;
 -  Blurring the original image is the first step in creating a bloom effect. The second step is to combine the blurred image with the original by brightening it;
 -  We can do this by accumulating the intermediate results, adding to the old data as we upsample;
 -  Adding to what I already have at an intermediate level can be done using additive mixing, rather than replacing the texture content. All I had to do was set the blending mode of the upsampling step to One One;
 -  At the moment, I'm still blurring the entire image. This is most evident for bright pixels. But one of the uses of the glow effect is to apply it only to very bright pixels;
 -  To make this possible, we have to introduce a brightness threshold.

# Features
---
This bloom shader is customizable in terms of brightness and blur as well as brightness threshold and the objects don't need to emit light to have this effect.

### Bloom

https://github.com/FabioRibeiro404/Bloom-Shader/assets/91754191/5c1c4fc3-837c-4670-81b6-ec4ad9557c35

### Brightness Threshold
---


https://github.com/FabioRibeiro404/Bloom-Shader/assets/91754191/5998c77f-90ad-4335-85e2-ca90d0611e23

# Overview
---
This report follows the entire process of creating a Bloom post-process effect.
This document shows the development that was carried out throughout the project. As well as the way you can customize the blur and brightness effect in the camera. To better see the results press Play to test.
# Performance
---
This shader has no impact This shader has no effect on performance.


https://github.com/FabioRibeiro404/Bloom-Shader/assets/91754191/3e744c2a-e507-46ef-b799-44e128424242



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
