using System;
using System.Collections.Generic;
using Vitamedica.ProyectoAlam.Shared.Models;
using Vitamedica.ProyectoAlam.Shared.ModelsService;

namespace Vitamedica.ProyectoAlam.Shared.Controllers
{
    public abstract class ControllerBase : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public abstract List<ErrorMessage> ValidateOperationRequest<TOperationRequest, TModel>(TOperationRequest request) where TOperationRequest : OperationRequestBase<TModel>;

        public abstract List<ErrorMessage> ValidateFilterRequest<TFilterRequest, TFilterModel>(TFilterRequest request) where TFilterRequest : FilterRequestBase<TFilterModel>;

        public List<ErrorMessage> ValidateEmptyRequest<TOperationRequest, TObject>(TOperationRequest request) where TOperationRequest : EmptyRequest
        {
            List<ErrorMessage> errors = new List<ErrorMessage>();
            switch (request.TipoDato)
            {
                case TipoParametro.Int:
                    if (request.Param.GetType() != typeof(int))
                        errors.Add(new ErrorMessage { Description = "" });
                    else
                    {
                        if (!((int?)request.Param).HasValue)
                            errors.Add(new ErrorMessage { Description = "" });
                    }
                    break;
                case TipoParametro.DateTime:
                    if (request.Param.GetType() != typeof(DateTime))
                        errors.Add(new ErrorMessage { Description = "" });
                    else
                    {
                        if (!((DateTime?)request.Param).HasValue)
                            errors.Add(new ErrorMessage { Description = "" });
                    }
                    break;
                case TipoParametro.String:
                    if (request.Param.GetType() != typeof(string))
                        errors.Add(new ErrorMessage { Description = "" });
                    else
                    {
                        if (string.IsNullOrEmpty((string)request.Param))
                            errors.Add(new ErrorMessage { Description = "" });
                    }
                    break;
                case TipoParametro.Bool:
                    if (request.Param.GetType() != typeof(bool))
                        errors.Add(new ErrorMessage { Description = "" });
                    else
                    {
                        if (!((bool?)request.Param).HasValue)
                            errors.Add(new ErrorMessage { Description = "" });
                    }
                    break;
                case TipoParametro.Decimal:
                    if (request.Param.GetType() != typeof(decimal))
                        errors.Add(new ErrorMessage { Description = "" });
                    else
                    {
                        if (!((decimal?)request.Param).HasValue)
                            errors.Add(new ErrorMessage { Description = "" });
                    }
                    break;
                case TipoParametro.Double:
                    if (request.Param.GetType() != typeof(double))
                        errors.Add(new ErrorMessage { Description = "" });
                    else
                    {
                        if (!((double?)request.Param).HasValue)
                            errors.Add(new ErrorMessage { Description = "" });
                    }
                    break;
                case TipoParametro.Long:
                    if (request.Param.GetType() != typeof(long))
                        errors.Add(new ErrorMessage { Description = "" });
                    else
                    {
                        if (!((long?)request.Param).HasValue)
                            errors.Add(new ErrorMessage { Description = "" });
                    }
                    break;
            }

            return errors;
        }
    }
}