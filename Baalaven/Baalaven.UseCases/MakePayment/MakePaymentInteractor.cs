using Baalaven.Entities.Exceptions;
using Baalaven.Entities.Interfaces;
using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using Baalaven.UseCases.Common.Validators;
using Baalaven.UseCasesDTOs.MakePayment;
using Baalaven.UseCasesPorts.MakePayment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.UseCases.MakePayment
{
    public class MakePaymentInteractor : IMakePaymentInputPort
    {
        //readonly IOrderRepository OrderRepository;
        //readonly IOrderDetailRepository OrderDetailRepository;
        readonly IPaymentRepository PaymentRepository;
        readonly IPaymentDetailRepository PaymentDetailRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IMakePaymentOutputPort OutputPort;
        readonly IEnumerable<IValidator<MakePaymentParams>> Validators;

        public MakePaymentInteractor(IPaymentRepository paymentRepository,
            IPaymentDetailRepository paymentDetailRepository,
            IUnitOfWork unitOfWork,
            IMakePaymentOutputPort outputPort,
            IEnumerable<IValidator<MakePaymentParams>> validators) =>
            (PaymentRepository, PaymentDetailRepository, UnitOfWork, OutputPort, Validators) =
            (paymentRepository, paymentDetailRepository, unitOfWork, outputPort, validators);


        public async Task Handle(MakePaymentParams payment)
        {
            await Validator<MakePaymentParams>.Validate(payment, Validators);

            

            Payments Payments = new Payments
            {
                OrderId = payment.OrderId,
                PaymentStatus = Entities.Enums.PaymentStatus.Paid
            };
            PaymentRepository.Create(Payments);

            foreach (var Item in payment.PaymentDetails)
            {
                PaymentDetailRepository.Create(
                    new PaymentDetails
                    {
                        Payments = Payments,
                        IdPaymentCard = Item.IdPaymentCard,
                        PaidAmount = Item.PaidAmount,
                        PaymentDate = DateTime.Now,
                        PaymentType = Item.PaymentType,
                    });
            }

            //output
            var output = new MakePaymentOutputPort();
            output.Payments = new List<MakePayments>();

            var expressionPaymentDetail = new Specification<PaymentDetails>(od => od.Payments.OrderId == Payments.OrderId);
            var paymentDetail = PaymentDetailRepository.GetPaymentDetailsByEspecification(expressionPaymentDetail).ToList();
            var paymentsId = paymentDetail.Select(p => p.Payments.Id).ToList();

            foreach (var id in paymentsId)
            {
                var payments = paymentDetail
                    .Where(s => s.Payments.Id == id)
                    .Select(s => new MakePayments(
                        s.Payments.Id,
                        s.Payments.OrderId,
                        s.Payments.AmountPayable,
                        s.Payments.PaymentStatus.ToString()
                        ))
                    .FirstOrDefault();
                var detail = paymentDetail
                    .Where(p => p.Payments.Id == id)
                    .Select(s => new MakePaymentDetails(
                        s.IdPaymentCard,
                        s.PaidAmount,
                        s.PaymentDate,
                        s.PaymentType
                        ))
                    .ToList();
                payments.SetPaymentDetails(detail);
                output.Payments.Add(payments);
            }
            try
            {
                await UnitOfWork.SaveChangesAsync();

                //var expressionPaymentDetail = new Specification<PaymentDetails>(pd => pd.Payments.Id.ToString() == payment.);

            }
            catch(Exception ex)
            {
                throw new GeneralException("Error al realizar el pago.", ex.Message);
            }
            
            await OutputPort.Handle(output);
            
        }
    }
}
