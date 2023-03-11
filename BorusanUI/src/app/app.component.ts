import { Component, OnInit } from '@angular/core';
import { OrderService } from './service/order.service';
import { Order } from './models/order';
import { Status } from './models/status';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  constructor(private orderService: OrderService) {}
  
  statuList :Status[]=[];// statu listesi
  orderList :Order[]=[];// order listesi
  selectedOrders :Order[]=[];//seçilenler listesi

  title = 'BorusanUI';

  //apiden gelen statu listesi
  public getOrderStatuList() {
    this.orderService.getOrderStatus().subscribe(data =>{
      this.statuList = data;
    });
  }

  //apiden gelen sipariş listesi
  public getOrderList() {
    this.orderService.getOrders().subscribe(data =>{
      this.orderList = data;
    });
  }

  //sipariş seçim işlemleri 
  onCheckboxChange(e:any,orderno:string) {
    if (e.target.checked){
      alert(orderno +' numaralı sipariş seçildi.');
      var index=this.orderList.findIndex(x => x.orderNo === orderno);
      this.selectedOrders.push(this.orderList[index]);
    }
    else{
      alert(orderno +' numaralı sipariş seçimi kaldırıldı.');
      const index = this.orderList.findIndex(x => x.orderNo === orderno);
      this.selectedOrders.splice(index, 1);
    }
  }
  
  //modaldan gelen seçimi seçilen siparişlerin durumuna uygula
  editOrder(statusId:any){
    this.selectedOrders.forEach(function (value) {
      value.status=statusId;//seçilen siparişlerin durumunu güncelle
    }); 
    this.updateOrder();//Güncel listeyi Api'ye gönder
  }
 
  
  //apiye gidecek olan listeyi servise gönder
  public updateOrder() {
    this.orderService.updateOrder(this.selectedOrders)
    .subscribe(
      (res)=>{
        alert("Güncelleme işlemi tamamlandı.");
      },
      (err)=>{
        console.warn(err);
        alert("Güncelleme işlemi sırasında hata oluştu: "+err.val);
      }
    );
  }
  
  ngOnInit(){
    this.getOrderList();//apiden siparişleri oku
    this.getOrderStatuList();
    this.title=this.orderService.api_title;
  }
}
