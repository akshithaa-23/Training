import { Component, OnInit } from '@angular/core';
import { ProductData } from '../../services/product-data';
import { Observable, BehaviorSubject, switchMap } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-products',
 imports: [FormsModule, CommonModule],
  templateUrl: './products.html',
  styleUrl: './products.css',
})
export class Products implements OnInit{

      private refresh$ = new BehaviorSubject<void>(undefined);

  products$!: Observable<any[]>;
  singleProduct$!: Observable<any>;

  product: any = this.getEmptyProduct();
  isEdit = false;
  editProductId: number | null = null;

  
  constructor(private productService: ProductData) {}

  ngOnInit(): void {
    this.products$ = this.refresh$.pipe(
      switchMap(() => this.productService.getProducts() as Observable<any[]>)
    );
  }

  // ===== QUICK LOOK =====
  showQuickProduct(id: number) {
    this.singleProduct$ = this.productService.getProductById(id);
  }

  // ===== ADD / UPDATE =====
  addProduct() {
    if (this.isEdit && this.editProductId !== null) {
      this.productService.UpdateProduct(this.editProductId, this.product).subscribe(() => {
        this.afterSave();
      });
    } else {
      const tempProduct = { ...this.product };

      this.afterSave(); // fast UI update

      this.productService.postProduct(tempProduct).subscribe(() => {
        this.refresh$.next();
      });
    }
  }

  // ===== EDIT =====
  editProduct(p: any) {
    this.product = { ...p };
    this.editProductId = p.id;
    this.isEdit = true;
  }

  // ===== DELETE =====
  deleteProduct(id: number) {
    if (!confirm('Are you sure you want to delete this product?')) return;

    // refresh UI immediately
    this.refresh$.next();

    this.productService.deleteProductById(id).subscribe(() => {
      this.singleProduct$ = undefined as any;
    });
  }

  // ===== RESET =====
  resetForm() {
    this.product = this.getEmptyProduct();
    this.isEdit = false;
    this.editProductId = null;
  }

  private afterSave() {
    this.refresh$.next();
    this.resetForm();
  }

  private getEmptyProduct() {
    return {
      name: '',
      brand: '',
      price: null,
      category: '',
      stock: null,
      rating: null
    };
  }
}


