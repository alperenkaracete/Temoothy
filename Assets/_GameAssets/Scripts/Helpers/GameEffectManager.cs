public static class GameEffectManager
{
    public static void PlayShakeForDamage()
    {
        CameraShake.Instance.HandleCameraShake(Others.CAMERA_SHAKE_AMP_FOR_DAMAGE, Others.CAMERA_SHAKE_DURATION_FOR_DAMAGE);
    }

    public static void PlayShakeForInstantDeath()
    {
        CameraShake.Instance.HandleCameraShake(Others.CAMERA_SHAKE_AMP_FOR_INSTA_DEAD, Others.CAMERA_SHAKE_DURATION_FOR_INSTA_DEAD);
    }
}
