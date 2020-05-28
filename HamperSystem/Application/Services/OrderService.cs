using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OrderHamper.Api.Application.Dto.OrderDto;

namespace OrderHamper.Api.Application.Services
{
    public class OrderService
    {
        public async Task<Order> GetOrderAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select o.[Id] as ordernumber,o.OrderDate as date, o.Description as description,
                        o.Address_City as city, o.Address_Country as country, o.Address_State as state, o.Address_Street as street, o.Address_ZipCode as zipcode,
                        os.Name as status, 
                        oi.ProductName as productname, oi.Units as units, oi.UnitPrice as unitprice, oi.PictureUrl as pictureurl
                        FROM ordering.Orders o
                        LEFT JOIN ordering.Orderitems oi ON o.Id = oi.orderid 
                        LEFT JOIN ordering.orderstatus os on o.OrderStatusId = os.Id
                        WHERE o.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapOrderItems(result);
            }
        }

        private Order MapOrderItems(dynamic result)
        {
            var order = new Order
            {
                Ordernumber = result[0].ordernumber,
                Date = result[0].date,
                Status = result[0].status,
                Description = result[0].description,
                Street = result[0].street,
                City = result[0].city,
                Zipcode = result[0].zipcode,
                Country = result[0].country,
                Orderitems = new List<Orderitem>(),
                Total = 0
            };

            foreach (dynamic item in result)
            {
                var orderitem = new Orderitem
                {
                    Productname = item.productname,
                    Units = item.units                    
                };

                order.Total += item.units;
                order.Orderitems.Add(orderitem);
            }

            return order;
        }
    }
}
