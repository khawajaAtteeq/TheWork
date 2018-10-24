using DataModel;
using AutoMapper;
using System.Linq;
using BusinessEntities;
using System.Transactions;
using DataModel.UnitOfWork;
using System.Collections.Generic;
using BusinessServices.Interface;

namespace BusinessServices.Services
{
    public class AccountsBalanceSheetNoteServices: IAccountsBalanceSheetNote
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountsBalanceSheetNoteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AccountsBalanceSheetNoteServices()
        {
        }

        public AccountsBalanceSheetNoteEntity GetBalanceSheetNoteById(int id)
        {
            var note = _unitOfWork.AccountsBalanceSheetNoteRepository.GetById(id);
            if (note != null)
            {
                Mapper.CreateMap<AccountsBalanceSheetNote, AccountsBalanceSheetNoteEntity>();
                var noteModel=Mapper.Map<AccountsBalanceSheetNote, AccountsBalanceSheetNoteEntity>(note);
                return noteModel;
            }
            return null;
        }

        public IEnumerable<AccountsBalanceSheetNoteEntity> GetAllBalanceSheetNotes()
        {
            var note = _unitOfWork.AccountsBalanceSheetNoteRepository.GetAll().ToList();
            if (note != null)
            {
                Mapper.CreateMap<AccountsBalanceSheetNote, AccountsBalanceSheetNoteEntity>();
                var noteModel = Mapper.Map<List<AccountsBalanceSheetNote>, List<AccountsBalanceSheetNoteEntity>>(note);
                return noteModel;
            }
            return null;
        }

        public int CreateBalanceSheetNote(AccountsBalanceSheetNoteEntity accountsBalanceSheetNoteEntity)
        {
            using(var scope= new TransactionScope())
            {
                var note = new AccountsBalanceSheetNote
                {
                    BalanceSheetNoteName=accountsBalanceSheetNoteEntity.BalanceSheetNoteName,
                    BalanceSheetNoteNumber=accountsBalanceSheetNoteEntity.BalanceSheetNoteNumber,
                    IsActive=accountsBalanceSheetNoteEntity.IsActive
                };
                _unitOfWork.AccountsBalanceSheetNoteRepository.Insert(note);
                _unitOfWork.Save();
                scope.Complete();
                return note.Id;
            }
        }

        public bool UpdateBalanceSheetNote(int id, AccountsBalanceSheetNoteEntity accountsBalanceSheetNoteEntity)
        {
            var success = false;
            if (accountsBalanceSheetNoteEntity !=null)
            {
                var note = _unitOfWork.AccountsBalanceSheetNoteRepository.GetById(id);
                if (note != null)
                {
                    using(var scope= new TransactionScope())
                    {
                        note.BalanceSheetNoteName = accountsBalanceSheetNoteEntity.BalanceSheetNoteName;
                        note.BalanceSheetNoteNumber = accountsBalanceSheetNoteEntity.BalanceSheetNoteNumber;
                        note.IsActive = accountsBalanceSheetNoteEntity.IsActive;

                        _unitOfWork.AccountsBalanceSheetNoteRepository.Update(note);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteBalanceSheetNote(int id)
        {
            var success = false;
            if (id > 0)
            {
                var note = _unitOfWork.AccountsBalanceSheetNoteRepository.GetById(id);
                if (note != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _unitOfWork.AccountsBalanceSheetNoteRepository.Delete(note);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
