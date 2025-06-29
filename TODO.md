# TODO

## Roadmap to Beta

- [X] Basic Player object
- [X] Basic Projectile object that moves
- [X] Have player create the projectile
- [X] Input for shooting projectile
- [X] Basic Enemy object with hurtbox
- [X] Hitbox and hurtbox layer + interaction settings
- [X] Add hitbox to projectile that detects hits on hitboxes
- [X] Projectile can detect its hurtbox has hit
- [X] Player movement
- [X] Projectile tells enemy it is hit
- [X] Spell shapes. New IHitResponder and Area. Swap out projecile for Area
- [X] Spell choice based on button pressed
- [X] Hit responders can be set to apply damage. Set only projectile to do so
- [X] Enemies can be set to receive damage
- [X] Basic Object object hitbox but no damage
- [X] Basic damageable object using IDamageable. Has Enemy use IDamageable
- [X] Interactable objects, interaction input, and interaction targetting
- [X] Object collision
- [X] Spell effects: damage, freeze, push, and pull. Assign to four casting buttons
- [ ] Spell queue. Spells are made by reading the queue.
- [ ] Key object that's a trigger to inform player it touched one
- [ ] Doors are an interactable object that need their key to interact
- [ ] Basic enemy movement
- [ ] Basic enemy attack
- [ ] Basic player death
- [ ] Spell aiming
- [ ] Push, damage, freeze, and size puzzle
- [ ] A boss that can have phases
- [ ] Modify spells
- [ ] Basic level with a reset
- [ ] A boss room
- [ ] Effect system and states. Actually make the spells work
- [ ] Basic sound effect system: Walking, spells, queueing, enemy noises, object sounds
- [ ] Basic sprites
- [ ] Animation system based on state
- [ ] Screens: Title screen, lose screen, and win screen
- [ ] UI: Spells and hearts
- ...


## Features

### Entities
- [X] Player
- [X] Enemy
- [ ] Boss
- [X] Object
- [X] BreakableObject
- [X] InteractableObject
- [ ] Keys
- [ ] Doors

### Spells
- [X] Damage spell
- [X] Freeze spell
- [X] Push spell
- [X] Grow spell

### Systems
- [ ] Spell queue
- [ ] Spell modification
- [ ] Enemy combat AI
- [ ] Boss fights
- [ ] Effect system
- [ ] Level system (navigation, resets)
- [ ] Player death

### Puzzles
- [ ] Push puzzles
- [ ] Damage puzzles
- [ ] Freeze puzzles
- [ ] Size puzzles


## Bug Fixes


## Refactors

- [ ] Editor warnings and tips for required components
- [ ] PlayerController to separate concerns of player input vs action
- [ ] Effect System: EffectReceiver and IEffect
- [ ] Spell pooling