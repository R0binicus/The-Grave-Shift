VAR questionsAsked2 = 0

-> Intro2

=== Intro2 ===
You touch a headstone, and call forth the spirit that resides within.
The spirit of a man emerges quickly, as if impatient.
God, my head still hurts. #kenneth
You’d think being dead would fix that shit, wouldn’t you? #kenneth

He looks at you properly for the first time.

You’re a sight for sore eyes, aren’t you? #kenneth
Here I thought that being dead would be all angels and sunshine. #kenneth
But I’m stuck here, with a dog, and two people who’ve definitely seen better days. #kenneth
Unnecessary griping. #grim
And rude. #gravedigger #portrait: small frown
But a soul deserving of your time nonetheless. #grim
I buried the man, didn’t I? #gravedigger #portrait: look away stress
And now he will be judged. #grim

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
Me? #kenneth
Oh, I make it my prerogative to not be so known. #kenneth
Being recognisable is bad for the business, y’know? #kenneth
That’s really what I am, y'see? A business man. #kenneth
He was somethin' like that, at least. #gravedigger #portrait: smile

{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== Question2_2 ===
Oh, now that’s a good story.  #kenneth
Some asshole had a problem with me, see? #kenneth
Got involved in my business, and he was decent at it too. #kenneth
‘S why I let them stick around. #kenneth
Then they got cocky. Thought they could run the whole thing.  #kenneth
Though I guess they did a decent job setting it all up, given that I’m here now. #kenneth
You give someone everything, and they still screw you over, huh? #kenneth

{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== Question3_2 ===
My work! #kenneth
My life’s work. #kenneth
Not the most upstanding, but hey, it got me money, didn’t it? #kenneth
And that’s what this is all about. #kenneth
Life. getting money, living it up, doing your best not to die of something stupid. #kenneth
Honestly, I was probably too soft hearted about it. #kenneth

{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== Question4_2 ===
Nothing! #kenneth
Well, except that little bastard getting in my way. #kenneth
... #gravedigger #portrait: frown
Got too cocky, thought he could run the whole operation. #kenneth
I don’t exactly want to be dead, you know. #kenneth
 I really think they’ll ruin it all. But who knows, ha! #kenneth

{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== Question5_2 ===
Not just who. What. #kenneth
But it's everything. #kenneth
My work. My wife. Not being buried in the ground. #kenneth
Being able to go places, live it up! #kenneth
This isn’t a life at all. I thought this was meant to be an afterlife. #kenneth
Something better. #kenneth
Are you gonna fix that? Get me outta here? #kenneth
You nod. Half of that statement is accurate, at least.


{questionsAsked2 == 3:
    -> End2
  - else:
    -> Questions_2
}

=== End2 ===
This guy's got opinions, huh? #gravedigger #portrait: look away stress
As do we all. #grim
What are yours? #grim
-> END
