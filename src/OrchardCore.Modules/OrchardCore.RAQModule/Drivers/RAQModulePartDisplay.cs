using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.RAQModule.Models;
using OrchardCore.RAQModule.ViewModels;

namespace OrchardCore.RAQModule.Drivers
{
    public class RAQModulePartDisplay : ContentPartDisplayDriver<RAQModulePart>
    {
        public override IDisplayResult Display(RAQModulePart part)
        {
            //return View("RAQModulePart", part).Location("Detail", "Content");
            return Initialize<RAQModulePart>("RAQModulePart", model =>
            {
                model.ButtonTitle = part.ButtonTitle;
                model.EmailAddress= part.EmailAddress;
                model.Price = part.Price;
                model.IternaryName = part.IternaryName;
                model.Cc = part.Cc;
                model.Bcc = part.Bcc;
            })
            .Location("Detail", "Header:5")
            .Location("Summary", "Header:5");
        }

        public override IDisplayResult Edit(RAQModulePart part)
        {
            return Initialize<RAQModulePartEditViewModel>("RAQModulePart_Fields_Edit", m =>
            {
                m.EmailAddress = part.EmailAddress;
                m.Price= part.Price;
                m.ButtonTitle= part.ButtonTitle;
                m.IternaryName= part.IternaryName;
                m.Cc= part.Cc;
                m.Bcc= part.Bcc;
            });
        }

        public async override Task<IDisplayResult> UpdateAsync(RAQModulePart part, IUpdateModel updater)
        {
            var viewModel = new RAQModulePartEditViewModel();

            if (await updater.TryUpdateModelAsync(viewModel, Prefix))
            {
                part.EmailAddress = viewModel.EmailAddress?.Trim();
                part.Price = viewModel.Price?.Trim();
                part.ButtonTitle = viewModel.ButtonTitle?.Trim();
                part.IternaryName = viewModel.IternaryName?.Trim();
                part.Cc = viewModel.Cc?.Trim();
                part.Bcc = viewModel.Bcc?.Trim();
            }
            return Edit(part);
        }
    }
}
