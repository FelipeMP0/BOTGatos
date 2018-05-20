using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using MaratonaBotsBOT.BO;
using MaratonaBotsBOT.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace MaratonaBotsBOT.Dialogs
{
    [Serializable]
    public class PesquisaDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as IMessageActivity;
            if (activity.Attachments.Count == 0)
            {
                await context.PostAsync("Envie a imagem");
                return;
            }
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Prediction-Key", "98c657c355564852ab97d271171063f5");
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.1/Prediction/d21039f3-98b1-4d00-b75a-52ebebf29730/image?";
            HttpResponseMessage response;
            var imagem = await client.GetAsync(activity.Attachments[0].ContentUrl);
            byte[] x = await imagem.Content.ReadAsByteArrayAsync();
            byte[] byteData = Imagem.GetImageAsByteArray(x);
            await context.PostAsync("Um momento, estou analisando sua imagem");
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(url, content);
                string json = await response.Content.ReadAsStringAsync();
                VisionResponse r = JsonConvert.DeserializeObject<VisionResponse>(json);
                if (r.Predictions[1].Probability > 0.50) {
                    await context.PostAsync("A mais provável raça é " + r.Predictions[0].Tag + ". Probabilidade: " + Math.Round((r.Predictions[0].Probability * 100)) + "%\nEsse gato também pode ser um " + r.Predictions[1].Tag + ". Probabilidade: " + Math.Round((r.Predictions[1].Probability * 100)) + "%");
                }
                else
                {
                    await context.PostAsync("A mais provável raça é " + r.Predictions[0].Tag + ". Probabilidade: " + (r.Predictions[0].Probability * 100) + "%");
                }
            }
            await context.Forward(new InformacoesDialog(), AfterInformacoesDialog, context.Activity, CancellationToken.None);
            context.Done(this);
        }
        private async Task AfterInformacoesDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceivedAsync);
        }
    }
}