VAR questionsAsked1 = 0

-> Intro1

=== Intro1 ===
You touch a headstone, and call forth the spirit that resides within.
A woman, whose life force drifts past your fingertips. She was buried not long ago.
Hey, I know this one. #gravedigger #portrait: closed eye smile
She’s been up a lot lately. #grim 
She keeps speaking to me, telling me she has been lonely. #grim 
No one visits her. #grim
Weren’t many at the funeral, neither. #gravedigger #portrait: look away stress

Ah, this the reckoning, is it? #nina
I assumed there’d be a lot more gates than this. #nina
Pearly or fiery, I wasn’t sure. #nina
Though by the looks of you, I'd assume you were takin' me to Hell. #nina

You shrug.
She laughs, warmer than you’d expect.
-> Questions_1

=== Questions_1 ===
+ [Who were you?]
    ~ questionsAsked1 = questionsAsked1 + 1
    -> Question1_1

 + [How did you die?]
    ~ questionsAsked1 = questionsAsked1 + 1
    -> Question2_1

 + [What did you live for?]
    ~ questionsAsked1 = questionsAsked1 + 1
    -> Question3_1

 + [What would you change?]
    ~ questionsAsked1 = questionsAsked1 + 1
    -> Question4_1
    
 + [Is there anyone you miss?]
    ~ questionsAsked1 = questionsAsked1 + 1
    -> Question5_1

=== Question1_1 ===
My name is Nina, but… that’s not really it, is it? #nina
Who am I... #nina 
No one, I guess. I’m just me.
I didn’t do anythin' wonderfully helpful, but nothin’ harmful, neither. #nina 
I just went to work, went home, every day. Whenever I had to. #nina 
That is enough, to make you someone. #grim
Is it, though? #nina 
I dunno. #nina 


{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== Question2_1 ===
I was sick. #nina 
I think that’s what it was, anyway.#nina 
I had enough to worry about without trying to get a name for whatever was goin' on. #nina 
Didn’t y’have anyone to help you out? #gravedigger #portrait: frown
Ha! God, no. #nina 
Half my family’s dead, and the other half probably forgot where I live. #nina 
Too busy to try to make friends or anything else. #nina 
Guess that's life. #nina


{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== Question3_1 ===
My goodness. Why are you even asking me that? #nina
It doesn’t matter. It probably never did. #nina
I’m dead now. #nina
This is all I have left. #nina

{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== Question4_1 ===
Everything! #nina 
But I wouldn’t even know where to start. #nina 
I wish I did more. But I wouldn’t even know what to do. #nina 
Quit my job? But then I’d have to get a new one. #nina 
Go out and meet more people? With what money? Where? #nina 
I... I died after getting sick, anyway. Wonder who I met that gave it to me. #nina 
I don’t know. Can anyone even change anything? If I tried, I don’t think it would’ve worked. #nina 

{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== Question5_1 ===
Ha. Great question. #nina
My cat, mostly. #nina
I knew some people, but I wasn't close to no one. #nina
I don’t know if anyone I knew was good, or bad. #nina
That’s what you’re asking me questions for, right? #nina
To see what kind of person I am - I was. #nina
It doesn’t matter. #nina


{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== End1 ===
So... whaddaya think? #gravedigger #portrait: smile
I... Hm... #gravedigger #portrait: eyes closed neutral
It is not our role to pass judgement. #grim.
Make your decision, arbiter. #grim
-> END
