﻿using API_ECommerce.DTOs;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces;

public interface IPedidoRepository
{
    List<Pedido> ListarTodos();
    Pedido BuscarPorId(int id);
    void Cadastrar(PedidoDto PedidoDto);
    void Atualizar(int id, PedidoDto PedidoDto);
    void Deletar(int id);
}
