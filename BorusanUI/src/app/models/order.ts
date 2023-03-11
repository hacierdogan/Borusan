export interface Order {
    orderNo:string;
    outputAddress:string;
    arrivalAddress:string,
    quantity :number,
    quantityUnit :string,
    weight :number,
    weightUnit:string,
    materialCode :string,
    note :string,
    status:number
    statusStr:string
}
