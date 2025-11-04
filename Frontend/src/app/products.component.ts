import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule], // ✅ أضف دي
  template: `
    <h2>Products</h2>
    <ul>
      <li *ngFor="let p of products">{{ p.name }} - {{ p.price }} EGP</li>
    </ul>
  `
})
export class ProductsComponent implements OnInit {
  products: any[] = [];

  constructor(private productService: ProductService) {}

ngOnInit(): void {
  this.productService.getAll().subscribe({
    next: (res) => {
      console.log('API response:', res); // 👈 دي مفيدة علشان تشوف شكل البيانات في الكونسول

      // ✅ تأكد إنك بتتعامل مع المصفوفة فقط
      if (res && (res as any).data && Array.isArray((res as any).data)) {
        this.products = (res as any).data;
      } else if (Array.isArray(res)) {
        this.products = res;
      } else {
        this.products = []; // fallback
      }
    },
  
  });
}
}
