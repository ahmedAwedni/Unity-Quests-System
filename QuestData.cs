using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest System/Quest")]
public class QuestData : ScriptableObject
{
    public string questID; // Unique identifier
    public string questTitle;
    [TextArea] public string description;
    
    public List<QuestObjective> objectives;

    [Header("Rewards")]
    public int goldReward;
    public int experienceReward;
    
}
