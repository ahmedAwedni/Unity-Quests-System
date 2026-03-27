# Unity Quest System

A clean, modular, and event-driven Quest System for Unity. Built using **ScriptableObjects** to define quests and a lightweight manager to track runtime progress, making it incredibly easy to integrate into RPGs, adventure games, or any project requiring objective tracking.

---

## 📦 Included Scripts

- QuestState.cs
- QuestObjective.cs
- QuestData.cs
- QuestInstance.cs
- QuestManager.cs

---

## ✨ Features

* **ScriptableObject Blueprints:** Design and configure quests, descriptions, and rewards entirely in the Unity Editor without writing code.
* **Multi-Objective Support:** Quests can have multiple distinct objectives (e.g., "Defeat 10 Goblins" AND "Collect 1 Magic Gem").
* **Event-Driven Architecture:** Uses C# "Actions" to broadcast quest acceptance, progress updates, and completion, ensuring your UI remains decoupled from your game logic.
* **Non-Destructive Data:** Uses a runtime wrapper ("QuestInstance") to track player progress, ensuring your base "QuestData" assets are never accidentally modified during gameplay.

---

## 🧠 Design Notes

This system separates **Definition** from **State**. 
* "QuestData" (ScriptableObject) acts as the immutable blueprint. 
* "QuestInstance" (C# Class) is generated at runtime when a quest is accepted. It creates a deep copy of the objectives so that player progress (like killing 3 out of 5 slimes) doesn't overwrite your project's asset files.

This Data-Oriented approach is memory-efficient and keeps your project highly organized, scaling smoothly from 5 quests to 500.

---

## 🧩 How To Use

1. **Create a Quest:** Right-click in your Project window: "Create > Quest System > Quest". Fill in the ID, title, objectives, and rewards.
2. **Setup the Manager:** Attach the "QuestManager.cs" script to a persistent GameObject in your scene (like your Player or GameManager).
3. **Accepting a Quest:** Call this method from an NPC or an interaction script:

   questManager.AcceptQuest(myQuestDataReference);
4. **Updating Progress:** When the player does something (like killing an enemy), update the objective:

   // Updates Objective 0 of the "slayer_quest" by 1
      questManager.UpdateObjectiveProgress("slayer_quest", 0, 1);
5.**Listening for UI:** Subscribe your UI scripts to the static events to display notifications:

   QuestManager.OnQuestCompleted += ShowRewardPopup;

---

## 🚀 Possible Extensions

* **Inventory Integration:** Add an ItemData field to the rewards section of QuestData to grant physical items upon completion.
* **Prerequisite Quests:** Add a List<QuestData> requiredQuests field to block players from accepting quests until previous ones are finished.
* **Save/Load System:** Serialize the activeQuests list into JSON to easily save the player's exact objective progress between sessions.
* **NPC Quest Givers:** Create a simple QuestGiver MonoBehaviour that holds a QuestData reference and triggers AcceptQuest on interaction.

---

## 🛠 Unity Version

Tested in Unity6+ (should also work without problems in the newer versions)

---

## 📜 License

MIT
