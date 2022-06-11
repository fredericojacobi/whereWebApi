﻿using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;

namespace Services;

public class ServiceWrapper : IServiceWrapper
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    private IUserApplicationService _userApplication;
    private IEventService _event;

    public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IUserApplicationService UserApplication => _userApplication ??= new UserApplicationService(_repository, _mapper);

    public IEventService Event => _event ??= new EventService(_repository, _mapper);
}