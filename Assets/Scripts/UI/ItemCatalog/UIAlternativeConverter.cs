using CharacterCustomizer;

namespace UI.ItemCatalog
{
    public static class UIAlternativeConverter
    {
        public static CharacterPart GetAlternativePart(CharacterPart characterPart)
        {
            if (characterPart == CharacterPart.Torso)
            {
                return CharacterPart.TorsoArmor;
            }
                
            else if (characterPart == CharacterPart.Pants)
            {
                return CharacterPart.BottomArmor;
            }
            else
            {
                return CharacterPart.Invalid;
            }
        }
    }
}