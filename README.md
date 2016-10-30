# DragonFrontDb

This is your one-stop-shop for the data underlying Dragon Front, a virtual reality game from High Voltage Software. 

This .NET libary will attempt to gather all the card (and other relevant) data from the game in one place and keep it updated as the game evolves. 

#We need your help!
The current card data is incomplete, and likely contains errors. We have not obtained a clean extract from the game itself, so it's up to the community to fill in the gaps. 

You don't need programming knowledge to help with this. Currently most cards (all but one at the time of this writing) are missing their 'flavor text', which is the secondary description text found in the game when viewing the details of a card.

The data is also currently missing many card 'traits' that are not clearly listed in the card's text description. For example, the card 'Chief Engineer Bromell' has the trait 'Add to hand', even though it is not explicitly stated that way in its description. We need the community to identify all these non-obvious traits and add them to the data!

#How to contribute card data
All current card data is located in the AllCards.json file. 
https://github.com/BenReierson/DragonFrontDb/blob/master/AllCards.json

The format is very easy to understand if you open it in any text editor. Feel free to fill in the gaps or correct errors and contribute them to this repository by editing the file directly, submitting pull requests, or opening an issue. 

This library is fully free and available to use for whatever purpose you desire. Let's build some fun stuff to support the game. 


