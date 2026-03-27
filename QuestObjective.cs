using UnityEngine;

public enum QuestState
{
    Inactive,
    Active,
    Completed
}

[System.Serializable]
public class QuestObjective
{
    public string objectiveName; // e.g.: "Kill Slimes" or "Collect Apples"
    public int requiredAmount;
    public int currentAmount { get; private set; }

    public bool IsCompleted => currentAmount >= requiredAmount;

    public void AddProgress(int amount)
    {
        currentAmount = Mathf.Clamp(currentAmount + amount, 0, requiredAmount);
    }
}
