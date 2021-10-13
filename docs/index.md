# Alternate Realities

##### There are currently broken images because I deleted the repo and apparently I didn't save the images...
____

## QuickNav

[Project One](#project-one-a-world-on-fire)

[Project Two](#project-two-but-deliver-us-from-evil)

____

## Project One: a world on fire.

### Intro: The Kickoff.

So, the first project of the semester. How did it turn out? Well, here it is.

![screenshot 1]()

![screenshot 2]()

![gif of experience]()



### The Concept: A World On Fire.

The concept of the scene and the world is something I explained in my project proposal. I'll just copy pasta it here.

The fantasy world is simply called “Earth” by its inhabitants. The continent of where the story takes place is the Eternian Commonwealth, a land ruled by seven kings. This was the result of a short and brutal war spearheaded by a prince of the Eternian Kingdom, who ‘conquered’ all the kingdoms in less than five years when they all said they were willing to sign a treaty. There were originally eight kingdoms.
In any case, the setting is medieval, a fantasy world where magic exists but is rather rare. As a result, almost all magicians are in the royal cities of their respective kingdoms. Even though there are monsters that roam about, the absence of magicians isn’t too much of a problem for villages out in the countrysides because of the existence of the Phalanx Guild, which trains ‘Adventurers’ who go out and perform tasks for compensation. The Phalanx Guild is supported by the kingdoms, meaning that they add to the rewards given out (as to lighten the load of commoners).
Anyway, there are also people called Hunters who are elite Adventurers who can handle pretty much every task. There are two entities above Hunters, but they aren’t relative to the story at hand, at least not in the moment of the scene.
And finally, among the monsters there are those that are feared by all–– one of these monsters is the creature known as the dragon. Rarely seen but known by all, these creatures are known to be able to wipe out entire villages and even cities. Hunters are a must, but sometimes even they aren’t a match for the legendary beasts. There is one group of people who take them on, though–– if they can actually be called people… But that’s a different story for a different time.

The village Drywell is in the southeastern part of the Eternian Commonwealth, located in the Eternian Kingdom. It’s a community of merchants, and the particular scene is a dragon attack, one of those uber-rare events that don’t happen very often. Fun, right?

Here's a shot of the scene I was picturing:

![scene sketch]()

As for the reason why the dragon attacked in the first place–– a traveller found an interesting rock that glittered when exposed to fire. They brought it to the village without knowing it was the egg of a dragon.
Anyway, as a small community, there are some buildings, but not a lot. Most of them are made of wood, which is readily available in the area. There are a few buildings made of stone, but not a lot. Stone is heavy and requires a lot of effort to carry from the nearest quarry, which is some five kilometers away.
There’s a main road that runs through the town. There’s a forest around the village and mountains some distance away, too. These mountains are where the dragon came from.


And here's the idea of the storyboarding I had:

![storyboard]()

And then I thought it'd be easier for me to draw out the main scene from the top:

![bird's eye view]()

The idea was to have an additional character, the "main" character, appear a few moments before the end when the dragon breathes fire on you, but I didn't have time to create a model with a cloth setup so that fell through. But that's enough of the concept, let's get to the process.


### The Process: Lots of Waiting. Last Minute Energy.

So, first things first, a lot of assets means that there's going to be a *lot* of waiting, both for GitHub and within Unity itself. Idiot me thought that it would be an amazing idea to try and download as many assets as possible so that I'd be covered on all fronts. Little did I know that doing so would result in a project folder of over 10GB. *Yep*. Bad idea. Just uploading to GitHub took at *least* 20-30 minutes, and that was *if* the LFS bit worked right (spoiler: it didn't). And then I had the amazing idea of trying to convert the build to Android and get Oculus support before I had finished creating the scene. I hit 3 hours of waiting for the conversion to finish, with my project incomplete. Absolutely *fantastic*. This was before the notice that we didn't need to actually run the thing on the Quest 2, which definitely made me feel like I didn't utilize my time very well.

But the bulk of the project happened pretty last-minute. This was because I hit the point where I actually started understanding what I was doing and how things worked (except sound, still dunno what's up with that) pretty late. It's not that I *wasn't* trying to understand, of course; it was just really confusing and most of the time was spent trying to understand all the tools available. So let's go. Here's the project deets.

#### The Terrain

Anyway, I guess I can talk about how the scene is built. It's bascially a combination of four terrain 3d objects. I used the built-in terrain brush features to add textures (materials from various asset packs and the materials lab) as well as to create the landscape. I was a bit confused on how to use the textures, but I think I figured it out (very tentative *think*). I also used the brush to create trees and grass. I know we learned to use Polybrush, but I thought that I'd try using the built-in one this time. Here's a terrain solo shot:

![image of terrain with mountains, trees, and cobblestone]()

#### The Buildings

There are some buildings in the scene, and I tried to keep a similar color palette of dark and dreary colors, as well as materials by focusing on wooden buildings and the occasional stone building. These were from a range of diferent asset packs (which caused some issues, as mentioned earlier with the size but also because of different and/or redundant dependencies). Some of the buildings (if you look closely) aren't really furnished at all and (if you look even more closely) aren't actually full buildings. I took some pieces of buildings that matched the overall vibe and placed them in the view of the main camera but didn't furnish their interiors or complete the buildings. This was because the user wouldn't be able to move around; they wouldn't be able to see that the buildings weren't complete ones. It's a bit lazy on my side but I also think that it's completely rational considering that you don't want to create more objects within the scene than necessary. In other words, the philosophy I went by with this scene was to show only what I needed to. Less is more... right? Well I guess that kind of contradicts what I did with the people assets later... In any case, here's the scene with the buildings added to it.

![image of terrain with mountains, trees, and an empty town]()

#### The Dragon and FIREEEE

And here's the spice, the sprinkle of razzle-dazzle, to the scene: the dragon(!!!) and the fire(!!!) effects. The dragon is from an asset pack (obviously; I was still struggling to use terrain brushes until a week ago–– there's no way I'd be able to model a 3D dragon complete with animations), as are the fire effects (thank you Unity Asset Store). But the position and animation-change bits for the dragon are from a manual script. *Why*, you might ask, *would one ever think about manually animating the positions and the different actions of an object?* Well, the answer lies in a single term: *legacy animations*. This, I believe, is a problem that arises when you download assets from the Internet. Some of them are old, meaning that they don't fit in with the latest version of Unity. This means that you need to update the materials or create new materials with the given textures in the case that the automatic update doesn't work. In addition, you can't use the built-in Unity animation scripter because it doesn't support legacy aniations. *Oh joy*.

![the scene complete with the dragon and landscape]()

*Anyway*, the script for the dragon is rather simple, using the SmoothStep function to create a more natural animation. I needed a script because I wanted to play two animations at once (position and action) but because the legacy animations were a) read only and b) unsupported by the build-in animator. I ultimately chose to make everything time-based (I'm sorry, dynamic programming based on other objects will come later; I just don't know Unity well enough). Here's the code for the Update() function for the dragon:

    // Decrementing time
    totalTime -= Time.deltaTime;
    //Debug.Log(totalTime);

    // Bring dragon down to ground first 15 seconds
    if (100 > totalTime && totalTime > 90)
    {
        float t = (Time.time - startTime) / duration;
        //Debug.Log(t);
        transform.position = new Vector3(Mathf.SmoothStep(startLoc.position.x, endLoc.position
        .x, t), Mathf.SmoothStep(startLoc.position.y, endLoc.position
        .y, t), Mathf.SmoothStep(startLoc.position.z, endLoc.position
        .z, t));
    }
    else if (91 > totalTime && totalTime >= 86)
    {
        if (!isStationary)
        {
            // land after reaching end spot
            ani.Play("FlyStationaryToLanding");
            isStationary = true;
        }
        if (!ani.isPlaying)
        {
            ani.Play("idleBreathe");
        }
    }
    else if (totalTime < 87)
    {
        ani.Play("spreadFire");
    }

It's very basic code, and there initially was a lot more (stationary mid-air, breathing fire, then flying again, then landing) but I deleted it in the process of not being able to figure out how to make the animation transitions a bit more smooth. I only found out recently, that it was because the animations were all set as looping animations. I fixed up the new and simplified actions of the dragon.

The fire, on the other hand, was a bit more manual. Thankfully all of the particle effects were already there and I could use the built-in animator (Timeline) to spawn the fire on command. Here's how ~~manual~~ the process looked:

![using the timeline to spawn fire using control tracks]()

#### Humans: Fighters and Runners

And now we move on to the puny humans who run in fear of the mighty dragon. They're split mainly into two groups, the fighters and the runners. It's rather straightforward. 

![the complete scene with all objects]()

Fighters fight for like 3 seconds and die (split into two groups with different timings), runners just keep running. Their actions are also time-based. Here's the code for their Update() functions.

        // Fighters

        // only alive for the first 15 seconds (wait 12 seconds fight 3 seconds)
        if (85 < totalTime && totalTime < 88)
        {
            // if fighting, switches between attacks
            if (isFighting && !ani.isPlaying)
            {
                isFighting = !isFighting;
                ani.Play("prepare spear");
            }
            else if (!isFighting && !ani.isPlaying)
            {
                isFighting = !isFighting;
                ani.Play("attack spear");
            }
            
        }
        // dies after 20 seconds
        else if (totalTime < 85 && !isDead)
        {
            ani.Play("die");
            isDead = true;
        }
        
        
        // Runners
        
        // All runners do is.. run.
        float t = (Time.time - startTime) / duration;
        //Debug.Log(t);
        this.transform.position += this.transform.forward * 0.02f;

About their skins, they might look a bit awkward but that's because I needed to recreate their materials because they were outdated (ah, legacy assets strike again) and didn't go as in-depth as I should have. But they all disappear/die anyway so I thought it was okay.

#### Sound

So this is a bit iffy. I added sound, but I have no idea how it will play because my editor doesn't seem to have an output for audio. I can see that something is happening, seen by how the mixer bar is constantly hitting the red, but I myself cannot hear it. I might as well explain what sounds I added. I added one for the dragon (Godzilla noises lol), the people who pass by you (a lot of heavy breathing, scared whimpers), the fire (crackle crackle), and the night ambience (nice crickets and the beautiful sound of everyone panicking and screaming).

### Issues

This section will be short because I don't want to relive everything again.

#### GitHub

So. I reached my LFS limit and GitHub has officially deactivated my LFS tracking. *Fun*. This was also the reason why I was unable to save my progress for a 6+ hour session in the library and *ended up having to delete everything*. Not sure how everything will work from now on, but I may just use the repos as a place to keep packages of the scenes, rather than the entire projects.

#### Animations

Legacy. Legacy. Legacy. Please end this nightmare.

#### Compilation Errors

Have you ever accidentally touched something and watched as thousands of compilation errors came raining down on you? *Yep*. That happened. A lot.

### Afterword: Ain't Doin' This Again. (Part 1 of 3)

And how do I feel about this project? Well, I'm not really satisfied with it. I could have done a *lot* more if I had another weekend. I started understanding how to use Unity and utilize scripts just *moments* before the project was due, which really sucks (but is also nice because now I understand). But I got (some) of it to work, so there's that.

But this was still kind of a nightmare to do (many all-nighters, even more issues, compilation errors) and I'm guessing that there are more nightmares to come. But I will (hopefully) be better equipped to face them in the future.

____

## Project Two: but deliver us from evil.

### Intro: Here We Go Again...
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

![](interactions_sketch1.png)

![](interactions_sketch2.png)

But we also needed to make sure they’d go in order. The original idea was that we would make all items of a station non-interactive unless the user finished a step previous to it, but as we progressed I realized that scripting all of that would be a really, really big pain. I could have technically hardcoded it all, but I chose to take the easy way out and used walls (explained later).

### The Result
Might as well start with the results of the project. These are some screenshots of the scene.

![](project2_screenshot1.png)

An overview of the scene (left)

![](project2_screenshot2.png)

An overview of the scene (right)

It took a while trying to get the assets in the right places to give a sense of aesthetic, but I think the placements worked out okay. So, now that all of that’s out of the way, let’s get to the main stuff: our ~~suffering~~ process.

### The Process

There were more things to consider in this project, now that interactions were on the table. No external 3D assets, meaning that we needed to make anything that we were planning on using. And now we were moving around, too, so we needed to consider that as well.

#### Locomotion

One thing that I decided the first moment we learned about locomotion and teleportation was that I was going to make smooth locomotion and turning, no matter what it took. I just didn’t like the concept of having to teleport everywhere and how snap turning didn’t give you enough freedom to look around. And so that’s what I did, surfing around the Internet in order to find how to make that a possibility. Turns out I didn’t have to look far, because the XR Interaction Toolkit that we had already had these features and I just needed to initialize them with some help from the Unity Manual and the authors’ GitHub repo.

![](project2_locomotion.png)

Technically, I think that locomotion is a form of interaction. It’s the most basic kind of interaction that a player can make, though, so I wouldn’t consider it an interaction that would drive the plot forward (though you *could* argue that it *literally* drives the plot forward). Anyway, that’s not the point. The point is that I added smooth locomotion and turning and I am very happy with it.

#### Singletons

I was wondering how to make global variables in Unity and came across singletons. It was very intuitive, and the fact that the variables could be called across different scripts by calling for the Global.Instance was really cool. I ended up using it in order to track the progress of the user, as well as to decide the order in which the user can progress throughout the game. The Global object has three walls that are semi-transparent in order to “lock” the user into a specific station within the scene. These are “unlocked” when the user performs all of the tasks that are required in order to progress. Here's the code for the singleton and the global variables:

    public static Global Instance { get; private set; }
    // check if cut ingredients have been added
    public bool ingredientsAdded;
    // check if both shakers have been used
    public bool razzleDazzled;
    // check if pot has been stirred
    public bool isStirred;
    // check if pot is cooking/has been cooked (turning dial activates trigger)
    public bool isCooking;
    public bool isCooked;
    // check if pot has been placed on molding table
    public bool isPlaced;
    // check if bomb has been assembled
    public bool isAssembled;
    // check to ensure singleton instance
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
    }

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

![](project2_ingredient1.png)

The script attached to the parent object was one that would wait for a collision to occur between the ingredient and the knife, after which a coroutine would be called in order to create a delay between the cutting of the ingredients (so the entire thing wouldn’t be cut at once). The coroutine basically takes the first child of the ingredient (the slice furthest to the right) and detaches it from the parent, then giving it a rigidbody so that it can be moved around. Here’s the code:

    IEnumerator cutIngredient(Collider collider)
    {
        // cut next child inside ingredient by deactivating kinematic
        if (childNum < childCount-3)
        {
            Debug.Log("cutting");
            Rigidbody childRB;
            // because each new first child is the child that we're trying to remove
            childRB = transform.GetChild(0).gameObject.AddComponent<Rigidbody>();

            // add gravity and turn off kinematic
            childRB.useGravity = true;
            childRB.isKinematic = false;
            // note: this means that the next child to be removed will be the FIRST child
            yield return new WaitForSeconds(0.3f);
            // removes the parent link between child and parent and allows each piece to move individually
            transform.GetChild(0).parent = null;
            childNum++;
        }
        else {
            // get rid of parent object after all pieces have been cut
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }

The short delay in the coroutine is to ensure that there’s a delay of when the knife cuts the ingredients (so all of the slices won’t fall off at once). I had to balance slices falling off too fast and the smoothness of the knife-ingredient interaction. Anyway, when the knife comes in contact with the ingredient, it gives the illusion that the mesh has been cut, like this:

![](project2_ingredient2.png)


There’s a lot of work that can be done for this script, such as changing the dimensions of the ingredient parent object when it’s cut, as well as simply creating a new “ingredient” object in the case that the knife hits a random slice in the ingredient (which would be equipped with a trigger), effectively creating the “mesh slice” effect.

But the point of the interaction isn’t to make it realistic (if I had the time I definitely would, though); it’s to make it work and that’s what’s important. I’m sorry, I have to keep telling myself this so I don’t go back to working on it and spending an all-nighter, again. Anyway, on to the next script.

#### Razzle Dazzle

Yes, you read that right. If you look in the scene, you’ll see that I named my shakers Razzle and Dazzle. And, so, when you use them to add a little spice to the ingredients, you’re essentially adding some razzle dazzle to the mixture. I just had to. Sorry.

![](project2_razzledazzle.png)

*Anyway,* the scripting for these is rather straightforward. I just had to modify the code from our interactions lab, the one with the launcher. I changed the number of objects generated, then had to add specific tags to them (you’ll see why soon). The particles themselves, Razzle and Dazzle, are just small colored spheres with rigidbodies and 3-second lifetimes (again, from the lab).

    // when activated with trigger, shakers will generate particles
    public void generateParticles()
    {
        for(int i = 0; i < 9; i++)
        {
            GameObject particle = GameObject.Instantiate(particlePrefab, generationLoc.position, generationLoc.rotation);
            particle.gameObject.tag = particlePrefab.tag;
            Rigidbody rb = particle.GetComponent<Rigidbody>();
            rb.AddForce(particle.transform.forward * Random.Range(force,1.5f*force));

        }
    }

There’s also the mixing spoon but that’s just so simple there’s no point in talking about it. Just a spoon with a trigger at the end of the spoon.


#### The Pot: The Main Interactable

By main, I don’t mean that it’s the main attraction of the simulator. If I had to choose something it’d be the cutting, cooking, or maybe the razzle dazzle, or perhaps the bomb itself. But the pot is at the center of event scripting because of how present it is throughout the entire scene.

We start with the beginning, where you need to place in cut ingredients and razzle dazzle the mixture. The idea is to make the user realize when a certain action has been completed. I was thinking of using some kind of visual (highlighting with shadow diffuses) to highlight the next item to be used, but it didn’t work out so I decided to just make the user eventually realize what they have to do next by making things appear in the pot but never increase when the number of objects placed into the pot has hit a certain limit. This is the case with the cuttable ingredients (maximum 4) and the razzle dazzle (6 each).

![](project2_pot1.png)

Here's the code for that bit:

    // pour cut ingredients into pot, if they are cut (not part of ingredient parent object)
    if (collision.gameObject.CompareTag("Ingredient") && collision.gameObject.transform.parent == null)
    {
        
        // deactivate ingredient
        collision.gameObject.SetActive(false);
        // if less than 4 ingredients added, increase the number of ingredients in pot
        if (ingredientsAdded < 4)
        {
            transform.GetChild(ingredientsAdded).gameObject.SetActive(true);
            Debug.Log("Ingredient added.");
            ingredientsAdded++;
        }
        //if 4 or more ingredients are added
        else if (ingredientsAdded >= 4 && !Global.Instance.ingredientsAdded)
        {
            Debug.Log("All ingredients added.");
            Global.Instance.ingredientsAdded = true;
        }

        // destroy ingredient
        //Destroy(collision.gameObject);
    }
    // razzle dazzle
    else if (collision.gameObject.CompareTag("Razzle"))
    {
        
        // deactivate particle
        collision.gameObject.SetActive(false);
        Debug.Log(Global.Instance.ingredientsAdded);
        // if less than 6 particles added AFTER ingredients added, increase the number of ingredients in pot
        if (Global.Instance.ingredientsAdded &&  razzleCount < 6)
        {
            Debug.Log("Razzle");
            transform.GetChild(4 + razzleCount).gameObject.SetActive(true);
            razzleCount+=1;
        }
        else if (razzleCount >= 6)
        {
            Debug.Log("Razzled.");
            
            // if razzle (accompanying set) has also hit 6, razzle dazzled, baby
            if (dazzleCount >= 6)
            {
                Debug.Log("Razzle dazzled.");
                Global.Instance.razzleDazzled = true;
            }

        }

        // destroy particle
        //Destroy(collision.gameObject);
    }
    else if (collision.gameObject.CompareTag("Dazzle"))
    {
        
        // deactivate particle
        collision.gameObject.SetActive(false);
        Debug.Log(dazzleCount);
        // if less than 6 particles added AFTER ingredients added, increase the number of ingredients in pot
        if (Global.Instance.ingredientsAdded && dazzleCount < 6)
        {
            Debug.Log("Dazzle");
            transform.GetChild(10 + dazzleCount).gameObject.SetActive(true);
            dazzleCount++;
            
        }
        else if (dazzleCount >= 6)
        {
            Debug.Log("Dazzled.");
            // if razzle (accompanying set) has also hit 6, razzle dazzled, baby
            if (razzleCount >= 6)
            {
                Debug.Log("Razzle dazzled.");
                Global.Instance.razzleDazzled = true;
            }

        }

        // destroy particle
        //Destroy(collision.gameObject);
    }

These were all implemented using the OnTriggerEnter function, which was used to determine the interactors and depending on the global variables states decide whether an interaction should occur. If the ingredients were all added, only then would you be able to razzle dazzle. And only if these two events happened would you be able to mix the ingredients, and so on.

    // mixing
    else if (collision.gameObject.CompareTag("Spoon"))
    {

        if (Global.Instance.razzleDazzled && !Global.Instance.isStirred)
        {
            Debug.Log("Stirred.");
            transform.GetChild(16).gameObject.SetActive(true);

            // once stirred, first wall disappears and the stove placement zone appears
            Global.Instance.isStirred = true;
            Global.Instance.transform.GetChild(0).gameObject.SetActive(false);
            stovePlacementZone.SetActive(true);

            // make pot interactable once stirred
            gameObject.GetComponent<XRGrabInteractable>().enabled = true;
        }

    }

I also used visual feedback to show the user that certain actions have been completed. Using the spoon on the pot (after both the cuttable ingredients and the razzle dazzle have been added) will show that the ingredients have been “mixed”, and placing the pot on the stove and turning it on will show that the ingredients are being “boiled” together as the surface level of the mixture will rise, giving the illusion that the ingredients are melting together.

![](project2_pot2.png)

This was placed on the stove’s script after some debugging showed that when the pot is on the stove and, during the time that the user would move the dial, the trigger event would pass. But it’s still really fun to watch the ingredients ‘melt’.

And once the mixture has melted, you’re prompted to place the pot onto a table in the next station. This is where the script for the pot ends, as when you place it on the wiring table it will trigger things for the wiring of the explosive.

    // place onto mold table
    else if (collision.gameObject.CompareTag("Mold Table"))
    {
        // toggle isPlaced
        Global.Instance.isPlaced = true;
        // empty pot
        for (int i = 0; i < 19; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        // pot is no longer interactable once placed on mold table
        gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        
    }

#### The Stove 
After the razzle dazzle interactions and the mixing, the pot is then moved to be placed on the stove! The stove’s interaction sequence is as follows: 

Dial:
- Placing the Pot on the stove 
- Using the joystick to rotate the dial 180
- Ones the Trigger is hit, the dial is now cooked 
- You hear the stove turning on, followed by sounds of the gas 
The pot is now immobile and as it cooks, the mixture rises to the top 

![](project2_pot3.png)

The interaction with the dial is a bit less intuitive than the other interactions, where you need to either use the right joystick (push forward to select the dial) or a button to grab the dial, then rotate your wrist. We wanted to add some variety in the interactions, but maybe just using a direct grab interactable would have been a better idea.

#### The Wiring Table

Okay, so I’ve been using a range of words to address this. The molding table, the *moulding* table, Station 3… the point is that this is where the user will wire the bomb and complete it. The script for this bit is fairly simple, just your good ol' OnCollideEnter() checking for the collider and making the corresponding object appear on the bomb. Once it's complete, it gets rid of the final wall and lets you finish the game.

![](project2_wiring.png)

The code is also fairly straightforward:

    // yes it's kinda hardcoded but i mean it works, right?
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("triggered");
        //Debug.Log(collision.gameObject.CompareTag("Detonator"));
        // if detonator is touched against bomb body
        if (!detonator && collision.gameObject.CompareTag("Detonator"))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("detonator attached.");
            transform.GetChild(0).gameObject.SetActive(true);
            detonator = true;
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        // if red wire is touched against bomb body
        else if (!redWire && collision.gameObject.CompareTag("Red Wire"))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("redwired.");
            transform.GetChild(1).gameObject.SetActive(true);
            redWire = true;
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        // if blue wire is touched against bomb body
        else if (!blueWire && collision.gameObject.CompareTag("Blue Wire"))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("bluewired.");
            transform.GetChild(2).gameObject.SetActive(true);
            blueWire = true;
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }

        // if bomb has been completed
        if(detonator && redWire && blueWire)
        {
            // if bomb is assembled, remove final wall
            Global.Instance.transform.GetChild(2).gameObject.SetActive(false);

            // display the "deliver here" box on the delivery table
            deliveryArea.SetActive(true);
            
        }
    }

#### The Ending

Fades to black. *Kaboom* in the background. Quits the app. Yep, I found that we can use Application.Quit() to quit the app. It took a while to work out because apparently it doesn't work when it's inside a coroutine, meaning it needs to be called explicity within the Update() function. But yeah, it's pretty cool.

#### Playtesting

We had a few people playtest our scene once we had implemented the interactions and found a few issues.

One issue was that occasionally you would be unable to grab anything–– the controllers would simply stop working as you hold objects in your hand. I *think* (very tentative) I fixed the issue, because I *think* it was triggered by me using the Destroy() function wayyy too much in the scripts for the pot and the wiring. Once I used SetActive(false) instead, the issues seemed to stop (hopefully).

We also added a kinematic option to items when they first spawned so that the user wouldn't accidentally knock things around (including the pot), which was what had been happening quite often.

Another issue was where the scene would push you off the map. We’re not sure *why* this happened, but it rarely happens (maybe once every fifteen to twenty runs). We don’t know how to fix this and frankly didn’t have the time or energy (or sanity) to try.

Overall, we got a lot of positive feedback from our playtesters. They really liked the various interactions, especially the cutting and razzle dazzle (I knew it would catch on haha). The streamline process of the stations was something that was implemented through playtesting as we realized some people felt lost when they spawned in the middle of the room.

There was also mention of a disconnect from the cooking the mixture to suddenly having a bomb to wire, though (but that was kinda the point hehe). This may have been caused by the fact that we omitted a step from the interactions, where you pour the mixture in the pot into a mold, which then can be opened to reveal the bomb. We tried to address this by making it so the inside of the pot would empty, leaving an explosive brick next to it with the same color as the mixture that was in the pot. We hoped that conveyed the transition.


#### Things Left Unsaid and Undone…

There are some features that we *wanted* to add but didn’t have the time to do so. One of them was, as mentioned earlier, the step of molding the mixture into the shape of a bomb. I wanted to make the user mold it themselves, but then due to skill constraints that turned to using a cookie cutter, then just getting rid of the step altogether as we realized that we didn't have the time to implement it.

Another thing was the UI. We wanted to implement floating text in front of each table that would tell them what they needed to do, but we didn’t have the time to put that in.

And of course there’s the super clean mesh slicing that I never got to coding. But I got something similar by thinking about how users would start cutting the ingredients based on the starting location of the knife.

Audio was something that we wanted to add–– the reports of bombings while you're cooking your mixture is meant to be a foreshadowing of what you're actually doing. And the ending report is supposed to be telling you what you're making and that you're the evil. That the evil you need to be delivered from is yourself. But anyway, that's something we couldn't get done because we were working too much on the interactions...


### But All in All… Ain't Doin' This Again (Part 2 of 3)

Things didn’t turn out too shabby. In fact, I think I’m somewhat satisfied with the product. Not fully satisfied, obviously, but I think that we did a lot given the time constraints we had. Looks like I was better prepared this time for the nightmares that were in my way. Maybe not completely prepared, but still a bit more prepared than last project.

It wasn't a complete disaster like last project, but there were still times when I felt that things were out of my control and I didn't know how to properly implement something and ended up compromising. I think there's going to be a lot of this kind of thing happening from now on. I suppose it's better than having *literally no idea what's going on*, though.

There were so many unexpected bugs and each time they triggered and I couldn't let go of the cutting board and pot I would have a moment of thinking "what am I doing?" And so I can say for a second time, I ain't doin' this again. Anyway, see you next project.
