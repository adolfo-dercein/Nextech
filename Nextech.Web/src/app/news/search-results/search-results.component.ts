import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemDTO } from 'src/api/model/item-dto';
import { ItemService } from 'src/api/service/item-service';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss']
})
export class SearchResultsComponent 
{
  searchParameter!: string;

  pageNumber: number = 1;
  pageSize: number = 10;
  total!: number;
  news!: ItemDTO[];

  loading: boolean = true;

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private itemService: ItemService) { }

  ngOnInit() 
  {
    this.searchParameter = this.route.snapshot.queryParamMap.get('searchParameter') || '';
    if(this.searchParameter)
    {
      this.loadNews();
    }
    else
    {
      this.router.navigate(['/news']);
    }
  }

  loadNews()
  {
    this.itemService.getSearchItemList(this.searchParameter.trim()).subscribe(result => 
    {
      if(result)
      {
        this.news = result.items;
        this.pageNumber = result.pageNumber;
        this.pageSize = result.pageSize;
        this.total = result.total;

        this.loading = false;
      }
    });
  }

  onChangePage(event: any)
  {
    this.pageNumber = event;
    this.loadNews();
  }
}
