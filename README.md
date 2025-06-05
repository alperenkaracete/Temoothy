# 🕹️ Teemothy 🐤

A third-person game prototype developed in Unity. The project focuses on core gameplay mechanics such as movement, pause/resume system, dynamic camera shake, UI transitions, and more.

## 🚀 Features

- 🎮 **Character Movement**: Smooth player movement with Rigidbody physics.
- 🐱 **Chaser AI**: Simple AI logic with NavAgent. Cat follow chick when player enters floor ground.
- ⏸️ **Pause/Resume System**: Game can be paused and resumed with saved velocity.
- 🔊 **Audio Manager**: Centralized sound system with volume controls for effects/music.
- 🎥 **Camera Shake**: Cinemachine-based shake effect triggered on events like damage or dead.
- 🎬 **Cutscene Support**: Optional camera transitions for cinematic sequences.
- 🧭 **Scene Transitions**: Smooth fades between scenes via a TransitionManager.
- ⚙️ **Settings Menu**: Toggle sound on/off and adjust volume via UI buttons.
- 🎮 **Main Menu**:   Users can start the game, quit, view the credits, or access the how-to-play instructions.
- 📜 **Event System**: Uses Unity Events for loose coupling between UI and logic layers.
- 🖥️📱 **Cross-Platform Support**: Fully playable on both PC and Android.

## 🛠️ Technologies

- Unity 6
- C#
- [DOTween](http://dotween.demigiant.com/)
- Cinemachine
- Transition Manager
- Joystick Package

## 🎮 How To Play

### Controls:
- **PC**: Use **WASD** to move, **Spacebar** to jump, and **E** / **R** for sliding or special actions.
- **Android**: Use the on-screen **joystick** for movement, and **Jump** / **Slide** buttons for actions.

---

### 🥖 Collectibles:
- **Wheats** (3 types):
  - **Green Wheat**: Increases jump distance.
  - **Golden Wheat**: Increases movement speed.
  - **Brown Wheat**: Decreases movement speed.
  
- **Eggs** (5 types):
  - Collecting all 5 eggs results in a **win**.

---

### 💀 Damage Sources:
- **Cat**:
  - The cat moves on a NavMesh surface.
  - When the player enters the area, the cat starts chasing.
  - If caught by the cat, the game is **lost**.

- **Fire**:
  - Jumping on fire causes the player to lose **1 health** and be pushed away with force.

---

### 🚀 Boostables:
- **Spatula**:
  - Jumping on a spatula gives the player a **jump boost**.

---

### 🕹️ Player Actions:
- **Move**: Player moves at a fixed speed.
- **Slide**: Faster than normal movement, used for quick bursts.
- **Jump**: Standard jump action.

---

### 🏁 Win / Lose Conditions:
- **Win**: Collect all 5 eggs.
- **Lose**: 
  - Get caught by the cat, or  
  - Lose all 3 health points.