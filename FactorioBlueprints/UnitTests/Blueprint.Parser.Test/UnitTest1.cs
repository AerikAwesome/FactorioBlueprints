using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Blueprint.Parser.Test
{
    public class Tests
    {
        private BlueprintParser parser;
        private Mock<ILogger<BlueprintParser>> mockLogger;

        public Tests()
        {
            mockLogger = new Mock<ILogger<BlueprintParser>>();
            parser = new BlueprintParser(mockLogger.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var testString =
                "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";
            var jsonResult = parser.DecodeString(testString);

            var blueprintParsed = parser.TryParseAsBlueprint(jsonResult, out var blueprintResult);

            Assert.True(blueprintParsed);
        }

        private string JsonBlueprintString =
            "{\"blueprint\":{\"icons\":[{\"signal\":{\"type\":\"item\",\"name\":\"algae-farm\"},\"index\":1}],\"entities\":[{\"entity_number\":1,\"name\":\"angels-flare-stack\",\"position\":{\"x\":-13.5,\"y\":-18.5},\"direction\":6},{\"entity_number\":2,\"name\":\"stone-pipe\",\"position\":{\"x\":-11,\"y\":-19}},{\"entity_number\":3,\"name\":\"stone-pipe\",\"position\":{\"x\":-12,\"y\":-19}},{\"entity_number\":4,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-9,\"y\":-19},\"direction\":2},{\"entity_number\":5,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-7,\"y\":-19},\"direction\":2},{\"entity_number\":6,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-8,\"y\":-19},\"direction\":2},{\"entity_number\":7,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-5,\"y\":-19},\"direction\":2},{\"entity_number\":8,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-6,\"y\":-19},\"direction\":2},{\"entity_number\":9,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-19},\"direction\":2},{\"entity_number\":10,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-4,\"y\":-19},\"direction\":2},{\"entity_number\":11,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-1,\"y\":-19},\"direction\":2},{\"entity_number\":12,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-2,\"y\":-19},\"direction\":2},{\"entity_number\":13,\"name\":\"basic-transport-belt\",\"position\":{\"x\":1,\"y\":-19},\"direction\":2},{\"entity_number\":14,\"name\":\"basic-transport-belt\",\"position\":{\"x\":0,\"y\":-19},\"direction\":2},{\"entity_number\":15,\"name\":\"basic-transport-belt\",\"position\":{\"x\":3,\"y\":-19},\"direction\":2},{\"entity_number\":16,\"name\":\"basic-transport-belt\",\"position\":{\"x\":2,\"y\":-19},\"direction\":2},{\"entity_number\":17,\"name\":\"basic-transport-belt\",\"position\":{\"x\":5,\"y\":-19},\"direction\":2},{\"entity_number\":18,\"name\":\"basic-transport-belt\",\"position\":{\"x\":4,\"y\":-19},\"direction\":2},{\"entity_number\":19,\"name\":\"basic-transport-belt\",\"position\":{\"x\":7,\"y\":-19},\"direction\":2},{\"entity_number\":20,\"name\":\"basic-transport-belt\",\"position\":{\"x\":6,\"y\":-19},\"direction\":2},{\"entity_number\":21,\"name\":\"basic-transport-belt\",\"position\":{\"x\":9,\"y\":-19},\"direction\":2},{\"entity_number\":22,\"name\":\"basic-transport-belt\",\"position\":{\"x\":8,\"y\":-19},\"direction\":2},{\"entity_number\":23,\"name\":\"basic-transport-belt\",\"position\":{\"x\":11,\"y\":-19},\"direction\":4},{\"entity_number\":24,\"name\":\"basic-transport-belt\",\"position\":{\"x\":10,\"y\":-19},\"direction\":2},{\"entity_number\":25,\"name\":\"small-electric-pole\",\"position\":{\"x\":-15,\"y\":-17}},{\"entity_number\":26,\"name\":\"angels-flare-stack\",\"position\":{\"x\":-13.5,\"y\":-16.5},\"direction\":6},{\"entity_number\":27,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-12,\"y\":-17},\"direction\":6},{\"entity_number\":28,\"name\":\"stone-pipe\",\"position\":{\"x\":-11,\"y\":-18}},{\"entity_number\":29,\"name\":\"stone-pipe\",\"position\":{\"x\":-11,\"y\":-17}},{\"entity_number\":30,\"name\":\"small-electric-pole\",\"position\":{\"x\":-10,\"y\":-17}},{\"entity_number\":31,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-9,\"y\":-18}},{\"entity_number\":32,\"name\":\"inserter\",\"position\":{\"x\":-9,\"y\":-17},\"direction\":4},{\"entity_number\":33,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-10,\"y\":-18},\"direction\":6},{\"entity_number\":34,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-8,\"y\":-17},\"direction\":2},{\"entity_number\":35,\"name\":\"stone-pipe\",\"position\":{\"x\":-7,\"y\":-17}},{\"entity_number\":36,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-6,\"y\":-17},\"direction\":6},{\"entity_number\":37,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-6,\"y\":-18},\"direction\":2},{\"entity_number\":38,\"name\":\"stone-pipe\",\"position\":{\"x\":-5,\"y\":-18}},{\"entity_number\":39,\"name\":\"stone-pipe\",\"position\":{\"x\":-5,\"y\":-17}},{\"entity_number\":40,\"name\":\"small-electric-pole\",\"position\":{\"x\":-4,\"y\":-17}},{\"entity_number\":41,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-18}},{\"entity_number\":42,\"name\":\"inserter\",\"position\":{\"x\":-3,\"y\":-17},\"direction\":4},{\"entity_number\":43,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-4,\"y\":-18},\"direction\":6},{\"entity_number\":44,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-2,\"y\":-17},\"direction\":2},{\"entity_number\":45,\"name\":\"stone-pipe\",\"position\":{\"x\":-1,\"y\":-17}},{\"entity_number\":46,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":0,\"y\":-17},\"direction\":6},{\"entity_number\":47,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":0,\"y\":-18},\"direction\":2},{\"entity_number\":48,\"name\":\"stone-pipe\",\"position\":{\"x\":1,\"y\":-18}},{\"entity_number\":49,\"name\":\"stone-pipe\",\"position\":{\"x\":1,\"y\":-17}},{\"entity_number\":50,\"name\":\"small-electric-pole\",\"position\":{\"x\":2,\"y\":-17}},{\"entity_number\":51,\"name\":\"basic-transport-belt\",\"position\":{\"x\":3,\"y\":-18}},{\"entity_number\":52,\"name\":\"inserter\",\"position\":{\"x\":3,\"y\":-17},\"direction\":4},{\"entity_number\":53,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":2,\"y\":-18},\"direction\":6},{\"entity_number\":54,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":4,\"y\":-17},\"direction\":2},{\"entity_number\":55,\"name\":\"stone-pipe\",\"position\":{\"x\":5,\"y\":-17}},{\"entity_number\":56,\"name\":\"stone-pipe\",\"position\":{\"x\":7,\"y\":-17}},{\"entity_number\":57,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":6,\"y\":-17},\"direction\":6},{\"entity_number\":58,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":6,\"y\":-18},\"direction\":2},{\"entity_number\":59,\"name\":\"stone-pipe\",\"position\":{\"x\":7,\"y\":-18}},{\"entity_number\":60,\"name\":\"small-electric-pole\",\"position\":{\"x\":8,\"y\":-17}},{\"entity_number\":61,\"name\":\"basic-transport-belt\",\"position\":{\"x\":9,\"y\":-18}},{\"entity_number\":62,\"name\":\"inserter\",\"position\":{\"x\":9,\"y\":-17},\"direction\":4},{\"entity_number\":63,\"name\":\"basic-transport-belt\",\"position\":{\"x\":11,\"y\":-18},\"direction\":4},{\"entity_number\":64,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":10,\"y\":-17},\"direction\":2},{\"entity_number\":65,\"name\":\"stone-pipe\",\"position\":{\"x\":11,\"y\":-17}},{\"entity_number\":66,\"name\":\"inserter\",\"position\":{\"x\":12,\"y\":-18},\"direction\":6},{\"entity_number\":67,\"name\":\"ore-crusher\",\"position\":{\"x\":14,\"y\":-17},\"recipe\":\"slag-processing-stone\"},{\"entity_number\":68,\"name\":\"angels-electrolyser\",\"position\":{\"x\":-9,\"y\":-14},\"direction\":4,\"recipe\":\"dirt-water-separation\"},{\"entity_number\":69,\"name\":\"angels-electrolyser\",\"position\":{\"x\":-3,\"y\":-14},\"direction\":4,\"recipe\":\"dirt-water-separation\"},{\"entity_number\":70,\"name\":\"angels-electrolyser\",\"position\":{\"x\":3,\"y\":-14},\"direction\":4,\"recipe\":\"dirt-water-separation\"},{\"entity_number\":71,\"name\":\"angels-electrolyser\",\"position\":{\"x\":9,\"y\":-14},\"direction\":4,\"recipe\":\"dirt-water-separation\"},{\"entity_number\":72,\"name\":\"small-electric-pole\",\"position\":{\"x\":12,\"y\":-16}},{\"entity_number\":73,\"name\":\"stone-pipe\",\"position\":{\"x\":13,\"y\":-15}},{\"entity_number\":74,\"name\":\"stone-pipe\",\"position\":{\"x\":12,\"y\":-15}},{\"entity_number\":75,\"name\":\"inserter\",\"position\":{\"x\":15,\"y\":-15}},{\"entity_number\":76,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-15}},{\"entity_number\":77,\"name\":\"small-electric-pole\",\"position\":{\"x\":16,\"y\":-16}},{\"entity_number\":78,\"name\":\"stone-pipe\",\"position\":{\"x\":12,\"y\":-14}},{\"entity_number\":79,\"name\":\"stone-pipe\",\"position\":{\"x\":12,\"y\":-13}},{\"entity_number\":80,\"name\":\"liquifier\",\"position\":{\"x\":14,\"y\":-13},\"direction\":4,\"recipe\":\"water-mineralized\"},{\"entity_number\":81,\"name\":\"small-electric-pole\",\"position\":{\"x\":-11,\"y\":-11}},{\"entity_number\":82,\"name\":\"stone-pipe\",\"position\":{\"x\":-7,\"y\":-11}},{\"entity_number\":83,\"name\":\"stone-pipe\",\"position\":{\"x\":-6,\"y\":-11}},{\"entity_number\":84,\"name\":\"stone-pipe\",\"position\":{\"x\":-5,\"y\":-11}},{\"entity_number\":85,\"name\":\"stone-pipe\",\"position\":{\"x\":-4,\"y\":-11}},{\"entity_number\":86,\"name\":\"stone-pipe\",\"position\":{\"x\":-3,\"y\":-11}},{\"entity_number\":87,\"name\":\"stone-pipe\",\"position\":{\"x\":-2,\"y\":-11}},{\"entity_number\":88,\"name\":\"stone-pipe\",\"position\":{\"x\":-1,\"y\":-11}},{\"entity_number\":89,\"name\":\"stone-pipe\",\"position\":{\"x\":0,\"y\":-11}},{\"entity_number\":90,\"name\":\"stone-pipe\",\"position\":{\"x\":1,\"y\":-11}},{\"entity_number\":91,\"name\":\"stone-pipe\",\"position\":{\"x\":2,\"y\":-11}},{\"entity_number\":92,\"name\":\"stone-pipe\",\"position\":{\"x\":3,\"y\":-11}},{\"entity_number\":93,\"name\":\"stone-pipe\",\"position\":{\"x\":4,\"y\":-11}},{\"entity_number\":94,\"name\":\"stone-pipe\",\"position\":{\"x\":5,\"y\":-11}},{\"entity_number\":95,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":-11}},{\"entity_number\":96,\"name\":\"stone-pipe\",\"position\":{\"x\":7,\"y\":-11}},{\"entity_number\":97,\"name\":\"stone-pipe\",\"position\":{\"x\":8,\"y\":-11}},{\"entity_number\":98,\"name\":\"stone-pipe\",\"position\":{\"x\":9,\"y\":-11}},{\"entity_number\":99,\"name\":\"stone-pipe\",\"position\":{\"x\":10,\"y\":-11}},{\"entity_number\":100,\"name\":\"stone-pipe\",\"position\":{\"x\":11,\"y\":-11}},{\"entity_number\":101,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":13,\"y\":-11},\"direction\":6},{\"entity_number\":102,\"name\":\"stone-pipe\",\"position\":{\"x\":12,\"y\":-12}},{\"entity_number\":103,\"name\":\"stone-pipe\",\"position\":{\"x\":12,\"y\":-11}},{\"entity_number\":104,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":15,\"y\":-11},\"direction\":2},{\"entity_number\":105,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-11}},{\"entity_number\":106,\"name\":\"offshore-pump\",\"position\":{\"x\":16,\"y\":-11},\"direction\":2},{\"entity_number\":107,\"name\":\"steam-engine\",\"position\":{\"x\":-14,\"y\":-9},\"direction\":2},{\"entity_number\":108,\"name\":\"steam-engine\",\"position\":{\"x\":-9,\"y\":-9},\"direction\":2},{\"entity_number\":109,\"name\":\"boiler\",\"position\":{\"x\":-5.5,\"y\":-9},\"direction\":6},{\"entity_number\":110,\"name\":\"small-electric-pole\",\"position\":{\"x\":-4,\"y\":-10}},{\"entity_number\":111,\"name\":\"inserter\",\"position\":{\"x\":-4,\"y\":-9},\"direction\":2},{\"entity_number\":112,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-9}},{\"entity_number\":113,\"name\":\"liquifier\",\"position\":{\"x\":-1,\"y\":-9},\"direction\":4,\"recipe\":\"gas-carbon-dioxide-from-wood\"},{\"entity_number\":114,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":1,\"y\":-10}},{\"entity_number\":115,\"name\":\"assembling-machine-1\",\"position\":{\"x\":4,\"y\":-9},\"recipe\":\"cellulose-fiber-algae\"},{\"entity_number\":116,\"name\":\"inserter\",\"position\":{\"x\":6,\"y\":-9},\"direction\":2},{\"entity_number\":117,\"name\":\"inserter\",\"position\":{\"x\":6,\"y\":-10},\"direction\":2},{\"entity_number\":118,\"name\":\"algae-farm\",\"position\":{\"x\":10,\"y\":-7},\"direction\":2,\"recipe\":\"algae-green\"},{\"entity_number\":119,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-9}},{\"entity_number\":120,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-10}},{\"entity_number\":121,\"name\":\"steam-engine\",\"position\":{\"x\":-14,\"y\":-6},\"direction\":2},{\"entity_number\":122,\"name\":\"steam-engine\",\"position\":{\"x\":-9,\"y\":-6},\"direction\":2},{\"entity_number\":123,\"name\":\"boiler\",\"position\":{\"x\":-5.5,\"y\":-6},\"direction\":6},{\"entity_number\":124,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-8}},{\"entity_number\":125,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-7}},{\"entity_number\":126,\"name\":\"stone-pipe\",\"position\":{\"x\":-1,\"y\":-7}},{\"entity_number\":127,\"name\":\"inserter\",\"position\":{\"x\":1,\"y\":-8},\"direction\":2},{\"entity_number\":128,\"name\":\"basic-transport-belt\",\"position\":{\"x\":1,\"y\":-7},\"direction\":2},{\"entity_number\":129,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":0,\"y\":-7},\"direction\":6},{\"entity_number\":130,\"name\":\"basic-transport-belt\",\"position\":{\"x\":2,\"y\":-8}},{\"entity_number\":131,\"name\":\"basic-transport-belt\",\"position\":{\"x\":2,\"y\":-7}},{\"entity_number\":132,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":5,\"y\":-7},\"direction\":2},{\"entity_number\":133,\"name\":\"inserter\",\"position\":{\"x\":4,\"y\":-7}},{\"entity_number\":134,\"name\":\"small-electric-pole\",\"position\":{\"x\":6,\"y\":-8}},{\"entity_number\":135,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":-7}},{\"entity_number\":136,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-8}},{\"entity_number\":137,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-7}},{\"entity_number\":138,\"name\":\"inserter\",\"position\":{\"x\":-4,\"y\":-6},\"direction\":2},{\"entity_number\":139,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-6}},{\"entity_number\":140,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-5}},{\"entity_number\":141,\"name\":\"steam-engine\",\"position\":{\"x\":-1,\"y\":-3}},{\"entity_number\":142,\"name\":\"basic-transport-belt\",\"position\":{\"x\":1,\"y\":-6}},{\"entity_number\":143,\"name\":\"basic-transport-belt\",\"position\":{\"x\":1,\"y\":-5}},{\"entity_number\":144,\"name\":\"small-electric-pole\",\"position\":{\"x\":2,\"y\":-6}},{\"entity_number\":145,\"name\":\"assembling-machine-1\",\"position\":{\"x\":4,\"y\":-5},\"recipe\":\"wood-pellets\"},{\"entity_number\":146,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":-6}},{\"entity_number\":147,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":-5}},{\"entity_number\":148,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-6}},{\"entity_number\":149,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-5}},{\"entity_number\":150,\"name\":\"steam-engine\",\"position\":{\"x\":-14,\"y\":-2},\"direction\":2},{\"entity_number\":151,\"name\":\"small-electric-pole\",\"position\":{\"x\":-11,\"y\":-4}},{\"entity_number\":152,\"name\":\"steam-engine\",\"position\":{\"x\":-9,\"y\":-2},\"direction\":2},{\"entity_number\":153,\"name\":\"stone-pipe\",\"position\":{\"x\":-5,\"y\":-4}},{\"entity_number\":154,\"name\":\"boiler\",\"position\":{\"x\":-5.5,\"y\":-2},\"direction\":6},{\"entity_number\":155,\"name\":\"small-electric-pole\",\"position\":{\"x\":-4,\"y\":-4}},{\"entity_number\":156,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-4}},{\"entity_number\":157,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-3}},{\"entity_number\":158,\"name\":\"basic-transport-belt\",\"position\":{\"x\":1,\"y\":-4}},{\"entity_number\":159,\"name\":\"basic-transport-belt\",\"position\":{\"x\":1,\"y\":-3}},{\"entity_number\":160,\"name\":\"inserter\",\"position\":{\"x\":2,\"y\":-3},\"direction\":2},{\"entity_number\":161,\"name\":\"inserter\",\"position\":{\"x\":2,\"y\":-4},\"direction\":2},{\"entity_number\":162,\"name\":\"assembling-machine-1\",\"position\":{\"x\":4,\"y\":-2},\"recipe\":\"wood-pellets\"},{\"entity_number\":163,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":-4}},{\"entity_number\":164,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":-3}},{\"entity_number\":165,\"name\":\"algae-farm\",\"position\":{\"x\":10,\"y\":0},\"direction\":2,\"recipe\":\"algae-green\"},{\"entity_number\":166,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-4}},{\"entity_number\":167,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-3}},{\"entity_number\":168,\"name\":\"inserter\",\"position\":{\"x\":-4,\"y\":-2},\"direction\":2},{\"entity_number\":169,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-2}},{\"entity_number\":170,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":-1}},{\"entity_number\":171,\"name\":\"small-electric-pole\",\"position\":{\"x\":2,\"y\":-1}},{\"entity_number\":172,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":-2}},{\"entity_number\":173,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":-1}},{\"entity_number\":174,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-2}},{\"entity_number\":175,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":-1}},{\"entity_number\":176,\"name\":\"steam-engine\",\"position\":{\"x\":-14,\"y\":1},\"direction\":2},{\"entity_number\":177,\"name\":\"steam-engine\",\"position\":{\"x\":-9,\"y\":1},\"direction\":2},{\"entity_number\":178,\"name\":\"boiler\",\"position\":{\"x\":-5.5,\"y\":1},\"direction\":6},{\"entity_number\":179,\"name\":\"inserter\",\"position\":{\"x\":-4,\"y\":1},\"direction\":2},{\"entity_number\":180,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":0}},{\"entity_number\":181,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":1}},{\"entity_number\":182,\"name\":\"boiler\",\"position\":{\"x\":-1,\"y\":0.5}},{\"entity_number\":183,\"name\":\"stone-pipe\",\"position\":{\"x\":1,\"y\":1}},{\"entity_number\":184,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":1,\"y\":0},\"direction\":4},{\"entity_number\":185,\"name\":\"assembling-machine-1\",\"position\":{\"x\":4,\"y\":2},\"recipe\":\"cellulose-fiber-algae\"},{\"entity_number\":186,\"name\":\"inserter\",\"position\":{\"x\":4,\"y\":0},\"direction\":4},{\"entity_number\":187,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":6,\"y\":1}},{\"entity_number\":188,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":0}},{\"entity_number\":189,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":0}},{\"entity_number\":190,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":1}},{\"entity_number\":191,\"name\":\"small-electric-pole\",\"position\":{\"x\":-11,\"y\":3}},{\"entity_number\":192,\"name\":\"small-electric-pole\",\"position\":{\"x\":-6,\"y\":3}},{\"entity_number\":193,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":2}},{\"entity_number\":194,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-3,\"y\":3}},{\"entity_number\":195,\"name\":\"small-electric-pole\",\"position\":{\"x\":-2,\"y\":2}},{\"entity_number\":196,\"name\":\"inserter\",\"position\":{\"x\":-1,\"y\":2},\"direction\":4},{\"entity_number\":197,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-2,\"y\":3},\"direction\":6},{\"entity_number\":198,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-1,\"y\":3},\"direction\":6},{\"entity_number\":199,\"name\":\"basic-transport-belt\",\"position\":{\"x\":0,\"y\":3},\"direction\":6},{\"entity_number\":200,\"name\":\"small-electric-pole\",\"position\":{\"x\":2,\"y\":2}},{\"entity_number\":201,\"name\":\"small-electric-pole\",\"position\":{\"x\":6,\"y\":3}},{\"entity_number\":202,\"name\":\"inserter\",\"position\":{\"x\":6,\"y\":2},\"direction\":2},{\"entity_number\":203,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":2}},{\"entity_number\":204,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":3}},{\"entity_number\":205,\"name\":\"algae-farm\",\"position\":{\"x\":-10,\"y\":7},\"direction\":6,\"recipe\":\"algae-green\"},{\"entity_number\":206,\"name\":\"assembling-machine-1\",\"position\":{\"x\":-4,\"y\":5},\"recipe\":\"cellulose-fiber-algae\"},{\"entity_number\":207,\"name\":\"inserter\",\"position\":{\"x\":-6,\"y\":5},\"direction\":6},{\"entity_number\":208,\"name\":\"inserter\",\"position\":{\"x\":-6,\"y\":4},\"direction\":6},{\"entity_number\":209,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-1,\"y\":4},\"direction\":2},{\"entity_number\":210,\"name\":\"basic-transport-belt\",\"position\":{\"x\":-2,\"y\":4},\"direction\":2},{\"entity_number\":211,\"name\":\"inserter\",\"position\":{\"x\":-2,\"y\":5},\"direction\":4},{\"entity_number\":212,\"name\":\"inserter\",\"position\":{\"x\":-1,\"y\":5}},{\"entity_number\":213,\"name\":\"basic-transport-belt\",\"position\":{\"x\":0,\"y\":4}},{\"entity_number\":214,\"name\":\"basic-transport-belt\",\"position\":{\"x\":1,\"y\":4},\"direction\":6},{\"entity_number\":215,\"name\":\"inserter\",\"position\":{\"x\":1,\"y\":5}},{\"entity_number\":216,\"name\":\"basic-transport-belt\",\"position\":{\"x\":2,\"y\":4},\"direction\":6},{\"entity_number\":217,\"name\":\"inserter\",\"position\":{\"x\":2,\"y\":5},\"direction\":4},{\"entity_number\":218,\"name\":\"assembling-machine-1\",\"position\":{\"x\":4,\"y\":5},\"recipe\":\"cellulose-fiber-algae\"},{\"entity_number\":219,\"name\":\"inserter\",\"position\":{\"x\":6,\"y\":5},\"direction\":2},{\"entity_number\":220,\"name\":\"inserter\",\"position\":{\"x\":6,\"y\":4},\"direction\":2},{\"entity_number\":221,\"name\":\"algae-farm\",\"position\":{\"x\":10,\"y\":7},\"direction\":2,\"recipe\":\"algae-green\"},{\"entity_number\":222,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":4}},{\"entity_number\":223,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":5}},{\"entity_number\":224,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":7}},{\"entity_number\":225,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-6,\"y\":7},\"direction\":6},{\"entity_number\":226,\"name\":\"small-electric-pole\",\"position\":{\"x\":-3,\"y\":7}},{\"entity_number\":227,\"name\":\"inserter\",\"position\":{\"x\":-4,\"y\":7}},{\"entity_number\":228,\"name\":\"stone-furnace\",\"position\":{\"x\":-1.5,\"y\":6.5}},{\"entity_number\":229,\"name\":\"stone-furnace\",\"position\":{\"x\":1.5,\"y\":6.5}},{\"entity_number\":230,\"name\":\"small-electric-pole\",\"position\":{\"x\":3,\"y\":7}},{\"entity_number\":231,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":5,\"y\":7},\"direction\":2},{\"entity_number\":232,\"name\":\"inserter\",\"position\":{\"x\":4,\"y\":7}},{\"entity_number\":233,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":6,\"y\":6},\"direction\":4},{\"entity_number\":234,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":7}},{\"entity_number\":235,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":6}},{\"entity_number\":236,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":7}},{\"entity_number\":237,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":8}},{\"entity_number\":238,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":9}},{\"entity_number\":239,\"name\":\"assembling-machine-1\",\"position\":{\"x\":-4,\"y\":9},\"recipe\":\"wood-pellets\"},{\"entity_number\":240,\"name\":\"inserter\",\"position\":{\"x\":-1,\"y\":8},\"direction\":4},{\"entity_number\":241,\"name\":\"assembling-machine-1\",\"position\":{\"x\":0,\"y\":10},\"recipe\":\"wood-bricks\"},{\"entity_number\":242,\"name\":\"inserter\",\"position\":{\"x\":1,\"y\":8},\"direction\":4},{\"entity_number\":243,\"name\":\"assembling-machine-1\",\"position\":{\"x\":4,\"y\":9},\"recipe\":\"wood-pellets\"},{\"entity_number\":244,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":8}},{\"entity_number\":245,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":9}},{\"entity_number\":246,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":8}},{\"entity_number\":247,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":9}},{\"entity_number\":248,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":10}},{\"entity_number\":249,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":11}},{\"entity_number\":250,\"name\":\"algae-farm\",\"position\":{\"x\":-10,\"y\":14},\"direction\":6,\"recipe\":\"algae-green\"},{\"entity_number\":251,\"name\":\"assembling-machine-1\",\"position\":{\"x\":-4,\"y\":12},\"recipe\":\"wood-pellets\"},{\"entity_number\":252,\"name\":\"inserter\",\"position\":{\"x\":-2,\"y\":10},\"direction\":6},{\"entity_number\":253,\"name\":\"inserter\",\"position\":{\"x\":-2,\"y\":11},\"direction\":6},{\"entity_number\":254,\"name\":\"inserter\",\"position\":{\"x\":2,\"y\":11},\"direction\":2},{\"entity_number\":255,\"name\":\"inserter\",\"position\":{\"x\":2,\"y\":10},\"direction\":2},{\"entity_number\":256,\"name\":\"assembling-machine-1\",\"position\":{\"x\":4,\"y\":12},\"recipe\":\"wood-pellets\"},{\"entity_number\":257,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":10}},{\"entity_number\":258,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":11}},{\"entity_number\":259,\"name\":\"algae-farm\",\"position\":{\"x\":10,\"y\":14},\"direction\":2,\"recipe\":\"algae-green\"},{\"entity_number\":260,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":10}},{\"entity_number\":261,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":11}},{\"entity_number\":262,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":12}},{\"entity_number\":263,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":13}},{\"entity_number\":264,\"name\":\"small-electric-pole\",\"position\":{\"x\":0,\"y\":12}},{\"entity_number\":265,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":12}},{\"entity_number\":266,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":13}},{\"entity_number\":267,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":12}},{\"entity_number\":268,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":13}},{\"entity_number\":269,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":15}},{\"entity_number\":270,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":14}},{\"entity_number\":271,\"name\":\"small-electric-pole\",\"position\":{\"x\":-6,\"y\":15}},{\"entity_number\":272,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-6,\"y\":14},\"direction\":6},{\"entity_number\":273,\"name\":\"assembling-machine-1\",\"position\":{\"x\":-4,\"y\":16},\"recipe\":\"cellulose-fiber-algae\"},{\"entity_number\":274,\"name\":\"inserter\",\"position\":{\"x\":-4,\"y\":14},\"direction\":4},{\"entity_number\":275,\"name\":\"assembling-machine-1\",\"position\":{\"x\":4,\"y\":16},\"recipe\":\"cellulose-fiber-algae\"},{\"entity_number\":276,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":5,\"y\":14},\"direction\":2},{\"entity_number\":277,\"name\":\"inserter\",\"position\":{\"x\":4,\"y\":14},\"direction\":4},{\"entity_number\":278,\"name\":\"small-electric-pole\",\"position\":{\"x\":6,\"y\":15}},{\"entity_number\":279,\"name\":\"stone-pipe\",\"position\":{\"x\":6,\"y\":14}},{\"entity_number\":280,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":15}},{\"entity_number\":281,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":14}},{\"entity_number\":282,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":16}},{\"entity_number\":283,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":17}},{\"entity_number\":284,\"name\":\"inserter\",\"position\":{\"x\":-6,\"y\":16},\"direction\":6},{\"entity_number\":285,\"name\":\"inserter\",\"position\":{\"x\":-6,\"y\":17},\"direction\":6},{\"entity_number\":286,\"name\":\"inserter\",\"position\":{\"x\":6,\"y\":17},\"direction\":2},{\"entity_number\":287,\"name\":\"inserter\",\"position\":{\"x\":6,\"y\":16},\"direction\":2},{\"entity_number\":288,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":16}},{\"entity_number\":289,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":17}},{\"entity_number\":290,\"name\":\"stone-pipe\",\"position\":{\"x\":-13,\"y\":18}},{\"entity_number\":291,\"name\":\"stone-pipe\",\"position\":{\"x\":-14,\"y\":18}},{\"entity_number\":292,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-12,\"y\":18},\"direction\":6},{\"entity_number\":293,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":-1,\"y\":18},\"direction\":2},{\"entity_number\":294,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":1,\"y\":18},\"direction\":6},{\"entity_number\":295,\"name\":\"stone-pipe\",\"position\":{\"x\":0,\"y\":18}},{\"entity_number\":296,\"name\":\"stone-pipe-to-ground\",\"position\":{\"x\":12,\"y\":18},\"direction\":2},{\"entity_number\":297,\"name\":\"stone-pipe\",\"position\":{\"x\":13,\"y\":18}},{\"entity_number\":298,\"name\":\"stone-pipe\",\"position\":{\"x\":14,\"y\":18}}],\"item\":\"blueprint\",\"version\":77311508481}}";

    }
}