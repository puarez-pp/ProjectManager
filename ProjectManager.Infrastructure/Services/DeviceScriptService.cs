using Microsoft.AspNetCore.Hosting;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.AddScript;
using System.Text;

namespace ProjectManager.Infrastructure.Services;

public class DeviceScriptService : IDeviceScriptService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ScriptTemplateRenderer _renderer;

    public DeviceScriptService(
        IWebHostEnvironment webHostEnvironment,
        ScriptTemplateRenderer renderer)
    {
        _webHostEnvironment = webHostEnvironment;
        _renderer = renderer;
    }
    public async Task<Domain.Entities.File> GenerateScriptAsync(DeviceSriptVm model)
    {
        
        var script = await _renderer.RenderAsync("/Views/Basic/Device/ScriptTemplates/DeviceScript.cshtml",model);
        var fileName = $"{model.DeviceName}_id_{model.DeviceId}.js";
        var folderRoot = Path.Combine(_webHostEnvironment.WebRootPath, "Content", "Files");

        if (!Directory.Exists(folderRoot))
            Directory.CreateDirectory(folderRoot);

        var filePath = Path.Combine(folderRoot, fileName);
        //zapis pliku
        await File.WriteAllTextAsync(filePath, script, Encoding.UTF8);


        var file = new Domain.Entities.File
        {
            Name = fileName,
            Description = $"Skrypt dla WINCC Unified urządzenia {model.DeviceName} o ID {model.DeviceId}",
            Bytes = Encoding.UTF8.GetByteCount(script),
        };
        return file;
    }
}
