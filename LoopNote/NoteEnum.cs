using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopNote
{
    public enum NoteEnum
    {
        Do =  0,
        Re =  1,
        Mi =  2,
        Fa =  3,
        Sol = 4,
        La =  5,
        Si =  6
    }

    public class NoteUtility
    {

        public IList<NoteEnum> NoteEnumList;

        public static string GetStringByNote(int idNote)
        {

            switch (idNote)
            {
                case 0: return NoteEnum.Do.ToString();
                case 1: return NoteEnum.Re.ToString();
                case 2: return NoteEnum.Mi.ToString();
                case 3: return NoteEnum.Fa.ToString();
                case 4: return NoteEnum.Sol.ToString();
                case 5: return NoteEnum.La.ToString();
                case 6: return NoteEnum.Si.ToString();

                default: throw new ArgumentException("Note not present");
            }
        }

        public static List<NoteEnum> GetNoteEnumList()
        {
            
            return Enum.GetValues(typeof(NoteEnum)).Cast<NoteEnum>().ToList();
        }

    }
}
