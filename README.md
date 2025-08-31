# VampireSurvivorsLite
Experimenting on Vampire Survivors game base for learning. <br/><br/>
A roguelike action RPG where you have a timer instead of a health bar. Enemy hits will reduce the time left in the timer. **Try to finish the game before you run out of time!**

# 1) Chunk System and Infinite Grid
For making infinite grid, I used a chunk system. 
The world is divided into NxN chunks where N is the number of cells of size M.
Depending on which chunk the player locates, the chunks within a radius are loaded, and the rest are unloaded. 
So in order for something to be lost, the player should really go far far away and unload that chunk.

<img width="1160" height="646" alt="ChunkedGrid1" src="https://github.com/user-attachments/assets/0514ab92-3f63-4492-8bb4-4601056bba7d" />
