using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : Minigame
{
    [SerializeField] int matchedPairs = 0;
    [SerializeField] int pairsToWin = 3;
    [SerializeField] CardObject firstChoice = null;
    [SerializeField] CardObject secondChoice = null;

    [SerializeField] GameObject cardGameObject;

    [SerializeField] List<CardInfo> spawnableCards;
    private CardInfo[] cardsToSpawn;
    [SerializeField] Transform cardsParent;

    List<CardObject> cardObjects = new List<CardObject>();

    [SerializeField] private List<Sprite> customBacks = new List<Sprite>();

    [SerializeField] AudioClip flipSound;
    [SerializeField] AudioClip wrongSound;
    [SerializeField] AudioClip correctSound;


    private int customBacksID = 0;

    new void Start()
    {
        base.Start();

        List<CardInfo> shuffledCardInfo = ShuffleList<CardInfo>(spawnableCards);
        cardsToSpawn = shuffledCardInfo.GetRange(0, pairsToWin).ToArray<CardInfo>();

        if (customBacks != null && customBacks.Count > 0)
        {
            customBacks = ShuffleList<Sprite>(customBacks);
        }


            matchedPairs = 0;
        SpawnCards(pairsToWin * 2);
        ShuffleCards(cardObjects);
    }

    void SpawnCards(int length)
    {
        for (int i = 0; i < length; i++)
        {
            CardObject cardO = Instantiate(cardGameObject, cardsParent).GetComponent<CardObject>();
            cardO.cardManager = this;

            if (customBacks != null && customBacks.Count > 0)
            {
                cardO.backSprite = customBacks[customBacksID];
                cardO.backImage.sprite = customBacks[customBacksID];
                customBacksID++;
            }

            cardObjects.Add(cardO);
        }
    }

    void ShuffleCards(List<CardObject> cardObjects)
    {
        List<CardInfo> cardsSpawned = new List<CardInfo>();

        foreach (CardInfo cardInfo in cardsToSpawn)
        {
            cardsSpawned.Add(cardInfo);
            cardsSpawned.Add(cardInfo);
        }

        cardsSpawned = ShuffleList(cardsSpawned);

        for (int i = 0; i < cardsSpawned.Count; i++)
        {
            cardObjects[i].cardInfo = cardsSpawned[i];
        }
    }

    public void SetSelected(CardObject card)
    {
        Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(flipSound);
        if (firstChoice == null)
        {
            firstChoice = card;
        }
        else if (secondChoice == null)
        {
            secondChoice = card;
            StartCoroutine(CheckMatching(firstChoice, secondChoice));
            firstChoice = null;
            secondChoice = null;
        }
    }

    IEnumerator CheckMatching(CardObject a, CardObject b)
    {
        yield return new WaitForSeconds(0.4f);
        if (a.cardInfo.cardName == b.cardInfo.cardName)
        {
            matchedPairs++;
            a.SetMatched(true);
            Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(correctSound);
        }
        else
        {
            Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(wrongSound);
            a.Hide();
            b.Hide();
        }
    }


    //From https://www.wayline.io/blog/how-to-shuffle-a-list-in-unity but modified to be generic
    public static List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }

    protected override bool HasWon()
    {
        return pairsToWin <= matchedPairs;
    }

}
