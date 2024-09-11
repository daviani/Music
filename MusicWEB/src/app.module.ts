import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { routes } from './app/app.routes';
import { ApiService } from './app/api/api.service';
import { AppComponent } from './app/app.component';

@NgModule({
  declarations: [],
  imports: [BrowserModule, HttpClientModule, RouterModule.forRoot(routes)],
  providers: [ApiService],
  bootstrap: [AppComponent] 
})
export class AppModule {}
