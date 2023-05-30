import { Component, Input, OnInit } from '@angular/core';
import { eTypeItem } from 'src/api/model/enum/eType-Item';
import { ItemDTO } from 'src/api/model/item-dto';

@Component({
  selector: 'app-news-card',
  templateUrl: './news-card.component.html',
  styleUrls: ['./news-card.component.scss']
})

export class NewsCardComponent implements OnInit 
{
  @Input() item!: ItemDTO;

  constructor() { }

  ngOnInit(): void { }

  get type()
  {
    return eTypeItem[this.item.type];
  }
}
