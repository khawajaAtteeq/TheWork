using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    public interface IAccountsBalanceSheetNote
    {
        AccountsBalanceSheetNoteEntity GetBalanceSheetNoteById(int id);
        IEnumerable<AccountsBalanceSheetNoteEntity> GetAllBalanceSheetNotes();
        int CreateBalanceSheetNote(AccountsBalanceSheetNoteEntity accountsBalanceSheetNoteEntity);
        bool UpdateBalanceSheetNote(int id, AccountsBalanceSheetNoteEntity accountsBalanceSheetNoteEntity);
        bool DeleteBalanceSheetNote(int id);
    }
}
