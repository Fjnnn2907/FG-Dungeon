using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.PixelArtPlatformer_Dungeon;
using UnityEngine.Playables;
public class QuestManager : MonoBehaviour
{
    [SerializeField] protected ItemData itemSO;
    [SerializeField] protected int countItem;
    [SerializeField] protected Door door;
    [SerializeField] protected PlayableDirector playableDirector;

    private bool hasPlayed = false;
    private void OnEnable()
    {
        Obsever.AddObsever("Quest", Quest);
    }

    private void OnDestroy()
    {
        Obsever.RemoveObsever("Quest", Quest);
    }

    protected void Quest()
    {
        if (hasPlayed) return;

        if (GameManager.instance.inventoryManager.CheckItem(itemSO, countItem))
        {
            if (playableDirector == null) return;

            playableDirector.Play();
            hasPlayed = true;
        }

    }
}
