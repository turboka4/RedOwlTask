import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { GetProductComponent } from './components/getproduct/getproduct.component';
import { AddProductComponent } from './components/addproduct/addproduct.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        AddProductComponent,
        GetProductComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'addproduct', component: AddProductComponent },
            { path: 'getproduct', component: GetProductComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
