# Sword-Fight
This is an action-adventure 3D game, featuring an engaging combat system and AI-driven enemies. The game utilizes a generic state machine to manage player and enemy behaviors dynamically and employs the observer pattern for efficient event handling, such as tracking player status and AI responses.

---

## Features

Scriptable Objects: Used to store and configure player and enemy data, making it easier to adjust settings without modifying code.

Character Controller: Handles smooth player movement and enemy AI interactions.

NavMesh: Utilized for enemy AI navigation and pathfinding.

Cinemachine: Provides dynamic and smooth camera movement for an immersive gameplay experience.

---

## Design Patterns

This project follows multiple design patterns to ensure maintainability and flexibility:


MVC Architecture: Separates the game logic into Model, View, and Controller for better code organization.

Dependency Injection: Injects dependencies between objects to reduce coupling and improve modularity.

State Pattern: Implements a generic state machine to manage different states for both player and enemy (e.g., Idle, Attacking, Patrolling).

Observer Pattern: Used for event-based communication, such as notifying systems when the player dies.

---

## How to Play

Move: Use the W, A, S, and D keys to move the player.

Attack: Click the Left Mouse Button to attack enemies.

---

## Watch

https://www.loom.com/share/bae7671eb1e145139f397e3837644871?sid=60c7451d-03d0-45d7-a88b-88750ac7b4ca
