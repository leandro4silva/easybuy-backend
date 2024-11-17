﻿using CompraFacil.Infrastructure.Notifications;
using CompraFacil.Infrastructure.Notifications.Abstraction;
using Microsoft.Extensions.Logging;

namespace CompraFacil.Application.Helpers;

public sealed class NotificationHelper
{
    public static void Notificar(
        Exception ex,
        string mensagem,
        INotificationService notificacaoService,
        ILogger? logger = null)
    {
        var notificacao = CriarNotificacao(mensagem);
        notificacaoService.Adicionar(notificacao);

        logger?.LogCritical(ex, $"Mensagem: {mensagem}. Detalhes: {ex.Message}");
    }

    private static ErroResponse CriarNotificacao(string mensagem) => new() { Mesangem = mensagem };
}
