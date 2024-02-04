VAR questionsAsked3 = 0

-> Intro3

=== Intro3 ===
#a:desc
You touch a headstone, and call forth the spirit that resides within.
The soul seems younger. Hesitant.
#c:gravedigger #p:smile
The funeral for this one was crowded.
#p:eyes closed neutral
Makes you feel kind of bad for him. 
#c:grim #p:neutral
He was clearly loved. 

-> Questions_3

=== Questions_3 ===
#a:enter soul
#c:edward
Good evening. Nice to meet... you? 
#a:desc
You smile a little.

 + [Who were you?]
    ~ questionsAsked3 = questionsAsked3 + 1
    -> Question1_3

 + [How did you die?]
   ~ questionsAsked3 = questionsAsked3 + 1
    -> Question2_3

 + [What did you live for?]
   ~ questionsAsked3 = questionsAsked3 + 1
    -> Question3_3

 + [What would you change?]
   ~ questionsAsked3 = questionsAsked3 + 1
    -> Question4_3

 + [Is there anyone you miss?]
    ~ questionsAsked3 = questionsAsked3 + 1
    -> Question5_3


=== Question1_3 ===
#c:edward
I was a student. I was studying, I mean. 
I guess that’s not really who I was, though... 
It’s hard to think of anything else. I spent so much time just… in school, or studying. 
It’s not exactly easy to become a doctor. 
It was all going to be worth it.
Once I got through all this work, I’d actually get to start helping people. 

{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== Question2_3 ===
#c:edward
An accident, I think.
I don’t know why anyone would... would do this, on purpose. 
There was a car, and it was going rather fast. 
They shouldn’t do that, and definitely not where people are walking! 
Maybe they didn’t see me that late at night. 
I just thought they’d go around me. But I suppose not. 


{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== Question3_3 ==+
#c:edward
Um... That’s a big question. 
I don’t really know if I can answer it. 
Maybe if I had more time, but.. 
Is that okay? '
#a:desc
You nod. There isn’t really any other choice. 

{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== Question4_3 ===
#c:edward
Well I bloody sure wouldn't want to be dead! 
#a:desc
#p:smile
The gravedigger snickers softly. 
#c:edward
Sorry. If that’s impolite. 
I simply wish that people had been a little more careful. 
There's no need for anyone to be driving that fast. 
I was just walking home.

{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== Question5_3 ===
#c:edward
Everyone, I think.
There’s so many people that I wish I’d spoken to more. 
I didn’t say enough to… to anyone, I don’t think. 
People I was too shy to say hi to, people I didn’t speak up for. 
It’s too late for all that now, and...
I miss the idea that I could try.

{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== End3 ===
#a:exit soul
#c:gravedigger 
#p:pout
Poor kid. Really thought he was gonna do great stuff, huh? 
#c:grim 
#p:squint
One would hope so. His confidence is... endearing. 
#c:gravedigger
#p:smile
What d'you think, then? 
-> END
