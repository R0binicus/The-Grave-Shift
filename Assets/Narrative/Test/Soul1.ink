// a: - action
// c: - character
// p: - portrait

VAR questionsAsked1 = 0

-> Intro1

=== Intro1 ===

#a:desc
You touch a headstone, and call forth the spirit that resides within.
A woman, whose life force drifts past your fingertips. She was buried not long ago.

#c:gravedigger
#p:eyes closed smile
Hey, I know this one.

#c:grim
She’s been up a lot lately.
She keeps speaking to me, telling me she has been lonely.
No one visits her.

#c:gravedigger
#p:look away stressed
Weren’t many at the funeral, neither. 

#a:enter soul
#c:nina
Ah, this the reckoning, is it?
I assumed there’d be a lot more gates than this.
Pearly or fiery, I wasn’t sure.
Though by the looks of you, I'd assume you were takin' me to Hell.

#a:desc
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
#c:nina
My name is Nina, but… that’s not really it, is it?
Who am I...
No one, I guess. I’m just me.
I didn’t do anythin' wonderfully helpful, but nothin’ harmful, neither.
I just went to work, went home, every day. Whenever I had to.

#c:grim
That is enough, to make you someone.

#c:nina
Is it, though? 
I dunno. 


{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== Question2_1 ===
#c:nina
I was sick.
I think that’s what it was, anyway.
I had enough to worry about without trying to get a name for whatever was goin' on.

#c:gravedigger
#p:frown
Didn’t y’have anyone to help you out? 

#c:nina
Ha! God, no.
Half my family’s dead, and the other half probably forgot where I live.
Too busy to try to make friends or anything else.
Guess that's life.


{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== Question3_1 ===
#c:nina
My goodness. Why are you even asking me that?
It doesn’t matter. It probably never did.
I’m dead now.
This is all I have left.

{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== Question4_1 ===
#c:nina
Everything!
But I wouldn’t even know where to start.
I wish I did more. But I wouldn’t even know what to do.
Quit my job? But then I’d have to get a new one.
Go out and meet more people? With what money? Where?
I... I died after getting sick, anyway. Wonder who I met that gave it to me.
I don’t know. Can anyone even change anything? If I tried, I don’t think it would’ve worked.

{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== Question5_1 ===
#c:nina
Ha. Great question.
My cat, mostly.
I knew some people, but I wasn't close to no one.
I don’t know if anyone I knew was good, or bad.
That’s what you’re asking me questions for, right?
To see what kind of person I am - I was.
It doesn’t matter.

{questionsAsked1 == 3:
    -> End1
  - else:
    -> Questions_1
}

=== End1 ===
#a:exit soul
#c:gravedigger
#p:smile
So... whaddaya think?
#p:eyes closed neutral
I... Hm...

#c:grim
It is not our role to pass judgement.
Make your decision, arbiter.
-> END
