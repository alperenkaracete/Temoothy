# Changelog

## [0.3.1] - 2025-06-02

### Edited
- Sound button become functional.

## [0.3.0] - 2025-06-02

### Edited
- Sound added.

## [0.2.9] - 2025-06-01

### Edited
- Cutscene added.

## [0.2.8] - 2025-06-01

### Edited
- Camera shake added.
- When player dead, or gets any damage camera shakes.

## [0.2.7] - 2025-06-01

### Edited
- Post processing edited.

## [0.2.6] - 2025-06-01

### Added
- Shaders added.

## [0.2.5] - 2025-05-31

### Added
- Scene transitions polished.
- Smooth transition added.

## [0.2.4] - 2025-05-31

### Added
- Main menu created.
- Button animations added.

## [0.2.3] - 2025-05-31

### Added
- Cat animations added.
- Cat kills player instantly.
- Game over when cat attacks to player.

## [0.2.2] - 2025-05-30

### Added
- Cat model added.
- Cat movement added.

## [0.2.1] - 2025-05-29

### Added
- Added fire damageables.
- When player land on a fire, gets 1 damage.

## [0.2.0] - 2025-05-29

### Added
- Added level environment.
- Designed new level.

## [0.1.9] - 2025-05-29

### Added
- Added restart system on win/lose screens.

## [0.1.8] - 2025-05-29

### Added
- Added win and lose popup windows.
- Player win when collect five eggs.
- Player lost when lost all lifes. 

## [0.1.7] - 2025-05-28

### Added
- Added settings button.
- Player can pause the game by pressing settings button. 

## [0.1.6] - 2025-05-28

### Added
- Added new 5 type of eggs.
- Added egg counter system to keep track of collceted eggs.
- Added egg counter UI.
- Added win condition when player collects all eggs.

## [0.1.5] - 2025-05-28

### Added
- Added timer rotation animation.
- Added timer system and format.

## [0.1.4] - 2025-05-27

### Added
- Added player health system.
- Added health lost/gain animations.

## [0.1.3] - 2025-05-27

### Added
- Added UI elements for player actions, buffs/debuffs, timer, and player health.
- Players can now clearly see their current state and active power-ups.

### Fixed
- Fixed an issue where the player could not jump at maximum speed.
- Improved jump physics: the player now falls more quickly and naturally after jumping.

## [0.1.2] - 2025-05-26

### Added
- Added new `Spatula`. Spatula gives a jump boost to player.
- Added new animations for Spatula.

### Modified
- Modified `BrownWheatCollectible`, `GoldWheatCollectible`, and `GreenWheatCollectible` to utilize `WheatDesignSO` for improved modularity and performance.

## [0.1.1] - 2025-05-26

### Added
- Added `WheatDesignSO` ScriptableObject to manage wheat configuration data.

### Modified
- Modified `BrownWheatCollectible`, `GoldWheatCollectible`, and `GreenWheatCollectible` to utilize `WheatDesignSO` for improved modularity and performance.

## [0.1.0] - 2025-05-26

### Added
- Interface added for wheat types.

## [0.0.9] - 2025-05-25

### Added
- Converted wheat types into collectible items.
- Player can now collect 3 types of wheat.
- Brown Wheat decreases the player's movement speed.
- Gold Wheat increases the player's movement speed.
- Green Wheat increases the player's jump speed.

### Modified
- Updated `PlayerController` and `PlayerInteractionController` to apply wheat effects.

## [0.0.8] - 2025-05-23

### Added
- Added `WheatTypes` class to define 3 wheat types.
- Added `PlayerInteractionControl` for managing player interactions with wheats.
- Added animations for wheats.

## [0.0.7] - 2025-05-23

### Added
- Added `ActionTypes` class to define player action types.
- Added `PlayerAnimationController` for managing and updating the current player animations.
- Added `GetCurrentSpeed()` function to `PlayerController` class for accessing current speed.
- Added `SetMovementSpeed()` function to `PlayerController` class for handling player's current speed.

## [0.0.7] - 2025-05-23

### Added
- Added `ActionTypes` class to define player action types.
- Added `PlayerAnimationController` for managing and updating the current player animations.
- Added `GetCurrentSpeed()` function to `PlayerController` class for accessing current speed.
- Added `SetMovementSpeed()` function to `PlayerController` class for handling player's current speed.

## [0.0.6] - 2025-05-23

### Added
- Added `PlayerState` enum to define player action states.
- Added `StateController` for managing and updating the current player state.

### Fixed
- Updated `PlayerController` for state handling logic to use new `PlayerState` enum values.

## [0.0.5] - 2025-05-23

### Added
[+] Added camera follow system for 3rd person character.

### Fixed
[~] Fixed character rotation problem.

## [0.0.4] - 2025-05-23

### Added
[+] Added project starter files.
[+] Added character move/slide.
[+] Added character jump.
[+] Added character movement speed limit.

## [0.0.3] - 2025-05-22

### Added
[+] Completed the project setup.

## [0.0.2] - 2025-05-22

### Added
[+] Required Unity packages have been added.

## [0.0.1] - 2025-05-21

### Added
[+] Required Unity project files have been added.