import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {

  productForm: FormGroup;
  isEdit: boolean = false;
  productId: string = "";

  constructor(private fb: FormBuilder, private productService: ProductService, private router: Router, private route: ActivatedRoute) {
    this.productForm = this.fb.group({
      name: new FormControl(''),
      quanity: new FormControl(0),
      price: new FormControl(0.0),
      description: new FormControl(''),
      file: new FormControl(''),
      fileSource: new FormControl('')
    });
  }

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['id'];
    this.isEdit = this.productId != null;

    if (this.isEdit) {
      this.productService.getProductById(this.productId).subscribe(product =>
      {
        this.productForm.patchValue({
          name: product.name,
          quanity: product.quantity,
          price: product.price,
          description: product.description
        });
      });
    }
  }

  createProduct() {
    const formData = new FormData();

    formData.append('image', this.productForm.get('fileSource')?.value);
    formData.append('name', this.productForm.get('name')?.value);
    formData.append('description', this.productForm.get('name')?.value);
    formData.append('quanity', this.productForm.get('quanity')?.value);
    formData.append('Price', this.productForm.get('price')?.value);

    if (!this.isEdit) {
      this.productService.createProduct(formData).subscribe(res => {
        alert('Created Successfully.');
        this.router.navigate(['/']);
      });
    }
    else {

      formData.append('Id', this.productId);

      this.productService.updateProduct(formData).subscribe(res => {
        alert('Updated Successfully.');
        this.router.navigate(['/']);
      });
    }

    
  }

  onFileChange(event: any) {

    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.productForm.patchValue({
        fileSource: file
      });
    }
  }

}
