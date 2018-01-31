import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'addproduct',
    templateUrl: './addproduct.component.html'
})



export class AddProductComponent {

    private http: Http;
    private baseUrl: string;
    public responseStatus: string | null;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    onSubmit(form: NgForm) {
        let product: Product =
        {
                name: form.value.name,
                price: form.value.price
        };

        this.http.post(this.baseUrl + 'api/product/addproduct', product).subscribe(
            result => this.responseStatus = result.statusText,
            error => this.responseStatus = error.statusText);
    }
}

interface Product {
    name: string;
    price: number;
}
