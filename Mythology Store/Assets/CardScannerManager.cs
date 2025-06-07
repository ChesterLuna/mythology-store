using Unity.Cinemachine;
using UnityEngine;

public class CardScannerManager : Minigame
{
    public bool hasScanned = false;

    public CinemachineCamera cmCamera;

    new void Start()
    {
        
    }

    public void DelayStart()
    {
        base.Start();
        // Move Camera
        cmCamera.Priority = 3;
    }

    protected override bool HasWon()
    {
        return hasScanned;
    }

    protected override void BeforeDestroying()
    {
        cmCamera.Priority = -2;
    }


}
