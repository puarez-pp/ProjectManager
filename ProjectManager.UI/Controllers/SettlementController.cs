using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Commands.AddSettlement;
using ProjectManager.Application.Settlements.Commands.DeleteInvoice;
using ProjectManager.Application.Settlements.Commands.DeleteWorkScopeCost;
using ProjectManager.Application.Settlements.Commands.EditSettlement;
using ProjectManager.Application.Settlements.Queries.GetAddInvoice;
using ProjectManager.Application.Settlements.Queries.GetAddWorkScopeCost;
using ProjectManager.Application.Settlements.Queries.GetAddWorkScopeOffer;
using ProjectManager.Application.Settlements.Queries.GetAssumptions;
using ProjectManager.Application.Settlements.Queries.GetCostDetails;
using ProjectManager.Application.Settlements.Queries.GetCostSummary;
using ProjectManager.Application.Settlements.Queries.GetEditInvoice;
using ProjectManager.Application.Settlements.Queries.GetEditSettlement;
using ProjectManager.Application.Settlements.Queries.GetEditWorkScopeCost;
using ProjectManager.Application.Settlements.Queries.GetEditWorkScopeOffer;
using ProjectManager.Application.Settlements.Queries.GetFinancialControl;
using ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;
using ProjectManager.Domain.Enums;

namespace ProjectManager.UI.Controllers
{
    public class SettlementController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<SettlementController> _logger;
        public SettlementController(IDateTimeService dateTimeService,
            ILogger<SettlementController> logger)
        {
            _dateTimeService = dateTimeService;
            _logger = logger;
        }

 
        public async Task<IActionResult> Assumption(int id)
        {
            return View(await Mediator.Send(new GetAssumptionsQuery { Id = id }));
        }

        public async Task<IActionResult> Offers(int id, WorkScopeType st)
        {
            return View(await Mediator.Send(new GetScopeTypeOfferQuery { Id = id, ScopeType = st}));
        }

        public async Task<IActionResult> FinControl(int id)
        {
            return View(await Mediator.Send(new GetFinancialControlQuery { Id = id}));
        }

        public async Task<IActionResult> CostsDetails(int id)
        {
            return View(await Mediator.Send(new GetCostDetailsQuery { Id = id }));
        }

        public async Task<IActionResult> CostsSummary(int id)
        {
            return View(await Mediator.Send(new GetCostSummaryQuery { Id = id }));
        }

        public async Task<IActionResult> AddSettlement(int id)
        {
            return View(new AddSettlementCommand());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSettlement(AddSettlementCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Dane zostały dodane.";

            return RedirectToAction("Assumption",new { @id = command.Id });
        }

        public async Task<IActionResult> EditSettlement(int id)
        {
            return View(await Mediator.Send(new GetEditSettlementQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSettlement(EditSettlementCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Dane zostały zaktualizowane.";

            return RedirectToAction("Assumption", new { @id = command.Id });
        }


        public async Task<IActionResult> AddCost(int id)
        {
            return View(await Mediator.Send(new GetAddWorkScopeCostQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCost(AddWorkScopeCostVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.ScopeCost);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane zostały zaktualizowane.";

            return RedirectToAction("Costs", new { @id = viewModel.SettlementId });
        }

        public async Task<IActionResult> EditCost(int id)
        {
            return View(await Mediator.Send(new GetEditWorkScopeCostQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCost(EditWorkScopeCostVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.ScopeCost);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane zostały zaktualizowane.";

            return RedirectToAction("Costs", new { @id = viewModel.SettlementId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCost(int id)
        {
            try
            {
                await Mediator.Send(
                    new DeleteWorkScopeCostCommand
                    {
                        Id = id
                    });

                return Json(new { success = true });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, null);
                return Json(new { success = false });
            }
        }

        public async Task<IActionResult> AddOffer(int id)
        {
            return View(await Mediator.Send(new GetAddWorkScopeOfferQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOffer(AddWorkScopeOfferVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.ScopeOffer);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane zostały zaktualizowane.";

            return RedirectToAction("Offers", new { @id = viewModel.SettlementId, @st = viewModel.ScopeType});
        }

        public async Task<IActionResult> EditOffer(int id)
        {
            return View(await Mediator.Send(new GetEditWorkScopeOfferQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOffer(EditWorkScopeOfferVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.ScopeOffer);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane zostały zaktualizowane.";

            return RedirectToAction("Offers", new { @id = viewModel.SettlementId, @st = viewModel.ScopeType });
        }

        public async Task<IActionResult> Invoices(int id)
        {
            return View(await Mediator.Send(new GetFinancialControlQuery { Id = id }));
        }

        public async Task<IActionResult> AddInvoice(int id)
        {
            return View(await Mediator.Send(new GetAddInvoiceQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInvoice(AddInvoiceVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.Invoice);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane zostały zaktualizowane.";

            return RedirectToAction("Invoices", new { @id = viewModel.SettlementId});
        }

        public async Task<IActionResult> EditInvoice(int id)
        {
            return View(await Mediator.Send(new GetEditInvoiceQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInvoice(EditInvoiceVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.Invoice);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane zostały zaktualizowane.";

            return RedirectToAction("Invoices", new { @id = viewModel.SettlementId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            try
            {
                await Mediator.Send(
                    new DeleteInvoiceQuery
                    {
                        Id = id
                    });
                return Json(new { success = true });
            }
            catch (Exception exception)
            {

                _logger.LogError(exception, null);
                return Json(new { success = false });
            }
        }

    }
}
