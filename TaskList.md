# Task List #

The world is represented as a two dimensional array of cells.
There are various actors within the world, that have to occupy a cell.
These actors can perform various actions, either on their own cell or on another cell
Actors can be equipped with items.
Items confer abilities onto the actor, such as attack.

1. When performing an action both in the same cell and in another cell, ensure the actor has enough points to do so
2. When performing an action on a cell that is different from the one the current actor is in, ensure that the cell is within range for the cell
3. An actor cannot perform the move action on the cell they are already in
4. An actor cannot move to a cell that is already occupied
5. An actor cannot move to a cell if they do not have enough points to do so
6. An attack should be able to critically hit, causing double damage. The critical hit chance should be specified by the weapon, but modified by the characters Strength stat for melee weapons, Dexterity for ranged and Intelligence for magic attacks. Formula to follow.
7. An attack should be able to critically miss, causing half the damage but to the actor who performed the attack. The critical miss chance should be specified by the weapon, but modified by the characters Strength stat for melee weapons, Dexterity for ranged and Intelligence for magic attacks. Formula to follow.
8. When calculating the hit chance, you use the characters relevant stat (from 1 to 20)