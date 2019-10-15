using AutoMapper;
using Bankflix.API.Models.Clientes.Clientes;
using Bankflix.API.Models.Movimentacoes.Depositos;
using Bankflix.API.Models.Movimentacoes.Transferencias;
using Clientes.Commands.Clientes;
using Movimentacoes.Commands.Depositos;
using Movimentacoes.Commands.Transferencias;
using System;

namespace Bankflix.API.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            MapearContextoClientes();
            MapearContextoMovimentacoes();
        }

        private void MapearContextoClientes()
        {
            CreateMap<CadastrarClienteViewModel, CadastrarClienteCommand>()
                .ConstructUsing(c => new CadastrarClienteCommand(c.Id, c.NomeCompleto, c.Cpf, c.DataNascimento, c.Email, c.Telefone, c.SenhaCriptografada, c.DataHoraCriacao));

            CreateMap<Guid, AprovarClienteCommand>()
                .ConstructUsing(id => new AprovarClienteCommand(id));

            CreateMap<Guid, RecusarClienteCommand>()
                .ConstructUsing(id => new RecusarClienteCommand(id));
        }

        private void MapearContextoMovimentacoes()
        {
            CreateMap<SolicitarDepositoViewModel, SolicitarDepositoCommand>()
                    .ConstructUsing(d => new SolicitarDepositoCommand(d.Id, d.ClienteId, d.ValorEmCentavos, d.DataHoraCriacao));

            CreateMap<SolicitarTransferenciaViewModel, SolicitarTransferenciaCommand>()
                    .ConstructUsing(t => new SolicitarTransferenciaCommand(t.Id, t.ClienteOrigemId, t.NumeroContaDestino, t.DigitoVerificadorContaDestino, t.ValorEmCentavos, t.DataHoraCriacao));
        }
    }
}
