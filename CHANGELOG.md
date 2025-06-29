# CHANGELOG

## [v0.0.13] 2025-06-28

- Player, objects, and enemies now respect collision
- Adds collider and rigid body settings to player, object, and enemy


## [v0.0.12] 2025-06-09

- Player has an Interactor which can detect interaction collisions with interactable objects
- Adds option to press E to interact
- Adds InteractableObject prefab


## [v0.0.11] 2025-06-08

- Adds Object and BreakableObject prefeb
- Abstracts taking damage into IDamagable
- Modifies HitResponder to check if target is damageable before applying damage


## [v0.0.10] 2025-06-08

- Spells can now be set to deal damage
- Enemies can receive damage


## [v0.0.9] 2025-06-08

- Player detects if pressing 1 for projectile and 2 for area


## [v0.0.8] 2025-06-08

- Adds the Area prefab
- Abstracts hit responding of the projectile to HitResponder
- Adds Area.cs which is a HitResponder
- Sets Player spell to be Area


## [v0.0.7] 2025-06-08

- Adds Enemy.cs
- Projectile calls TakeDamage in Enemy.cs on hit

## [v0.0.6] 2025-06-08

- Adds PlayerController
- PlayerController gets movement input and moves the player


## [v0.0.5] 2025-06-08

- Adds Hitbox.cs to Hitbox object
- Hitbox detects collisions with hurtboxes


## [v0.0.4] 2025-06-08

- Moves projectile spawn to Update based on if the space key is pressed


## [v0.0.3] 2025-06-08

- Moves projectile spawn to Update based on if the space key is pressed


## [v0.0.2] 2025-06-08

- Adds a Projectile game object prefab
- Adds Projectile.cs
- Player spawns projectile


## [v0.0.1] 2025-06-08

- adds Player game object
- adds Prefabs and Scripts folder
- adds CHANGELOG.md