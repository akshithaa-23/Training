import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ProductData {
  private http=inject(HttpClient);
  getProducts(){
    return this.http.get('http://localhost:3000/products');
  }
  getProductById(id:number){
    return this.http.get(`http://localhost:3000/products/${id}`);
  }
  postProduct(products:any){
    return this.http.post<any>('http://localhost:3000/products',products);
  }
   UpdateProduct(id:number,products:any){
    return this.http.put<any>(`http://localhost:3000/products/${id}`,products);
  }
  deleteProductById(id:number){
    return this.http.delete(`http://localhost:3000/products/${id}`);
  }

}
