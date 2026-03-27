using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static event Action<QuestInstance> OnQuestAccepted;
    public static event Action<QuestInstance> OnQuestProgressed;
    public static event Action<QuestInstance> OnQuestCompleted;

    public List<QuestInstance> activeQuests = new List<QuestInstance>();

    public void AcceptQuest(QuestData questData)
    {
        if (activeQuests.Exists(q => q.data.questID == questData.questID))
        {
            Debug.LogWarning("Quest already active!");
            return;
        }

        QuestInstance newQuest = new QuestInstance(questData);
        newQuest.state = QuestState.Active;
        activeQuests.Add(newQuest);

        OnQuestAccepted?.Invoke(newQuest);
    }

    public void UpdateObjectiveProgress(string questID, int objectiveIndex, int amount)
    {
        QuestInstance quest = activeQuests.Find(q => q.data.questID == questID);
        
        if (quest != null && quest.state == QuestState.Active)
        {
            if (objectiveIndex >= 0 && objectiveIndex < quest.runtimeObjectives.Count)
            {
                quest.runtimeObjectives[objectiveIndex].AddProgress(amount);
                OnQuestProgressed?.Invoke(quest);

                CheckQuestCompletion(quest);
            }
        }
    }

    private void CheckQuestCompletion(QuestInstance quest)
    {
        foreach (var objective in quest.runtimeObjectives)
        {
            if (!objective.IsCompleted) return; // If any objective is not done, exit
        }

        CompleteQuest(quest);
    }

    private void CompleteQuest(QuestInstance quest)
    {
        quest.state = QuestState.Completed;
        activeQuests.Remove(quest);
        
        // Here is where you would normally give the player their rewards
        Debug.Log($"Rewarded {quest.data.goldReward} Gold and {quest.data.experienceReward} EXP!");

        OnQuestCompleted?.Invoke(quest);
    }
}
