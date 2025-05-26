using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] int matchedPairs = 0;
    [SerializeField] CardObject firstChoice = null;
    [SerializeField] CardObject secondChoice = null;

    [SerializeField] GameObject cardGameObject;

    [SerializeField] CardInfo[] cardsToSpawn;
    [SerializeField] Transform cardsParent;

    List<CardObject> cardObjects = new List<CardObject>();

    void Start()
    {
        matchedPairs = 0;
        SpawnCards(cardsToSpawn.Length * 2);
        ShuffleCards(cardObjects);

    }

    void SpawnCards(int length)
    {
        for (int i = 0; i < length; i++)
        {
            CardObject cardO = Instantiate(cardGameObject, cardsParent).GetComponent<CardObject>();
            cardO.cardManager = this;
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
        if (firstChoice == null)
        {
            firstChoice = card;
        }
        else if (secondChoice == null)
        {
            secondChoice = card;
            CheckMatching(firstChoice, secondChoice);
            firstChoice = null;
            secondChoice = null;
        }
    }

    void CheckMatching(CardObject a, CardObject b)
    {
        if (a.cardInfo.cardName == b.cardInfo.cardName)
        {
            matchedPairs++;
        }
        else
        {
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

}
