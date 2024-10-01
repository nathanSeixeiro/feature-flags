using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.Extensions.Options;
using pocFlags;

[ApiController]
[Route("api/[controller]")]
public class ModelosController : ControllerBase
{
    private readonly IFeatureManager _featureManager;
    private readonly FeatureFlagsSettings _featureFlagsSettings;

    public ModelosController(IFeatureManager featureManager, IOptions<FeatureFlagsSettings> featureFlagsSettings)
    {
        _featureManager = featureManager;
        _featureFlagsSettings = featureFlagsSettings.Value; // Carrega as configurações de ModelFeatures
    }

    [HttpGet("{modelName}")]
    public async Task<IActionResult> GetModeloInfo(string modelName)
    {
        // Verifica se o modelo tem features associadas
        bool isFeatureEnabled = false;

        if (_featureFlagsSettings.ModelFeatures.TryGetValue(modelName, out var features))
        {
            // Verifica se a feature "MarcarEntrevista" está associada ao modelo
            isFeatureEnabled = features.Contains("MarcarEntrevista");
        }

        // Retorna a resposta com a informação se a feature está habilitada
        var response = new
        {
            ModelName = modelName,
            MarcarEntrevista = isFeatureEnabled
        };

        return Ok(response);
    }
}
