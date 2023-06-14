import { HttpClient, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  URL = "https://localhost:44377/api/Products";

  constructor(private httpClient: HttpClient) { }

  createProduct(formData: FormData) : Observable<any>{

    return this.httpClient.post(this.URL, formData);
  }

  getProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.URL);
  }

  deleteProducts(Id: string): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.URL}?productId=${Id}`);
  }

  getProductById(productId: string): Observable<Product> {
    return this.httpClient.get<Product>(`${this.URL}/${productId}`);
  }

  updateProduct(formData: FormData): Observable<any> {
    return this.httpClient.put(this.URL, formData);
  }
}
