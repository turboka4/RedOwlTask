import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'getproduct',
    templateUrl: './getproduct.component.html'
})
export class GetProductComponent {
    public products: Product[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/product/getproducts').subscribe(result => {
            this.products = result.json() as Product[];
        }, error => console.error(error));
    }
}

interface Product {
    Name: string;
    Price: number;
}
