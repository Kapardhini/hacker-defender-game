# HackShield 101 — Hacker vs. Defender VR Game

A Unity 3D game that gamifies cybersecurity concepts through an interactive "Hacker vs. Defender" scenario set in a virtual server room.

## What it is

Players take on one of two roles — **Hacker** or **Defender** — and navigate a 3D environment where they interact with game objects representing real network security concepts. The goal is to make cybersecurity education immersive and engaging through gameplay rather than passive learning.

## Built with

- Unity 3D (VR Level Design)
- C# scripting
- Unity Collider & Trigger systems
- UI Canvas for in-game HUD
- Scene management for multi-stage game flow

## How to open

1. Clone this repo
2. Open Unity Hub → **Add project from disk** → select the cloned folder
3. Open the main scene from `Assets/Scenes/`
4. Press **Play** in the Unity Editor to run

-> Built and tested on Unity 2022.x. Earlier versions may have compatibility issues.

## Project structure

Assets/
├── Scenes/         # Main game scenes
├── Scripts/        # C# game logic (role switching, triggers, UI, sequence logic)
├── Prefabs/        # Interactive game objects
└── UI/             # Canvas and HUD elements

## Commit history

| Commit -> What was built |

| Initial Unity project -> Base Unity setup and scene scaffolding 
| Walls, mini game -> Environment walls and mini-game mechanics 
| Defender game -> Defender role logic and interactions 
| Hacker game -> Hacker role logic and attack simulation 
| Final ->Sequence Logic and UI Fix | Game sequence flow, win/loss logic, UI polish |

## Author

Sri Kapardhini Nadella — Game logic, C# scripting | 
Anvitha Vinnakota -  UI, scene design
