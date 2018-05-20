using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MaratonaBotsBOT.BO;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace MaratonaBotsBOT.Dialogs
{
    [Serializable]
    [LuisModel("a192d8da-d643-44c6-a7de-05a39306bad9", "3c6168b228f445fb8850900e21d533e4")]
    public class InformacoesDialog : LuisDialog<object>
    {

        [LuisIntent("problemas")]
        public async Task Problemas(IDialogContext context, LuisResult result)
        {
            var racas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", racas.ToArray());
            string raca = Formata.getRaca(filtro);
            var endpoint = ConfigurationManager.AppSettings["urlAPI"] + $"Informacoes/problemas/?raca={raca}";
            await context.PostAsync("Um momento, estou buscando essa informação");
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Desculpe, não consegui buscar sua informação");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Informacao>(json);
                    var problemas = $"{resultado.texto}";
                    await context.PostAsync($"{problemas}");
                }
            }
            context.Done(true);
        }

        [LuisIntent("pais_de_origem")]
        public async Task PaisDeOrigem(IDialogContext context, LuisResult result)
        {
            var racas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", racas.ToArray());
            string raca = Formata.getRaca(filtro);
            var endpoint = ConfigurationManager.AppSettings["urlAPI"] +  $"Informacoes/paisdeorigem/?raca={raca}";
            await context.PostAsync("Um momento, estou buscando essa informação");
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Desculpe, não consegui buscar sua informação");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Informacao>(json);
                    var paisDeOrigem = $"{resultado.texto}";
                    await context.PostAsync($"{paisDeOrigem}");
                }
            }
            context.Done(true);
        }

        [LuisIntent("origem")]
        public async Task Origem(IDialogContext context, LuisResult result)
        {
            var racas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", racas.ToArray());
            string raca = Formata.getRaca(filtro);
            var endpoint = ConfigurationManager.AppSettings["urlAPI"] + $"Informacoes/origem/?raca={raca}";
            await context.PostAsync("Um momento, estou buscando essa informação");
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Desculpe, não consegui buscar sua informação");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Informacao>(json);
                    var origem = $"{resultado.texto}";
                    await context.PostAsync($"{origem}");
                }
            }
            context.Done(true);
        }

        [LuisIntent("cuidados")]
        public async Task Cuidados(IDialogContext context, LuisResult result)
        {
            var racas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", racas.ToArray());
            string raca = Formata.getRaca(filtro);
            var endpoint = ConfigurationManager.AppSettings["urlAPI"] +  $"Informacoes/cuidados/?raca={raca}";
            await context.PostAsync("Um momento, estou buscando essa informação");
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Desculpe, não consegui buscar sua informação");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Informacao>(json);
                    var cuidados = $"{resultado.texto}";
                    await context.PostAsync($"{cuidados}");
                }
            }
            context.Done(true);
        }

        [LuisIntent("caracteristicas_fisicas")]
        public async Task CaracteristicasFisicas(IDialogContext context, LuisResult result)
        {
            var racas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", racas.ToArray());
            string raca = Formata.getRaca(filtro);
            var endpoint = ConfigurationManager.AppSettings["urlAPI"] + $"Informacoes/CaracteristicasFisicas/?raca={raca}";
            await context.PostAsync("Um momento, estou buscando essa informação");
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Desculpe, não consegui buscar sua informação");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Informacao>(json);
                    var caracteristicasFisicas = $"{resultado.texto}";
                    await context.PostAsync($"{caracteristicasFisicas}");
                }
            }
            context.Done(true);
        }

        [LuisIntent("caracteristicas_comportamentais")]
        public async Task CaracteristicasComportamentais(IDialogContext context, LuisResult result)
        {
            var racas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", racas.ToArray());
            string raca = Formata.getRaca(filtro);
            var endpoint = ConfigurationManager.AppSettings["urlAPI"] +  $"Informacoes/CaracteristicasComportamentais/?raca={raca}";
            await context.PostAsync("Um momento, estou buscando essa informação");
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Desculpe, não consegui buscar sua informação");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Informacao>(json);
                    var caracteristicasComportamentais = $"{resultado.texto}";
                    await context.PostAsync($"{caracteristicasComportamentais}");
                }
            }
            context.Done(true);
        }

        [LuisIntent("imagens")]
        public async Task Imagens(IDialogContext context, LuisResult result)
        {
            var racas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", racas.ToArray());
            string raca = Formata.getRaca(filtro);
            Activity resposta = ((Activity)context.Activity).CreateReply();
            var endpoint = ConfigurationManager.AppSettings["urlAPI"] + $"Informacoes/Imagens/?raca={raca}";
            await context.PostAsync("Um momento, estou buscando essa informação");
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Desculpe, não consegui buscar sua informação");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Informacao>(json);
                    var imagens = $"{resultado.texto}";
                    string[] urlImagens = imagens.Split(';');
                    HeroCard card = new HeroCard
                    {
                        Title = resultado.raca,
                        Subtitle = resultado.informacao
                    };
                    card.Images = new List<CardImage>
                    {
                         new CardImage(urlImagens[0]),
                         new CardImage(urlImagens[1]),
                         new CardImage(urlImagens[2])
                    };
                    resposta.Attachments.Add(card.ToAttachment());
                    await context.PostAsync(resposta);
                }
            }
            context.Done(true);
        }

        [LuisIntent("idade")]
        public async Task Idade(IDialogContext context, LuisResult result)
        {
            var endpoint = ConfigurationManager.AppSettings["urlAPI"] + $"Informacoes/Idade";
            await context.PostAsync("Um momento, estou buscando essa informação");
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Desculpe, não consegui buscar sua informação");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Informacao>(json);
                    var idade = $"{resultado.texto}";
                    await context.PostAsync($"{idade}");
                }
            }
            context.Done(true);
        }

        [LuisIntent("saudacoes")]
        public async Task Saudacoes(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Olá, eu sou um bot que sabe sobre gatos. Eu posso lhe informar e mostras imagens sobre " +
                                "raças, identificar uma raça baseada em uma foto, ou responder perguntas comuns sobre gatos.");
            context.Done(true);
        }

        [LuisIntent("ajuda")]
        public async Task Ajuda(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Eu posso lhe fornecer informações sobre raças de gato, como: características físicas e comportamentais, origem, país de origem, cuidados necessários e principais problemas de saúde. Também posso enviar imagens dos gatos. Se me enviar um imagem eu também posso identificar qual é a raça. Meu desenvolvedor é o Felipe Pena.");
            context.Done(true);
        }

        [LuisIntent("enviarImagem")]
        public async Task EnviarImagem(IDialogContext context, LuisResult result)
        {
            await context.Forward(new PesquisaDialog(), AfterPesquisaDialog, context.Activity, CancellationToken.None);
        }

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.Forward(new PesquisaDialog(), AfterPesquisaDialog, context.Activity, CancellationToken.None);
        }

        private async Task AfterPesquisaDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }
    }
}