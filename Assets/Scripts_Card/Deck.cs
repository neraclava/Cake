using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    [SerializeField] Card CardObj;
    [SerializeField] Hand HandObj;
    List<Card> mCardList = new List<Card>();

    private void Start()
    {
        for (int i = 0; i <3; i++)
        {
            Card Card = Spawn();
            Card.gameObject.SetActive(false);
            mCardList.Add(Card);
        }

    }
    Card Spawn()
    {
        Card tCard = Instantiate(CardObj, transform);
        tCard.cardEffect = (Card.CardEffect)Random.Range(0, 3);
        tCard.value = Random.Range(1, 11);
        tCard.SetCardText();
        return tCard;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Card tDrawCard = Draw();
            tDrawCard.transform.SetParent(HandObj.transform);
            tDrawCard.gameObject.SetActive(true);
        }
    }
    private Card Draw()
    {
        Card tCard = mCardList[0];
        mCardList.RemoveAt(0);
        return tCard;
    }
}