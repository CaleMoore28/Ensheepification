using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class TicketManager : MonoBehaviour
{
    [SerializeField] private TicketDisplay ticketDisplay;
    [Header("Tickets By Day")]

    // format is prompt, number of attributes, number of tags
    // tags: cute, evil, fluffy, basic, [corrupted]
    // attributes: horns, wings, tails
    [SerializeField] private object[,] dayOneTickets =
    {
        {"@Doll-E, make me a sheep with a $tag $attribute.", 1, 1},      
        {"My Prompt 4 Doll-e: GENERATE A <$tag> SHEEP WITH <$tag> <$attribute>.", 1, 2},
        {"Doll-E!!!!!!! Gimme a $tag $attribute on a $tag sheep", 1, 2},
        {"generate me a sheep that is $tag enough for me to hang with after a long day.!", 0, 1},
        {"dolly the sheep lol. i want sheep $attribute that is $tag", 1, 1},
        {"I want the best and most $tag sheep you could ever make.", 0, 1},
        {"can u make a sheep that feels like a big $tag blanket?", 0, 1},
        {"A sheep with $tag, you must generate. Very $tag, its $attribute will be.", 1, 2}
        //{"Prompt: Generate a sheep with $attribute attribute and $tag tag", 1, 1},
    };
    [SerializeField] private object[,] dayTwoTickets=
    {
        //{"Doll-E!!! I want a $tag $attribute on a $tag sheep", 1, 2},
        //{"Doll-E!!! I want a $tag $attribute and a $tag $attribute on a $tag and $tag sheep", 2, 4},
        {"@Grok generate me a sheep that I can give my $tag boyfriend. Make a sheep that says “wrap me up in your big, $tag arms.” But make sure it’s not too nice or I can’t dump him next year." 
            , 0, 2},
        {"Generate me a sheep that reminds me of my incredibly $tag coworker Carl. Give it a $tag $attribute.", 1, 2},
        {"@Doll-E, please give me a sheep that feels like a $tag hug!", 0, 1},
        {"DOLL-E IF U DON'T GIVE ME A $tag $attribute AND A $tag $attribute ON A $tag AND $tag SHEEP I WILL SKIN U", 1, 2},
        {"Doll-E, Generate Me A Sheep That Is So $tag That It Will Intimidate A Bear With One $tag Stare.", 0, 2},
        {"a $tag sheep So it's like prada yk", 0, 1},
        {"I want a sheep with a $tag enough $attribute to keep the monsters guessing!", 1, 1},
    };
    [SerializeField] object[,] dayThreeTickets=
    {
        {"dollee i need a sheep with roguelike elements and make it $tag and and spit on it.", 0, 1},
        {"square root of 23 @Doll-E", 0, 0},
        {"my bf HATED THE LAST SHEEP I GAVE HIM WTF!! I need a new one pleaseee @doll-e and im sorry if I called you grok. OMFG just give me a sheep with a $tag $attribute like im literally shaking and crying rn", 1, 1},
        {"@Doll-E whats a good sheep to dump my girlfriend with? how about a $tag sheep.", 0, 1},
        {"Vreau o oaie drăguță și foarte $tag care este $attribute.", 1, 1},
        {"HEY SHEEPCORP, don't you know what you're doing here is DISGUSTING?? do NOT 'generate' me a sheep, you are an EVIL corporation and you need to be TAKEN DOWN!!! BOYCOTT SHEEPCORP AND DOLL-E EVERYONE", 0, 0},
        {"i wwana sheeep which is $tag as ny granndna but nt as much so as my grandpa. and i want it as $tag as my hrandpa but notsomuch as granma. also dolle cna u make wth a $tag $attribute too cuz i rlly like that pleaesn thankyou", 1, 3},
    };

    [SerializeField] string[] tags = {"cute", "evil", "basic", "fluffy", "chill", "fantastical", "old-fashioned", "fat", "trendy", "luxurious", "budget", "baazarrre", "hdkjdkfjejufiop", "idkk", "Quirked Up White Boy", "ugly", "creepy", "quirky", "beautiful", "majestic", "weird", "idk", "eldritch"};

    [SerializeField] private Ticket currentTicket;

    [SerializeField] private SatisfactionHandler satisfactionHandler;

    [SerializeField] private PromptGenerator promptGenerator;

// Generate me a sheep that is BLANK enough to keep the monsters guessing!

// Generate me a sheep that feels like a big BLANK blanket.

// Generate me a sheep that is BLANK enough for me to hang with after a long day.

// Generate me a sheep that is so BLANK that it will intimidate a bear with one, BLANK stare. 

// Generate me a sheep that reminds me of my incredibly BLANK coworker Carl.

// Generate me a sheep that is BLANK as my grandma but not as much so as my grandpa. Make sure it is as BLANK as my grandpa but not as much as my grandma.
    

    public Action OnAllTicketsFinished;

    public void SetDay(int day)
    {
        promptGenerator.promptOptions = SetTicketQueue(day);
        promptGenerator.GenerateTicket();
        ticketDisplay.DisplayTicketData(currentTicket);
        if (day == 3)
        {
            currentTicket.setTags(tags);
        }
    }

    public void NextTicket()
    {  
        promptGenerator.GenerateTicket();
        ticketDisplay.DisplayTicketData(currentTicket);
    }


    private object[,] SetTicketQueue(int day)
    {
        if (day == 1)
        {
            return dayOneTickets;
        }
        else if (day == 2)
        {
            return dayTwoTickets;
        }
        else if (day == 3)
        {
            return dayThreeTickets;
        }
        return null;
    }

    public void EvaluateTicket(List<GameObject> parts)
    {
        satisfactionHandler.ScoreTicket(currentTicket, parts);
        NextTicket();
    }
}
