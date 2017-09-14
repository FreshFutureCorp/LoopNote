using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopNote.Domain
{

    public class NoteType
    {
        public NoteType(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        #region Properties

        public int Id { get; protected set; }
        public string Description { get; protected set; }

        #endregion


    }

    public class NoteTypeList : ReadOnlyCollection<NoteType>
    {

        public static NoteType Do = new NoteType(0, "Do");
        public static NoteType Re = new NoteType(1, "Re");
        public static NoteType Mi = new NoteType(2, "Mi");
        public static NoteType Fa = new NoteType(3, "Fa");
        public static NoteType Sol = new NoteType(4, "Sol");
        public static NoteType La = new NoteType(5, "La");
        public static NoteType Si = new NoteType(6, "Si");

        public static ReadOnlyCollection<NoteType> AllNoteType = new ReadOnlyCollection<NoteType>(new List<NoteType>() { Do, Re, Mi, Fa, Sol, La, Si });


        public NoteTypeList() : base(AllNoteType)
        {
        }


    }

}
