## but deliver us from evil.
Joseph Hong | Alternate Realities Project 2 Documentation

### Preface
Welcome to another episode of nightmares in coding and all-nighters! Not as many all-nighters this time round, but just as many (if not more) problems!

### The Conception: Hear me out. What if we…
make a fun little cooking simulator that turns out to be you making a bomb? This was the ‘grand’ idea that I tossed out during our brainstorming session. It seemed like it would be fun and there was a guarantee that it would be interactive. Like Cooking Mama, just a lot darker. It was just a silly idea that my child-like, short-attention-spanned mind produced, at least until it actually became the theme of our project.

### The Story
So here’s the story. When you open your eyes, you’re in a room. There’s not much, just a few shelves here and there, a radio, and in front of you are tables and a stove. One of the tables has ingredients, a cutting board, and a pot. Another has some cookie-cutters, a few strange black boxes and colorful strings.
And so, after a moment of pondering, you decide to step forward and do what comes naturally to you–– work with what you have. When life gives you lemons, you make lemonade. So when life gives you ingredients, you… cook them?
In any case, as you start cooking and molding the mixture, you hear some news about bombings from nearby–– or at least you have reason to think it’s nearby; why else would it be on the radio ––but don’t think much of it. After all, it’s a one-in-a-million chance something will happen to you, right? And so you continue your work, decorating your mixture with the little black boxes and the colorful wires–– not strings, you can tell because they’re so stiff ––until you finally make a few completed products.
Something feels off, but you smile nonetheless, feeling accomplished. You put them down in front of you and admire your handiwork. A bomb. Hmm. Something feels off, but you don’t know what it is. Shrugging, you place your finished product in the delivery zone and listen as more reports of explosions sound in the background…

### Interactions: The Name of the Game
The plan was to have at least 4 interactions. The first was the cutting of ingredients, followed by the scraping of ingredients from the cutting board into the pot. Then would come a few sprinkles of shakers and a quick mix with a spoon. After that would be the stove, where you cook all the ingredients together by turning up the heat with a dial. Once the mixture finished cooking, the pot would go to the second table and there you would mold the mixture into a block and then wire the explosive (oops, spoiler alert) and finally place it into the delivery zone. Wait a sec that’s a lot more than 4 interactions…

*Anyway,* the point was to make a fun little interactive scene for users to mess around with ingredients and have fun.

!()[interactions_sketch1.png]

!()[interactions_sketch2.png]

But we also needed to make sure they’d go in order. The original idea was that we would make all items of a station non-interactive unless the user finished a step previous to it, but as we progressed I realized that scripting all of that would be a really, really big pain. I could have technically hardcoded it all, but I chose to take the easy way out and used walls (explained later).

### The Result
Might as well start with the results of the project. These are some screenshots of the scene.

!()[project2_screenshot1.png]

An overview of the scene (left)

!()[project2_screenshot2.png]

An overview of the scene (right)

It took a while trying to get the assets in the right places to give a sense of aesthetic, but I think the placements worked out okay. So, now that all of that’s out of the way, let’s get to the main stuff: our ~~suffering~~ process.

### The Process

There were more things to consider in this project, now that interactions were on the table. No external 3D assets, meaning that we needed to make anything that we were planning on using. And now we were moving around, too, so we needed to consider that as well.

#### Locomotion

One thing that I decided the first moment we learned about locomotion and teleportation was that I was going to make smooth locomotion and turning, no matter what it took. I just didn’t like the concept of having to teleport everywhere and how snap turning didn’t give you enough freedom to look around. And so that’s what I did, surfing around the Internet in order to find how to make that a possibility. Turns out I didn’t have to look far, because the XR Interaction Toolkit that we had already had these features and I just needed to initialize them with some help from the Unity Manual and the authors’ GitHub repo.

!()[project2_locomotion.png]

Technically, I think that locomotion is a form of interaction. It’s the most basic kind of interaction that a player can make, though, so I wouldn’t consider it an interaction that would drive the plot forward (though you *could* argue that it *literally* drives the plot forward). Anyway, that’s not the point. The point is that I added smooth locomotion and turning and I am very happy with it.

#### Singletons

I was wondering how to make global variables in Unity and came across singletons. It was very intuitive, and the fact that the variables could be called across different scripts by calling for the Global.Instance was really cool. I ended up using it in order to track the progress of the user, as well as to decide the order in which the user can progress throughout the game. The Global object has three walls that are semi-transparent in order to “lock” the user into a specific station within the scene. These are “unlocked” when the user performs all of the tasks that are required in order to progress.

#### Guiding Interactions

This bit with the walls was the alternative to scripting for turning off interactions for all objects that weren’t being used, and I think it’s a pretty good way to guide the user through the interactions.

Some other considerations was the use of shaders, outer-diffuse shaders in particular, to highlight the objects that should be used. But the logistics of that seemed to be a bit too complicated to do in this project.

Another idea was possibly changing the material of all non-interactable objects gray. This one seemed too complicated because the idea came up halfway through, meaning that we would have to go back and change everything we had already created.

In the end, we decided on the walls but also played around with the interactivity of the pot. You can only interact with it and place it on the stove once you put in the ingredients and mix them; after that you can only interact with it when turning the stove dial once the mixture has finished cooking.


#### Assets

So as you can see we have custom assets, but their original shapes and sizes are actually a lot different from those in the game. I had to manually edit the sizes to make them look clean, which actually took a lot longer than expected because I needed to make mesh colliders so they wouldn’t fall through the map. Shoutout to Ilya, who made a lot of the assets we used, as well as Dhabia for the 3D modelling!

#### Cutting: The Start of Scripting

And now we get to the ~~stressful~~ fun part, the scripting for interactions. The first thing that I worked on was (aside from grab interactables) the cutting of ingredients. Now, I wasn’t sure how I was going to implement this. The first thing that went through my head was slicing the mesh, which is apparently a topic that is a lot more complicated than I thought. And so I thought that I should do something more simple. I was honestly just going to split an object in half every time a knife touched it, but then I decided to get a little more in-depth and make it look cooler (and more fun; that’s a running theme in my suffering–– I just want people to enjoy the experience).


So what I ended up doing was creating a parent object that encased a set of child objects, each of which would be the slices.

!()[project2_ingredient1.png]

The script attached to the parent object was one that would wait for a collision to occur between the ingredient and the knife, after which a coroutine would be called in order to create a delay between the cutting of the ingredients (so the entire thing wouldn’t be cut at once). The coroutine basically takes the first child of the ingredient (the slice furthest to the right) and detaches it from the parent, then giving it a rigidbody so that it can be moved around. Here’s the code:



The short delay in the coroutine is to ensure that there’s a delay of when the knife cuts the ingredients (so all of the slices won’t fall off at once). I had to balance slices falling off too fast and the smoothness of the knife-ingredient interaction. Anyway, when the knife comes in contact with the ingredient, it gives the illusion that the mesh has been cut, like this:

!()[project2_ingredient2.png]


There’s a lot of work that can be done for this script, such as changing the dimensions of the ingredient parent object when it’s cut, as well as simply creating a new “ingredient” object in the case that the knife hits a random slice in the ingredient (which would be equipped with a trigger), effectively creating the “mesh slice” effect.
But the point of the interaction isn’t to make it realistic (if I had the time I definitely would, though); it’s to make it work and that’s what’s important. I’m sorry, I have to keep telling myself this so I don’t go back to working on it and spending an all-nighter, again. Anyway, on to the next script.

#### Razzle Dazzle

Yes, you read that right. If you look in the scene, you’ll see that I named my shakers Razzle and Dazzle. And, so, when you use them to add a little spice to the ingredients, you’re essentially adding some razzle dazzle to the mixture. I just had to. Sorry.

!()[project2_razzledazzle.png]

*Anyway,* the scripting for these is rather straightforward. I just had to modify the code from our interactions lab, the one with the launcher. I changed the number of objects generated, then had to add specific tags to them (you’ll see why soon). The particles themselves, Razzle and Dazzle, are just small colored spheres with rigidbodies and 3-second lifetimes (again, from the lab).

There’s also the mixing spoon but that’s just so simple there’s no point in talking about it. Just a spoon with a trigger at the end of the spoon.


#### The Pot: The Main Interactable

By main, I don’t mean that it’s the main attraction of the simulator. If I had to choose something it’d be the cutting, cooking, or maybe the razzle dazzle, or perhaps the bomb itself. But the pot is at the center of event scripting because of how present it is throughout the entire scene.

We start with the beginning, where you need to place in cut ingredients and razzle dazzle the mixture. The idea is to make the user realize when a certain action has been completed. I was thinking of using some kind of visual (highlighting with shadow diffuses) to highlight the next item to be used, but it didn’t work out so I decided to just make the user eventually realize what they have to do next by making things appear in the pot but never increase when the number of objects placed into the pot has hit a certain limit. This is the case with the cuttable ingredients (maximum 4) and the razzle dazzle (6 each).

These were all implemented using the OnTriggerEnter function, which was used to determine the interactors and depending on the global variables states decide whether an interaction should occur. If the ingredients were all added, only then would you be able to razzle dazzle. And only if these two events happened would you be able to mix the ingredients, and so on.

I also used visual feedback to show the user that certain actions have been completed. Using the spoon on the pot (after both the cuttable ingredients and the razzle dazzle have been added) will show that the ingredients have been “mixed”, and placing the pot on the stove and turning it on will show that the ingredients are being “boiled” together as the surface level of the mixture will rise, giving the illusion that the ingredients are melting together.

This was placed on the stove’s script after some debugging showed that when the pot is on the stove and, during the time that the user would move the dial, the trigger event would pass. But it’s still really fun to watch the ingredients ‘melt’.

And once the mixture has melted, you’re prompted to place the pot onto a table in the next station. This is where the script for the pot ends, as when you place it on the wiring table it will trigger things for the wiring of the explosive.




#### The Stove 
After the razzle dazzle interactions and the mixing, the pot is then moved to be placed on the stove! The stove’s interaction sequence is as follows: 
Dial: 
Placing the Pot on the stove 
Using the joystick to rotate the dial 180
Ones the Trigger is hit, the dial is now cooked 
You hear the stove turning on, followed by sounds of the gas 
The pot is now immobile and as it cooks, the mixture rises to the top 

#### The Wiring Table

Okay, so I’ve been using a range of words to address this. The molding table, the *moulding* table, Station 3… the point is that this is where the user will wire the bomb and complete it.


#### Playtesting

We had a few people playtest our scene once we had implemented the interactions and found a few issues.

One issue was that occasionally you would be unable to grab anything–– the controllers would simply stop working as you hold objects in your hand. I *think* (very tentative) I fixed the issue, because I *think* it was triggered by me using the Destroy() function wayyy too much in the scripts for the pot and the wiring. Once I used SetActive(false) instead, the issues seemed to stop (hopefully).

Another issue was where the scene would push you off the map. We’re not sure *why* this is happening, but it only happens every now and then. We don’t know how to fix this and frankly didn’t have the time or energy (and sanity) to try.

There were other really random things, like the pot suddenly disappearing from the map, that happened very rarely, but we didn’t know where to start (so we didn’t lol).

Overall, we got a lot of positive feedback from our playtesters. They really liked the various interactions, especially the cutting and razzle dazzle (I knew it would catch on haha). There was mention of a disconnect from the cooking the mixture to suddenly having a bomb to wire, though. This was caused by the fact that we had omitted a step from the interactions, where you pour the mixture in the pot into a mold, which then can be opened to reveal the bomb.

#### The Ending



#### Things Left Unsaid, Undone…

There are some features that we *wanted* to add but didn’t have the time to do so. One of them was, as mentioned earlier, the step of molding the mixture into the shape of a bomb. I wanted to make the user mold it themselves, but then due to skill constraints that turned to using a cookie cutter, then just getting rid of the step altogether as we realized that it was a redundant interaction. It took a toll on the story flow, though, which really sucks.

Another thing was the UI. We wanted to implement floating text in front of each table that would tell them what they needed to do, but we didn’t have the time to put that in.

And of course there’s the super clean mesh slicing that I never got to coding.


### But All in All… 

Things didn’t turn out too shabby. In fact, I think I’m somewhat satisfied with the product. Not fully satisfied, obviously, but I think that we did a lot given the time constraints we had. 
