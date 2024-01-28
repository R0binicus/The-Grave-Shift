VAR questionsAsked4 = 0

-> Intro4

=== Intro4 ===
You touch a headstone, and call forth the spirit that resides within.
The spirit almost seems to recoil from your touch, before emerging. Slowly. 
I think she's been waiting here a while. #gravedigger
Not that she minds, much. #gravedigger
One has already reached the unknown. Why be impatient to see more? #grim
...Sure. Somethin' like what she said. #gravedigger

-> Questions4
How can I help you, my dear? #maureen

=== Questions4 ===
+ [Who were you?]
    ~ questionsAsked4 = questionsAsked4 + 1
    -> Question1_4

 + [How did you die?]
    ~ questionsAsked4 = questionsAsked4 + 1
    -> Question2_4
    
 + [What did you live for?]
    ~ questionsAsked4 = questionsAsked4 + 1
    -> Question3_4

 + [What would you change?]
    ~ questionsAsked4 = questionsAsked4 + 1
    -> Question4_4
    
 + [Is there anyone you miss?]
    ~ questionsAsked4 = questionsAsked4 + 1
    -> Question5_4
    
=== Question1_4 ===
Isn’t that a good question? #maureen
Hmm... #maureen
I was a lot of things to other people. #maureen
A mother, a wife, a friend, a partner. #maureen
And I was also me. #maureen
I think my favourite thing about myself was that I was a dang good cook. #maureen

{questionsAsked4 == 3:
    -> End4
  - else:
    -> Questions4
}

=== Question2_4 ===
The specifics are a little hard to come by, my dear. #maureen
All I know is that it was peaceful enough. #maureen
I went to sleep, and woke up again in a very strange way. #maureen
I feel so light without a body. So few aches and pains. #maureen


{questionsAsked4 == 3:
    -> End4
  - else:
    -> Questions4
}

=== Question3_4 ===
Why, life itself, my dear. #maureen
The Church Grim doesn't exactly smile, but it seems pleased. #grim #portrait: pleased
Shouldn’t that be all of it? #maureen
I lived quite a good life. Better than most others around me. #maureen
Most people were quite jealous of me. #maureen
And I knew it, haha. #maureen


{questionsAsked4 == 3:
    -> End4
  - else:
    -> Questions4
}

=== Question4_4 ===
What a good question, dear. #maureen
Aren’t I old enough that it’s a bit late to be asking that? #maureen
And, well, dead enough. #maureen
Saying I wanted to change things now will only cause me trouble. #maureen
Regrets don’t make anyone any happier. #maureen
I am certainly not the expectation. #maureen
I simply kept living. And I’m perfectly happy with that. #maureen


{questionsAsked4 == 3:
    -> End
  - else:
    -> Questions4
}

=== Question5_4 ===
All the usual folks, I suppose. #maureen
My family, #maureen
Though I do miss my friends. #maureen
I’ll probably be seeing them--some of them, at least. #maureen
Depending on where I end up! #maureen
I promise I’ve done my best, my dear. #maureen

{questionsAsked4 == 3:
    -> End4
  - else:
    -> Questions4
}

=== End4 ===
Sweet old lady. #gravedigger #portrait: smile
So she seemed. #grim #portrait: displeased
Well it ain't up to us, is it? #gravedigger #portrait: look away stress
-> END
