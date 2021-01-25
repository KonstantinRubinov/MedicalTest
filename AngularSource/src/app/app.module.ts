import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ImageCropperModule } from 'ngx-image-cropper';
import { CookieService } from 'ngx-cookie-service';

import { Store } from './redux/store';
import { NgReduxModule, NgRedux } from 'ng2-redux';
import { Reducer } from './redux/reducer';

import { LayoutComponent } from './components/design-elements/layout/layout.component';
import { HeaderComponent } from './components/design-elements/header/header.component';
import { FooterComponent } from './components/design-elements/footer/footer.component';
import { AppRoutingModule } from './modules/app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { WorkplaceComponent } from './components/data-elements/workplace/workplace.component';

@NgModule({
  declarations: [
    LayoutComponent,
    HeaderComponent,
    FooterComponent,
    WorkplaceComponent
  ],
  imports: [
    BrowserModule,
    NgReduxModule,
    HttpClientModule,
    ImageCropperModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    CommonModule
  ],
  providers: [CookieService ],
  bootstrap: [LayoutComponent]
})
export class AppModule { 
  public constructor(redux:NgRedux<Store>){
    redux.configureStore(Reducer.reduce, new Store());
  }
}