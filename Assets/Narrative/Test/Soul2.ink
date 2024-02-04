VAR questionsAsked2 = 0

-> Intro2

=== Intro2 ===
#a:desc
You touch a headstone, and call forth the spirit that resides within.
The spirit of a man emerges quickly, as if impatient.

#a:enter soul
#c:kenneth
God, my head still hurts. 
You’d think being dead would fix that shit, wouldn’t you? 

#a:desc
He looks at you properly for the first time.

#c:kenneth
You’re a sight for sore eyes, aren’t you? 
Here I thought that being dead would be all angels and sunshine. 
But I’m stuck here, with a dog, and two people who’ve definitely seen better days. 

#c:grim 
#p:squint
Unnecessary griping.
#c:gravedigger 
#p:small frown
And rude.
#c:grim
#p:neutral
But a soul deserving of your time nonetheless. 
#c:gravedigger 
#p:look away stress
I buried the man, didn’t I? 
#c:grim 
#p:neutral
And now he will be judged.

-> Questions_2

=== Questions_2 ===

 + [Who were you?]
    ~ questionsAsked2 = questionsAsked2 + 1
    -> Question1_2

 + [How did you die?]
    ~ questionsAsked2 = questionsAsked2 + 1
    -> Question2_2

 + [What did you live for?]
    ~ questionsAsked2 = questionsAsked2 + 1
    -> Question3_2

 + [What would you change?]
    ~ questionsAsked2 = questionsAsked2 + 1
    -> Question4_2
    
 + [Is there anyone you miss?]
  ~ questionsAsked2 = questionsAsked2 + 1
    -> Question5_2

=== Question1_2 ===
#c:kenneth
Me? 
Oh, I make it my prerogative to not be so known. 
Being recognisable is bad for the business, y’know? 
That’s really what I am, y'see? A business man. 
#c:gravedigger
#p:smile
He was somethin' like that, at least. 

{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== Question2_2 ===
#c:kenneth
Oh, now that’s a good story.  
Some asshole had a problem with me, see? 
Got involved in my business, and he was decent at it too. 
‘S why I let them stick around. 
Then they got cocky. Thought they could run the whole thing.  
Though I guess they did a decent job setting it all up, given that I’m here now. 
You give someone everything, and they still screw you over, huh? 

{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== Question3_2 ===
#c:kennneth
My work! 
My life’s work. 
Not the most upstanding, but hey, it got me money, didn’t it? 
And that’s what this is all about. 
Life, I mean.
What is it for, except getting money, living it up, doing your best not to die of something stupid. 
Honestly, I was probably too soft hearted about it. 

{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== Question4_2 ===
#c:kenneth
Nothing! 
Well, except that little bastard getting in my way.
#c:gravedigger
#p:pout
... 
#c:kenneth
Got too cocky, thought he could run the whole operation. 
I don’t exactly want to be dead, you know. 
 I really think they’ll ruin it all. But who knows? Haha...
 
{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== Question5_2 ===
#c:kenneth
Not just who. What.
But it's everything. 
My work. My wife. Not being buried in the ground. 
Being able to go places, live it up! 
This isn’t a life at all. I thought this was meant to be an afterlife. 
Something better. 
Are you gonna fix that? Get me outta here? 
#a:desc
You nod. Half of that statement is accurate, at least.


{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== End2 ===
#a:exit soul
#c:gravedigger 
#p:look away stressed
This guy's got opinions, huh? 
#c:grim 
#p:neutral
As do we all. 
What are yours? 
-> END
