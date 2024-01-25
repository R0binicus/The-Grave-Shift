VAR questionsAsked = 0

-> Intro

=== Intro ===
This one was interesting... #grim
-> Questions

=== Questions ===
Ask and ye shall receive. #gravedigger

 + [Question 1]
    ~ questionsAsked = questionsAsked + 1
    -> Question1

 + [Question 2]
    ~ questionsAsked = questionsAsked + 1
    -> Question2

 + [Question 3]
    ~ questionsAsked = questionsAsked + 1
    -> Question3

 + [Question 4]
    ~ questionsAsked = questionsAsked + 1
    -> Question4

 + [Question 5]
    ~ questionsAsked = questionsAsked + 1
    -> Question5

=== Question1 ===
Answer 1. #grim

{questionsAsked == 3:
    -> End
  - else:
    -> Questions
}

=== Question2 ===
Answer 2. #gravedigger

{questionsAsked == 3:
    -> End
  - else:
    -> Questions
}

=== Question3 ===
Answer 3. #grim

{questionsAsked == 3:
    -> End
  - else:
    -> Questions
}

=== Question4 ===
Answer 4. #grim

{questionsAsked == 3:
    -> End
  - else:
    -> Questions
}

=== Question5 ===
Answer 5. #gravedigger

{questionsAsked == 3:
    -> End
  - else:
    -> Questions
}

=== End ===
Make your choice. Heaven or hell? #grim
-> END
