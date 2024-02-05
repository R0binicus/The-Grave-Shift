VAR questionsAsked5 = 0

-> Intro5

=== Intro5 ===
#a:desc
You touch a headstone, and call forth the spirit that resides within.
A young woman grabs upwards, hauling herself back towards the land of the living.
#c:gravedigger
#p:pout
This one's death was meant to have been tragic. 
#p:look away stressed
She certainly ain't happy about it. 
#c:grim 
#p:neutral
That isn't terribly uncommon. 
#p:displeased
I'm sure she will have more to say on the matter. 

#a:enter soul
#c:diane
What can I do you for, then? Come to help me out at all? 

-> Questions5

=== Questions5 ===

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
#c:diane
Name’s Diane. #diane
That what you were asking? 
Or who I was - what I did. 
I just lived on the farm. 
I looked after the animals, I cleaned the house, and I stayed home when I was meant to. 
What else was I meant to do? 


{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== Question2_5 ===
#c:diane
The storms, they got real bad. 
I think it’s the storm’s fault, anyway. 
The dust got into everything. 
My house, my chest, my throat. 
Made it damned hard to breathe. 
So hard, I darn well died of it. 

{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== Question3_5 ===
#c:diane
The idea I could leave, one day. 
I did my work, kept my head down, and hoped that one day one of ‘em would tell me it’d been enough. 
That I could go. 
My dear ol’ Pa wasn’t changing his mind, so I had to make sure someone else had the chance to. 
And then they didn’t! 
Because all I did was keep my damned head down. 

{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== Question4_5 ===
#c:diane
I was hopin’ to get out more. 
Travel and the like. Not everything can be fields and paddocks all the way down, right?
When my Pa finally got knocked off, I thought that’d make life easier. 
That ain’t the way though. Just means someone else gets to make all the rules. 
And it sure as hell weren’t me. 


{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== Question5_5 ===
#c:diane
Ha! Fuck no. 
No one did me any damn good. 
All I wanted was to get the hell outta there. 
Least they buried me closer to the city. 
Got darn close to giving me my one final wish. 

{questionsAsked5 == 3:
    -> End5
  - else:
    -> Questions5
}

=== End5 ===
#a:exit soul
#c:gravedigger
#p:smile
So... whaddaya think? 
#c:grim 
#p:neutral
It is not our role to pass judgement. 
Make your decision, arbiter. 
-> END
