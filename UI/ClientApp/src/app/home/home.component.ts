import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from '../models/product.model';
import { AuthService } from '../services/auth-service.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public products: Product[] = [];

  userName: FormControl = new FormControl('');
  password: FormControl = new FormControl('');

  constructor(public authService: AuthService, private productService: ProductService, private router: Router) {
    this.getProducts();
  }

  loginUser(){
    this.authService.login({ userName: this.userName.value, password: this.password.value }).subscribe(_ => this.router.navigate(['/']));
  }

  OnDelete(productId: string)
  {
    if (confirm("Are you sure you want to Delete ?") == true) {

      this.productService.deleteProducts(productId).subscribe(_ => this.getProducts());

    } 
  }

  OnEdit(productId: string)
  {
    this.router.navigate(["/edit-product", productId]);
  }

  getProducts() {
    this.productService.getProducts().subscribe(products => this.products = products);
  }

}
