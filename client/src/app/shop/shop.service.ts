import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { IBrand } from '../shared/models/brands';
import { IPagination, Pagination } from '../shared/models/pagination';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  private baseUrl = 'https://localhost:5001/api/';
  private products: IProduct[] = [];
  private brands: IBrand[] = [];
  private types: IType[] = [];
  private pagination = new Pagination();
  private shopParams = new ShopParams();
  private productCache = new Map();

  constructor(private http: HttpClient ) { }

  getProducts(useCache: boolean) {
    const key = Object.values(this.shopParams).join('-');
    if (this.productCache.size > 0 && useCache) {
      if (this.productCache.has(key)) {
        this.pagination.data = this.productCache.get(key);
        return of(this.pagination);
      }
    }
    if (!useCache) {
      this.productCache = new Map();
    }
    let params = new HttpParams();
    if (this.shopParams.brandId !== 0) {
      params = params.append('brandId', this.shopParams.brandId);
    }
    if (this.shopParams.typeId !== 0) {
      params = params.append('typeId', this.shopParams.typeId);
    }
    if (this.shopParams.search) {
      params = params.append('search', this.shopParams.search);
    }
    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.shopParams.pageNumber);
    params = params.append('pageSize', this.shopParams.pageSize);
    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params}).pipe(map(response => {
      this.productCache.set(key, response.body.data);
      this.pagination = response.body;
      return this.pagination;
    }));
  }

  setShopParams(params: ShopParams) {
    this.shopParams = params;
  }

  getShopParams() {
    return this.shopParams;
  }

  getProduct(id: number) {
    let product: IProduct;
    this.productCache.forEach((products: IProduct[]) => product = products.find(p => p.id == id));
    if (product) {
      return of(product);
    }
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }

  getBrands() {
    if (this.brands.length > 0) {
      return of(this.brands);
    }
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands').pipe(map(response => {
      this.brands = response;
      return response;
    }));
  }

  getTypes() {
    if (this.types.length > 0) {
      return of(this.types);
    }
    return this.http.get<IType[]>(this.baseUrl + 'products/types').pipe(map(response => {
      this.types = response;
      return response;
    }));
  }
}
