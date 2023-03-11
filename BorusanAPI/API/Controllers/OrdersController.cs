using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        protected IOrderService _orderService;
        protected IMaterialService _materialService;
        public OrdersController(
            IOrderService orderService,
            IMaterialService materialService)
        {
            _orderService = orderService;
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var orderList = await _orderService.TGetAll();
                if (orderList != null)
                {
                    var resultList = from order in orderList
                                     select new
                                     {
                                         Selected = false,
                                         Id = order.Id,//sistem sipariş no
                                         OrderNo = order.OrderNo,
                                         OutputAddress = order.OutputAddress,
                                         ArrivalAddress = order.ArrivalAddress,
                                         Quantity = order.Quantity,
                                         QuantityUnit = order.QuantityUnit,
                                         Weight = order.Weight,
                                         WeightUnit = order.WeightUnit,
                                         MaterialCode = order.MaterialCode,
                                         //MaterialName = order.MaterialName,
                                         Note = order.Note,
                                         //CreateDate = order.CreateDate,
                                         //EditDate = order.EditDate,
                                         StatusStr ="onaylandı",
                                         //StatusId = order.StatusId,
                                     };

                    return Ok(orderList);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                //await _logService.TCreate("GetAllOrder",ex.Message.ToString()); //db için log yapısı oluşturulacak
                throw;
            }

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var order = await _orderService.TGetById(id);

                if (order != null)
                    return Ok(order);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Order> orderList)
        {
            try
            {
                Order createOrder = new Order();
                foreach (Order order in orderList)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    else
                    {

                        if (await _orderService.GetOrderByOrderNo(order.OrderNo) != null)
                        {
                            //siparis kodu önceden eklenmis ise
                            return BadRequest("Girilen müşteri sipariş numarası daha önceden eklenmiş.");
                        }
                        else
                        {
                            Material material = await _materialService.GetMaterialByMaterialCode(order.MaterialCode);
                            if (material != null)
                            {
                                //malzeme kodu önceden eklenmis ise
                                order.MaterialId = material.Id;
                            }
                            else
                            {
                                //malzeme kodu ilk defa ekleniyor ise
                                material = new Material()
                                {
                                    MetarialCode = order.MaterialCode,
                                    MetarialName = order.MaterialName
                                };
                                var createMaterial = await _materialService.TCreate(material);
                                order.MaterialId = createMaterial.Id;
                            }
                        }
                        order.StatusId = 1; // 1 = Sipariş Alındı
                        createOrder = await _orderService.TCreate(order);

                    }
                }
                return CreatedAtAction("Get", new { id = createOrder.Id }, createOrder);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    Order dbOrder = await _orderService.TGetById(order.Id);
                    if (dbOrder != null)
                    {
                        dbOrder.StatusId = order.StatusId;
                        dbOrder.EditDate = DateTime.Now;
                        return Ok(await _orderService.TUpdate(dbOrder));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
