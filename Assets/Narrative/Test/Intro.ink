// a: - action
// c: - character
// p: - portrait

#a:desc
Crossing the bounds between the afterlife and life is never easy. 
Part of the hellish experience is actually emerging from Hell, and the jarring change of temperature.
You do this fairly regularly, but the sudden cool of the night air is always disorientating. 
You stand now, in a graveyard, the moon shining bright in the sky above.
The unfeeling fog drifts gently across your skin. It’s a familiar feeling.
It reminds you that you have work to do, fiendish chores that have to be done.
There’s a quota, after all.
A certain number of souls must be brought to Hell tonight.
You try your best to make sure they are deserving, but you never know how many you have to take.
The quota is elusive, and you will not know til the work is done. 
All you can do is decide is who to send where.
The graveyard stretches forever before you, shapes looming in and out of the dark.
There are more tombstones, headstones, gravestones here than last time, noticeably piled on top of one another. 
Every time you’re here, there seems to be more of them, lurking in the mist.
You can see a few spirits milling about, attached to these new fixtures of the graveyard. They haven’t noticed you yet, and for the better. You won’t be able to see them all tonight.
As if summoned by your very thoughts, a figure begins to emerge from the fog.
You brace yourself for the tirade of anger or pleading, but the presence in front of you seems very, very alive. 

#a:enter gravedigger
#c:gravedigger
#p:smile
Ah. Was wondering when you was gonna show up.
#p:eyes closed smile
Been a few nights, hasn’t it?

+ [I guess.]
    -> Guess
 + [I've been busy.]
    -> Busy
    
=== Guess ===
#c:gravedigger 
#p:smile
Don’t think I’m complaining. 
#p:eyes closed
We had our work to do.
-> Continuing

=== Busy === 
#c:gravedigger
#p:pout
Haven’t we all.
#p:eyes closed
You stopped countin’ ‘em, yet?

#a:desc
You shake your head. It’s not exactly an option you have.

#c:gravedigger
#p:eyes closed smile
Fair enough.
#p:smile
Does get easier when y’do, though.
-> Continuing

=== Continuing ===
#c:gravedigger
#p:pout
There’ll be a few waitin’ for you tonight. 
#p:eyes closed
How many exactly, I'm not sure… 

#a:desc
They pause to think, hand brushing over their chin.
In the silence, you hear the jingling of metal, alongside thundering footsteps.
They’re getting rapidly closer.
A large black dog leaps out of the fog. The lantern it carries swings wildly until it is set by its side. 

#a:enter grim
#c:grim
#p:neutral
Apologies for my lateness. I wasn’t sure you were going to be here tonight. 

#c:gravedigger
#p:smile
I told y’they would be. 

#c:grim
#p:displeased
You always assume they'll be here. 

#c:gravedigger
#p:pout
Eh. There’s a lot of souls waitin’ for ‘em at the moment. 

#c:grim
#p:neutral
Is that any different to usual? 

#c:gravedigger
#p:look away stressed
You’ve seen how busy I’ve been. 

#c:grim
#p:neutral
I suppose I have. 
How many can you take tonight? 

#a:desc
You hold up a hand - five fingers.

#c:gravedigger
#p:freakin
That ain’t many. 

#c:grim
#p:squint
It is some, at least. 
Do you know how many you have to take? 

#a:desc
You don't say anything. 
The dog seems to roll her eyes.

#c:grim
#p:displeased
You never do. 

#c:gravedigger
#p:smile
Night won't last forever. Better get started. 

#a:desc
You sigh, and turn your attention away from the minders of the graveyard.
Who calls to you tonight? 
You can only speak to each of them for a few moments - you've found three questions suits you best. 
-> DONE