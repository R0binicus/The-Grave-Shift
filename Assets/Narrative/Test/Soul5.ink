VAR questionsAsked5 = 0

-> Intro5

=== Intro5 ===
You touch a headstone, and call forth the spirit that resides within.
A young woman grabs upwards, hauling herself back towards the land of the living.
This one's death was meant to have been tragic. #gravedigger #portait: pout
She certainly ain't happy about it. #gravedigger #portrait: look away stressed
That isn't terribly uncommon. #grim #portrait: neutral
I'm sure she will have more to say on the matter. #grim #portrait: displeased
-> Questions5

=== Questions5 ===
What can I do you for, then? Come to help me out at all? #diane
 + [Who were you?]
    ~ questionsAsked5 = questionsAsked5 + 1
    -> Question1_5

 + [How did you die?]
    ~ questionsAsked5 = questionsAsked5 + 1
    -> Question2_5

 + [What did you live for?]
   ~ questionsAsked5 = questionsAsked5 + 1
    -> Question3_5

 + [What would you change?]
    ~ questionsAsked5 = questionsAsked5 + 1
    -> Question4_5

 + [Is there anyone you miss?]
   ~ questionsAsked5 = questionsAsked5 + 1
    -> Question5_5

=== Question1_5 ===
Name’s Diane. #diane
That what you were asking? #diane
Or who I was - what I did. #diane
I just lived on the farm. #diane
I looked after the animals, I cleaned the house, and I stayed home when I was meant to. #diane
What else was I meant to do? #diane


{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== Question2_5 ===
The storms, they got real bad. #diane
I think it’s the storm’s fault, anyway. #diane
The dust got into everything. #diane
My house, my chest, my throat. #diane
Made it damned hard to breathe. #diane
So hard, I darn well died of it. #diane

{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== Question3_5 ===
The idea I could leave, one day. #diane
I did my work, kept my head down, and hoped that one day one of ‘em would tell me it’d been enough. #diane
That I could go. #diane
My dear ol’ Pa wasn’t changing his mind, so I had to make sure someone else had the chance to. #diane
And then they didn’t! #diane
Because all I did was keep my damned head down. #diane

{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== Question4_5 ===
I was hopin’ to get out more. #diane
Travel and the like. Not everything can be fields and paddocks all the way down, right? #diane
When my Pa finally got knocked off, I thought that’d make life easier. #diane
That ain’t the way though. Just means someone else gets to make all the rules. #diane
And it sure as hell weren’t me. #diane


{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== Question5_5 ===
Ha! Fuck no. #diane
No one did me any damn good. #diane
All I wanted was to get the hell outta there. #diane
Least they buried me closer to the city. #diane
Got darn close to giving me my one final wish. #diane

{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== End5 ===
So... whaddaya think? #gravedigger #portrait: smile
It is not our role to pass judgement. #grim.
Make your decision, arbiter. #grim
-> END
