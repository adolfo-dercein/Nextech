import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TopNewsComponent } from './news/top-news/top-news.component';
import { SearchResultsComponent } from './news/search-results/search-results.component';

const routes: Routes = 
[
  { path: '', component: TopNewsComponent },
  { path: 'news', component: TopNewsComponent },
  { path: 'search', component: SearchResultsComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
