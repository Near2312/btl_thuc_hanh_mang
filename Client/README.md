![ColloquorBanner](https://raw.githubusercontent.com/igtampe/ColloquorClient/master/Resources/Colloquor%20(Banner).png)
Colloquor is a basic chat application, which allows users to connect to "channels" and communicate with each other. I wrote it mostly as an example of what Switchboard can do. It's the 4th version, because it's the newest incarnation of a batch program I wrote back in 2014. A release of Colloquor 2.4, the last version before the only barely successful SSH Single window batch version, along with the following dedication.

Learn more about Colloquor on our Server's repo here: https://github.com/igtampe/ColloquorServer

Also maybe someday I'll make Colloquor 5 as a WPF application instead of Windows Forms to get into that. Shouldn't be too difficult. Most of the code *should* be easily portable. I mean... I hope.

## A dedication:
Several years ago, I wrote a small program. A program called Colloquor. It was a simple chat program, coded in batch. It all centered around one file. The program would “send” messages to a channel by writing to it, and other clients would “receive” it by checking that file, and noticing that it had changed since they last read it.

The way you used it on a network was to share a network location, and have each user run it from the drive.

The oldest version I can find still in my records is early 2014, but it’s version 1.4, so it was possibly created during 2013. Still, what matters is I remember actually using it on my school’s network. I remember chatting with one of my friends while he was in the computer lab, and I was in another classroom. It was breathtaking that I had achieved that.

![Colloquor2.4Picture](https://raw.githubusercontent.com/igtampe/ColloquorClient/master/Resources/COlloquor2.4.png)

Now of course, that drive is probably no longer there. Though, I still have the program, and its included in this release. Well, Version 2.4, which has quite a few improvements over the original.

Version 3 was also coded on batch, but we made some severe sacrifices to make it run on a single window so that it could run on SSH. They were a bit much, and we never had that magical moment where we saw it work. 

![Colloquor3Picture](https://raw.githubusercontent.com/igtampe/ColloquorClient/master/Resources/Colloquor3.1.png)

Now though, we take this a step further.

Colloquor is back for Version 4. Now in C#, using the new Switchboard Server.

![Colloquor4Picture](https://raw.githubusercontent.com/igtampe/ColloquorClient/master/Resources/Colloquor4.png)

Perhaps not as fully featured as the original version, I only really intended this to be a demo for Switchboard first, and an
incarnation of Colloquor second. 

Still, its curious that even after I have moved on from Batch, and learned VB.NET, Java, and now C#, a little bit of my roots manages
to come up again.

Heck, Colloquor’s new protocol is very similar to the original. Check on the server to see if the latest message has changed.

Perhaps its not very efficient. We don’t even have a chat history, something Version 3 sort of implemented, by keeping the three latest messages.

But on the other hand, I find it an homage to where I came from. An homage to that little middle-schooler who just blew his mind when one message was sent on one computer and received on another by using a program of his own design.

I know that if it wasn’t for him, I wouldn’t really have gotten to where I am today.

Godspeed, past me. If only you could see yourself now.

-IGT

PS: If you run the original, though I couldn’t include the song for copyright reasons, try “/DISCO” (Use /DISCOSTOP when you’re done)
