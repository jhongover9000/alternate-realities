# Alternate Realities

____

## QuickNav

[Project One](#Project-One)

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
