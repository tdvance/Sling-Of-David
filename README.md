#Sling David

Game Design Document

## Game Concept

This is the author’s first Unity3d game that is not a clone.  It may share similarities with a very popular game, but the principal mechanic is quite different.

Emulate Boy David (who would later become King David) and try to match his skills with the sling.  Drag the sling with the mouse (or touchscreen) repeatedly to build angular momentum and release to send the stone flying toward various structures and attempt to destroy them.

## Rules and Mechanics
### Summary
The sling transfers drag velocity to rotational energy of the stone.  When the stone is circling at the desired speed, and when it reaches the right place in the circle, release and let the stone fly.  The stone, if aimed properly, smashes into structures made of blocks of various types, bonus smash-ups (like pickups, but you smash them instead), and enemies.  You are given a fixed number of rocks to use, and must destroy all the enemies to continue to the next level.  Points are scored for damage dealt and destruction of items.  More points are given for destroying an object with fewer separate colisions.  For maximum score, try to destroy objects with just one hit.
### Game States
#### Splash Screen
+ Lasts 2.5 seconds, then goes to last saved position in *Progress Map*
+ Shows company logo
+ Shows game title
+ Plays short intro music

#### Progress Map
+ If first level on the next page was just unlocked, unlock a new page and go to *New Page* state before doing the rest
+ A graph of progression through game levels
+ Locked levels are grayed out
+ Current level is highlighted, and is usually the last unlocked level
+ User can select any unlocked level, or go forward/backward to other pages of the progress map (if any have been unlocked yet).
+ Each level shows highest score attained on that level, with some indication of how that compares to par levels.
+ Last score attained and which level it was on is displayed on the page
+ Selecting a level goes to *Start Level* for that level
+ Options Menu button, the “cog” or settings button goes to *Options Menu* state.

#### Options Menu
	Allowed actions are are:
+ Set music volume
+ Set sound effects volume
+ Return to *Progress Map* state
####  Start Level
+ Load appropriate level scene
+ Show score (initially 0) and highest score attained for this level, as well as par rating
+ Optional animation of level
+ Disable the Next Level and Restart Level buttons
+ After time required for animation, etc., go to *Empty Sling* state

#### Empty Sling
+ Show the sling and the current inventory of rocks
+ After a short delay (1.5 seconds), go to *Get A Rock* state
####Get A Rock
+ If no enemies remaining, enable Next Level button
+ If there are rocks remaining, remove first rock from inventory and add it to sling
+ Pressing Next Level, if enabled, goes to *End Level* state
+ Pressing Restart Level, if enabled, goes to *Start Level* state
+ If sling has rock, go to *Sling With Rock* state

#### Sling With Rock
+ If sling is dragged, go to *Sling Spinning* state
+ If Next Level button is enabled and pressed, go to *End Level* state
#### Sling Spinning
+ While sling is dragged, increase angular momentum of rock, otherwise decrease angular momentum
+ When drag is released, go to *Rock Deployed* state
+ If drag is released and speed is too slow, treat as a “cancel” and return to *Sling With Rock* state

#### Rock Deployed
+ Enable Restart Level button
+ Deploy the rock
+ Go to *Empty Sling* state

See Rock Physics section for how the rock behaves in the level

#### End Level
+ If enemies remain, go to *Lose Level* state; _never gets called, have to rework this_
+ Show bonus points for remaining rocks (in inventory and in sling)
+ 5000 bonus for first rock, multiply by 2 for each additional remaining rock
+ Show animations for new high score attained and new par level attained
+ Unlock next level if not already unlocked
+ Set next level as “current level” 
+ Go to *Progress Map* state
#### Lose Level
+ Show Lose Level animation
+ This level is still “current level”
+ Go to *Progress Map* state

#### New Page
+ May show animation for new page
+ Show new page, first level of page, which is unlocked, is current level
+ Return to *Progress Map* state


## Asset Requirements
+ Rocks to throw
+ Blocks to break
+ Enemies to kill
+ SmashUp bonus items to destroy
+ Background art
+ Hand-crafted levels
+ Animations for cutscenes, etc.
+ Progress map pages
+ Indicators of varous types (bonus score, par levels, etc)
