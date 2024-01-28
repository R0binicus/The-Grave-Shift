VAR questionsAsked3 = 0

-> Intro3

=== Intro3 ===
You touch a headstone, and call forth the spirit that resides within.
The soul seems younger. Hesitant.
The funeral for this one was crowded. #gravedigger #smile
Makes you feel kind of bad for him. #gravedigger #portrait: eyes closed frown
He was clearly loved. #grim

-> Questions_3

=== Questions_3 ===
Good evening. Nice to meet... you? #edward
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
I was a student. Studying. #edward
I guess that’s not really who I was, though... #edward
It’s hard to think of anything else. I spent so much time just… in school, or studying. #edward
It’s not exactly easy to become a doctor. #edward
It was all going to be worth it. #edward
Once I got through all this work, I’d actually get to start helping people. #edward

{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== Question2_3 ===
An accident, I think. #edward
I don’t know why anyone would... would do this, on purpose. #edward
There was a car, and it was going rather fast. #edward
They shouldn’t do that, and definitely not where people are walking! #edward
Maybe they didn’t see me that late at night. #edward
I just thought they’d go around me. But I suppose not. #edward


{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== Question3_3 ===
Um... That’s a big question. #edward
I don’t really know if I can answer it. #edward
Maybe if I had more time, but.. #edward
Is that okay? #edward
You nod. There isn’t really any other choice. 

{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== Question4_3 ===
I wouldn’t want to be dead! #edward
The gravedigger snickers softly. #gravedigger #portrait: eyes closed smile
Sorry. If that’s impolite. #edward
I simply wish that people had been a little more careful. #edward
What did they even need a car for? And why did they need to travel that quickly? #edward
I was just walking home. #edward

{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== Question5_3 ===
Everyone, I think. #edward
There’s so many people that I wish I’d spoken to more. #edward
I didn’t say enough to… to anyone, I don’t think. #edward
People I was too shy to say hi to, people I didn’t speak up for. #edward
It’s too late for all that now, and...#edward
I miss the idea that I could try.#edward

{questionsAsked3 == 3:
    -> End3
  - else:
    -> Questions_3
}

=== End3 ===
Poor kid. Really thought he was gonna do great stuff, huh? #gravedigger #portrait: frown
One would hope so. His confidence is... endearing. #grim
What d'you think, then? #gravedigger #portrait: smile
-> END
