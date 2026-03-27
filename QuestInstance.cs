[System.Serializable]
public class QuestInstance
{
    public QuestData data;
    public QuestState state;
    public List<QuestObjective> runtimeObjectives;

    public QuestInstance(QuestData questData)
    {
        data = questData;
        state = QuestState.Inactive;
        
        // Deep copy the objectives so the ScriptableObject is not modified
        runtimeObjectives = new List<QuestObjective>();
        foreach (var obj in questData.objectives)
        {
            runtimeObjectives.Add(new QuestObjective 
            { 
                objectiveName = obj.objectiveName, 
                requiredAmount = obj.requiredAmount 
            });
        }
    }
}
