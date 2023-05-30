import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopNewsComponent } from './news/top-news/top-news.component';
import { NewsCardComponent } from './components/news-card/news-card.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { SearchResultsComponent } from './news/search-results/search-results.component';
import { LoadingComponent } from './components/loading/loading.component';
import { ToastContainerComponent } from './components/toast-container/toast-container.component';


@NgModule({
  declarations: [
    AppComponent,
    TopNewsComponent,
    NewsCardComponent,
    SearchResultsComponent,
    LoadingComponent,
    ToastContainerComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
