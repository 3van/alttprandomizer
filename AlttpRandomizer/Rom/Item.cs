﻿using System.Text;

namespace AlttpRandomizer.Rom
{
    public enum ItemType
    {
		Nothing = 0xFF,
		L1SwordAndShield = 0x00, // can't be used until after uncle dies
        L2Sword = 0x01, // crashes game
        L3Sword = 0x02, // can't be used until after uncle dies
        L4Sword = 0x03, // can't be used until after uncle dies
        BlueShield = 0x04, // can't be used until after uncle dies
        RedShield = 0x05, // can't be used until after uncle dies
        MirrorShield = 0x06, // can't be used until after uncle dies
        FireRod = 0x07,
        IceRod = 0x08,
        Hammer = 0x09,
        Hookshot = 0x0a,
        Bow = 0x0b,
        Boomerang = 0x0c, // alt: 10 arrows
        Powder = 0x0d,
        Bee = 0x0e, // does nothing if no bottle
        Bombos = 0x0f,
        Ether = 0x10,
        Quake = 0x11,
        Lamp = 0x12, // alt: 5 rupees
        Shovel = 0x13,
        OcarinaInactive = 0x14,
        CaneOfSomaria = 0x15,
        Bottle = 0x16,
        PieceOfHeart = 0x17,
        StaffOfByrna = 0x18,
        Cape = 0x19,
        MagicMirror = 0x1a,
        PowerGlove = 0x1b,
        TitansMitt = 0x1c,
        BookOfMudora = 0x1d,
        Flippers = 0x1e,
        MoonPearl = 0x1f,
        Crystal = 0x20, // crashes game
        BugCatchingNet = 0x21,
        BlueMail = 0x22,
        RedMail = 0x23,
        Key = 0x24,
        Compass = 0x25,
        HeartContainerNoAnimation = 0x26,
        Bomb = 0x27,
        ThreeBombs = 0x28,
        Mushroom = 0x29,
        RedBoomerang = 0x2a,
        BottleWithRedPotion = 0x2b,
        BottleWithGreenPotion = 0x2c,
        BottleWithBluePotion = 0x2d,
        RedPotion = 0x2e, // does nothing if no bottle
        GreenPotion = 0x2f, // does nothing if no bottle
        BluePotion = 0x30, // does nothing if no bottle
        TenBombs = 0x31,
        BigKey = 0x32,
        Map = 0x33,
        OneRupee = 0x34,
        FiveRupees = 0x35,
        TwentyRupees = 0x36,
        PendantOfCourage = 0x37, // green
        PendantOfWisdom = 0x38, // red
        PendantOfPower = 0x39, // blue
        BowAndArrows = 0x3a,
        BowAndSilverArrows = 0x3b,
        BottleWithBee = 0x3c, 
        BottleWithFairy = 0x3d, 
        HeartContainerNoDialog = 0x3e,
        HeartContainer = 0x3f,
        OneHundredRupees = 0x40,
        FiftyRupees = 0x41,
        Heart = 0x42,
        Arrow = 0x43,
        TenArrows = 0x44,
        SmallMagic = 0x45,
        ThreeHundredRupees = 0x46,
        TwentyRupees2 = 0x47,
        BottleWithGoldBee = 0x48,
        L1Sword = 0x49, // can't be used until after uncle dies
        OcarinaActive = 0x4a,
        PegasusBoots = 0x4b,
        
        // Magic Bat
        FullMagic = 0x00,
        HalfMagic = 0x01,
        QuarterMagic = 0x02,
	}

	public class Item
    {
        private ItemType type;
        public char HexValue { get; set; }

        public Item(ItemType insertedItem)
        {
            Type = insertedItem;
        }

        public ItemType Type
        {
            get { return type; }
            set
            {
                type = value;
                HexValue = (char)type;
            }
        }

	    public static byte[] GetItemLevel(ItemType item)
	    {
            byte retVal;

            switch (item)
            {
                case ItemType.RedBoomerang:
                case ItemType.Powder:
                case ItemType.MagicMirror:
                case ItemType.TitansMitt:
                case ItemType.RedShield:
                case ItemType.OcarinaInactive:
                case ItemType.L2Sword:
                case ItemType.BowAndArrows:
                case ItemType.RedMail:
                    retVal = 0x02;
                    break;
                case ItemType.BowAndSilverArrows:
                case ItemType.OcarinaActive:
                case ItemType.MirrorShield:
                case ItemType.L3Sword:
                    retVal = 0x03;
                    break;
                case ItemType.L4Sword:
                    retVal = 0x04;
                    break;
                default:
                    // Anything not listed here is a 1
                    retVal = 0x01;
                    break;
            }

            return new[] { retVal };
        }

        public static byte[] GetCheckLocation(ItemType item)
        {
            byte retVal;

            switch (item)
            {
                case ItemType.Bow:
                case ItemType.BowAndArrows:
                case ItemType.BowAndSilverArrows:
                    retVal = 0x40;
                    break;
                case ItemType.Boomerang:
                case ItemType.RedBoomerang:
                    retVal = 0x41;
                    break;
                case ItemType.Hookshot:
                    retVal = 0x42;
                    break;
                case ItemType.Mushroom:
                case ItemType.Powder:
                    retVal = 0x44;
                    break;
                case ItemType.FireRod:
                    retVal = 0x45;
                    break;
                case ItemType.IceRod:
                    retVal = 0x46;
                    break;
                case ItemType.Bombos:
                    retVal = 0x47;
                    break;
                case ItemType.Ether:
                    retVal = 0x48;
                    break;
                case ItemType.Quake:
                    retVal = 0x49;
                    break;
                case ItemType.Lamp:
                    retVal = 0x4a;
                    break;
                case ItemType.Hammer:
                    retVal = 0x4b;
                    break;
                case ItemType.Shovel:
                case ItemType.OcarinaActive:
                case ItemType.OcarinaInactive:
                    retVal = 0x4c;
                    break;
                case ItemType.BugCatchingNet:
                    retVal = 0x4d;
                    break;
                case ItemType.BookOfMudora:
                    retVal = 0x4e;
                    break;
                case ItemType.CaneOfSomaria:
                    retVal = 0x50;
                    break;
                case ItemType.StaffOfByrna:
                    retVal = 0x51;
                    break;
                case ItemType.Cape:
                    retVal = 0x52;
                    break;
                case ItemType.MagicMirror:
                    retVal = 0x53;
                    break;
                case ItemType.PowerGlove:
                case ItemType.TitansMitt:
                    retVal = 0x54;
                    break;
                case ItemType.PegasusBoots:
                    retVal = 0x55;
                    break;
                case ItemType.Flippers:
                    retVal = 0x56;
                    break;
                case ItemType.MoonPearl:
                    retVal = 0x57;
                    break;
                case ItemType.L1Sword:
                case ItemType.L1SwordAndShield:
                case ItemType.L2Sword:
                case ItemType.L3Sword:
                case ItemType.L4Sword:
                    retVal = 0x59;
                    break;
                case ItemType.BlueShield:
                case ItemType.RedShield:
                case ItemType.MirrorShield:
                    retVal = 0x5a;
                    break;
                case ItemType.BlueMail:
                case ItemType.RedMail:
                    retVal = 0x5b;
                    break;
                default:
                    retVal = 0x00;
                    break;
            }

            return new[] { retVal };
        }

        public static byte[] GetCreditsName(ItemType item)
        {
            int maxLength = 20;
            StringBuilder retVal = new StringBuilder(maxLength, maxLength);

            switch (item)
            {
                case ItemType.Bow:
                    retVal.Append("arrow sling");
                    break;
                case ItemType.BowAndArrows:
                    retVal.Append("point stick");
                    break;
                case ItemType.BowAndSilverArrows:
                    retVal.Append("sharp stick");
                    break;
                case ItemType.Boomerang:
                case ItemType.RedBoomerang:
                    retVal.Append("bent stick");
                    break;
                case ItemType.Hookshot:
                    retVal.Append("boinger");
                    break;
                case ItemType.Mushroom:
                case ItemType.Powder:
                    retVal.Append("legal drugs");
                    break;
                case ItemType.FireRod:
                    retVal.Append("flame staff");
                    break;
                case ItemType.IceRod:
                    retVal.Append("ice cream");
                    break;
                case ItemType.Bombos:
                    retVal.Append("swirly coin");
                    break;
                case ItemType.Ether:
                    retVal.Append("bolt coin");
                    break;
                case ItemType.Quake:
                    retVal.Append("wavy coin");
                    break;
                case ItemType.Lamp:
                    retVal.Append("candle");
                    break;
                case ItemType.Hammer:
                    retVal.Append("m c hammer");
                    break;
                case ItemType.Shovel:
                    retVal.Append("dirt spade");
                    break;
                case ItemType.OcarinaActive:
                case ItemType.OcarinaInactive:
                    retVal.Append("bird call");
                    break;
                case ItemType.BugCatchingNet:
                    retVal.Append("stick web");
                    break;
                case ItemType.BookOfMudora:
                    retVal.Append("moon runes");
                    break;
                case ItemType.CaneOfSomaria:
                    retVal.Append("block stick");
                    break;
                case ItemType.StaffOfByrna:
                    retVal.Append("shiny stick");
                    break;
                case ItemType.Cape:
                    retVal.Append("red hood");
                    break;
                case ItemType.MagicMirror:
                    retVal.Append("your face");
                    break;
                case ItemType.PowerGlove:
                    retVal.Append("lift glove");
                    break;
                case ItemType.TitansMitt:
                    retVal.Append("carry glove");
                    break;
                case ItemType.PegasusBoots:
                    retVal.Append("sprint shoe");
                    break;
                case ItemType.Flippers:
                    retVal.Append("finger webs");
                    break;
                case ItemType.MoonPearl:
                    retVal.Append("lunar orb");
                    break;
                case ItemType.L1Sword:
                case ItemType.L1SwordAndShield:
                case ItemType.L2Sword:
                case ItemType.L3Sword:
                case ItemType.L4Sword:
                    retVal.Append("sword");
                    break;
                case ItemType.BlueShield:
                    retVal.Append("shield");
                    break;
                case ItemType.RedShield:
                    retVal.Append("red shield");
                    break;
                case ItemType.MirrorShield:
                    retVal.Append("face shield");
                    break;
                case ItemType.BlueMail:
                    retVal.Append("blue suit");
                    break;
                case ItemType.RedMail:
                    retVal.Append("purple hat");
                    break;
                default:
                    retVal.Append("life lesson");
                    break;
            }

            retVal.Append(" for sale");

            //space it some on the left to center it sliIIiightly better
            if (retVal.Length < maxLength)
            {
                retVal.Insert(0, " ", maxLength - retVal.Length);
            }

            return ConvertToCreditEncoding(retVal.ToString());
        }

        private static byte[] ConvertToCreditEncoding(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input.ToLower());

            // 'a' in ASCII = 0x61
            // 'a' in z3credits = 0x1A (among others, but this for the small font)
            for (var i = 0; i < inputBytes.Length; ++i)
            {
                switch (inputBytes[i])
                {
                    case (byte)' ':
                        inputBytes[i] = 0x9F;
                        break;
                    case (byte)'\'':
                        inputBytes[i] = 0x35;
                        break;
                    case (byte)'-':
                        inputBytes[i] = 0x36;
                        break;
                    case (byte)',':
                        inputBytes[i] = 0x37;
                        break;
                    default:
                        inputBytes[i] = (byte)(inputBytes[i] - 0x47);
                        break;
                }
            }
            return inputBytes;
        }

    }
}
