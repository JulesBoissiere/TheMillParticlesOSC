using System;
using UnityEngine;

public class EmotionPreset
{
    public enum EmoPreset
    {
        JOY,
        CALM,
        SAD,
        ANGER,
        OTHER1,
        OTHER2
    };

    public Vector3 Color1;
    public Vector3 Color2;
    public Vector3 ShapePos;
    public Vector3 VeloLin;
    public Vector3 VeloOrb;
    public float VeloRad;
    public float VeloSpd;
    public float VeloLimSpd;
    public float VeloDmp;
    public Vector3 NoiseStr;
    public float NoiseFrq;
    public float NoiseOctaveCount;
    public float NoiseOctaveMultiplier;
    public float NoiseOctaveScale;
    public float NoiseSpd;
    public float NoisePos;
    public float NoiseRot;
    public float NoiseScl;
    public float SizeLif;

    public Vector2 EmoCoords;

    public EmotionPreset()
    {

    }

    public static EmotionPreset interpPreset(Vector2 coords)
    {
        EmotionPreset res = new EmotionPreset();

        EmotionPreset[] emotions = new EmotionPreset[6];

        emotions[0] = getCue7();
        emotions[1] = getCue13();
        emotions[2] = getCue20();
        emotions[3] = getCueB22();
        emotions[4] = getCue32();
        emotions[5] = getCue41();
      

        res = interpPresetFromArray(emotions, coords);

        return res;
    }

    //go through a list of emotion presets, and return the weighted interpolation
    // of preset values based on inverse square distance from current coords
    public static EmotionPreset interpPresetFromArray(EmotionPreset[] emos, Vector2 coords)
    {
        EmotionPreset res = new EmotionPreset();
        float[] weights = new float[emos.Length];
        float sum = 0;
        for (int i= 0; i < emos.Length; i++)
        {
            float dx = coords.x - emos[i].EmoCoords.x;
            float dy = coords.y - emos[i].EmoCoords.y;
            weights[i] = 1/(float)Math.Sqrt(Math.Pow(dx, 2)+Math.Pow(dy, 2)+0.001); //prevent NaN when we're on top of a coord
            sum += weights[i];
        }
        for (int i=0; i< emos.Length; i++)
        {
            weights[i] = weights[i] / sum;
            Debug.Log("weight " + i.ToString() + " = " + weights[i].ToString());
        }

        for (int i=0; i< emos.Length; i++)
        {
            float w = weights[i];
            res.Color1 += emos[i].Color1 * w;
            res.Color2 += emos[i].Color2 * w;
            res.ShapePos += emos[i].ShapePos * w;
            res.VeloLin += emos[i].VeloLin * w;
            res.VeloOrb += emos[i].VeloOrb * w;
            res.VeloRad += emos[i].VeloRad * w;
            res.VeloSpd += emos[i].VeloSpd * w;
            res.VeloLimSpd += emos[i].VeloLimSpd * w;
            res.VeloDmp += emos[i].VeloDmp * w; //NOTE: is this supposed to be on/off?
            res.NoiseStr += emos[i].NoiseStr * w;
            res.NoiseFrq += emos[i].NoiseFrq * w;
            res.NoiseSpd += emos[i].NoiseSpd * w;
            res.NoisePos += emos[i].NoisePos * w;
            res.NoiseRot += emos[i].NoiseRot * w;
            res.NoiseScl += emos[i].NoiseScl * w;
            res.SizeLif += emos[i].SizeLif * w;

        }
        

        return res;
    }

    public EmotionPreset GetPreset(EmoPreset emo = EmoPreset.CALM)
    {
        switch (emo)
        {
            case EmoPreset.JOY:
                return getCue13();
            case EmoPreset.CALM:
                return getCue7();
            case EmoPreset.SAD:
                return getCue20();
            case EmoPreset.ANGER:
                return getCueB22();
            case EmoPreset.OTHER1:
                return getCue32();
            case EmoPreset.OTHER2:
                return getCue41();
               
            default:
                return getCue7();
        }
    }

    //from table

    // JOY is 1, 1

    public static EmotionPreset getCue7()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 0);
        preset.Color1 = new Vector3(2.87f, 0.8f, 0.5f);
        preset.Color2 = new Vector3(1.27f, -1f, -2.42f);
        preset.VeloLin = new Vector3(-0.5f, 0.58f, -0.58f);
        preset.VeloOrb = new Vector3(0, 0, 0);
        preset.VeloRad = 0;
        preset.VeloSpd = 0.33f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(13, -6, 0);
        preset.NoiseFrq = 0.001f;
        preset.NoiseOctaveCount = 2f;
        preset.NoiseOctaveMultiplier = 1f;
        preset.NoiseOctaveScale = .5f;
        preset.NoiseSpd = 20f;
        preset.NoisePos = -10f;
        preset.NoiseRot = 10f;
        preset.NoiseScl = 0f;
        preset.SizeLif = 2f;

        preset.EmoCoords = new Vector2(1, 1);

        return preset;
    }
    public static EmotionPreset getCue13()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 0);
        preset.Color1 = new Vector3(2.38f, 0.32f, 0);
        preset.Color2 = new Vector3(1f, 0, 0);
        preset.VeloLin = new Vector3(0, 0, 0);
        preset.VeloOrb = new Vector3(0.1f, 0, 0);
        preset.VeloRad = 0;
        preset.VeloSpd = 1f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(9, 0, 0);
        preset.NoiseFrq = 0.0024f;
        preset.NoiseOctaveCount = 1f;
        preset.NoiseOctaveMultiplier = 0;
        preset.NoiseOctaveScale = 0;
        preset.NoiseSpd = 307f;
        preset.NoisePos = -15f;
        preset.NoiseRot = 0;
        preset.NoiseScl = 0;
        preset.SizeLif = 2f;

        preset.EmoCoords = new Vector2(1, 0);

        return preset;
    }
    

  

    public static EmotionPreset getCue20()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 0);
        preset.Color1 = new Vector3(1f, 0f, 0);
        preset.Color2 = new Vector3(1.15f, 0.05f, 0);
        preset.VeloLin = new Vector3(0, 0, 10f);
        preset.VeloOrb = new Vector3(0, 0, 0);
        preset.VeloRad = 0;
        preset.VeloSpd = 2f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(0, 0, 2);
        preset.NoiseFrq = 0.009f;
        preset.NoiseOctaveCount = 1f;
        preset.NoiseOctaveMultiplier = 0f;
        preset.NoiseOctaveScale = 1f;
        preset.NoiseSpd = 60f;
        preset.NoisePos = -9f;
        preset.NoiseRot = 0;
        preset.NoiseScl = 0;
        preset.SizeLif = 3f;

        preset.EmoCoords = new Vector2(1, -1);

        return preset;
    }

    public static EmotionPreset getCueB22()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 0);
        preset.Color1 = new Vector3(0.05f, 0.11f, 0.5f);
        preset.Color2 = new Vector3(0, 0.1f, 1.84f);
        preset.VeloLin = new Vector3(3, 50, -50);
        preset.VeloOrb = new Vector3(0.8f, 0.09f, 0f);
        preset.VeloRad = -30;
        preset.VeloSpd = 0.1f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(-60, 0, 0);
        preset.NoiseFrq = 0.003f;
        preset.NoiseOctaveCount = 2f;
        preset.NoiseOctaveMultiplier = 1f;
        preset.NoiseOctaveScale = .2f;
        preset.NoiseSpd = 100f;
        preset.NoisePos = 4;
        preset.NoiseRot = 0;
        preset.NoiseScl = 0f;
        preset.SizeLif = 3f;

        preset.EmoCoords = new Vector2(-1, -1);

        return preset;
    }
    public static EmotionPreset getCue32()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 0);
        preset.Color1 = new Vector3(0.2f, -0.3f, 0.01f);
        preset.Color2 = new Vector3(0.97f, 0.04f, 0.01f);
        preset.VeloLin = new Vector3(0.03f, 0, -10f);
        preset.VeloOrb = new Vector3(0, 0, 0.15f);
        preset.VeloRad = 5;
        preset.VeloSpd = 4f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(0, 0, 0.9f);
        preset.NoiseFrq = 0.004f;
        preset.NoiseOctaveCount = 1;
        preset.NoiseOctaveMultiplier = 0;
        preset.NoiseOctaveScale = 0.5f;
        preset.NoiseSpd = 80;
        preset.NoisePos = 3.6f;
        preset.NoiseRot = 0.5f;
        preset.NoiseScl = 0;
        preset.SizeLif = 2f;

        preset.EmoCoords = new Vector2(-1, 0);

        return preset;
    }

    public static EmotionPreset getCue41()
       {
           EmotionPreset preset = new EmotionPreset();
           preset.ShapePos = new Vector3(0, 0, 0);
           preset.Color1 = new Vector3(3.5f, 0, 0);
           preset.Color2 = new Vector3(1, 0.36f, 0.3f);
           preset.VeloLin = new Vector3(0, 0, 0);
           preset.VeloOrb = new Vector3(0, 0, .3f);
           preset.VeloRad = -30f;
           preset.VeloSpd = 3;
           preset.VeloLimSpd = 0;
           preset.VeloDmp = 0;
           preset.NoiseStr = new Vector3(0, -2, 0);
           preset.NoiseFrq = 0.002f;
           preset.NoiseOctaveCount = 2f;
           preset.NoiseOctaveMultiplier = 4f;
           preset.NoiseOctaveScale = 0.2f;
           preset.NoiseSpd = 50;
           preset.NoisePos = 5;
           preset.NoiseRot = 1;
           preset.NoiseScl = 0;
           preset.SizeLif = 3f;

           preset.EmoCoords = new Vector2(-1, 1);

           return preset;
       }
}
