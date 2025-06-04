# 🕹️ Teemothy

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
  - PC: Use **WASD** for movement, **Spacebar** to jump, and **E/R** for actions like moving,sliding.
  - Android: On-screen **joystick** for movement, **jump** and **slide/move** buttons for interaction.

## 🛠️ Technologies

- Unity 6
- C#
- [DOTween](http://dotween.demigiant.com/)
- Cinemachine
- Transition Manager
- Joystick Package