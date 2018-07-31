
using System;
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

        public override bool Equals(Object obj)
        {
            return obj is Move && this == (Move)obj;
        }
        public override int GetHashCode()
        {
            return Identifiant.GetHashCode() ^ Sens.GetHashCode();
        }
        public static bool operator ==(Move x, Move y)
        {
            return x.Identifiant == y.Identifiant && x.Sens == y.Sens;
        }
        public static bool operator !=(Move x, Move y)
        {
            return !(x == y);
        }

        public enum EnumSens
        {
            Normal,
            Prime,
            Seconde,
        }
    }
}
