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
    public class AccountsProfitLoseNoteServices: IAccountsProfitLoseNote
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountsProfitLoseNoteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AccountsProfitLoseNoteServices()
        {
        }

        public AccountsProfitLoseNoteEntity GetProfitLoseNoteById(int id)
        {
            var note = _unitOfWork.AccountsProfitLoseNoteRepository.GetById(id);
            if (note != null)
            {
                Mapper.CreateMap<AccountsProfitLoseNote, AccountsProfitLoseNoteEntity>();
                var noteModel= Mapper.Map<AccountsProfitLoseNote, AccountsProfitLoseNoteEntity>(note);
                return noteModel;
            }
            return null;
        }

        public IEnumerable<AccountsProfitLoseNoteEntity> GetProfitLoseNotes()
        {

            var note = _unitOfWork.AccountsProfitLoseNoteRepository.GetAll().ToList();
            if (note != null)
            {
                Mapper.CreateMap<AccountsProfitLoseNote, AccountsProfitLoseNoteEntity>();
                var noteModel = Mapper.Map<List<AccountsProfitLoseNote>, List<AccountsProfitLoseNoteEntity>>(note);
                return noteModel;
            }
            return null;
        }

        public int CreateProfitLoseNote(AccountsProfitLoseNoteEntity accountsProfitLoseNoteEntity)
        {
            using(var scope= new TransactionScope())
            {
                var note = new AccountsProfitLoseNote
                {
                    ProfitLoseNoteName=accountsProfitLoseNoteEntity.ProfitLoseNoteName,
                    ProfitLoseNoteNumber=accountsProfitLoseNoteEntity.ProfitLoseNoteNumber,
                    IsActive=accountsProfitLoseNoteEntity.IsActive
                };
                _unitOfWork.AccountsProfitLoseNoteRepository.Insert(note);
                _unitOfWork.Save();
                scope.Complete();
                return note.Id;
            }
        }

        public bool UpdateProfitLoseNote(int id, AccountsProfitLoseNoteEntity accountsProfitLoseNoteEntity)
        {
            var success = false;
            if (accountsProfitLoseNoteEntity != null)
            {
                using(var scope=new TransactionScope())
                {
                    var note = _unitOfWork.AccountsProfitLoseNoteRepository.GetById(id);
                    if (note != null)
                    {
                        note.ProfitLoseNoteName = accountsProfitLoseNoteEntity.ProfitLoseNoteName;
                        note.ProfitLoseNoteNumber = accountsProfitLoseNoteEntity.ProfitLoseNoteNumber;
                        note.IsActive = accountsProfitLoseNoteEntity.IsActive;

                        _unitOfWork.AccountsProfitLoseNoteRepository.Update(note);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteProfitLoseNote(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var note = _unitOfWork.AccountsProfitLoseNoteRepository.GetById(id);
                    if (note != null)
                    {
                        _unitOfWork.AccountsProfitLoseNoteRepository.Delete(note);
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
