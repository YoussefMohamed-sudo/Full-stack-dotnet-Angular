import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'http://localhost:5192/api/products'; // ✅ عدّل المنفذ حسب API بتاعك

  constructor(private http: HttpClient) {}

  // 🟢 دالة تجيب كل المنتجات
  getAll(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  // (اختياري) دالة تجيب منتج واحد بالـ id
  getById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  // (اختياري) دالة لإضافة منتج جديد
  create(product: any): Observable<any> {
    return this.http.post(this.apiUrl, product);
  }

  // (اختياري) دالة لتحديث منتج
  update(id: number, product: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, product);
  }

  // (اختياري) دالة لحذف منتج
  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
