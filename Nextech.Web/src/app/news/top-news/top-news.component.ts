import { Component, OnInit } from '@angular/core';
import { ItemDTO } from 'src/api/model/item-dto';
import { ItemService } from 'src/api/service/item-service';

@Component({
  selector: 'app-top-news',
  templateUrl: './top-news.component.html',
  styleUrls: ['./top-news.component.scss']
})
export class TopNewsComponent implements OnInit 
{
  constructor(private itemService: ItemService) { }

  pageNumber: number = 1;
  pageSize: number = 10;
  total!: number;
  news!: ItemDTO[];

  loading: boolean = true;

  ngOnInit(): void 
  {
    this.loadNews();
  }

  loadNews()
  {
    this.itemService.getItemList(this.pageNumber, this.pageSize).subscribe(result => 
    {
      if(result)
      {
        this.news = result.items;
        this.pageNumber = result.pageNumber;
        this.pageSize = result.pageSize;
        this.total = result.total;

        this.loading = false
      }
    });
  }

  onChangePage(event: any)
  {
    this.pageNumber = event;
    this.loadNews();
  }
}
