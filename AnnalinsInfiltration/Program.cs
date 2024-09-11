using System;

namespace AnnalinsInfiltration
{
    public static class QuestLogic
    {
        public static bool CanFastAttack(bool knightIsAwake)
        {
            if (knightIsAwake == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
        {
            if ((knightIsAwake == false && archerIsAwake == false) && prisonerIsAwake == false)
            {
                return false;
            }

            else
            {
                return true;
            }

        }

        public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
        {
            if (archerIsAwake == false && prisonerIsAwake == true)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
        {
            if (petDogIsPresent == true && archerIsAwake == false)
            {
                return true;
            }

            else if (prisonerIsAwake == true && (archerIsAwake == false && knightIsAwake == false))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static void Main()
        {
            bool knightIsAwake = false;
            bool archerIsAwake = true;
            bool prisonerIsAwake = true;
            bool petDogIsPresent = false;
            CanFastAttack(knightIsAwake);
            CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake);
            CanSignalPrisoner(archerIsAwake, prisonerIsAwake);
            CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent);
        }
    }
}
