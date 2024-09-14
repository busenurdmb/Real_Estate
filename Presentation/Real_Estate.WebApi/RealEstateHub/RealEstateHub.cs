using MediatR;
using Microsoft.AspNetCore.SignalR;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetList;

namespace Real_Estate.WebApi.RealEstateHub
{
	public class RealEstateHub:Hub
	{
		private readonly IMediator _mediator;
		private readonly IHttpClientFactory _httpClientFactory;

		public RealEstateHub(IHttpClientFactory httpClientFactory, IMediator mediator)
		{
			_httpClientFactory = httpClientFactory;
			_mediator = mediator;
		}

		public async Task SendProperty()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7028/api/Property/CountApprova");
			var value = await responseMessage.Content.ReadAsStringAsync();
			await Clients.All.SendAsync("ReceivePropertyCount", value);

			//       var client2 = _httpClientFactory.CreateClient();
			//var responseMessage2 = await client2.GetAsync("https://localhost:7028/api/Property/PropertyApproveList");
			//var value2 = await responseMessage2.Content.ReadAsStringAsync();
			var values = await _mediator.Send(new GetListPendingApprovePropertyQuery());
			await Clients.All.SendAsync("ReceivePropertyList", values);
		}

	
	}
}
