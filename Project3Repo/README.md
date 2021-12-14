# our demons.
Repository for the final project of Alternate Realities, with the theme Immersive Narrative.

## Introducing The Final(?) Project

Okay. So, ladies and gentlemen. We. Are. Back. Another project, this one being more ambitious than the last (to the point I actually question if we were taking this too seriously), about immersive storytelling. But I mean, considering that it was the *final* project that we were doing for the semester, I can see why we took it as seriously as we did. This was a nice long run of ~~panicking, all-nighters, and crying in corners~~ learning, enduring, and persevering. And I think that we came out relatively alive and well in the end. 

## The Story and Plot

May as well get into the finer details about the project and its requirements. I think that this time we were placing a lot more emphasis on the existence of a *story*, something that somewhat existed in our past projects but not as strongly. Storytelling is something that I’ve always enjoyed and coming up with stories is something I do to entertain myself (hmmm, why am I in CS again?) from time to time. In any case, when we thought about stories to pursue, I let my mind wander (as I always do) and thought of an interesting story concerning a man named Jared (look, I didn't put much thought into it, okay).

### Take One

I think I may have been inspired by some aspects of Supernatural, Constantine, and the Witcher, as well as just about every other exorcist/monster slayer or similar-to-such things I've watched or read. Jared (you) is a former detective/exorcist/monster slayer who deals with the supernatural. He moved out into a small town in the forests of Alaska with his wife Nora. They had a child, Emily. However, at this time it was revealed that Nora was possessed by a demon, which eventually led to Jared being forced to “sealing” her away in an abandoned mineshaft. The story of the experience would take place some eighteen years later, when Emily, now grown, learns about the truth behind her mother's disappearance and sets out to go into the mineshaft for clues. It's basically you chasing after her, knowing that she has no idea what is actually there. And it's supposed to be tragic, where Nora (whose soul is now fused with the demon) has possessed the body of Emily, leaving you no choice but to kill your daughter to prevent your wife from massacring the town. Kinda dark, and I guess that •is• a theme that runs throughout a lot of my ideas.

As you've probably already realized, the setting of the world is one where there are demons and monsters, all those supernatural things. And that was a theme that stayed constant throughout, as well as the concept of a tragedy.

### Take Two

Anyway, I went ahead and drafted a script for this, but then our group decided to add a bit of (Japanese) spice. The plot was more or less the same, but the details of the story, as well as its setting, changed quite a bit. Rather than looking at Jared (his name was in the works of change) as a modern-day Supernatural-style exorcist, he became a traditional exorcist–– especially considering that the period we were considering as the setting was in the 19th century, when Japan was very adamant about sticking to tradition and culture. He became an exorcist who had dabbled a bit in Western practices (as portrayed by the gun). And his wife became a shrine maiden. All of this led to the second version of the story.

Exorcist and shrine maiden–– an interesting combo, to say the least. But it was one that worked. You and Ayane were beautifully wed and enjoyed each other’s company. You also had a daughter together, whom you named Hinako, “child of the sun”. Your days were filled with joy and happiness–– even the most tiring day could be washed away by the “welcome home” you heard as you stepped through your front door.

Then all that changed one day, all because of your carelessness. Leaving to an emergency exorcism, you left the door to your study unlocked as you rushed out the door. Never had it crossed your mind that your daughter would enter it while you were gone. When you arrived back at your house, you didn’t hear the usual “welcome back”. Instead, all you could hear was Hinako’s cries. Rushing to the study, you came across a horrifying sight: Hinako, hiding behind your desk, and Ayane, looking at you with a frenzied expression. The pendant around Hinako’s neck and the broken clay figurine on the ground told the story all too well. A demonic spirit, which had been sealed in the figurine during one of your past assignments, had broken loose, and Ayane had cast aside her divine protection in a last ditch effort to keep the spirit from harming Hinako.

As a result, Ayane was possessed. The spirit had entangled itself with her soul so badly that it was impossible to remove it without killing her, and if left alone Ayane would hunt down every living being until she was either killed or killed everyone in the town.

And so faced with an impossible choice, you sealed her away at the shrine, hoping for a miracle. But it never happened. To Hinako, you said that her mother needed to work at a shrine in a different province.

Three years have passed since that day. The pain is still fresh, though–– every time you close your eyes you can hear Ayane’s voice crying out to you, asking you to save her from her eternal prison. And you listen to her, burdened with the guilt of having torn your family apart by your own carelessness. You are listening once more when your brother, Ryuuji, comes knocking on the door. He says that Hinako has gone missing, that she was last seen heading up the nearby mountain towards the 
bamboo forest, towards the shrine that Ayane is sealed in, speaking into the air. You realize that it’s not just you that has been hearing her voice.

### Themes

One of the main themes of the story, which led to the name 'our demons.' for the project, is the idea that "we make our own demons". It's a quote from one of the *Iron Man* movies, but it's also something mentioned by Oscar Wilde, that we each are our own devils, that we make the world our own hell. And that's kind of what the story is about: looking at the consequences of a person's decisions from the past and how that affects their future (in a very tragic sense).

Another theme was the concept of family bonds. One of the hardest things to do while writing the script (which wasn't fully used due to time constraints) was to make Ayane *likable*. To truly recreate the sense of longing that Hisashi feels and his hesitation when it comes to shooting her, even when the entire village is at stake. I don't think that was portrayed well enough in my initial proposal, which ended up in our project portraying Ayane as evil and very much unlikable. I think that in order to have accomplished such a feat, it would have taken an experience that was several times longer than what we have already.

## The Result

As usual, before getting too deep into the process, here's a quick look at the results of our labor. There's quite a lot to see. There are technically 5 scenes: a menu, the lobby, a cutscene, the forest, and finally the shrine, where everything comes to an end.

## The Process

And of course, now that we've seen the result, we should probably get into the nitty-gritty stuff.

### Scene Transitions

Obviously, in a multi-scene experience, you need to have scene transitions. This one is somewhat straightforward, as I used the code from the lab. However, after getting feedback from playtesting, I also added a section within the transitioning process that would hide the unloading from the player. See, because our scenes were so big, it would take a while to load and players would be staring at empty air for a few seconds. So I created a black box that would envelope the player during those transitions, to make it seem more... robust. This was also paired with the CheckScene() function from the player (explained later). Here's a quick look; the box is the 'load screen':

    IEnumerator Load(string scene)
    {
        isLoading = true;
        yield return StartCoroutine(Fade(1.0f));
        PlayerManager.Instance.ShowLoadScreen();
        yield return StartCoroutine(UnloadCurrent());

        yield return StartCoroutine(LoadNewScene(scene));
        PlayerManager.Instance.CheckScene();
        PlayerManager.Instance.RemoveLoadScreen();
        yield return StartCoroutine(Fade(0.0f));
        isLoading = false;
    }

### Interactions. Yup.

Suffered. You got that right. There are actually quite a few interactions in the experience and they took varying amounts of time to implement. Oftentimes they were rather easy to initialize, but then started getting more and more complicated as we started adding finer details on how things should look and work.

#### The Player Manager: Tracking Objects

Of course, to interact, you need the player. First off, smooth locomotion was a unanimous decision on the navigation system. We wanted to create a seamless experience and thus increase the immersiveness of our narrative (and it worked quite well for the most part, except when you suddenly fell off the map out of the blue during our playtests). But more so than that was *how* I was planning on implementing the interactions and events that would happen to the player.

I think this was the first times that I actually decked out the entire XR Rig to suit those needs. I added all sorts of colliders and triggers, controllers (eye, ray, direct), and the good ol' singleton for the Player Manager object. This was the solution I had arrived at when considering the fact that there would be scene transitions. You see, the thing about having multiple scenes at once is that it's rather had to create interactions that have lasting impact between the two. There are methods like transferring objects across scenes, but I also wanted to keep track of all of those events happening, then create changes directly in the player. And that led to a Player Manager singleton with like 15+ different public objects to keep track of and enhance the player's interactions:

    // XR Rig
    public GameObject xrRig;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject leftCont;
    public GameObject rightCont;
    public GameObject leftWrist;
    public GameObject rightWrist;

    public GameObject revolverAimRight;
    public GameObject revolverAimLeft;

    // Load Box Group
    public GameObject loadScreen;
    public GameObject endingTitle;

    // Player Objects
    public AudioSource audioSource;
    public GameObject lantern;
    public Light lanternLight;
    public GameObject revolver;
    public GameObject mainHolster;
    public GameObject holster;
    public GameObject holsterSpawn;

    // ending
    public AudioClip laughingEnd;
    public AudioClip onShotClip;   // saying sorry after shooting
    bool hasEnded;

    public bool hasRevolver = false;
    public bool hasLantern = false;

    public bool checkScene = false;

    Scene xrScene;

In any case, because of this it was a lot easier triggering interactions and changes in the player without having to go into the trouble of searching for specific game objects inside of certain scenes. 

#### The Player Manager: WaitToSpeak(), CheckScene()

There were also some special objects inside the player that I created in order to help things such as dialogue, though they weren't really used from the sound-side. I placed an audio source inside of the player so that the player would have their own *designated* audio source, meaning no chance of overlaps. In order to further prevent this, I created a coroutine function that would prevent the sudden change in dialogue when something is triggered, instead saying it after the line has been finished: this is the WaitToSpeak() function.

    public void WaitToSpeak(AudioClip clip)
    {
        coroutine = StartCoroutine(WaitForDialogue(clip));
    }

    // wait till audio is finished if it's still playing
    IEnumerator WaitForDialogue(AudioClip clip)
    {
        while (audioSource.isPlaying)
        {
            yield return new WaitForSeconds(clip.length / 2);
        }
        
    }
    
It's actually rather simple, and is used in tandem with changing the audioSource clip and playing it, like this:

    // wait if player is already speaking
    PlayerManager.Instance.WaitToSpeak(PlayerManager.Instance.audioSource.clip);
    PlayerManager.Instance.audioSource.clip = desiredClip;
    PlayerManager.Instance.audioSource.Play();

Another little tidbit I added was the CheckScene() function, which will basically ensure that you have the necessary items on your person when entering a scene *if you don't have them on you*. For example, if you were to have accidentally dropped your gun somewhere in a scene, then were transported into a new scene where you need it again, it'll appear in your holster. This was done using a lot of if statements and comparing the scenes in order to decide what needed to be done. This often dealt with the speed of the player and what items they had on them at the start of the scene, as well as what items should/shouldn't be loaded.

    // check scene to see what needs to be loaded and what doesn't
    public void CheckScene()
    {
        PlayerManager.Instance.xrRig.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 2;
        // activate ray if in first scene
        if (XRSceneTransitionManager.Instance.currentScene.name == "Menu")
        {
            lantern.SetActive(false);
            revolver.SetActive(false);
        }
        else
        {
            // deactivate rays
            revolverAimRight.SetActive(false);
            revolverAimLeft.SetActive(false);
            if (XRSceneTransitionManager.Instance.currentScene.name == "House"){lantern.SetActive(true);}
            else{lantern.SetActive(false);}
            revolver.SetActive(true);
        }
        if (XRSceneTransitionManager.Instance.currentScene.name == "Bamboo" || XRSceneTransitionManager.Instance.currentScene.name == "Shrine")
        {
            // if revolver is not holstered (was dropped somewhere in prev scene), holster it
            if (!RevolverController.Instance.isHolstered)
            {
                revolver.transform.position = holster.transform.position;
                RevolverController.Instance.HolsterWeapon();
            }
            if (hasLantern)
            {
                lanternLight.gameObject.SetActive(true);
                lantern.gameObject.SetActive(false);
            }
            PlayerManager.Instance.xrRig.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 1;
        }
    }

#### The Revolver

This one is a pretty cut-and-dry case. There was quite a lot of scripting (which is a given for such an object). I'm not sure if this means that I've become numb to all of the work that goes into scripting an interactable. Once again, as with the Player Manager, I decided to make the revolver into a singleton object because of how crucial it is in the story and I didn't want to accidentally spawn two, given the special feature of *limited bullets* that it had. The first pickup of the object triggers an easter egg from Supernatural, about the Colt that can "kill anything", but that's just something I added for fun.

Anyway, when it comes to the actual firing of the revolver, there are certain scenes where you can and other scenes where you can't. For example, you can't shoot inside of the house or a cutscene. In these situations, I made it so that audio would play, letting the player know that they shouldn't be doing what they're trying to do.

In the case that they *did* have the ability to shoot, I used a similar feature to the previous project where I would set the children of the revolver visual to inactive in order to give emphasis that a bullet has been shot and that you are running out of bullets. There are only six shots available, and after that trying to shoot will only trigger empty chamber noises. There were some more things I wanted to add, such as the barrel of the gun rolling on shot along with the hammer moving, but there just wasn't enough time for that. Here's the excerpt of the revolver's firing sequence:

    public void Launch()
    {
        // only able to fire in certain scenes
        if (XRSceneTransitionManager.Instance.currentScene.name == "Bamboo" || XRSceneTransitionManager.Instance.currentScene.name == "Shrine")
        {
            canFire = true;
        }
        if (canFire)
        {
            isFiring = true;

            if (bulletCount > 0)
            {
                // shoot bullet
                GameObject projectile = GameObject.Instantiate(projectilePrefab, launchSpawn.position, launchSpawn.rotation);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(projectile.transform.forward * launchForce);
                // particles
                if (bulletCount == 6)
                {
                    // particles
                    for (int i = 0; i < particleGroup.transform.childCount; i++)
                    {
                        particleGroup.transform.GetChild(i).gameObject.SetActive(true);
                        ParticleSystem effect = particleGroup.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                        effect.Play();
                    }
                }
                for (int i = 0; i < particleGroup.transform.childCount; i++)
                {
                    particleGroup.transform.GetChild(i).gameObject.SetActive(true);
                    ParticleSystem effect = particleGroup.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                    effect.Play();
                }
                // sound of firing
                audioSource.clip = gunshot;
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                audioSource.Play();
                // get rid of bullet (front)
                GameObject child = visual.transform.GetChild(6 - bulletCount).gameObject;
                child.SetActive(false);
                bulletCount--;
                RecoilObject.recoil += 0.1f;
            }
            else
            {
                // sound of empty gun
                audioSource.clip = empty;
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                audioSource.Play();
            }
            isFiring = false;
        }
        // if in a place where you can't shoot, don't allow user to shoot
        else
        {
            PlayerManager.Instance.WaitToSpeak(PlayerManager.Instance.audioSource.clip);
            PlayerManager.Instance.audioSource.clip = dontShoot;
            PlayerManager.Instance.audioSource.Play();
        }
    }

#### The Holster: From Playtest Feedback

When you have a gun, you need a holster. This was something that was felt during the playtesting, since when you hold an object you no longer can use the joystick of said controller. Because of this, people would constantly be dropping the gun or switching back and forth between hands in order to navigate through the game. And so I decided that I would make a holster.

At first, I tried to use a socket interactor. I have no idea why, but it didn't seem to work no matter what I tried. And so I decided to go the brute-force way, which was basically just scripting my own holsters from scratch. Using a main holster object, I created two side holsters with their attaches, then made this follow the rotation of the main camera (so that they wouldn't just hang suspended mid-air in the wrong way). This was done by slowly transitioning the rotation to match that of the camera object. Here's part of the code:

    // update the position of the holster to follow the main camera
    transform.position = new Vector3(mainEyeAnchor.transform.position.x, mainEyeAnchor.transform.position.y/1.05f, mainEyeAnchor.transform.position.z);
    transform.forward = transform.forward * 1.1f;
    [adjust the rotationSpeed]
    // final step size is the speed * time frame time
    var step = finalRotationSpeed * Time.deltaTime;
    // rotate towards desired rotation angle
    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, mainEyeAnchor.transform.eulerAngles.y, 0), step);
    
And of course, once that was set, the next step was actually getting the gun to holster. This was done revolver-side, with the HolsterWeapon() function. I had to look at a tutorial for this one, since I wasn't really sure how to make it work properly. If there's something different that I did, well it's that I didn't actually re-code the grabbing script; I just added the function to the revolver's controller. Basically, it'll check to make sure that there's a holster that's nearby and that it's not holstered already, then will transform the gun into the holster. Here's the function: 

    // holster weapon (if applicable)
    public void HolsterWeapon()
    {
        var holsters = GameObject.FindGameObjectsWithTag("Holster");
        foreach (var holster in holsters)
        {
            var distanceToHolster = Vector3.Distance(transform.position, holster.transform.position);
            var childrenOfHolster = holster.GetComponentInChildren<ICanHolster>();
            // if distance is close enough
            if (childrenOfHolster == null && distanceToHolster < 0.2f)
            {
                // set position and rotation of revolver to holster attach
                transform.rotation = holster.transform.GetChild(0).transform.rotation;
                transform.position = holster.transform.GetChild(0).transform.position;
                // turn on kinematic and set holster as parent object
                GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<FloorTimeout>().spawnLoc = holster.transform.GetChild(0).transform;
                transform.SetParent(holster.transform);
                isHolstered = true;
            }
            
        }
        
    }

#### The Onis

One of the main interactions in the experience, of course. If you have a revolver, you want to shoot it, right? And that's what happens in the third scene, where a trigger spawns an *oni*–– a troll ––which will run at you, and which you have to shoot to kill. This was part of the script that I created for the onis. They were made as Nav Agents that would take the player's position as a destination point and head there accordingly. They also had animation controllers to keep track of their states. But wait, it doesn't end there. Once you kill it, it'll spawn *another* oni! And after that one, another. And that's the second part of the code, which spawns a new oni on death.

    void Update()
    {
        if (!isDead)
        {
            bool isMoving = agent.velocity.magnitude > 0.01f && agent.remainingDistance > agent.radius;
            Vector3 velocity = agent.velocity;
            animator.SetBool(isWalkingHash, isMoving);
            velocity = transform.InverseTransformVector(velocity);
            animator.SetFloat(velocityXHash, velocity.x);
            animator.SetFloat(velocityZHash, velocity.z);
            Vector3 PlayerLoc = PlayerManager.Instance.xrRig.transform.position;
            agent.SetDestination(PlayerLoc);
        }
        else
        {
            agent.SetDestination(transform.position);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            if(nextOni != null)
            {
                coroutine = StartCoroutine(SpawnOni());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isAttackingHash, true);
            isAttacking = true;
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            animator.SetBool("isDead", true);
            sound.Stop();
            isDead = true;
        }
    }

Something that was removed, but I really wish we kept, was the feature of resetting the scene when they attacked you–– essentially telling you that you needed to save your bullets to kill them all. It was removed because there wasn't enough of a transition to let the user know what happened, as well as the fact that the scene leading up to the shooting bit is rather long.

#### The Lantern: Another ~~Nightmare~~Obstacle

I don't really know why it was so hard trying to decide what to do with the lantern. The thing is, the lantern goes on the left hand, but that's also the hand used to navigate. And that means you can't move when you're holding the lantern, which is kinda counterintuitive. That was another big issue that came up during playtesting. So I decided that I'd create some kind of socket holder for the lantern.

And I failed. Miserably, too. The socket wouldn't work. I thought about adding a hinge joint and adding swinging physics, but it just ended up making everything go crazy (crazier than it already was). So I dropped it. Six hours of debating later, I just settled on simply deactivating the object and making a light source on the player's main camera light up, to give the effect of a 'lantern' being held to illuminate your sight.

    // essentially picking up lantern, now illuminates your view
    public void LanternPickup()
    {
        PlayerManager.Instance.hasLantern = true;
        PlayerManager.Instance.lanternLight.gameObject.SetActive(true);
        gameObject.SetActive(false);

    }
    
#### The Ending

And of course, we needed to end the experience, and for this we created two possible scenarios. This was done by creating a script that would decide Ayane's fate. It's actually a very simple script, one that calls some of the functions that are inside the Player Manager (see, told you it was useful). If a bullet hit her, that meant that the player shot her, and she would die and the game would end with the gunshot. On the other hand, if she came in contact with the player, that would mean that a) the player did not shoot her or b) the player wasted their bullets on something else, resulting in the player's death and the second ending.

    private void OnTriggerEnter(Collider other)
    {
        // if the ending is about to be triggered, go for it bruh
        if (isKillable)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerManager.Instance.EndingOne();
            }
            else if (other.gameObject.CompareTag("Bullet"))
            {
                PlayerManager.Instance.EndingTwo();
            }
        }
    }

And to make the player *finish* the dialogue before shooting, I added that 'isKillable' boolean, which decides if she is, in fact, able to be killed at that moment. This is set using a signal from the animation timeline, which in turn calls the function Killable():

    public void Killable()
    {
        isKillable = true;
        xr.SendHapticImpulse(0.7f, 1f);
    }

#### Other Interactions

Of course, this is just the main stuff that I focused on throughout the project. There are other interactables, such as the paintings which trigger dialogue about the family when looking at them or the door triggering and animations, as well as other features such as the many, many border boxes I created around all the maps so that players wouldn't wander off. It's not so much that they aren't important, per se, but rather just that there are so many things that I didn't realize I actually ended up doing throughout the project. I also ended up working on a lot of the animation controllers and the Nav Agents throughout the project, which wasn't too bad, but it was a bit tough juggling that alongside recording audio, setting up dialogue for certain object interactions, scripting (both dialogue and c#), scene-editing, and the likes. But yeah, I'm pretty sure the others will go more in-depth into those.

## And So It Ends.

Hey, we made it to the end of the semester. And *you* made it to the end of this documentation. Truth be told, I’m leaving rather unsatisfied with the project. There are so many areas for improvement, so many more things that could have been implemented if there was just more time to do so. But there’s only so much you can do with the time that you’re given, as well as the skills you have at that time. Could I have done more? Perhaps. Are there things I would have done differently if I went back? Definitely. But at this point in time, none of those things matter in the sense that what’s done is done. We worked on the project and invested a lot of time and effort (or so I’d like to believe) into it, and the result we have isn’t terrible; if anything, it’s rather decent. There’s room for improvement, obviously, but the topic and story that we were trying to tackle and portray was rather ambitious, as were a lot of the interactions that were ~~attempted but failed miserably~~ dropped and along with it parts of the story.

But despite all of that we managed to come together and produce a final output that runs, has a story, and is, well *immersive*. In that sense, I say that this project can be considered a success. There are a lot of lessons learned, of course, about how to do things and how not to. But with the class coming to a close, those lessons may not seem usable now. However, I know that they *will* be in the future. That’s where we’re going, I guess. *Forward*, into whatever life leads us.

I know I said that I ain’t doing this again, and I still stand by my words, no matter how many times I *have*, in fact, done it again. And I will probably continue to do so, knowing me, complaining with every step but secretly enjoying the entire way there. Forward, right? To whatever project may be ahead. But this time, I’ll be ready.


