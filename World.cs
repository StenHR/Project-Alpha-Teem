using System.Runtime.CompilerServices;
using Project_Alpha_Teem.locations.AlchemistsGarden;
using Project_Alpha_Teem.locations.Bridge;
using Project_Alpha_Teem.locations.Forrest;

public static class World
{

    public static readonly List<Weapon> Weapons = new List<Weapon>();
    public static readonly List<Monster> Monsters = new List<Monster>();
    public static readonly List<Quest> Quests = new List<Quest>();
    public static readonly List<Location> Locations = new List<Location>();
    public static readonly Random RandomGenerator = new Random();

    public const int WEAPON_ID_RUSTY_SWORD = 1;
    public const int WEAPON_ID_CLUB = 2;
    public const int WEAPON_ID_SWORD_OF_SPIDER_SLAYING = 3;

    public const int MONSTER_ID_RAT = 1;
    public const int MONSTER_ID_SNAKE = 2;
    public const int MONSTER_ID_GIANT_SPIDER = 3;

    public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
    public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
    
    public const int QUEST_ID_START_SPIDER_SILK = 3;
    public const int QUEST_ID_BATTLE_SPIDERS = 4;
    public const int QUEST_ID_COMPLETE_SPIDER_SILK = 5;
    
    public const int QUEST_ID_BEAT_GIANT_SPIDER = 6;

    public const int LOCATION_ID_HOME = 1;
    public const int LOCATION_ID_TOWN_SQUARE = 2;
    public const int LOCATION_ID_GUARD_POST = 3;
    public const int LOCATION_ID_ALCHEMIST_HUT = 4;
    public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
    public const int LOCATION_ID_FARMHOUSE = 6;
    public const int LOCATION_ID_FARM_FIELD = 7;
    public const int LOCATION_ID_BRIDGE = 8;
    public const int LOCATION_ID_SPIDER_FIELD = 9;

    public static Player Player;

    static World()
    {
        PopulateWeapons();
        PopulateMonsters();
        PopulateQuests();
        PopulateLocations();
    }

    public static void AddPlayer(Player player)
    {
        World.Player = player;
    }


    public static void PopulateWeapons()
    {

        Weapons.Add(new Weapon(WEAPON_ID_RUSTY_SWORD, "Rusty sword", 5, 0.2, 10));
        Weapons.Add(new Weapon(WEAPON_ID_CLUB, "Club", 10, 0.3, 100));
        Weapons.Add(new Weapon(WEAPON_ID_SWORD_OF_SPIDER_SLAYING, "Magical Sword of Spider Slaying", 10, 0, 120));
    }

    public static void PopulateMonsters()
    {
        Monster rat = new Monster(MONSTER_ID_RAT, "rat", 3, 5, 2);


        Monster snake = new Monster(MONSTER_ID_SNAKE, "snake", 10, 7, 7);


        Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "giant spider", 3, 10, 10);


        Monsters.Add(rat);
        Monsters.Add(snake);
        Monsters.Add(giantSpider);
    }

    public static void PopulateQuests()
    {
        Quest clearAlchemistGarden =
            new Quest(
                QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                "Clear the alchemist's garden",
                "Kill rats in the alchemist's garden ",
                new ClearAlchemistGardenQuest(), moneyReward: 50, experienceReward: 25
            );

        Quest clearFarmersField =
            new Quest(
                QUEST_ID_CLEAR_FARMERS_FIELD,
                "Clear the farmer's field",
                "Kill snakes in the farmer's field",
                new ClearFarmersFieldQuest(), moneyReward: 100, experienceReward: 50
            );


        List<Quest> collectSpiderSilkQuestChain = new List<Quest>
        {
            new Quest(
                QUEST_ID_START_SPIDER_SILK,
                "Cotton Spider Candy",
                "Meet Grissom, the old candy seller in the village square",
                new StartCollectSpiderSilkQuest(),
                moneyReward: 25, experienceReward: 15
            ),
            new Quest(
                QUEST_ID_BATTLE_SPIDERS,
                "Silkfang Hunting",
                "Collect spider silk from Silkfang spiders in the forest west of the bridge",
                new ForestSpiderBattleQuest(),
                false, moneyReward: 60, experienceReward: 120
            ),
            new Quest(
                QUEST_ID_COMPLETE_SPIDER_SILK,
                "Sweet Rewards",
                "Return to Grissom with the spider silk to collect your reward",
                new CompleteSpiderSilkQuest(),
                false, moneyReward: 100, experienceReward: 150
            )
        };
    
        Quest beatGiantSpider = new Quest(
            QUEST_ID_BEAT_GIANT_SPIDER,
            "Defeat the Giant Spider",
            "Defeat the Giant Spider in the forest",
            new BeatGiantSpiderQuest(), moneyReward: 75, experienceReward: 300
        );

        Quests.Add(clearAlchemistGarden);
        Quests.Add(clearFarmersField);
        Quests.Add(beatGiantSpider);
        foreach (Quest quest in collectSpiderSilkQuestChain)
        {
            Quests.Add(quest);
        }
    }

    public static void PopulateLocations()
    {
        // Create each locationn
        Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.", null, null);

        Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.", null, null);

        Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.", null, null);
        alchemistHut.QuestAvailableHere.Add(QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN));

        Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.", null, null);
        alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

        Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.", null, null);
        farmhouse.QuestAvailableHere.Add(QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD));

        Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.", null, null);
        farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

        Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.", null, null);

        Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.", null, null);
        bridge.QuestAvailableHere.Add(QuestByID(QUEST_ID_START_SPIDER_SILK));
        bridge.QuestAvailableHere.Add(QuestByID(QUEST_ID_COMPLETE_SPIDER_SILK));

        Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.", null, null);
        spiderField.QuestAvailableHere.Add(QuestByID(QUEST_ID_BATTLE_SPIDERS));
        spiderField.QuestAvailableHere.Add(QuestByID(QUEST_ID_BEAT_GIANT_SPIDER));
        spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

        //Location store = new Location(LOCATION_ID_STORE, "Store", "A place to buy.", null, null);

        // Link the locations together
        home.LocationToNorth = townSquare;

        townSquare.LocationToNorth = alchemistHut;
        townSquare.LocationToSouth = home;
        townSquare.LocationToEast = guardPost;
        townSquare.LocationToWest = farmhouse;
        //townSquare.LocationToNorthEast = store;

        farmhouse.LocationToEast = townSquare;
        farmhouse.LocationToWest = farmersField;

        farmersField.LocationToEast = farmhouse;

        alchemistHut.LocationToSouth = townSquare;
        alchemistHut.LocationToNorth = alchemistsGarden;

        alchemistsGarden.LocationToSouth = alchemistHut;

        guardPost.LocationToEast = bridge;
        guardPost.LocationToWest = townSquare;

        bridge.LocationToWest = guardPost;
        bridge.LocationToEast = spiderField;

        spiderField.LocationToWest = bridge;

        // Add the locations to the static list
        Locations.Add(home);
        Locations.Add(townSquare);
        Locations.Add(guardPost);
        Locations.Add(alchemistHut);
        Locations.Add(alchemistsGarden);
        Locations.Add(farmhouse);
        Locations.Add(farmersField);
        Locations.Add(bridge);
        Locations.Add(spiderField);
        //Locations.Add(store);
    }

    public static Location LocationByID(int id)
    {
        foreach (Location location in Locations)
        {
            if (location.ID == id)
            {
                return location;
            }
        }

        return null;
    }

    public static Player GetPlayer()
    {
        return World.Player;
    }

    public static Weapon WeaponByID(int id)
    {
        foreach (Weapon item in Weapons)
        {
            if (item.ID == id)
            {
                return item;
            }
        }

        return null;
    }


    public static Monster MonsterByID(int id)
    {
        foreach (Monster monster in Monsters)
        {
            if (monster.ID == id)
            {
                return monster;
            }
        }

        return null;
    }

    public static Quest QuestByID(int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.ID == id)
            {
                return quest;
            }
        }

        return null;
    }
}
