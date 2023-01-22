# PasswordToKeyGame

## The file is supposed to be a website demo
which includes:
1. Home page
2. Register page
3. Sign in page
4. Update page (which can only be accessed by getting the password 3 times wrong on the Sign in page)
5. and the game itself

Also as in a normal website, you have the ability to go through the pages by getting back with the left arrow and going forwards by using the right arrow

# in addition to the program class, I've added 2 more classes which are:
1. Display- that is in charge of the main page.
2. Keyboard- that is supposed to imitate the Console.ReadLine by using Console.ReadKey.

## For saving the data, the file is using a database that holds all of the data

# Things that I had to deal with and how I dealt with them
1. I had to find the string that connects the database and the program- Google came to the rescue.
2. figure out that I need to download an Access Engine and set it up-same as here Google came in clutch.
3. find a way to execute a SQL Query that doesn't read (UPDATE, INSERT)- As always Google is your best friend (ExecuteNonQuery).
4. To be able to go back and forward through the menus I had to change the way I receive the string from the user because Console.ReadLine doesn't accept any keys- I've decided to build the Console.ReadLine by only using the Console.ReadKey and declare the purpose of each key. to go back and forward we'll be using the keys LeftArrow and RightAroow.
5. to be able to go back and forward the program needs to know from which page the program just came and in the case of LeftArrow where the program is heading- for that we'll be using two stacks one for Backwards and one for Forwards. every time the program sends us to another page we'll be saving it in the Backwards stack, and every time the user decides to go back we'll be adding the current page to the Forwards stack.
6. if we really want to make our Keyboard class as real as we can we'll need to add the Ctrl Backspace option- for that first we need to find how to know if the ctrl is pressed, which google can help us with that. after we got that don't we'll need to figure out how can we make the program understand what a word is and how to only erase one word. for that I've we'll use a List that will hold each word's length and when we simply want to Cntrl Backspace the program will take the length of the word and remove that from the string.
