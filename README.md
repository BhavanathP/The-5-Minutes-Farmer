# 🌱 5 Minute Farmer  

## 🎮 Overview  
**5 Minute Farmer** is a short, fast-paced farming game where the player has only **5 minutes of real time** to plant, grow, harvest, and sell crops.

## 🧩 Core Gameplay  
- Plant seeds on tiles  
- Water crops and wait for them to grow  
- Harvest to gain points  
- Timer counts down from 5 minutes  
- Multiple crop types with different values  
- Shop system to unlock crops/upgrades  

## 🛠 Tech Stack  
- **Engine:** Unity (2D URP)  
- **Language:** C#  
- **Version Control:** Git (Bitbucket + Sourcetree)  
- **Project Management:** Trello 
- **Communication:** Slack (Plug&Play Studio)  

## 🚀 Development Timeline  
**Week 1 – Core Systems**  
- Player movement + interaction  
- Farm grid + tile states  
- Timer + crop growth/harvest  
- Score system + basic UI  

**Week 2 – Expansion & Polish**  
- Add 2nd crop type + shop system
- Audio + placeholder art  
- Playtest + bug fixes  
- Final polish + build

# 👩‍💻 Contributing Guidelines – 5 Minute Farmer

## 🔀 Branching Model
- `main` → stable release builds only  
- `develop` → active sprint build  
- `feature/*` → feature branches (e.g., `feature/player-movement`)

## 💬 Commit Messages
Follow format:  
`[Feature] Short description`  
Examples:  
- `[Player] Added movement controller`  
- `[Farming] Implemented tile state transitions`

## ✅ Pull Requests
1. Always branch from `develop`.  
2. Commit small, logical changes.  
3. Open a PR into `develop`.  
4. Teammate reviews & approves before merging.  

## 📦 Sprint Workflow
- Tasks tracked in Trello.  
- Pick tasks from **This Sprint** column.  
- Move card → `In Progress` → `Done` when complete.  

---

5 Minutes Farmer – GDD 
Project Title 
The 5 Minutes Farmer 
Genre 
Casual / Farming / Time Management 
Platform 
PC (expandable later) 
Camera 
Top-down 2D 
High-Level Concept 
The 5 Minutes Farmer is a short, fast-paced farming game where the player has only 5 minutes 
of real time to grow, harvest, and sell as many crops as possible.The game is designed as a 
prototype test for farming loops, scoring systems, and short-session gameplay. 
Core Gameplay Loop 
1. The player moves around the farm grid. 
2. On each tile, they can: 
○ Plant seed 
○ Water crop 
○ Harvest grown crop 
3. Each harvested crop adds to the score. 
4. Crops vary in growth time and point value. 
5. When the timer reaches 0:00, the game ends, and the final score is shown. 
Controls 
● WASD / Arrow Keys → Move 
● Spacebar / Left Mouse Click → Interact (plant/water/harvest) 
● R → Restart game 
Features in Scope 
● Timer system (5 minutes countdown) 
● Farm grid with tile states (Empty → Planted → Watered → Growing → Harvestable) 
● 2 crop types: Carrot (fast, low points), Corn (slow, high points) 
● Scoring system (points displayed in UI) 
● Simple shop (unlock crop types/upgrades with harvested points) 
● UI elements: Timer, Score, Game Over screen 
● Basic sound effects (plant, water, harvest, game over) 
● Placeholder 2D art (tiles, crops, farmer) 
Stretch Goals (Optional) 
● Random rain event (auto-waters crops) 
● Persistent high score system 
● Particle effects & polish 
Art & Style 
● Simple pixel/cartoon style 
● Bright colors, cheerful tone 
● Minimal UI for clarity 
Sound Design 
● Upbeat farming background loop 
● SFX for planting, watering, harvesting, game over 
Development Timeline (2 Weeks) 
Week 1 – Core Systems 
● Player movement + interaction 
● Farm grid + tile states 
● Timer system + crop growth/harvest 
● Score system + basic UI 
Week 2 – Expansion & Polish 
● Add 2nd crop type + shop system 
● Implement audio + placeholder art 
● Playtest + bug fixes 
● Final polish + build + screenshots
