using ABP.Demo.Appointments;
using BookingSystem.Appointments;
using BookingSystem.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookingSystem.Data
{
    public class PaymentsDataSeeder : IDataSeedContributor
    {

        private readonly IRepository<Payment, int> _paymentRepository;

        public PaymentsDataSeeder(IRepository<Payment, int> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task SeedAsync(DataSeedContext context)
        {
            var payments = new List<Payment>
            {
                new Payment
                {
                    Amount = 150.00m,
                    PaymentMethod = PaymentMethod.CreditCard,
                    PaymentStatus = PaymentStatus.Paid,
                    PaymentDate = new DateTime(2025, 1, 20),
                    AppointmentId = 5
                },
                new Payment
                {
                    Amount = 200.00m,
                    PaymentMethod = PaymentMethod.Cash,
                    PaymentStatus = PaymentStatus.Pending,
                    PaymentDate = new DateTime(2025, 1, 21),
                    AppointmentId = 4
                },
                new Payment
                {
                    Amount = 300.00m,
                    PaymentMethod = PaymentMethod.CreditCard,
                    PaymentStatus = PaymentStatus.Paid,
                    PaymentDate = new DateTime(2025, 1, 22),
                    AppointmentId = 2
                },
                new Payment
                {
                    Amount = 100.00m,
                    PaymentMethod = PaymentMethod.Cash,
                    PaymentStatus = PaymentStatus.Pending,
                    PaymentDate = new DateTime(2025, 1, 23),
                    AppointmentId = 1
                },
                new Payment
                {
                    Amount = 250.00m,
                    PaymentMethod = PaymentMethod.CreditCard,
                    PaymentStatus = PaymentStatus.Paid,
                    PaymentDate = new DateTime(2025, 1, 24),
                    AppointmentId = 3
                }
            };

            return _paymentRepository.InsertManyAsync(payments);

        }
    }
}
