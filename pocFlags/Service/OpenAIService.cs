using Microsoft.FeatureManagement;

namespace pocFlags.Service;

public class OpenAIService
{
    private readonly IFeatureManager _featureManager;

    public OpenAIService(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async Task<string> ResponseOpenai(string modelName)
    {
        var response = await MakeResponse(modelName);
        if (modelName == "curriculo" && await _featureManager.IsEnabledAsync("CurriculoMarcarEntrevista"))
            await MarcarEntrevista();

        return response;
    }

    private Task MarcarEntrevista() =>
        // Simulação de uma requisição para marcar uma entrevista
        Task.CompletedTask;

    private Task<string> MakeResponse(string modelName) =>
        // Simulação de uma requisição à OpenAI com base no modelo
        Task.FromResult($"Resposta do OpenAI para o modelo {modelName}");
}