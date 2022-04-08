﻿using BlazorTrails.Shared.Features.ManageTrails;
using FluentValidation;
using MediatR;

namespace BlazorTrails.Client.Features.ManageTrails
{
    public record AddTrailRequest(TrailDto Trail) : IRequest<AddTrailRequest.Response>
    {
        public const string RouteTemplate = "/api/trails";
        public record Response(int TrailId);
    }
    public class AddTrailRequestValidator : AbstractValidator<AddTrailRequest>
    {
        public AddTrailRequestValidator()
        {
            RuleFor(x => x.Trail).SetValidator(new TrailValidator());
        }
    }
}
