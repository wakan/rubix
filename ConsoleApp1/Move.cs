
using System.Text;

namespace ConsoleApp1
{
    public struct Move
    {
        public char Identifiant;
        public EnumSens Sens;

        public override string ToString() {
            var sb = new StringBuilder(4);
            sb.Append(Identifiant);
            sb.Append(Sens == EnumSens.Normal ? string.Empty
                : Sens == EnumSens.Prime ? "'"
                : Sens == EnumSens.Seconde ? "''"
                : string.Empty);
            return sb.ToString();
        }


        public enum EnumSens
        {
            Normal,
            Prime,
            Seconde,
        }
    }
}
