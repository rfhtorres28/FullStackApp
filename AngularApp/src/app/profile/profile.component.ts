import { Component, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common'; // these provides ngStyle, ngIf, and nfor directives
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

interface ProductSale {
   column1: string;
   asin: string;
   product_title: string;
   product_price: number;
   product_original_price: number;
   currency: string;
   product_star_rating: number;
   product_num_ratings: number;
   product_url: string;
   product_photo: string;
   product_num_offers: number;
   product_minimum_offer_price: number;
   is_amazon_choice: boolean;
   is_prime: boolean;
   climate_pledge_friendly: boolean;
   sales_volume: number;
   delivery: string;
   has_variations: boolean;
   product_availability: boolean;
   unit_price: number;
   unit_count: number;
 }

@Component({ selector: 'app-profile', standalone: true, imports: [CommonModule, ReactiveFormsModule], templateUrl: './profile.component.html', styleUrls: ['./profile.component.css'] })
export class ProfileComponent{
   
   currency_width = '50px';
   product_price = '80px';
   product_original_price_width = '120px';
   product_title = '80px';
   product_num_rating_width = '120px';
   product_star_rating_width = '110px';
   product_url_width = '80px';
   product_num_offers_width = '130px';
   product_min_offer_price_width = '160px';
   climate_pledge_friendly_width = '130px';
   column_width = '50px';
   asin_width = '10px'; 
   product_photo_width = '90px';
   is_best_sellers_width = '80px';
   is_amazon_choice_width = '110px';
   is_prime_width = '60px';
   sales_volume_width = '80px';
   delivery_width = '60px';
   has_variations_width = '80px';
   product_availability_width = '110px';
   unit_price_width = '70px';
   unit_count_width = '70px';

   productsales: ProductSale[] = [];
   
   constructor(private http: HttpClient) {}


   httpRequest(): Observable<HttpResponse<any>> {
        return this.http.get<string[]>("http://localhost:5223/api/amazon-products/amazon-query", {observe: 'response'}); 
   }


   onSubmit() {
      // in HttpResponse<T>, T here is the data structure type of the body of the Http response from the backend server
      this.httpRequest().subscribe((response: HttpResponse<ProductSale[]>)=>{
         console.log(response);
         // check if the response.body is present and an array type
         if(response.body && Array.isArray(response.body)) {

            const product_sales = response.body;
            for (let i=0; i<10; i++) {
               const row = product_sales[i];

               this.productsales.push({
                  column1: row.column1,
                  asin: row.asin,
                  product_title: row.product_title,
                  product_price: row.product_price,
                  product_original_price: row.product_original_price,
                  currency: row.currency,
                  product_star_rating: row.product_star_rating,
                  product_num_ratings: row.product_num_ratings,
                  product_url: row.product_url,
                  product_photo: row.product_photo,
                  product_num_offers: row.product_num_offers,
                  product_minimum_offer_price: row.product_minimum_offer_price,
                  is_amazon_choice: row.is_amazon_choice,
                  is_prime: row.is_prime,
                  climate_pledge_friendly: row.climate_pledge_friendly,
                  sales_volume: row.sales_volume,
                  delivery: row.delivery,
                  has_variations: row.has_variations,
                  product_availability: row.product_availability,
                  unit_price: row.unit_price,
                  unit_count: row.unit_count,
                })
               
               
            }
            console.log(this.productsales);
         }
         else {
            this.productsales = [];
         }
         

      }, 
      (error: HttpErrorResponse)=>{
         console.error(error);
      })
   }



   

  
   
}
