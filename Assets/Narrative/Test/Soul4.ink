VAR questionsAsked4 = 0

-> Intro4

=== Intro4 ===
#a:desc
You touch a headstone, and call forth the spirit that resides within.
The spirit almost seems to recoil from your touch, before emerging. Slowly. 
#c:gravedigger 
#p:eyes closed neutral
I think she's been waiting here a while. 
#p:eyes closed smile
Not that she minds, much. 
#c:grim 
#p:neutral
One has already reached the unknown. Why be impatient to see more? 
#c:gravedigger 
#p:look away stressed
...Sure. Somethin' like what she said.

#a:enter soul
#c:maureen
How can I help you, my dear? 
-> Questions4

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
#c:maureen
Isn’t that a good question?
Hmm... 
I was a lot of things to other people. 
A mother, a wife, a friend, a partner. 
And I was also me. 
I think my favourite thing about myself was that I was a dang good cook. 

{questionsAsked4 == 3:
    -> End4
  - else:
    -> Questions4
}

=== Question2_4 ===
#c:maureen
The specifics are a little hard to come by, my dear. 
All I know is that it was peaceful enough. 
I went to sleep, and woke up again in a very strange way. 
I feel so light without a body. So few aches and pains.


{questionsAsked4 == 3:
    -> End4
  - else:
    -> Questions4
}

=== Question3_4 ===
#c:maureen
Why, life itself, my dear. 
#c:maureen
#p:pleased
The Church Grim doesn't exactly smile, but it seems pleased. 
#c:maureen
Shouldn’t that be all of it? 
I lived quite a good life. Better than most others around me. 
Most people were quite jealous of me. 
And didn't I know it?


{questionsAsked4 == 3:
    -> End4
  - else:
    -> Questions4
}

=== Question4_4 ===
#c:maureen
What a good question, dear. 
Aren’t I old enough that it’s a bit late to be asking that? 
And, well, dead enough. 
Saying I wanted to change things now will only cause me trouble. 
Regrets don’t make anyone any happier. 
I am certainly not the expectation. 
I simply kept living. And I’m perfectly happy with that. 


{questionsAsked4 == 3:
    -> End4
  - else:
    -> Questions4
}

=== Question5_4 ===
#c:maureen
All the usual folks, I suppose. 
My family, of course.
Though I do miss my friends.
I’ll probably be seeing them--some of them, at least. 
Depending on where I end up! 
I promise I’ve done my best, my dear. 

{questionsAsked4 == 3:
    -> End4
  - else:
    -> Questions4
}

=== End4 ===
#a:exit soul
#c:gravedigger
#p:smile
Sweet old lady. 
#c:grim 
#p:displeased
So she seemed. 
#c:gravedigger
#p:look away stressed
Well it ain't up to us, is it? 
-> END
