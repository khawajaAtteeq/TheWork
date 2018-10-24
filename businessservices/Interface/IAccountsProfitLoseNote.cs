using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    public interface IAccountsProfitLoseNote
    {
        AccountsProfitLoseNoteEntity GetProfitLoseNoteById(int id);
        IEnumerable<AccountsProfitLoseNoteEntity> GetProfitLoseNotes();
        int CreateProfitLoseNote(AccountsProfitLoseNoteEntity accountsProfitLoseNoteEntity);
        bool UpdateProfitLoseNote(int id, AccountsProfitLoseNoteEntity accountsProfitLoseNoteEntity);
        bool DeleteProfitLoseNote(int id);
    }
}
