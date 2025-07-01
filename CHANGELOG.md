# CHANGELOG

## [v0.0.20] 2025-06-30

- Spell data changes based on queue
- Spell builder interprets queue to set modifiers such as size and speed
- Separates concerns for casting spells: SpellRegistry for data, SpellCaster for casting logic, and SpellCasterBuilder for deciding which spell based on spell queue


## [v0.0.19] 2025-06-29

- Player casting spell now references mouse position for direction of projectiles


## [v0.0.18] 2025-06-29

- Updates Enemy with player targeting, movement, attack cooldown, and attacking
- Gives player the ability to take hits
- Updates hitbox to ignore source to prevent self-hits
- New timer object for tracking times


## [v0.0.17] 2025-06-29

- Adds Door prefab that's in Interactable
- Door will open if player has collected key
- Key will be removed once used


## [v0.0.16] 2025-06-29

- Player can now collect a key
- New Key object prefab


## [v0.0.15] 2025-06-29

- Adds SpellQueue data structure
- Player controls now use 1, 2, 3, 4 for spell queue and SPACE to cast the spell


## [v0.0.14] 2025-06-28

- Player has two new spells: Push and Size


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