using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using ServiceContracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class BookUserReferenceService : IBookUserReferenceService
    {
        private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BookUserReferenceService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            //_logger = logger;
            _mapper = mapper;
        }
        public async Task<BookUserReferenceDTO> CreateBookUserReferenceAsync(BookUserReferenceForCreationDTO reference)
        {
            var ReferenceEntity = _mapper.Map<BookUserReference>(reference);
            _repository.BookUserReference.CreateBookUserReference(ReferenceEntity);
            await _repository.SaveAsync();
            var ReferenceToReturn = _mapper.Map<BookUserReferenceDTO>(ReferenceEntity);
            return ReferenceToReturn;
        }

        public async Task DeleteBookUserReferenceAsync(Guid bookUserReferenceId, bool trackChanges)
        { 
            var reference = await _repository.BookUserReference.GetBookUserReference(bookUserReferenceId, trackChanges);
            if (reference is null)
                throw new BookNotFoundException(bookUserReferenceId);
            _repository.BookUserReference.DeleteBookUserReference(reference);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<BookUserReferenceDTO>> GetAllBookUserReferencesAsync(bool trackChanges)
        {
            var references = await _repository.BookUserReference.GetAllBookUserReferences(trackChanges);
            var referencesDto = _mapper.Map<IEnumerable<BookUserReferenceDTO>>(references);
            return referencesDto;
        }

        public async Task<BookUserReferenceDTO> GetBookUserReferenceAsync(Guid id, bool trackChanges)
        {
            var reference = await _repository.BookUserReference.GetBookUserReference(id, trackChanges);
            if (reference is null)
                throw new BookNotFoundException(id);
            var referenceDto = _mapper.Map<BookUserReferenceDTO>(reference);
            return referenceDto;
        }

        public async Task UpdateBookUserReferenceAsync(Guid id, BookUserReferenceForUpdateDTO referenceForUpdate, bool trackChanges)
        {
            var referenceEntity = await _repository.BookUserReference.GetBookUserReference(id, trackChanges);
            if (referenceEntity is null)
                throw new BookNotFoundException(id);
            _mapper.Map(referenceForUpdate, referenceEntity);
            await _repository.SaveAsync();
        }
    }
}
