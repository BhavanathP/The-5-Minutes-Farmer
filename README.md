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

# GDD

## Project Title 
- The 5 Minutes Farmer 
## Genre 
- Casual / Farming / Time Management 
## Platform 
- PC (expandable later) 
## Camera 
- Top-down 2D 
## High-Level Concept 
The 5 Minutes Farmer is a short, fast-paced farming game where the player has only 5 minutes 
of real time to grow, harvest, and sell as many crops as possible.The game is designed as a 
prototype test for farming loops, scoring systems, and short-session gameplay. 
## Core Gameplay Loop 
1. The player moves around the farm grid. 
2. On each tile, they can: 
-  Plant seed 
-  Water crop 
-  Harvest grown crop 
3. Each harvested crop adds to the score. 
4. Crops vary in growth time and point value. 
5. When the timer reaches 0:00, the game ends, and the final score is shown. 
## Controls 
-  WASD / Arrow Keys → Move 
-  E → Interact (plant/water/harvest) 
## Features in Scope 
-  Timer system (5 minutes countdown) 
-  Farm grid with tile states (Empty → Planted → Watered → Growing → Harvestable) 
-  2 crop types: Carrot (fast, low points), Corn (slow, high points) 
-  Scoring system (points displayed in UI) 
-  Simple shop (unlock crop types/upgrades with harvested points) 
-  UI elements: Timer, Score, Game Over screen 
-  Basic sound effects (plant, water, harvest, game over) 
-  Placeholder 2D art (tiles, crops, farmer) 
## Stretch Goals (Optional) 
-  Random rain event (auto-waters crops) 
-  Persistent high score system 
-  Particle effects & polish 
## Art & Style 
-  Simple pixel/cartoon style
-  Bright colors, cheerful tone 
-  Minimal UI for clarity 
## Sound Design 
-  Upbeat farming background loop 
-  SFX for planting, watering, harvesting, game over 
---

# Technical Design Document (TDD) 
This TDD describes the modular architecture, systems, and components required to implement 
The 5 Minutes Farmer. It acts as a blueprint for development, ensuring clean, scalable, and 
reusable code. 
## Week 1 – Core Systems 
**1. Player Movement + Interaction**
-  Input System → abstraction for keyboard/controller/mobile 
-  PlayerManager → central façade, holds references 
-  PlayerMovementController → handles movement, acceleration, facing 
-  PlayerInteractionController → raycast/trigger detection for interactions 
-  PlayerAnimationController → wraps Animator, handles blending 
-  PlayerVFXController → optional dust, interaction effects (Optional) 
-  PlayerSFXController → footsteps, interaction sounds (Optional) 
**2. Farm Grid + Tile States**
-  GridManager → generates farm grid dynamically 
-  TileController → state machine (Empty, Planted, Watered, Growing, Harvestable) 
-  TileData (ScriptableObject) → defines tile/crop properties 
-  CropManager → controls crop lifecycle and state transitions 
-  TileVisualController → handles sprite/mesh updates 
**3. Timer System + Crop Growth/Harvest**
-  GameTimer → 5 min countdown, broadcasts tick/end events 
-  CropGrowthSystem → subscribes to timer, updates crop growth 
-  HarvestSystem → handles harvesting, inventory updates 
**4. Score System + Basic UI** 
-  ScoreManager → tracks points, raises OnScoreChanged event 
-  UIManager → listens to ScoreManager/GameTimer, updates UI 
-  GameOverUI → shows final score, restart button 
## Week 2 – Expansion & Polish 
**5. Second Crop Type + Shop System** 
-  CropData (ScriptableObject) → defines crop properties (name, growth, value) 
-  ShopManager → UI for buying seeds/upgrades 
-  CurrencyManager → tracks in-game currency 
-  UnlockSystem → unlocks crops/items when purchased 
**6. Audio + Placeholder Art** 
-  AudioManager → singleton/service locator, pools sounds 
-  Placeholder Art → simple sprites for farmer, tiles, crops 
-  VFXController → particle effects for planting/harvesting 
**7. Playtest + Bug Fixes** 
-  Debug logging 
-  Balance crops (growth vs. value) 
-  Fix colliders, animation glitches 
**8. Final Polish + Build + Screenshots** 
-  Clean UI layout 
-  Fix art scaling issues 
-  Export PC build 
-  Capture screenshots of gameplay
