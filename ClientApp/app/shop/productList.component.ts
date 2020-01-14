import { Component, OnInit } from "@angular/core";
import { DataService } from '../shared/dataService';
import { Product } from '../shared/product';

@Component({
  selector: "product-list",
  templateUrl: "productList.component.html",
  styleUrls: [ "productList.component.css" ]
})
export class ProductList {

  constructor(private data: DataService) {

  }

  public products: Product[] = [];

  ngOnInit(): void {
    this.data.loadProducts()
      .subscribe(success => {
        if (success) {
          this.products = this.data.products;
        }
      });
  }
}