using UnityEngine;
using System;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class Bloom : MonoBehaviour
{
    public Shader bloomShader;
    [Range(1.0f, 16.0f)]
    public int interations = 1;
    [NonSerialized]
    Material bloom;
    const int BoxDownPrefilterPass = 0;
    const int BoxDownPass = 0;
    const int BoxUpPass = 1;
    const int ApplyBloomPass = 2;
    [Range(0, 10)]
    public float threshold = 1;
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (bloom == null)
        {
            bloom = new Material(bloomShader);
            bloom.hideFlags = HideFlags.HideAndDontSave;
        }

        bloom.SetFloat("_Threshold", threshold);

        RenderTexture[] textures = new RenderTexture[16];
        int width = source.width / 2;
        int height = source.height / 2;
        RenderTextureFormat format = source.format;
        RenderTexture currentDestination = textures[0] = RenderTexture.GetTemporary(width, height, 0, format);

        Graphics.Blit(source, currentDestination, bloom, BoxDownPrefilterPass);
        RenderTexture currentSource = currentDestination;

        int i = 1;
        for (; i < interations; i++)
        {
            width /= 2;
            height /= 2;
            if (height < 2)
            {
                break;
            }
            currentDestination = textures[i] = RenderTexture.GetTemporary(width, height, 0, format);
            Graphics.Blit(currentSource, currentDestination, bloom, BoxDownPass);
            currentSource = currentDestination;
        }
        for (i -= 2; i >= 0; i--)
        {
            currentDestination = textures[i];
            textures[i] = null;
            bloom.SetTexture("_SourceTex", source);
            Graphics.Blit(currentSource, currentDestination, bloom, ApplyBloomPass);
            RenderTexture.ReleaseTemporary(currentSource);
            currentSource = currentDestination;
        }

        Graphics.Blit(currentSource, destination, bloom, BoxUpPass);

        RenderTexture.ReleaseTemporary(currentSource);
    }
}