using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] Text NameText;
    [SerializeField] Text DescriptionText;

    // パラメータ
    [Header("効果の種類")]
    public CardEffect cardEffect;
    [Header("効果値")]
    public int value;

    #region 効果の種類定義部
    // カード効果定義
    public enum CardEffect
    {
        Rock,
        Scissors,
        Paper,
    };

    // 効果名(JP)
    readonly public static Dictionary<CardEffect, string> EffectNameDic = new Dictionary<CardEffect, string>()
    {
        { CardEffect.Rock,     "グー {0}" },
        { CardEffect.Scissors, "チョキ {0}" },
        { CardEffect.Paper,    "パー {0}" },
    };

    // 効果説明(JP)
    readonly public static Dictionary<CardEffect, string> EffectExplainDic = new Dictionary<CardEffect, string>()
    {
        { CardEffect.Rock,     "相手に {0} のダメージを与える" },
        { CardEffect.Scissors, "相手に {0} のダメージを与える" },
        { CardEffect.Paper,    "自分の体力を {0} 回復する" },
    };
    #endregion

    void Awake()
    {
        
    }
    public void SetCardText()
    {
        // インスタンスフィールドへの代入はここで行う
        if (NameText != null)
            NameText.text = string.Format(EffectNameDic[cardEffect], value);
        if (DescriptionText != null)
            DescriptionText.text = string.Format(EffectExplainDic[cardEffect], value);
    }
}

