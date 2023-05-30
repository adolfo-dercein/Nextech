import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastService } from 'src/shared/services/toast-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent 
{
  searchTerm!: string;

  constructor(
    private router: Router,
    public toastService: ToastService) { }

  onSearch()
  {
    if(!this.searchTerm || this.searchTerm.trim() == '')
    {
		  this.toastService.show('Search Term cannot be empty.');
    }
    else
    {
      this.router.navigate(
        ['/search'],
        { queryParams: { searchParameter: this.searchTerm } }
      );
    }
  }
}
